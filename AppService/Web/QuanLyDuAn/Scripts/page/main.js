﻿$(function () {
    checkLogin();
    loadMenu();
});

function logout(url) {
    if (url == null || url.length == 0) url = "Home";
    sessionStorage.clear();
    window.location = "/Account/Login?url=" + url;
}

function checkLogin() {
    var url = window.location.pathname;
    if (!isNullOrEmpty(sessionStorage.getItem("userCurrent"))) {
        logout(url);
    }
}
function loadMenu() {
    var rs = "", url = URL_API_PM_READ + "/Actions";
    var container = $(".list-menu-left");
    var params = {
        PageSize: 0,
        PageNumber: 0,
        SortCol: "level",
        SortADSC: 1
    };

    $.getJSON(url, params)
        .done(function (data, textStatus, jqXHR) {
            if (textStatus == "success" && data.isOk) {
                container.html(null);
                var listMenu = data.result.items;
                listMenu.filter(e => e.parentId === 0).forEach(x => rs += menuItem(x, listMenu));
            } else {
                DevExpress.ui.notify("Xảy ra lỗi trong quá trình lấy danh sách menu", "error", 3000);
                console.log(jqXHR);
            }
        })
        .fail(function (jqxhr, settings, ex) {
            DevExpress.ui.notify("Xảy ra lỗi trong quá trình lấy danh sách menu", "error", 3000);
            console.log(ex);
        }).always(function () {
            container.html(rs);
            $.each($('.nav').find('li'), function () {
                $(this).toggleClass("menu-open", window.location.pathname.includes($(this).find('a').attr('href')));
                $(this).children(".nav-link").toggleClass('active', window.location.pathname == ($(this).find('a').attr('href')));
            });
        });
}
function menuItem(item, list) {
    var listChild = list.filter(x => x.parentId == item.id);
    var rs = "<li class='nav-item has-treeview'>\
        <a class='nav-link' href='" + item.url + "'>\
        <i class='nav-icon mr-2 " + item.icon + "'></i>\
        <p>" + item.title + ((listChild != null && listChild.length > 0) ? "<i class='ti-angle-double-left right'></i>" : "") + "</p>\
        </a>";    
    if (listChild != null && listChild.length > 0) {
        rs += "<ul class='nav nav-treeview ml-2'>";
        listChild.forEach(x => rs += menuItem(x, list));
        rs += "</ul>";
    }
    rs += "</li>";

    return rs;
}


var loadingPanel = $("#loading-panel").dxLoadPanel({
    shadingColor: "rgba(0,0,0,0.3)",
    visible: false, message: "Vui lòng chờ ...",
    showIndicator: true,
    showPane: true,
    shading: true,
    closeOnOutsideClick: false,
}).dxLoadPanel("instance");

function isNullOrEmpty(value) {
    return value !== undefined && value !== null && value !== "";
}

function getParamInUrl(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

let ajax_load = (url, values) => {
    var deferred = $.Deferred(),
        params = {
            'PageSize': values["take"],
            'PageNumber': values["skip"]
        }; 
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*'
        },
        url: url, dataType: "json", data: params,
        success: function (data) {
            deferred.resolve(
                data.result.items,
                {
                    totalCount: data.result.pagingInfo.totalItems,
                }
            );
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr.responseJSON);
            deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách. Mở Console để xem chi tiết.");
        },
        timeout: 5000
    });
    return deferred.promise();
}
let ajax_insert = (url, values) => { 
    var deferred = $.Deferred();
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*'
        },
        url: url, dataType: "json", type: "POST",
        data: JSON.stringify(values),
        success: function (data) {
            deferred.resolve();
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr.responseJSON);
            deferred.reject("Có lỗi xảy ra trong quá trình thêm dữ liệu. Mở Console để xem chi tiết.");
        },
        timeout: 5000
    });
    return deferred.promise();
}
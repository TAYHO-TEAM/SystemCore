let checkLogin = () => (isNullOrEmpty(localStorage.getItem("userCurrent")) && isNullOrEmpty(window.localStorage.getItem("userCurrentInfo")));
var UserCurrent = localStorage.getItem("userCurrent");
var UserCurrentInfo = JSON.parse(localStorage.getItem("userCurrentInfo"));
var PROJECTID = isNullOrEmpty(localStorage.getItem("projectIdCurrent")) ? parseInt(localStorage.getItem("projectIdCurrent")) : 0;
var header = {};
var PermitInAction = { id:0, view: false, insert: false, update: false, delete: false }

DevExpress.localization.locale('vi');

$(function () {
    if (checkLogin()) loadMenu();
    else logout(window.location.pathname);
}); 

function logout(url) {
    if (url == null || url.length == 0 || url == "/") url = "/Home";
    localStorage.clear();
    window.location = "/Account/Login?url=" + url;
}

function loadMenu() {
    //loadHeader
    header = {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'Authorization': 'Bearer ' + UserCurrentInfo.accessToken,
    };
    //loadInfo
    $('.user-panel div.image img').attr("src", "data:image/png;base64," + UserCurrentInfo.avatarImg).attr("alt", UserCurrentInfo.UserCurrent);
    $('.user-panel div.info a').html(UserCurrentInfo.userName);
    $('.user-panel div.info span').html(UserCurrentInfo.title);
    //LoadMenu
    var rs = "", url = URL_API_ACC_READ + "/Actions/getMenuOfUser";
    var container = $(".list-menu-left");
    var params = { 
        FindParentId: 5
    };

    $.ajax({
        headers: header, url: url, dataType: "json", data: params, async: false,
        success: function (data) { 
            if (data.isOk) {
                container.html(null);
                var listMenu = data.result.items;
                listMenu.filter(e => e.parentId === 0).forEach(x => rs += menuItem(x, listMenu));
            } else {
                DevExpress.ui.notify("Xảy ra lỗi trong quá trình lấy danh sách menu", "error", 3000);
                console.log(jqXHR);
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            DevExpress.ui.notify("Xảy ra lỗi trong quá trình lấy danh sách menu", "error", 3000);
            console.log(xhr);
        },
        complete: function () {
            container.html(rs);
            $.each($('.nav').find('li'), function () {
                var aTarget = $(this).find('a');
                $(this).toggleClass("menu-open", window.location.pathname.includes(aTarget.attr('href')));
                if (window.location.pathname == aTarget.attr('href')) {

                    

                    PermitInAction['id'] = aTarget.data('id');
                    console.log(PermitInAction);
                    checkPermitInAction(aTarget.data('id'), url);
                    $(this).children(".nav-link").addClass('active', true);
                }
                
            });
        },
    }); 
}

let checkPermitInAction = (id, url) => {
    var params = { FindId: id };
    $.ajax({
        headers: header, url: url, dataType: "json", data: params,
        success: function (data) {
            if (data.isOk) {
                console.log(data);
            } else {
                DevExpress.ui.notify("Xảy ra lỗi trong quá trình lấy quyền theo menu", "error", 3000);
                console.log(data);
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            DevExpress.ui.notify("Xảy ra lỗi trong quá trình lấy quyền theo menu", "error", 3000);
            console.log(xhr);
        },
    });
}

let menuItem = (item, list) => {
    var listChild = list.filter(x => x.parentId == item.id);
    var rs = "<li class='nav-item has-treeview'>\
        <a class='nav-link' data-id='"+ item.id+"' href='" + item.url + "'>\
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

var ajax_insert = (url, values) => {
    var deferred = $.Deferred();
    $.ajax({
        headers: header, url: url, dataType: "json", type: "POST",
        data: JSON.stringify(values),
        success: function (data) {
            deferred.resolve();
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus);
            console.log(errorThrown);
            console.log(xhr);
            deferred.reject("Có lỗi xảy ra trong quá trình thêm dữ liệu. Mở Console để xem chi tiết.");
        },
       timeout: 5000
    });
    return deferred.promise();
}

var ajax_update = (url, key, values) => {
    var keyObj = JSON.parse('{"id":' + key + '}');
    var deferred = $.Deferred();
    $.ajax({
        headers: header, url: url, dataType: "json", type: "PUT",
        data: JSON.stringify($.extend(keyObj, values)),
        success: function (data) {
            deferred.resolve();
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr.responseJSON);
            deferred.reject("Có lỗi xảy ra trong quá trình cập nhật dữ liệu. Mở Console để xem chi tiết.");
        },
        timeout: 5000
    });
    return deferred.promise();
}

var ajax_delete = (url, key) => {
    var deferred = $.Deferred();
    var keys = typeof (key) == 'number' ? [key] : key;
    $.ajax({
        headers: header, url: url, dataType: "json", type: "DELETE",
        data: JSON.stringify({ "ids": keys}),
        success: function (data) {
            deferred.resolve();
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr.responseJSON);
            deferred.reject("Có lỗi xảy ra trong quá trình xóa dữ liệu. Mở Console để xem chi tiết.");
        },
        timeout: 5000
    });
    return deferred.promise();
}

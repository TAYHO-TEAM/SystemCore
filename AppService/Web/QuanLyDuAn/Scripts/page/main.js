let checkLogin = () => (isNullOrEmpty(localStorage.getItem("userCurrent")) && isNullOrEmpty(window.localStorage.getItem("userCurrentInfo")));
var UserCurrent = localStorage.getItem("userCurrent");
var UserCurrentInfo = JSON.parse(localStorage.getItem("userCurrentInfo"));
var PROJECTID = isNullOrEmpty(localStorage.getItem("projectIdCurrent")) ? parseInt(localStorage.getItem("projectIdCurrent")) : 0;
var GIAIDOANID = isNullOrEmpty(localStorage.getItem("giaiDoanIdCurrent")) ? parseInt(localStorage.getItem("giaiDoanIdCurrent")) : 0;
var header = {};
var PermitInAction = { id: 0, view: false, insert: false, update: false, delete: false, readonly: false };

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

    $.ajax({
        headers: header, url: url, dataType: "json", data: { FindParentId: 5 }, async: false,
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
                    checkPermitInAction(aTarget.data('id'), url);
                    $(this).children(".nav-link").addClass('active', true);
                } else if (window.location.pathname == "/" && aTarget.attr('href') == "/Home") { 
                    checkPermitInAction(aTarget.data('id'), url);
                    $(this).children(".nav-link").addClass('active');
                }
            });
        },
    }); 
}

var checkPermitInAction=(id, url) => { 
    $.ajax({
        headers: header, url: url, dataType: "json", data: { FindId: id }, async: false,
        success: (data) =>  {
            if (data && data.isOk && data.result && data.result.items.length>0) {
                var list = data.result.items;
                PermitInAction = {
                    id: id,
                    readonly: list.filter(x => x.permistionId == 1).length > 0,
                    insert: list.filter(x => x.permistionId == 2).length > 0,
                    update: list.filter(x => x.permistionId == 3).length > 0,
                    delete: list.filter(x => x.permistionId ==4).length > 0,
                    view: list.filter(x => x.permistionId == 5).length > 0,
                }; 
            } else {
                DevExpress.ui.notify("Xảy ra lỗi trong quá trình lấy quyền theo menu", "error", 3000);
                console.log(data);
            }
        },
        error: (xhr, textStatus, errorThrown) => {
            DevExpress.ui.notify("Xảy ra lỗi trong quá trình lấy quyền theo menu", "error", 3000);
            console.log(xhr);
        }, 
        complete: () => {
            console.log(PermitInAction);
            if (!PermitInAction['view'])
                window.location = "/Account/NoAuthentication";
        }
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
    return value !== undefined && value !== null && value !== "" && value !== "null";
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

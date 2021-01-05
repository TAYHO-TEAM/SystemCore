﻿let checkLogin = () => (isNullOrEmpty(localStorage.getItem("userCurrent")) && isNullOrEmpty(window.localStorage.getItem("userCurrentInfo")));
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

                    $('.title-page').html(aTarget.data('descriptions'));
                    document.title = aTarget.data('descriptions') + ' - ' + document.title;
                } else if (window.location.pathname == "/" && aTarget.attr('href') == "/Home") {
                    checkPermitInAction(aTarget.data('id'), url);
                    $(this).children(".nav-link").addClass('active');
                }
            });
        },
    });
}

var checkPermitInAction = (id, url) => {
    $.ajax({
        headers: header, url: url, dataType: "json", data: { FindId: id }, async: false,
        success: (data) => {
            if (data && data.isOk && data.result && data.result.items.length > 0) {
                var list = data.result.items;
                PermitInAction = {
                    id: id,
                    readonly: list.filter(x => x.permistionId == 1).length > 0,
                    insert: list.filter(x => x.permistionId == 2).length > 0,
                    update: list.filter(x => x.permistionId == 3).length > 0,
                    delete: list.filter(x => x.permistionId == 4).length > 0,
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
        <a class='nav-link' data-id='"+ item.id + "' data-descriptions='" + item.descriptions + "' href='" + item.url + "'>\
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
    loadingPanel.show();
    var deferred = $.Deferred();
    $.ajax({
        headers: header, url: url, dataType: "json", type: "POST",
        data: JSON.stringify(values),
        success: function (data) {
            loadingPanel.hide();
            if (data != null && data.isOk && data.result != null)
                deferred.resolve(data.result);
            else
                deferred.reject("Có lỗi xảy ra trong quá trình thêm dữ liệu.");
        },
        error: function (xhr, textStatus, errorThrown) {
            loadingPanel.hide();
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
    loadingPanel.show();
    var keyObj = JSON.parse('{"id":' + key + '}');
    var deferred = $.Deferred();
    $.ajax({
        headers: header, url: url, dataType: "json", type: "PUT",
        data: JSON.stringify($.extend(keyObj, values)),
        success: function (data) {
            loadingPanel.hide();
            deferred.resolve();
        },
        error: function (xhr, textStatus, errorThrown) {
            loadingPanel.hide();
            console.log(textStatus);
            console.log(errorThrown);
            console.log(xhr);
            deferred.reject("Có lỗi xảy ra trong quá trình cập nhật dữ liệu. Mở Console để xem chi tiết.");
        },
        timeout: 5000
    });
    return deferred.promise();
}
var ajax_delete = (url, key) => {
    loadingPanel.show();
    var deferred = $.Deferred();
    var keys = typeof (key) == 'number' ? [key] : key;
    $.ajax({
        headers: header, url: url, dataType: "json", type: "DELETE",
        data: JSON.stringify({ "ids": keys }),
        success: function (data) {
            loadingPanel.hide();
            deferred.resolve();
        },
        error: function (xhr, textStatus, errorThrown) {
            loadingPanel.hide();
            console.log(textStatus);
            console.log(errorThrown);
            console.log(xhr);
            deferred.reject("Có lỗi xảy ra trong quá trình xóa dữ liệu. Mở Console để xem chi tiết.");
        },
        timeout: 5000
    });
    return deferred.promise();
}

var ajax_log_insert = (event, table, key, values) => {
    var data = {
        event: event,
        action: PermitInAction.id.toString(),
        ownerById: key,
        ownerByTable: table.replace('/', ''),
        message: values != null ? JSON.stringify(values) : null
    };
    ajax_insert(URL_API_ACC_CMD + "/LogEvent", data);
}

var callLogEvent = (id, table) => {
    var eventList = [
        {
            value : "Insert",
            text : "Tạo mới"
        },
        {
            value : "Update",
            text : "Cập nhật"
        },
        {
            value : "Delete",
            text : "Xóa bỏ"
        }
    ];
    var customStoreEvent = new DevExpress.data.CustomStore({
        key: "id",
        load: (values) => {
            let deferred = $.Deferred(), params = {};
            params = {
                'PageSize': isNullOrEmpty(values.take) ? values.take : 0,
                'PageNumber': (isNullOrEmpty(values.take) && isNullOrEmpty(values.skip)) ? ((values.skip / values.take) + 1) : 0,
                'FindId': "ownerById," + id + ";ownerByTable,'" + table.replace('/', '')+"'",
                'SortCol': 'createDate',
                'SortADSC':'0'
            }; 

            $.ajax({
                headers: header,
                url: URL_API_ACC_READ + "/LogEvent",
                dataType: "json",
                data: params,
                success: function (data) {
                    deferred.resolve(data.result.items);
                },
                error: function (xhr, textStatus, errorThrown) {
                    console.log(xhr.responseJSON);
                    deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách. Mở Console để xem chi tiết.");
                },
                timeout: 5000
            });
            return deferred.promise();
        },
    });

    $("#popup-log-event").dxPopup({
        width: 900, height: "auto",
        fullScreen: $(window).width() <= 900,
        dragEnabled: true, resizeEnabled: false,
        showTitle: true, title: "Nhật ký cập nhật",
        showCloseButton: true, closeOnOutsideClick: false,
        visible: true,
        position: { my: 'top', at: 'top', of: window },
        contentTemplate: (container) => {
            var scrollView = $("<div id='scrollView'></div>");
            var content = $("<div />");
            content.dxDataGrid({
                dataSource: customStoreEvent,
                showBorders: true, showColumnHeaders: true, showColumnLines: false, rowAlternationEnabled: false,
                showRowLines: true, columnAutoWidth: true, wordWrapEnabled: true, hoverStateEnabled: false,
                columns: [
                    {
                        caption: "STT", cellTemplate: (c, o) => c.append(o.rowIndex + 1),
                        alignment: "center", width: 80,
                    },
                    {
                        dataField: "createBy_Name", caption: "Người tạo",
                        alignment: "center", width: 200,
                        cellTemplate: (c, o) => {
                            if (o.data.createBy_Name != null) {
                                $("<div />").addClass("d-flex").append(
                                    $("<img />").attr("src", "data:image/png;base64," + o.data.createBy_Avartar).addClass("img-circle elevation-2 img-size-30"),
                                    $("<div />").addClass("ml-2 text-left").append(
                                        $("<div />").addClass("font-weight-bold").append(o.value),
                                        $("<em />").addClass("small").append(o.data.createBy_Title + ' - ' + o.data.createBy_Department)
                                    )
                                ).appendTo(c); 
                            }
                        }
                    },
                    {
                        dataField: "event", caption: "Sự kiện",
                        width: 80, alignment: "center",
                        lookup: {
                            dataSource: eventList,
                            valueExpr: "value", displayExpr: "text",
                        },
                        cssClass:"font-weight-bold"
                    },
                    {
                        dataField: "createDate", dataType: "date", caption: "Thời gian",
                        width: 150, alignment: "center",
                        cellTemplate: (c, o) => {
                            $("<div />").append(
                                $("<em />").addClass("small").append("Cách đây " + moment(o.value).locale("vi").fromNow()),
                                $("<div/>").addClass("font-weight-bold").append(moment(o.value).format("HH:mm DD/MM/YY"))
                            ).appendTo(c);
                        }
                    },
                    {
                        dataField: "message", caption: "Nội dung cập nhật",
                        cellTemplate: (c, o) => {
                            c.append(o.value.replaceAll('{', '').replaceAll('}', '').replaceAll(',', '<br/>').replaceAll('"', '').replaceAll(':', ' : '));
                        }
                    },
                ]
            });
            scrollView.append(content);
            scrollView.dxScrollView({ width: '100%', height: '100%' });
            container.append(scrollView);
            return container;
        }
    }).dxPopup('instance');
}
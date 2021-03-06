﻿const ACTION_PROJECT = "/Projects";
const ACTION_NHOMCONGVIEC = "/NS_NhomCongViec";
const ACTION_CONGVIEC = "/NS_CongViec";
const ACTION_NHOMCONGVIECDETAIL = "/NS_NhomCongViecDetail";
const ACTION_HANGMUC = "/NS_HangMuc";
const ACTION_LOAICONGVIEC = "/NS_LoaiCongViec";
const ACTION_GIAIDOAN = "/NS_GiaiDoan";
const ACTION_HANGMUCDETAIL = "/NS_HangMucDetail";
const ACTION_CONGVIECDETAIL = "/NS_CongViecDetail";

const ACTION_PHAT = "/NS_Phat";
const ACTION_PHAT_THEODOI = "/NS_Phat_TheoDoi";
const ACTION_PHAT_NHOM = "/NS_Phat_Nhom";
const ACTION_TAMUNG = "/NS_TamUng";
const ACTION_TAMUNG_THEODOI = "/NS_TamUng_TheoDoi";
const ACTION_KHAUTRU = "/NS_KhauTru";
const ACTION_KHAUTRU_THEODOI = "/NS_KhauTru_TheoDoi";

var customStore_Projects = new DevExpress.data.CustomStore({
    key: "id", loadMode: "raw",
    load: (values) => {
        var deferred = $.Deferred();
        $.ajax({
            headers: header, dataType: "json",
            url: URL_API_PM_READ + ACTION_PROJECT,
            success: function (data) {
                var list = data.result.items.filter(x => x.isActive == true && x.isVisible == true);
                if (PROJECTID == 0) {
                    localStorage.setItem("projectIdCurrent", parseInt(list[0].id));
                    PROJECTID = parseInt(list[0].id)
                }
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Projects'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
});

var customStore_Phat_Nhom = new DevExpress.data.CustomStore({
    key: "id", loadMode: "raw",
    load: (values) => {
        var deferred = $.Deferred();
        var params = { "FindId": 'isActive,1;IsVisible,1' };
        $.ajax({
            headers: header, dataType: "json",
            data: params,
            url: URL_API_PM_READ + ACTION_PHAT_NHOM,
            success: (data) => deferred.resolve(data.result.items),
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Projects'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
});

var dataGridOptions = {
    height: heightScreen,
    paging: {
        enabled: true, pageSize: 20
    },
    pager: {
        showPageSizeSelector: true, showInfo: true,
        allowedPageSizes: [10, 20, 40, 80],       
    },
    searchPanel: {
        highlightCaseSensitive: true, highlightSearchText: true,
        searchVisibleColumnsOnly: true, visible: true
    },
    showBorders: false, showColumnHeaders: true, showColumnLines: false, hoverStateEnabled: true,
    showRowLines: true, columnAutoWidth: true, wordWrapEnabled: true, rowAlternationEnabled: true, 
};

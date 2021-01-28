const ACTION_READ_REQUESTREGISTBYACC = "/RequestRegist/GetByAccountID";
const ACTION_READ_REQUESTREGISTDETAIL = "/RequestRegist/GetDetail";
const ACTION_READ_RESPONSEBYACC = "/ResponseRegist/getByAccount";
const ACTION_READ_RESPONSE = "/ResponseRegist";
const ACTION_READ_FILEGET = "/FilesAttachment/getBy";
const ACTION_READ_PROJECT = "/Projects";
const ACTION_READ_HANGMUC = "/WorkItems";
const ACTION_READ_DOCUMENTTYPE = "/DocumentType";
const ACTION_READ_REPLY = "/ResponseRegistReply";
const ACTION_READ_ACCOUNTINFO = "/AccountInfo";

const ACTION_CMD_REQUESTREGIST = "/RequestRegist";
const ACTION_CMD_RESPONSEREGIST = "/ResponseRegist";
////---------------------------CMD--------------------------- 
let customStore_CMD_READ = (CMD, READ) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        let deferred = $.Deferred(), params = {};

        if (values.filter && values.filter[0] == "parentId") params['FindParentId'] = values.filter[2];
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
        }
        $.ajax({
            headers: header,
            url: URL_API_PM_READ + READ,
            dataType: "json",
            data: params,
            success: function (data) {
                let list = data.result.items;
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách. Mở Console để xem chi tiết.");
            },
            timeout: 10000//10 giây
        });

        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + CMD, values),
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});
let customStore_CMD_READ_WITHPROJECTID = (CMD, READ) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        let deferred = $.Deferred(), params = { 'FindId': 'projectId,' + PROJECTID };

        if (values.filter && values.filter[0] == "parentId") params['FindParentId'] = values.filter[2];
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
            params['FindId'] = 'projectId,' + PROJECTID;
        }
        $.ajax({
            headers: header,
            url: URL_API_PM_READ + READ,
            dataType: "json",
            data: params,
            success: function (data) {
                let list = data.result.items;
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách. Mở Console để xem chi tiết.");
            },
            timeout: 10000//10 giây
        });

        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + CMD, values),
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});
let customStore_UPDATE_READ = (ID, CMD, READ) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        var deferred = $.Deferred();
        var params = {
            'PageSize': isNullOrEmpty(values.take) ? values.take : 0,
            'PageNumber': (isNullOrEmpty(values.take) && isNullOrEmpty(values.skip)) ? ((values.skip / values.take) + 1) : 0,
            'FindId': ID
        }
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
        }
        $.ajax({
            headers: header, dataType: "json",
            data: params,
            url: URL_API_PM_READ + READ,
            success: function (data) {
                var list = data.result.items;
                deferred.resolve(
                    list,
                    {
                        totalCount: list.length,
                    }
                );
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
});
let customStore_INSERT_READ = (INSERT, READ) => new DevExpress.data.CustomStore({
    key: "id",

    load: (values) => {
        var deferred = $.Deferred();
        var params = {
            'PageSize': isNullOrEmpty(values.take) ? values.take : 0,
            'PageNumber': (isNullOrEmpty(values.take) && isNullOrEmpty(values.skip)) ? ((values.skip / values.take) + 1) : 0,
            'FindId': ID
        }
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
        }
        $.ajax({
            headers: header, dataType: "json",
            data: params,
            url: URL_API_PM_READ + READ,
            success: function (data) {
                var list = data.result.items;
                deferred.resolve(
                    list,
                    {
                        totalCount: list.length,
                    }
                );
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + INSERT, values),
});
let customStore_CMD_READ_FILTER_FK = (CMD, READ, FKID) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        let deferred = $.Deferred(), params = {};

        //if (values.filter && values.filter[0] == "parentId") params['FindParentId'] = values.filter[2];
        params['FindParentId'] = FKID;
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
        }
        $.ajax({
            headers: header,
            url: URL_API_PM_READ + READ,
            dataType: "json",
            data: params,
            success: function (data) {
                let list = data.result.items;
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách. Mở Console để xem chi tiết.");
            },
            timeout: 10000//10 giây
        });

        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + CMD, values),
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});
let customStore_CMD_READ_FILTER_ID = (CMD, READ, ID) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {

        var deferred = $.Deferred();
        var params = {
            'PageSize': isNullOrEmpty(values.take) ? values.take : 0,
            'PageNumber': (isNullOrEmpty(values.take) && isNullOrEmpty(values.skip)) ? ((values.skip / values.take) + 1) : 0,
            'FindId': ID
        }
        if (values.sort) {
            params['SortCol'] = values.sort[0].selector;
            params['SortADSC'] = values.sort[0].desc;
        }
        $.ajax({
            headers: header, dataType: "json",
            data: params,
            url: URL_API_PM_READ + READ,
            success: function (data) {
                var list = data.result.items;
                deferred.resolve(
                    list,
                    {
                        totalCount: list.length,
                    }
                );
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
    insert: (values) => ajax_insert(URL_API_PM_CMD + CMD, values),
    update: (key, values) => ajax_update(URL_API_PM_CMD + CMD, key, values),
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});
let customStore_DELETE_READDATASOURCE = (CMD, DATASOURCE) => new DevExpress.data.CustomStore({
    key: "id",
    load: (values) => {
        let deferred = $.Deferred(), params = {};

        deferred.resolve(DATASOURCE);

        return deferred.promise();
    },
    remove: (key) => ajax_delete(URL_API_PM_CMD + CMD, key),
});

////---------------------------READ--------------------------- 
let customStore_READ_ALL_ACC = (READ) => new DevExpress.data.CustomStore({
    key: "id",
    loadMode: "raw",
    load: (values) => {
        var deferred = $.Deferred();
        $.ajax({
            headers: header, dataType: "json",
            url: URL_API_ACC_READ + READ,
            success: function (data) {
                var list = data.result.items.filter(x => x.isActive == true && x.isVisible == true);
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
});
let customStore_READ_ALL = (READ) => new DevExpress.data.CustomStore({
    key: "id", loadMode: "raw",
    load: (values) => {
        var deferred = $.Deferred();
        $.ajax({
            headers: header, dataType: "json",
            url: URL_API_PM_READ + READ,
            success: function (data) {
                var list = data.result.items.filter(x => x.isActive == true && x.isVisible == true);
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
});
let customStore_READ_FILTER = (READ, FILTER) => new DevExpress.data.CustomStore({
    key: "id", loadMode: "raw",
    load: (values) => {
        let deferred = $.Deferred(), params = { 'FindId': FILTER };
        $.ajax({
            headers: header, dataType: "json",
            url: URL_API_PM_READ + READ,
            data: params,
            success: function (data) {
                var list = data.result.items.filter(x => x.isActive == true && x.isVisible == true);
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
});
let customStore_READ_ID = (READ, ID) => new DevExpress.data.CustomStore({
    key: "id",
    loadMode: "raw",
    load: (values) => {
        var deferred = $.Deferred();
        var params = {
            'PageSize': isNullOrEmpty(values.take) ? values.take : 0,
            'PageNumber': (isNullOrEmpty(values.take) && isNullOrEmpty(values.skip)) ? ((values.skip / values.take) + 1) : 0,
            'FindId': ID,
        }
        $.ajax({
            headers: header, dataType: "json",
            data: params,
            url: URL_API_PM_READ + READ,
            success: function (data) {
                var list = data.result.items.filter(x => x.isActive == true && x.isVisible == true);
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
            },
            timeout: 10000
        });
        return deferred.promise();
    },
});
let customStore_GET_LINK = (LINK) => new DevExpress.data.CustomStore({
    key: 'id',
    loadMode: "raw",
    load: () => {
        var deferred = $.Deferred();
        $.ajax({
            headers: header,
            dataType: "json",
            url: LINK,
            success: function (data) {
                var list = data.result.items;
                deferred.resolve(list);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(xhr.responseJSON);
                deferred.reject("Có lỗi xảy ra trong quá trình lấy danh sách 'Hạng mục'. Mở Console để xem chi tiết.");
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
    showBorders: false,
    showColumnHeaders: true,
    showColumnLines: false,
    hoverStateEnabled: true,
    showRowLines: true,
    columnAutoWidth: true,
    wordWrapEnabled: true,
    rowAlternationEnabled: true,
};
function CALLPOPUP(title, url, width, container) {

    var isFullscreen = false;
    if (width == "100%") isFullscreen = true;

    $("#popup-main").dxPopup({
        width: width, height: "auto",
        fullScreen: isFullscreen,
        position: { my: 'top', at: 'top', of: window },
        dragEnabled: true,
        resizeEnabled: true,
        visible: true,
        showTitle: true,
        closeOnOutsideClick: false,
        showCloseButton: true,
        title: title,
        contentTemplate: function (container) {
            var scrollView = $("<div id='scrollView'></div>");
            var content = $("<div/>");
            content.load(url);
            scrollView.append(content);
            scrollView.dxScrollView({
                width: '100%',
                height: '100%'
            });
            container.append(scrollView);
            return container;
        },
        onHiding: function () {
            container.refresh();
        },
        onHidden: function () {
            loadData();
        }
    });
}


//-----------------------Unity OBJ -----------------------
const Category = [{
    "CategoryName": "Email",
},
{
    "CategoryName": "Notify",
},
{
    "CategoryName": "SMS",
}]

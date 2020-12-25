const ACTION_PROJECT = "/Projects";
const ACTION_NHOMCONGVIEC = "/NS_NhomCongViec";
const ACTION_CONGVIEC = "/NS_CongViec";
const ACTION_NHOMCONGVIECDETAIL = "/NS_NhomCongViecDetail";
const ACTION_HANGMUC = "/NS_HangMuc";
const ACTION_LOAICONGVIEC = "/NS_LoaiCongViec";
const ACTION_GIAIDOAN = "/NS_GiaiDoan";
const ACTION_HANGMUCDETAIL = "/NS_HangMucDetail";
const ACTION_CONGVIECDETAIL = "/NS_CongViecDetail";

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

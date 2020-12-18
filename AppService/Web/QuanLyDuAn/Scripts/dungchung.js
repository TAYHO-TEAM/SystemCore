//Tinh chiều cao - chiều cao header
var heightScreen = $(document).height() - $('.main-header').height() - 90;
var widthScreen = $(document).width();
//Thông số api
const api_version = 1; 
const URL_API_ACC_CMD = "https://api-acc-cmd.tayho.com.vn/api/cmd/v" + api_version;
const URL_API_ACC_READ = "https://api-acc-read.tayho.com.vn/api/read/v" + api_version; 
const URL_API_PM_CMD = "https://api-pm-cmd.tayho.com.vn/api/cmd/v" + api_version;
const URL_API_PM_READ = "https://api-pm-read.tayho.com.vn/api/read/v" + api_version;

//Thông số firebase
var firebaseConfig = {
    apiKey: "AIzaSyBoX_eyCVaUqrx5axGmwDKtmEKshszhoOU",
    authDomain: "theodoicongviec-2a0a5.firebaseapp.com",
    databaseURL: "https://theodoicongviec-2a0a5.firebaseio.com",
    projectId: "theodoicongviec-2a0a5",
    storageBucket: "theodoicongviec-2a0a5.appspot.com",
    messagingSenderId: "876925206152",
    appId: "1:876925206152:web:cf774522d180d33f52293d",
    measurementId: "G-RYM6Z8161F"
};

const listSexs = [
    {value: 0, text:"Nữ"},
    {value: 1, text:"Nam"},
    {value: 2, text:"Khác"},
];
const typeApprove = [
    { value: 1, text: "Đồng ý" },
    { value: 2, text: "Đồng ý kèm ý kiến" },
    { value: 3, text: "Từ chối" },
    { value: 4, text: "Trả lại" },
]; 
 
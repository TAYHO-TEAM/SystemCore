// Import and configure the Firebase SDK
// These scripts are made available when the app is served or deployed on Firebase Hosting
// If you do not serve/host your project using Firebase Hosting see https://firebase.google.com/docs/web/setup
importScripts('https://www.gstatic.com/firebasejs/7.21.0/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/7.21.0/firebase-messaging.js');
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
// Initialize Firebase
firebase.initializeApp(firebaseConfig);
const messaging = firebase.messaging();

messaging.setBackgroundMessageHandler(function (payload) {
   console.log('[firebase-messaging-sw.js] Received background message ', payload);
   // Customize notification here
   const notificationTitle = 'Background Message Title';
   const notificationOptions = {
      body: 'Background Message body.',
      icon: '/Content/images/logo.png'
   };

   return self.registration.showNotification(notificationTitle, notificationOptions);
});
importScripts('https://www.gstatic.com/firebasejs/8.10.0/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/8.10.0/firebase-messaging.js');


// Your web app's Firebase configuration
firebase.initializeApp({
  apiKey: "AIzaSyA088X-qZMokDx7XjcFuOfnsrgx1SATyI0",
  authDomain: "e-biblioteka-e0a3e.firebaseapp.com",
  projectId: "e-biblioteka-e0a3e",
  storageBucket: "e-biblioteka-e0a3e.appspot.com",
  messagingSenderId: "306083469041",
  appId: "1:306083469041:web:c30911ff66dd8b089dfb50"
});

// Initialize Firebase
//const app = initializeApp(environment.firebase);

const messaging = firebase.messaging();



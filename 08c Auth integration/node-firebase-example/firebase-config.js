// firebase-config.js
import { initializeApp } from 'firebase/app';
import { getAuth } from 'firebase/auth';

const firebaseConfig = {
    apiKey: "AIzaSyDzeII7c521YgFEsxV-Oq6DrfNQ9iQIX_E",
    authDomain: "frederik-systemintegration.firebaseapp.com",
    projectId: "frederik-systemintegration",
    storageBucket: "frederik-systemintegration.appspot.com",
    messagingSenderId: "180064139091",
    appId: "1:180064139091:web:76a903c00dd928ac59d3a6"
  };

const app = initializeApp(firebaseConfig);
const auth = getAuth(app);

export { auth };
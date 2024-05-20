# Firebase integration guide:

Dette er en hurtig guide til firebase auth

## Firebase project setup:

- Gå ind på console.firebase.google.com
- Tilføj et projekt
- Tilføj en web app
- Kopier FirebaseConfig-filen med appens informationer

## Setup Web app:

- npm i vite firebase
- lav en firebase-config.js klasse med firbareConfig-filen fra projekt/app-setuppen
- I samme klasse skal der laves en firebaseapp som tager imod config-filen
- brug getAuth-metoden på firebaseapp og gem den i en variabel auth
- exporter auth

## I app.js:

- Importer auth fra din config-klasse, og importer de login metoder du ønsker.
- Hvis der ønskes google auth skal man inde under firebase console -> projekt -> authentication -> sign-in method vælge 'Add new provider' og enable google.
- Man skal importere den ønskede provider, hvis man logger ind med eksempelvis google. GoogleAuthProvider from 'firebase/auth'

Ens hjemmeside skal køre med Vite eller en anden bundler.

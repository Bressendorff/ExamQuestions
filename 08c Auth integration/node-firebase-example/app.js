import { auth } from "./firebase-config";
import { createUserWithEmailAndPassword, signInWithEmailAndPassword, signInWithPopup } from "firebase/auth";
import { GoogleAuthProvider } from 'firebase/auth';

const provider = new GoogleAuthProvider();


window.createUser = (email, password) => createUserWithEmailAndPassword(auth, email, password)
  .then((userCredential) => {
    // Signed up 
    const user = userCredential.user;
    console.log('User created:', user);
    // ...
  })
  .catch((error) => {
    const errorCode = error.code;
    const errorMessage = error.message;
    console.error('Error code:', errorCode, 'Error message:', errorMessage);
    // ..
  });

window.signIn = (email, password) => signInWithEmailAndPassword(auth, email, password)
  .then((userCredential) => {
    // Signed in 
    const user = userCredential.user;
    console.log("User logged in:", user.email)

    console.log(user.email)
    return user.email;
    // ...
  })
  .catch((error) => {
    const errorCode = error.code;
    const errorMessage = error.message;

    return "error occurred";
  });

  window.signInGoogle = () => signInWithPopup(auth, provider)
  .then((result) => {
    const credential = GoogleAuthProvider.credentialFromResult(result);
    const token = credential.accessToken;

    
    const user = result.user;
    console.log(user.email)
    return user.email;
  }).catch((error) => {
    const errorCode = error.code;
    const errorMessage = error.message;
  });

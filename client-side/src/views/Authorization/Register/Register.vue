<template>
  <body>
    <div class="main">
        <div class="form">
            <form>
               <label id="login">Already have an account?</label>
                  <router-link class="router-link" :to="{ name: 'Login' }">
                    <h2>Login</h2>
                  </router-link>
               <label id="login">Display Name:</label>
                <input type="text" placeholder="Display Name" v-model="displayName">
               <label id="login">Photo URL</label>
                <input type="text" placeholder="Photo Url" v-model="photoURL">
                <label id="login">Email</label>
                <input type="text" placeholder="Email" v-model="email">
                <label>Password:</label>
                <input  type="password" placeholder="Password" v-model="password">
              <button-f buttonText="Sign Up" @click.prevent="submitForm"/>
            </form>
        </div>
          <div class="error" v-if="errorMsg">
          {{ errorMsg }}
        </div>
    </div>
</body>
</template>



<script>
import ButtonF from "../../../components/ButtonF.vue"

import {
  getAuth,
  createUserWithEmailAndPassword,
  GoogleAuthProvider,
  signInWithPopup,
} from "firebase/auth";

export default {
  components: { ButtonF },
  data() {
    return {
      email: null,
      displayName: null,
      password: null,
      photoURL: null,
      phoneNumber: null,
      roles: [0],
      status: 1,
      error: null,
      errorMsg: null,
    };
  },

  methods: {
    signInWithGoogle() {
      const provider = new GoogleAuthProvider();
      signInWithPopup(getAuth(), provider).then((result) => {
        console.log(result.user);
        this.$router.push("/");
      });
    },
    submitForm() {
      if (this.isFormValid()) {
        this.error = false;
        this.errorMsg = null;
        createUserWithEmailAndPassword(getAuth(), this.email, this.password)
          .then((result) => {
            console.log("result", result);
            // TODO: fix to save results to firestore database
            // const database = db.collection("users").doc(result.user.uid);

            // dataBase.set({
            //   id: result.user.uid,
            //   email: this.email,
            //   displayName: this.displayName,
            //   phoneNumber: this.phoneNumber,
            //   photoURL: this.photoURL,
            //   roles: this.roles,
            //   status: this.status,
            // });
            console.log("User registered!");
            this.$router.push("/home");
          })
          .catch((err) => {
            console.log(err.code);
            alert(err.message);
          });
      } else {
        this.error = true;
        this.errorMsg = "Please fill out all the fields!";
      }
    },
    isFormValid() {
      if (
        this.firstName !== null &&
        this.lastName !== null &&
        this.email !== null &&
        this.password !== null
      ) {
        return true;
      } else {
        return false;
      }
    },
  },
};
</script>


<style lang="scss" scoped>

body{
    background-color: #221C48;
}

.main{
    width: 30%;
    margin-right: 35%;
    margin-left: 35%;
    margin-top: 5%;
    margin-bottom: 5%;
}

h2{
  margin-bottom: 2%;
  margin-top: 10%;
}

.form {
    border: 1px solid white;
    border-radius: 5px;
    padding: 40px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    background-color: rgb(20, 13, 59);
}

form{
    background-color: whitesmoke;
    display: flex;
    flex-direction: column;
    padding:50px;
}

form label{
    color: black;
    margin:10px;
    font-size: 23px;
    height:20px;
    text-align: center;
}

input{
    height: 32px;
    border-radius: 12px;
    font-size: 20px;
}

.form a{
    text-decoration: none;
    color: #221C48;
    text-align: center;
    margin: 3%;
}

    @media screen and (max-width: 1150px) {
      .main{
          width: 50%;
          margin-right: 25%;
          margin-left: 25%;
      }
    }

    @media screen and (max-width: 700px) {
         .main{
          width: 80%;
          margin-right: 10%;
          margin-left: 10%;
      }
    }


</style>
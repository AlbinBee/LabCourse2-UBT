<template>
  <body>
    <div class="main">
        <div class="form">
            <form>
                <label id="login">Log In</label>
                <label>Email:</label>
                <input type="text" placeholder="Email" v-model="email">
                <label>Password:</label>
                <input  type="password" placeholder="Password" v-model="password">
                <label id="sign">Don't have an account?</label>
                <a href="#">Sign Up</a>
              <button-f buttonText="Google Sign in" @click.prevent="signInWithGoogle"/>
              <button-f buttonText="Sign In" @click.prevent="submitForm"/>
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
  signInWithEmailAndPassword,
  GoogleAuthProvider,
  signInWithPopup,
} from "firebase/auth";
export default {

  components: { ButtonF },

  data() {
    return {
      email: null,
      password: null,
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
        this.errorMsg = null;
        signInWithEmailAndPassword(getAuth(), this.email, this.password)
          .then(() => {
            console.log("Successfully signed in!");
            this.$router.push("/home");
          })
          .catch((err) => {
            this.errorMsg = err.code;
          });
      } else {
        this.errorMsg = "Please fill out all the fields!";
      }
    },
    isFormValid() {
      if (this.email !== null && this.password !== null) {
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

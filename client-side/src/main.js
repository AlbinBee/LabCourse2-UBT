import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import { BootstrapVue, IconsPlugin } from "bootstrap-vue";
import { initializeApp } from "firebase/app";

import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

Vue.config.productionTip = false;

const firebaseConfig = {
  apiKey: "AIzaSyAnYLc54geuQzqysf2161E0ZmLH7-GKo44",
  authDomain: "cinemaverse-13e76.firebaseapp.com",
  projectId: "cinemaverse-13e76",
  storageBucket: "cinemaverse-13e76.appspot.com",
  messagingSenderId: "502334150744",
  appId: "1:502334150744:web:17548aaaf23dabaf81922d",
};

initializeApp(firebaseConfig);

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");

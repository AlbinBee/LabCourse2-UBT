import Vue from "vue";
import Vuex from "vuex";
import createPersistedState from "vuex-persistedstate";

import app from "./app";

//Users
import users from "./Users/users";

//Movies
import movies from "./Movies/movies";

//Cinemas
import cinemas from "./Cinemas/cinemas";

//Events
import events from "./Events/events";

//Actors
import actors from "./Actors/actors";

const initialState = {
  users: { ...users.state },
};

Vue.use(Vuex);

export default new Vuex.Store({
  plugins: [
    createPersistedState({
      storage: window.sessionStorage,
    }),
  ],
  modules: {
    app,
    users,
    movies,
    cinemas,
    events,
    actors,
  },
  state: {},
  mutations: {
    RESET_STATE(state) {
      sessionStorage.clear();
      Object.keys(state).forEach((key) => {
        Object.assign(state[key], initialState[key]);
      });
    },
  },
  strict: process.env.DEV,
  actions: {},
  getters: {},
});

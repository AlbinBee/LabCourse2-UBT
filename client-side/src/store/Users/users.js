import api from "@/libs/api";

export default {
  state: {
    loading: true,
    loggedIn: false,
    error: false,
    errorMsg: null,
    isAdmin: false,
    users: [],
    user: {},
  },
  mutations: {
    SET_LOADING(state, value) {
      state.loading = value;
    },
    SET_LOGGED_IN(state, value) {
      state.loggedIn = value;
    },
    SET_ADMIN(state, payload) {
      const adminRole = payload.includes(1);
      state.isAdmin = adminRole;
    },
    UPDATE_USER(state, payload) {
      state.user = payload;
    },
    SIGN_USER_OUT(state) {
      state.currentUser.profileId = null;
    },
    SET_USERS(state, payload) {
      state.users = payload;
    },
    SET_USER(state, payload) {
      state.user = payload;
    },
  },
  actions: {
    getUsers({ commit }) {
      commit("SET_LOADING", true);
      return new Promise((resolve, reject) => {
        api("node")
          .get(`users`)
          .then((response) => {
            commit("SET_USERS", response.data);
            resolve(response);
          })
          .catch((error) => {
            reject(error);
          })
          .finally(() => {
            commit("SET_LOADING", false);
          });
      });
    },
    getUser({ commit }, id) {
      commit("SET_LOADING", true);
      return new Promise((resolve, reject) => {
        api("node")
          .get(`users/${id}`)
          .then((response) => {
            commit("SET_USER", response.data);
            resolve(response);
          })
          .catch((error) => {
            reject(error);
          })
          .finally(() => {
            commit("SET_LOADING", false);
          });
      });
    },
    addUser({ commit }, query) {
      commit("SET_LOADING", true);
      return new Promise((resolve, reject) => {
        api("node")
          .post(`users`, query)
          .then((response) => {
            commit("SET_USER", response.data.result);
            resolve(response);
          })
          .catch((error) => {
            reject(error);
          })
          .finally(() => {
            commit("SET_LOADING", false);
          });
      });
    },

    // async makeAdmin({ commit }, id) {
    //   commit("SET_LOADING", true);
    //   const dataBase = await db.collection("users").doc(id);
    //   await dataBase.update({
    //     roles: [0, 1],
    //     updatedDate: new Date(),
    //   });
    //   commit("SET_LOADING", false);
    // },
    // async removeAdmin({ commit }, id) {
    //   commit("SET_LOADING", true);
    //   const dataBase = await db.collection("users").doc(id);
    //   await dataBase.update({
    //     roles: [0],
    //     updatedDate: new Date(),
    //   });
    //   commit("SET_LOADING", false);
    // },
  },
};

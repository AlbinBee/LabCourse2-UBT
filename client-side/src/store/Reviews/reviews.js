import api from "@/libs/api";

export default {
	state: {
		loading: false,
		fetchingreviews: false,
		removingreview: false,
		reviews: [],
		review: {},
	},
	getters: {
		reviewList(state) {
			return state.reviews;
		},
	},
	mutations: {
		SET_LOADING(state, value) {
			state.loading = value;
		},
		SET_REVIEWS(state, payload) {
			state.reviews = payload;
		},
		SET_REVIEW(state, payload) {
			state.review = payload;
		},
		REMOVE_REVIEW(state, id) {
			state.reviews = state.reviews.filter((h) => h.id !== id);
		},
		ADD_REVIEW(state, payload) {
			state.reviews.push(payload);
		},
	},
	actions: {
		getReviews({ commit }, reviewId) {
			commit("SET_LOADING", true);
			return new Promise((resolve, reject) => {
				api("movies")
					.get(`cinemas/${reviewId}/reviews`)
					.then((response) => {
						commit("SET_reviewS", response.data.result);
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
		removeReview({ commit }, query) {
			commit("SET_LOADING", true);
			return new Promise((resolve, reject) => {
				api("movies")
					.delete(`cinemas/${query.cinemaId}/reviews/${query.reviewId}`)
					.then((response) => {
						commit("REMOVE_review", query.reviewId);
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
		createReview({ commit }, query) {
			commit("SET_LOADING", true);
			return new Promise((resolve, reject) => {
				api("movies")
					.post(`cinemas/${query.cinemaId}/reviews`, query.review)
					.then((response) => {
						commit("ADD_review", query.review);
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
	},
};

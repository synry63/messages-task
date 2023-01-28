import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex);

const state = {
    user: null
};
const getters = {
    getUserWelcome: (state) => state.user != null ? "welcome " + state.user.email : "",
    getUser: (state) => state.user
};
const mutations = {
    setUser: (state, user) => {
        state.user = user
    },
};
const actions = {
    setMainUser: ({ commit }, user) => {
        commit('setUser', user);
    }
};

export default new Vuex.Store({
    state,
    getters,
    mutations,
    actions
})
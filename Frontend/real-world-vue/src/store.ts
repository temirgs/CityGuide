import Vue from "vue";
import Vuex from "vuex";
import axios from 'axios'

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    cities: [],
    photos:[],
    city:[]
  },
  mutations: {
    initCities(state, cities) {
      state.cities = cities
    },
    initcitydetail(state, citiesId) {
      // state.cities=cities
    },
    initgetPhotoById(state, ciiesId) {

    },
    addCity(state, cities) {
      state.cities.push()
    }
  },
  actions: {
    initApp({ commit }) {
      axios.get("https://localhost:44358/api/Cities/GetCities").then(response => {
        commit("initCities", response.data)
      })
    },
    addCity(context, staff) {
      return axios.post("https://localhost:44358/api/Cities/Add", staff.city)
        .then(response => {
          context.commit("addCity", { ...staff.city })
        })
    },
  },
  getters: {
    getCites(state) {
      return state.cities
    }
  }

});

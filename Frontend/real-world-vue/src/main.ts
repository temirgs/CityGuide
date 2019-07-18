import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
import axios from 'axios'
import VueAxios from 'vue-axios'

import VueJWT from 'vuejs-jwt'
 
Vue.use(VueJWT, Option) 

Vue.use(VueAxios, axios)
Vue.use(VueMaterial)
Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");

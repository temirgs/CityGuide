import Vue from "vue";
import Router from "vue-router";
import Login from "./components/Login.vue";
import Card from "./views/Card.vue";
import CityDetail from "./views/CityDetail.vue";
Vue.use(Router);

export default new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "Card",
      component: Card
    },
    {
      path: "/Login",
      name: "Login",
      component: Login
    },
    {
      path: "/CityDetail/:id",
      name: "Detail",
      component: CityDetail
    }
  ]
});

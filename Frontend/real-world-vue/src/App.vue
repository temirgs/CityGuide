import VueJWT from 'vuejs-jwt';
<template>
  <div>
    <div id="app">
      <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
        <a class="navbar-brand" style="color:black" href="#">Navbar</a>
        <button
          class="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarColor02"
          aria-controls="navbarColor02"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarColor02">
          <ul class="navbar-nav mr-auto">
            <li class="nav-item active">
              <router-link   to="/" class="nav-link">Home</router-link>
            </li>
            <li class="nav-item active">
              <router-link class="nav-link" to="/NewCity">New City</router-link>
            </li>
          </ul>
          <form @submit.prevent="onSubmit" class="form-inline my-2 my-lg-0">
            <input
              v-model="login.username"
              class="form-control mr-sm-2"
              type="text"
              placeholder="UserName"
              required
            />
            <input
              v-model="login.password"
              class="form-control mr-sm-2"
              type="password"
              placeholder="Password"
              required
            />
            <button class="btn btn-secondary my-2 my-sm-0" type="submit">Login</button>
          </form>
          <button style="margin-left:12px;" @click="logOut" class="btn btn-secondary my-2 my-sm-0" type="button">LogOut</button>
          <router-link to="/Register">
            <button style="margin-left:12px;" type="button" class="btn btn-dark">Register</button>
          </router-link>
        </div>
      </nav>
      <router-view></router-view>
    </div>
  </div>
</template>
<script>
export default {
  name: "Counters",

  data() {
    return {
      login: {
        username: "",
        password: ""
      }
    };
  },
  methods: {
    onSubmit() {
      return this.axios
        .post("https://localhost:44358/api/Default/Login", this.login)
        .then(response => {
          this.saveToken(response.data);
        });
    },
    saveToken(token) {
      localStorage.setItem("token", token);
    },
    logOut() {
      localStorage.removeItem("token");
    },
     GetToken() {
        return localStorage.getItem('token') 
      },
  }
};
</script>
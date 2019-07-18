<template>
  <div class="container">
    <br />
    <br />
    <form @submit.prevent="onSubmit">
      <md-field>
        <label>User Name</label>
        <md-input required="" v-model="login.username" md-counter="30"></md-input>
      </md-field>

      <md-field>
        <label>Password</label>
        <md-input required="" type="password" v-model="login.password" maxlength="30"></md-input>
      </md-field>
      <button type="submit" class="btn btn-primary btn-lg btn-block">Register</button>
    </form>
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
      this.axios.post("https://localhost:44358/api/Default/Login",this.login)
      .then(response=>{
        this.saveToken(response.data),
        this.$router.push('/')
      })
    },
    saveToken(token){
      localStorage.setItem('token',token)
    },
  }
};
</script>
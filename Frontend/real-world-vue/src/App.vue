<template>
<div>

  <div id="app">
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <a class="navbar-brand" href="#">Logo</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarColor02">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <router-link to="/" class="nav-link" >Home</router-link> 
      </li>
      <li class="nav-item active">
        <router-link class="nav-link" to="/NewCity">New City</router-link>
      </li>
    </ul>
    <router-link type="button" style=" margin-right:50px;" class="btn btn-link" to="/Login">Login</router-link> 
     <router-link type="button" style=" margin-right:50px;" class="btn btn-link" to="/Register">Register</router-link> 
  </div>
</nav>
     <router-view></router-view>
  </div>
  </div>
</template>

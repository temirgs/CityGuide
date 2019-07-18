<template>
  <div class="container">
    <br />
    <form @submit.prevent="onSubmit">
      <md-field>
        <label>City Name</label>
        <md-textarea required="" v-model="city.name" md-autogrow md-counter="80"></md-textarea>
      </md-field>
      <md-field>
        <label>Description</label>
        <md-textarea required="" v-model="city.description" md-counter="200"></md-textarea>
      </md-field>
      <button type="submit" class="btn btn-primary btn-lg btn-block">Add New City</button>
    </form>
  </div>
</template>
<script>
export default {
  name: "Counters",
  data() {
    return {
      city: {
        name: "",
        description: ""
      }
    };
  },
  methods: {
    onSubmit() {
      this.axios
        .post("https://localhost:44358/api/Cities/Add", this.city)
        .then(() => {
          this.$router.push("/");
        });
    }
  }
};
</script>
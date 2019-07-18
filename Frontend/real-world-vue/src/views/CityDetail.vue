<template>
  <div class="container">
    <br />
    <div class="card-group">
      <div v-for="(item,index) in photos" :key="index" class="card">
        <img :src="item.url" style="height:200px;width:400px" class="card-img-top" />
        <div class="card-body">
          <h5 class="card-title">Card title</h5>
          <p class="card-text">{{item.description}}</p>
          <p class="card-text">
            <small class="text-muted">{{item.dateAdded}}</small>
          </p>
        </div>
      </div>
    </div>
    <br />
    <br />
    <h3>Photo Upload</h3>
      <md-field>
        <label>Only images</label>
        <md-file  accept="image/*" />
      </md-field>
      <button   type="button" class="btn btn-primary btn-lg btn-block">Add New Photo</button>
  </div>
</template>
<script>
export default {
  name: "CityDetail",
  data() {
    return {
      photos: []
    };
  },
  methods: {
    loadPhoto(id) {
      this.axios
        .get("https://localhost:44358/api/Photos/GetPhoto/", {
          params: { id: id }
        })
        .then(response => {
          this.photos = response.data;
        });
    }
  },
  created() {
    this.loadPhoto(this.$route.params.id);
  }
};
</script>

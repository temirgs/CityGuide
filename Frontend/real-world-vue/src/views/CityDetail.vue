import axios from 'axios';
<template>
  <main role="main" class="container">
    <br />
    <br />
    <div
      id="carousel-example-2"
      class="carousel slide carousel-fade z-depth-1-half"
      data-ride="carousel"
    >
      <!--Indicators-->
      <ol class="carousel-indicators">
        <li data-target="#carousel-example-2" data-slide-to="0" class="active"></li>
        <li data-target="#carousel-example-2" data-slide-to="1"></li>
        <li data-target="#carousel-example-2" data-slide-to="2"></li>
      </ol>
      <!--/.Indicators-->
      <!--Slides-->
      <div class="carousel-inner" role="listbox">
        <div v-for="(item,index) in photos" :key="index">
          <div class="carousel-item active">
            <div class="view">
              <img class="d-block w-100" :src="item.url" alt="First slide" />
              <div class="mask rgba-black-light"></div>
            </div>
            <div class="carousel-caption">
              <h3 class="h3-responsive">{{item.description}}</h3>
              <p>{{item.dateAdded}}</p>
            </div>
          </div>
        </div>
        <!--/.Slides-->
        <!--Controls-->
        <a class="carousel-control-prev" href="#carousel-example-2" role="button" data-slide="prev">
          <span class="carousel-control-prev-icon" aria-hidden="true"></span>
          <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carousel-example-2" role="button" data-slide="next">
          <span class="carousel-control-next-icon" aria-hidden="true"></span>
          <span class="sr-only">Next</span>
        </a>
        <!--/.Controls-->
      </div>
    </div>
  </main>
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
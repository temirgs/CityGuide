<template>

  <div class="card-expansion container">
    <md-card v-for="(item,index) in cities" :key="index">
      <md-card-media>
        <img style="height:200px;width:100%" :src="item.photoUrl">
      </md-card-media>
      <md-card-header>
        <div class="md-title">{{item.name}}</div>
      </md-card-header>

      <md-card-expand>
        <md-card-actions md-alignment="space-between">
          <div>
            <router-link :to="{ name: 'Detail', params: { id: item.id } }">Learn More</router-link>
          </div>
          <md-card-expand-trigger>
            <md-button class="md-icon-button">
              <md-icon>keyboard_arrow_down</md-icon>
            </md-button>
          </md-card-expand-trigger>
        </md-card-actions>

        <md-card-expand-content>
          <md-card-content>{{item.description}}</md-card-content>
        </md-card-expand-content>
      </md-card-expand>
    </md-card>
  </div>

</template>
<script>
export default {
  name: "CardExpansion",
  created(){
    this.$store.dispatch("initApp");
  },
  computed:{
    cities(){
      return this.$store.getters.getCites;
    }
  }
};
</script>
<style  scoped>
.card-expansion {
  height: 480px;
}

.md-card {
  width: 320px;
  margin: 4px;
  display: inline-block;
  vertical-align: top;
}
</style>
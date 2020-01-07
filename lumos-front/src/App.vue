<template>
  <v-app>
    <v-navigation-drawer v-model="drawer" app>
      <v-list dense>
        <v-list-item link to="/future">
          <v-list-item-action>
            <v-icon>mdi-star-outline</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Я сдам</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item link to="/passed">
          <v-list-item-action>
            <v-icon>mdi-star</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Я сдала</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item link to="/about">
          <v-list-item-action>
            <v-icon>mdi-widgets</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>О портале</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar color="indigo" app dark>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title>{{currentRouteName}}</v-toolbar-title>
    </v-app-bar>

    <v-content>
      <router-view />
    </v-content>

    <v-footer color="indigo" app fixed>
      <span class="white--text">&copy; Твой reGrach - 2020</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  data: () => ({
    drawer: null,
    titlePage: null
  }),

  computed: {
    currentRouteName() {
      return this.$route.name;
    }
  },

  watch: {
    $route(to) {
      this.titlePage = to.name;
    }
  },
};
</script>

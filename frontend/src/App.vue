<template>
  <v-app>
    <v-app-bar app clipped-left color="primary" dark>
      <v-app-bar-nav-icon
        v-if="$auth.isAuthenticated"
        @click="drawer = !drawer"
      />
      <v-img
        alt="gachi meal"
        class="shrink mr-2"
        contain
        src=".././public/gacha-club.svg"
        transition="scale-transition"
        width="65"
      />
      <h1 class="ml-100 mt-1">Gachi Meal</h1>
      <v-spacer />
      <template v-if="$auth.isAuthenticated">
        <v-menu right bottom>
          <template v-slot:activator="{ on }">
            <v-btn icon v-on="on" class="mx-auto">
              <v-avatar>
                <img :src="$auth.user.picture" alt="User Picture" />
              </v-avatar>
            </v-btn>
          </template>
          <v-list class="text-center">
            <v-list-item>
              <v-avatar class="mx-auto">
                <img :src="$auth.user.picture" alt="User Picture" />
              </v-avatar>
            </v-list-item>
            <v-list-item>
              <v-list-item-content>
                <v-list-item-title>
                  {{ $auth.user.name }}
                </v-list-item-title>
                <v-list-item-subtitle>{{
                  $auth.user.email
                }}</v-list-item-subtitle>
              </v-list-item-content>
            </v-list-item>
            <v-list-item>
              <v-btn block color="primary" @click="$auth.logout">
                Log Out
                <v-icon class="ml-1">mdi-logout</v-icon>
              </v-btn>
            </v-list-item>
          </v-list>
        </v-menu>
      </template>
    </v-app-bar>

    <v-navigation-drawer
      v-if="$auth.isAuthenticated"
      v-model="drawer"
      app
      clipped
      color="grey lighten-4"
      width="auto"
    >
      <v-list dense nav>
        <v-list-item to="/receipts">
          <v-list-item-action>
            <v-icon>mdi-receipt</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title> Receipts </v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/products">
          <v-list-item-action>
            <v-icon>mdi-format-list-bulleted</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Products</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/another">
          <v-list-item-action>
            <v-icon>mdi-kayaking</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Another</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script>
export default {
  name: 'App',

  components: {},
  data: () => ({
    drawer: false
  })
}
</script>

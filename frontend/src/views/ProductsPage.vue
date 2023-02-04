<template>
  <v-container fluid>
    <v-row align="center" justify="space-between" class="px-4">
      <v-col class="pb-sm-3 pb-0 px-sm-2 px-2"
        ><div class="text-h5">Products</div></v-col
      >
      <v-col cols="12" sm="9" class="pt-sm-3 pt-0"
        ><v-row
          justify="space-between"
          justify-sm="end"
          align="center"
          class="ma-0"
          ><v-switch
            hide-details
            class="mr-4 mt-sm-0 mt-2 pt-0"
            inset
            v-model="showOwnedOnly"
            label="Show owned only"
          ></v-switch
          ><v-switch
            hide-details
            inset
            v-model="showByCategories"
            label="Show by categories"
            class="mt-sm-0 mt-2 mr-sm-n1 pt-0"
          ></v-switch></v-row
      ></v-col>
    </v-row>
    <v-row v-if="loading"
      ><v-col
        cols="12"
        sm="6"
        md="6"
        lg="4"
        xl="3"
        v-for="i of 12"
        v-bind:key="i"
        ><v-skeleton-loader
          type="list-item-avatar-two-line, image, actions"
        ></v-skeleton-loader></v-col
    ></v-row>
    <Card
      :cards="products"
      :userProducts="userProducts"
      :showByCategories="showByCategories"
      @updateUser="updateUser"
    />
  </v-container>
</template>
<script>
import { getUser, updateUser, getAllProducts } from '../firebaseDb'
import Card from '@/components/Card'
export default {
  name: 'ProductsPage',
  components: { Card },
  data: () => ({
    showByCategories: false,
    showOwnedOnly: false,
    products: [],
    userProducts: [],
    cards: [],
    loading: false
  }),
  async created () {
    this.loading = true
    let user
    const userEmail = this.$auth.user.email
    await getUser(userEmail)
      .then((doc) => {
        user = doc
      })
      .catch(() => {
        user = { email: userEmail, products: [] }
        updateUser(user)
      })
    let products
    await getAllProducts()
      .then((doc) => {
        products = doc.products
      })
      .catch(() => {
        products = []
      })
    this.userProducts = user.products || []
    this.products = products
      .map((product) => {
        product.count =
          this.userProducts.find(
            (userProduct) => product.name === userProduct.name
          )?.count || '0'
        product.src =
          'https://www.svgrepo.com/show/4638/rice.svg'
        product.show = false
        return product
      })
      .sort(this.sortByName)
    this.cards = this.products
    this.loading = false
  },
  methods: {
    sortByName: (a, b) => {
      const fa = a.name.toLowerCase()
      const fb = b.name.toLowerCase()
      if (fa < fb) {
        return -1
      }
      if (fa > fb) {
        return 1
      }
      return 0
    },
    async updateUser () {
      const userEmail = this.$auth.user.email
      const userProducts = this.products
        .filter((product) => product.count !== '0')
        .map((product) => {
          return {
            name: product.name,
            countType: product.countType,
            count: product.count
          }
        })
      await updateUser({
        email: userEmail,
        products: userProducts
      })
    }
  },
  watch: {
    showOwnedOnly: function (showOwnedOnly) {
      if (showOwnedOnly) {
        this.cards = this.products
        this.products = this.products.filter(
          (product) => product.count !== '0'
        )
      } else {
        this.products = this.cards
      }
    }
  }
}
</script>

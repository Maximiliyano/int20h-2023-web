<template>
  <v-container fluid>
    <v-row align="center" justify="space-between" class="px-4">
      <v-col class="pb-sm-3 pb-0 px-sm-2 px-2"><div class="text-h5">Receipts</div></v-col>
      <v-col cols="12" sm="9" class="pt-sm-3 pt-0"><v-row justify="space-between" justify-sm="end" align="center" class="ma-0"><v-switch hide-details class="mr-4 mt-sm-0 mt-2 pt-0" v-model="showAvailbleOnly" inset label="Show available only"></v-switch><v-switch hide-details class="mt-sm-0 mt-2 mr-sm-n1 pt-0" v-model="showByDifficulty" inset label="Show by difficult"></v-switch></v-row></v-col>
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
    <Receipts :cards="meals" :userProducts="userProducts" :showByDifficulty="showByDifficulty"/>
  </v-container>
</template>

<script>
import Receipts from '@/components/Receipts'
import { getUser, updateUser, getAllReceipts } from '../firebaseDb'
export default {
  name: 'ReceiptsPage',
  components: { Receipts },
  data: () => ({
    loading: false,
    showByDifficulty: false,
    showAvailbleOnly: false,
    cards: [],
    userProducts: [],
    meals: []
  }),
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
    }
  },
  async created () {
    this.loading = true
    let user
    const userEmail = this.$auth.user.email
    getUser(userEmail).then((doc) => {
      user = doc
    }).catch(() => {
      user = { email: userEmail, products: [] }
      updateUser(user)
    })
    let receipts
    await getAllReceipts().then((doc) => {
      receipts = doc.receipts
    }).catch(() => {
      receipts = []
    })
    this.userProducts = user.products || []
    console.log(this.userProducts)
    this.meals = receipts.map((receipt) => {
      receipt.show = false
      return receipt
    }).sort(this.sortByName)
    this.cards = this.meals
    this.loading = false
  },
  watch: {
    showAvailbleOnly: function (showAvailbleOnly) {
      if (showAvailbleOnly) {
        this.meals = this.meals.filter((receipt) => {
          return receipt.products.every((ingridient) => {
            return this.userProducts?.some((product) => {
              return (ingridient.name === product.name && +product.count >= ingridient.count) || ingridient.count === '(optional)'
            })
          })
        })
      } else {
        this.meals = this.cards
      }
    }
  }
}
</script>

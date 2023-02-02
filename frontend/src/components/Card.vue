<template>
  <v-container fluid>
    <v-row dense>
      <v-col
        v-for="(card, index) in cards"
        :key="card.name + index"
        cols="12"
        sm="12"
        md="6"
        lg="4"
        xl="3"
      >
        <v-card>
          <v-img
            :src="card.src"
            class="white--text align-end"
            gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
            height="200px"
          >
            <v-card-title v-text="card.name"></v-card-title>
          </v-img>

          <v-card-actions>
            <v-btn
              color="orange lighten-2"
              text
              @click="card.show = !card.show"
            >
              Description
              <v-icon>
                {{ card.show ? "mdi-chevron-up" : "mdi-chevron-down" }}
              </v-icon>
            </v-btn>
            <v-spacer></v-spacer>
            <v-row align="center" justify="end">
              <v-col cols="2" sm="2" class="px-0"
                ><v-btn icon color="error" @click="card.count = changeCount(card.count, card.countType, false)">
                  <v-icon color="error">mdi-minus</v-icon>
                </v-btn></v-col
              >
              <v-col cols="4" sm="2" md="3" lg="3" class="px-0"
                ><v-text-field
                  maxlength="4"
                  solo
                  hide-details
                  dense
                  v-model="card.count"
                ></v-text-field
              ></v-col>
              <v-col cols="3" sm="2" class="pr-0 pl-3 mr-n3"
                >{{ card.countType}}</v-col>
              <v-col cols="2" sm="2" class="px-0"
                ><v-btn icon color="success" @click="card.count = changeCount(card.count, card.countType, true)">
                  <v-icon color="success">mdi-plus</v-icon>
                </v-btn></v-col
              >
            </v-row>
          </v-card-actions>
          <v-expand-transition>
            <div v-show="card.show">
              <v-card-text>
                {{ card.description }}
              </v-card-text>
            </div>
          </v-expand-transition>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
export default {
  name: 'Card',
  components: {},
  props: {
    // cards: Array
  },
  data: () => ({
    userProducts: [
      { name: 'carrot', count: '1', countType: 'pcs' },
      { name: 'milk', count: '50', countType: 'ml' },
      { name: 'chickenMeat', count: '400', countType: 'g' }
    ],
    cards: [
      {
        name: 'Gachi1',
        src: 'https://cdn.vuetifyjs.com/images/cards/house.jpg',
        show: false,
        count: '1',
        countType: 'pcs',
        description: 'description gachi 1'
      },
      {
        name: 'Gachi2',
        src: 'https://cdn.vuetifyjs.com/images/cards/road.jpg',
        show: false,
        count: '50',
        countType: 'ml',
        description: 'description gachi 2'
      },
      {
        name: 'Gachi3',
        src: 'https://cdn.vuetifyjs.com/images/cards/plane.jpg',
        show: false,
        count: '100',
        countType: 'g',
        description: 'description gachi 3'
      },
      {
        name: 'Gachi1',
        src: 'https://cdn.vuetifyjs.com/images/cards/house.jpg',
        show: false,
        count: '1',
        countType: 'pcs',
        description: 'description gachi 1'
      },
      {
        name: 'Gachi2',
        src: 'https://cdn.vuetifyjs.com/images/cards/road.jpg',
        show: false,
        count: '50',
        countType: 'ml',
        description: 'description gachi 2'
      },
      {
        name: 'Gachi3',
        src: 'https://cdn.vuetifyjs.com/images/cards/plane.jpg',
        show: false,
        count: '100',
        countType: 'g',
        description: 'description gachi 3'
      },
      {
        name: 'Gachi1',
        src: 'https://cdn.vuetifyjs.com/images/cards/house.jpg',
        show: false,
        count: '1',
        countType: 'pcs',
        description: 'description gachi 1'
      },
      {
        name: 'Gachi2',
        src: 'https://cdn.vuetifyjs.com/images/cards/road.jpg',
        show: false,
        count: '50',
        countType: 'ml',
        description: 'description gachi 2'
      },
      {
        name: 'Gachi3',
        src: 'https://cdn.vuetifyjs.com/images/cards/plane.jpg',
        show: false,
        count: '100',
        countType: 'g',
        description: 'description gachi 3'
      },
      {
        name: 'Gachi1',
        src: 'https://cdn.vuetifyjs.com/images/cards/house.jpg',
        show: false,
        count: '1',
        countType: 'pcs',
        description: 'description gachi 1'
      },
      {
        name: 'Gachi2',
        src: 'https://cdn.vuetifyjs.com/images/cards/road.jpg',
        show: false,
        count: '50',
        countType: 'ml',
        description: 'description gachi 2'
      },
      {
        name: 'Gachi3',
        src: 'https://cdn.vuetifyjs.com/images/cards/plane.jpg',
        show: false,
        count: '100',
        countType: 'g',
        description: 'description gachi 3'
      }
    ]
  }),
  created () {},
  methods: {
    searchProductByNameAndCount (products, productToSearch) {
      return products.find(
        (product) =>
          product.name === productToSearch.name &&
          Number(product.count) >= Number(productToSearch.count)
      )
    },
    countLackOfProduct (userProducts, product) {
      return (
        product.count -
        (
          userProducts.find((userProduct) => userProduct.name === product.name)
            ?.count || 0
        ).toString() +
        product.countType
      )
    },
    changeCount (count, countType, increase) {
      let countStep = 50
      if (countType === 'pcs') {
        countStep = 1
      }
      const result = increase ? (Number(count) + countStep).toString() : (count - countStep)
      if (increase) {
        return result < 10000 ? result.toString() : '9999'
      }
      return result > 0 ? result.toString() : '0'
    }
  }
}
</script>

<template>
  <v-container fluid>
    <v-row dense v-if="!showByCategories">
      <v-col
        v-for="(card, index) in cards"
        :key="card.name + index"
        cols="12"
        sm="6"
        md="6"
        lg="4"
        xl="3"
      >
        <v-card>
          <v-row dense class="my-2 mx-3 pt-2" justify="space-between" align="center"><v-col cols="8"><v-card-title v-text="card.name" class="pa-0 ma-0 text-truncate"></v-card-title></v-col><v-col cols="4"
              ><v-row dense align="center" justify="end"
                ><v-icon>
                  {{ categoryIcons[card.category] }}</v-icon
                >
                <span class="mx-1">{{ card.category }}</span></v-row
              ></v-col
            ></v-row>
          <v-img
            :src="card.src"
            class="white--text align-end"
            gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
            height="200px"
          >
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
              <v-col
                cols="2"
                sm="2"
                class="px-0 d-flex flex-column justify-center align-center"
                ><v-btn
                  icon
                  color="error"
                  @click="
                    card.count = changeCount(card.count, card.countType, false)
                  "
                >
                  <v-icon color="error">mdi-minus</v-icon>
                </v-btn></v-col
              >
              <v-col cols="5" sm="7" md="3" lg="4" xl="4" class="px-0"
                ><v-text-field
                  maxlength="4"
                  solo
                  hide-details
                  dense
                  type="number"
                  class="input__number"
                  v-model="card.count"
                  :suffix="card.countType"
                ></v-text-field
              ></v-col>
              <v-col
                cols="2"
                sm="2"
                class="px-0 d-flex flex-column justify-center align-center"
                ><v-btn
                  icon
                  color="success"
                  @click="
                    card.count = changeCount(card.count, card.countType, true)
                  "
                >
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
    <v-row justify="center" v-else dense v-for="category in new Set(cards.map((product) => product.category).sort())" :key="category">
      <v-col cols="12"><div class="text-h5 my-3 text-center">{{category[0].toUpperCase() + category.slice(1)}}</div></v-col>
      <v-col cols="12"><v-row >
        <v-col
          v-for="(card, index) in cards.filter(product => product.category === category)"
          :key="card.name + index"
          cols="12"
          sm="6"
          md="6"
          lg="4"
          xl="3"
        >
        <v-card>
          <v-row dense class="my-2 mx-3 pt-2" justify="space-between" align="center"><v-col cols="8"><v-card-title v-text="card.name" class="pa-0 ma-0 text-truncate"></v-card-title></v-col><v-col cols="4"
              ><v-row dense align="center" justify="end"
                ><v-icon>
                  {{ categoryIcons[category] }}</v-icon
                >
                <span class="mx-1">{{ card.category }}</span></v-row
              ></v-col
            ></v-row>
          <v-img
            :src="card.src"
            class="white--text align-end"
            gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
            height="200px"
          >
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
              <v-col
                cols="2"
                sm="2"
                class="px-0 d-flex flex-column justify-center align-center"
                ><v-btn
                  icon
                  color="error"
                  @click="
                    card.count = changeCount(card.count, card.countType, false)
                  "
                >
                  <v-icon color="error">mdi-minus</v-icon>
                </v-btn></v-col
              >
              <v-col cols="5" sm="7" md="3" lg="4" xl="4" class="px-0"
                ><v-text-field
                  maxlength="4"
                  solo
                  hide-details
                  dense
                  type="number"
                  class="input__number"
                  v-model="card.count"
                  :suffix="card.countType"
                ></v-text-field
              ></v-col>
              <v-col
                cols="2"
                sm="2"
                class="px-0 d-flex flex-column justify-center align-center"
                ><v-btn
                  icon
                  color="success"
                  @click="
                    card.count = changeCount(card.count, card.countType, true)
                  "
                >
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
    </v-col>
    </v-row>
    <v-btn class="fixed__button mt-6" color="accent" tile @click="updateUser()"> Save </v-btn>
  </v-container>
</template>
<script>

export default {
  name: 'Card',
  components: {},
  props: {
    cards: Array,
    showByCategories: Boolean
  },
  data: () => ({
    categoryIcons: {
      Bread: 'mdi-bread-slice',
      Cereal: 'mdi-corn',
      Confectionery: 'mdi-cupcake',
      Dressing: 'mdi-taco',
      Drink: 'mdi-beer',
      Fruit: 'mdi-food-apple',
      Grain: 'mdi-barley',
      Juice: 'mdi-fruit-watermelon',
      Liqueur: 'mdi-liquor',
      Meat: 'mdi-food-drumstick',
      Pastry: 'mdi-food-croissant',
      Sauce: 'mdi-soy-sauce',
      Side: 'mdi-rice',
      Spice: 'mdi-shaker',
      Spirit: 'mdi-glass-stange',
      Vegetable: 'mdi-carrot',
      Wine: 'mdi-bottle-wine',
      Other: 'mdi-shape'
    }
  }),
  created () {

  },
  methods: {
    changeCount (count, countType, increase) {
      let countStep = 50
      if (countType === 'pcs') {
        countStep = 1
      }
      const result = increase
        ? (Number(count) + countStep).toString()
        : count - countStep
      if (increase) {
        return result < 10000 ? result.toString() : '9999'
      }
      return result > 0 ? result.toString() : '0'
    },
    async updateUser () {
      this.$emit('updateUser')
    }
  }
}
</script>
<style>
.input__number input[type='number'] {
    -moz-appearance: textfield;
    appearance: textfield;
}
.input__number input::-webkit-outer-spin-button,
.input__number input::-webkit-inner-spin-button {
    -webkit-appearance: none;
}
.fixed__button {
  position: sticky;
  display: block;
  bottom: 12px;
  width: 200px;
  left: 100%;
}
</style>

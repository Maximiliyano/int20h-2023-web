<template>
  <v-container fluid>
    <v-row v-if="!showByDifficulty" dense>
      <v-col
        v-for="(card, index) in cards"
        :key="card.name + index"
        cols="12"
        sm="6"
        md="6"
        lg="4"
        xl="3"
      >
        <v-card class="my-2">
          <v-row
            dense
            class="my-2 mx-3 pt-2"
            justify="space-between"
            align="center"
            ><v-col cols="9"
              ><v-card-title
                v-text="card.name"
                class="pa-0 ma-0 text-truncate"
              ></v-card-title></v-col
            ><v-col cols="3"
              ><v-row dense align="center" justify="end"
                ><v-icon :color="setDifficultyColor(card.difficulty)"
                  >mdi-chef-hat</v-icon
                >
                <span class="mx-1">{{ card.difficulty }}</span></v-row
              ></v-col
            ></v-row
          >
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
              Ingridients
              <v-icon>
                {{ card.show ? "mdi-chevron-up" : "mdi-chevron-down" }}
              </v-icon>
            </v-btn>
            <v-spacer></v-spacer>
            <v-dialog v-model="card.dialog" width="900px">
              <template v-slot:activator="{ on, attrs }">
                <v-btn text v-bind="attrs" v-on="on" color="primary">
                  Receipt
                </v-btn>
              </template>
              <v-card>
                <v-row justify="center" align="center" class="mx-2">
                  <v-col><v-row dense></v-row></v-col>
                  <v-col
                    ><v-row dense justify="center">
                      <v-card-title>
                        <div class="text-h5 text-center">{{ card.name }}</div>
                      </v-card-title></v-row
                    ></v-col
                  >
                  <v-col
                    ><v-row dense justify="end">
                      <v-btn
                        icon
                        dark
                        small
                        color="primary"
                        @click="card.dialog = false"
                      >
                        <v-icon dark> mdi-close </v-icon>
                      </v-btn></v-row
                    >
                  </v-col>
                </v-row>
                <v-row class="mx-5 mb-0 mt-1 pa-0"
                  ><span class="text-h6 mt-1 mx-1">Ingridients: </span
                  ><v-chip
                    v-for="(product, index) of card.products"
                    :key="product.name + index"
                    class="my-1 ml-0 mr-2"
                    >{{ product.name }} {{ product.count }}
                    {{ product.countType }}</v-chip
                  ></v-row
                >
                <v-row class="mx-2 px-0 mt-4 mb-2" justify="center"
                  ><span class="text-h5">Instructions</span></v-row
                >
                <v-card-text class="text-pre-wrap color-dark">{{
                  card.instructions
                }}</v-card-text>
              </v-card>
            </v-dialog>
          </v-card-actions>
          <v-expand-transition>
            <div v-show="card.show">
              <v-divider></v-divider>
              <v-card-text>
                <v-row>
                  <v-tooltip
                    v-for="(product, index) of card.products"
                    :key="product.name + index"
                    bottom
                    :color="
                      searchProductByNameAndCount(product) ? 'success' : 'error'
                    "
                  >
                    <template v-slot:activator="{ on, attrs }">
                      <v-chip
                        v-bind="attrs"
                        v-on="on"
                        outlined
                        round
                        elevation="2"
                        :color="
                          searchProductByNameAndCount(product)
                            ? 'success'
                            : 'error'
                        "
                        class="ma-1"
                        >{{
                          product.name +
                          ": " +
                          product.count +
                          product.countType
                        }}</v-chip
                      >
                    </template>
                    <span>{{
                      searchProductByNameAndCount(product)
                        ? product.count === "(optional)"
                          ? "optional"
                          : "enough"
                        : `lack ${countLackOfProduct(product)}`
                    }}</span>
                  </v-tooltip>
                </v-row>
              </v-card-text>
            </div>
          </v-expand-transition>
        </v-card>
      </v-col>
    </v-row>
    <v-row
      justify="center"
      v-else
      dense
      v-for="difficulty in new Set(cards.map(meal => meal.difficulty).sort())"
      :key="difficulty"
    >
      <v-col cols="12"
        ><div class="text-h5 my-3 text-center">
          {{ difficulty[0].toUpperCase() + difficulty.slice(1) }}
        </div></v-col
      >
      <v-col cols="12">
        <v-row dense>
          <v-col
            v-for="(card, index) in cards.filter(meal => meal.difficulty === difficulty)"
            :key="card.name + index"
            cols="12"
            sm="6"
            md="6"
            lg="4"
            xl="3"
          >
            <v-card class="my-2">
              <v-row
                dense
                class="my-2 mx-3 pt-2"
                justify="space-between"
                align="center"
                ><v-col cols="9"
                  ><v-card-title
                    v-text="card.name"
                    class="pa-0 ma-0 text-truncate"
                  ></v-card-title></v-col
                ><v-col cols="3"
                  ><v-row dense align="center" justify="end"
                    ><v-icon :color="setDifficultyColor(card.difficulty)"
                      >mdi-chef-hat</v-icon
                    >
                    <span class="mx-1">{{ card.difficulty }}</span></v-row
                  ></v-col
                ></v-row
              >
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
                  Ingridients
                  <v-icon>
                    {{ card.show ? "mdi-chevron-up" : "mdi-chevron-down" }}
                  </v-icon>
                </v-btn>
                <v-spacer></v-spacer>
                <v-dialog v-model="card.dialog" width="900px">
                  <template v-slot:activator="{ on, attrs }">
                    <v-btn text v-bind="attrs" v-on="on" color="primary">
                      Receipt
                    </v-btn>
                  </template>
                  <v-card>
                    <v-row justify="center" align="center" class="mx-2">
                      <v-col><v-row dense></v-row></v-col>
                      <v-col
                        ><v-row dense justify="center">
                          <v-card-title>
                            <div class="text-h5 text-center">
                              {{ card.name }}
                            </div>
                          </v-card-title></v-row
                        ></v-col
                      >
                      <v-col
                        ><v-row dense justify="end">
                          <v-btn
                            icon
                            dark
                            small
                            color="primary"
                            @click="card.dialog = false"
                          >
                            <v-icon dark> mdi-close </v-icon>
                          </v-btn></v-row
                        >
                      </v-col>
                    </v-row>
                    <v-row class="mx-5 mb-0 mt-1 pa-0"
                      ><span class="text-h6 mt-1 mx-1">Ingridients: </span
                      ><v-chip
                        v-for="(product, index) of card.products"
                        :key="product.name + index"
                        class="my-1 ml-0 mr-2"
                        >{{ product.name }} {{ product.count }}
                        {{ product.countType }}</v-chip
                      ></v-row
                    >
                    <v-row class="mx-2 px-0 mt-4 mb-2" justify="center"
                      ><span class="text-h5">Instructions</span></v-row
                    >
                    <v-card-text class="text-pre-wrap color-dark">{{
                      card.instructions
                    }}</v-card-text>
                  </v-card>
                </v-dialog>
              </v-card-actions>
              <v-expand-transition>
                <div v-show="card.show">
                  <v-divider></v-divider>
                  <v-card-text>
                    <v-row>
                      <v-tooltip
                        v-for="(product, index) of card.products"
                        :key="product.name + index"
                        bottom
                        :color="
                          searchProductByNameAndCount(product)
                            ? 'success'
                            : 'error'
                        "
                      >
                        <template v-slot:activator="{ on, attrs }">
                          <v-chip
                            v-bind="attrs"
                            v-on="on"
                            outlined
                            round
                            elevation="2"
                            :color="
                              searchProductByNameAndCount(product)
                                ? 'success'
                                : 'error'
                            "
                            class="ma-1"
                            >{{
                              product.name +
                              ": " +
                              product.count +
                              product.countType
                            }}</v-chip
                          >
                        </template>
                        <span>{{
                          searchProductByNameAndCount(product)
                            ? product.count === "(optional)"
                              ? "optional"
                              : "enough"
                            : `lack ${countLackOfProduct(product)}`
                        }}</span>
                      </v-tooltip>
                    </v-row>
                  </v-card-text>
                </div>
              </v-expand-transition>
            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
export default {
  name: 'Receipts',
  components: {},
  props: {
    cards: Array,
    userProducts: Array,
    showByDifficulty: Boolean
  },
  data: () => ({}),
  created () {},
  methods: {
    searchProductByNameAndCount (productToSearch) {
      return this.userProducts?.find(
        (product) =>
          (product.name === productToSearch.name &&
            Number(product.count) >= Number(productToSearch.count)) ||
          productToSearch.count === '(optional)'
      )
    },
    countLackOfProduct (product) {
      return (
        product.count -
        (
          this.userProducts?.find(
            (userProduct) => userProduct.name === product.name
          )?.count || 0
        ).toString() +
        product.countType
      )
    },
    setDifficultyColor (difficulty) {
      if (difficulty === 'easy') {
        return 'accent'
      }
      if (difficulty === 'medium') {
        return 'orange lighten-2'
      }
      return 'error'
    }
  }
}
</script>

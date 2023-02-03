<template>
  <v-container fluid>
    <v-row dense>
      <v-col
        v-for="(card, index) in cards"
        :key="card.title + index"
        cols="12"
        sm="6"
        md="4"
        lg="3"
      >
        <v-card>
          <v-img
            :src="card.src"
            class="white--text align-end"
            gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
            height="200px"
          >
            <v-card-title v-text="card.title"></v-card-title>
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
                <v-col><v-row dense justify="center">
                    <v-card-title>
                      <div class="text-h5 text-center">{{ card.title }}</div>
                    </v-card-title></v-row
                  ></v-col>
                  <v-col><v-row dense justify="end">
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
                <v-row class="ma-0 mx-2 px-0" justify="center"
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
                      searchProductByNameAndCount(userProducts, product)
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
                          searchProductByNameAndCount(userProducts, product)
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
                      searchProductByNameAndCount(userProducts, product)
                        ? "enough"
                        : `lack ${countLackOfProduct(userProducts, product)}`
                    }}</span>
                  </v-tooltip>
                </v-row>
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
  name: 'Receipts',
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
        title: 'Gachi1',
        src: 'https://cdn.vuetifyjs.com/images/cards/house.jpg',
        show: false,
        dialog: false,
        instructions:
          "STEP 1\r\nPut a large saucepan of water on to boil.\r\n\r\nSTEP 2\r\nFinely chop the 100g pancetta, having first removed any rind. Finely grate 50g pecorino cheese and 50g parmesan and mix them together.\r\n\r\nSTEP 3\r\nBeat the 3 large eggs in a medium bowl and season with a little freshly grated black pepper. Set everything aside.\r\n\r\nSTEP 4\r\nAdd 1 tsp salt to the boiling water, add 350g spaghetti and when the water comes back to the boil, cook at a constant simmer, covered, for 10 minutes or until al dente (just cooked).\r\n\r\nSTEP 5\r\nSquash 2 peeled plump garlic cloves with the blade of a knife, just to bruise it.\r\n\r\nSTEP 6\r\nWhile the spaghetti is cooking, fry the pancetta with the garlic. Drop 50g unsalted butter into a large frying pan or wok and, as soon as the butter has melted, tip in the pancetta and garlic.\r\n\r\nSTEP 7\r\nLeave to cook on a medium heat for about 5 minutes, stirring often, until the pancetta is golden and crisp. The garlic has now imparted its flavour, so take it out with a slotted spoon and discard.\r\n\r\nSTEP 8\r\nKeep the heat under the pancetta on low. When the pasta is ready, lift it from the water with a pasta fork or tongs and put it in the frying pan with the pancetta. Don't worry if a little water drops in the pan as well (you want this to happen) and don't throw the pasta water away yet.\r\n\r\nSTEP 9\r\nMix most of the cheese in with the eggs, keeping a small handful back for sprinkling over later.\r\n\r\nSTEP 10\r\nTake the pan of spaghetti and pancetta off the heat. Now quickly pour in the eggs and cheese. Using the tongs or a long fork, lift up the spaghetti so it mixes easily with the egg mixture, which thickens but doesn't scramble, and everything is coated.\r\n\r\nSTEP 11\r\nAdd extra pasta cooking water to keep it saucy (several tablespoons should do it). You don't want it wet, just moist. Season with a little salt, if needed.\r\n\r\nSTEP 12\r\nUse a long-pronged fork to twist the pasta on to the serving plate or bowl. Serve immediately with a little sprinkling of the remaining cheese and a grating of black pepper. If the dish does get a little dry before serving, splash in some more hot pasta water and the glossy sauciness will be revived.",
        products: [
          { name: 'carrot', count: '1', countType: 'pcs' },
          { name: 'milk', count: '100', countType: 'ml' },
          { name: 'water', count: '300', countType: 'ml' },
          { name: 'chickenMeat', count: '400', countType: 'g' }
        ]
      },
      {
        title: 'Gachi2',
        src: 'https://cdn.vuetifyjs.com/images/cards/road.jpg',
        show: false,
        dialog: false,
        instructions:
          "STEP 1\r\nPut a large saucepan of water on to boil.\r\n\r\nSTEP 2\r\nFinely chop the 100g pancetta, having first removed any rind. Finely grate 50g pecorino cheese and 50g parmesan and mix them together.\r\n\r\nSTEP 3\r\nBeat the 3 large eggs in a medium bowl and season with a little freshly grated black pepper. Set everything aside.\r\n\r\nSTEP 4\r\nAdd 1 tsp salt to the boiling water, add 350g spaghetti and when the water comes back to the boil, cook at a constant simmer, covered, for 10 minutes or until al dente (just cooked).\r\n\r\nSTEP 5\r\nSquash 2 peeled plump garlic cloves with the blade of a knife, just to bruise it.\r\n\r\nSTEP 6\r\nWhile the spaghetti is cooking, fry the pancetta with the garlic. Drop 50g unsalted butter into a large frying pan or wok and, as soon as the butter has melted, tip in the pancetta and garlic.\r\n\r\nSTEP 7\r\nLeave to cook on a medium heat for about 5 minutes, stirring often, until the pancetta is golden and crisp. The garlic has now imparted its flavour, so take it out with a slotted spoon and discard.\r\n\r\nSTEP 8\r\nKeep the heat under the pancetta on low. When the pasta is ready, lift it from the water with a pasta fork or tongs and put it in the frying pan with the pancetta. Don't worry if a little water drops in the pan as well (you want this to happen) and don't throw the pasta water away yet.\r\n\r\nSTEP 9\r\nMix most of the cheese in with the eggs, keeping a small handful back for sprinkling over later.\r\n\r\nSTEP 10\r\nTake the pan of spaghetti and pancetta off the heat. Now quickly pour in the eggs and cheese. Using the tongs or a long fork, lift up the spaghetti so it mixes easily with the egg mixture, which thickens but doesn't scramble, and everything is coated.\r\n\r\nSTEP 11\r\nAdd extra pasta cooking water to keep it saucy (several tablespoons should do it). You don't want it wet, just moist. Season with a little salt, if needed.\r\n\r\nSTEP 12\r\nUse a long-pronged fork to twist the pasta on to the serving plate or bowl. Serve immediately with a little sprinkling of the remaining cheese and a grating of black pepper. If the dish does get a little dry before serving, splash in some more hot pasta water and the glossy sauciness will be revived.",
        products: [
          { name: 'carrot', count: '1', countType: 'pcs' },
          { name: 'milk', count: '100', countType: 'ml' },
          { name: 'water', count: '300', countType: 'ml' },
          { name: 'chickenMeat', count: '400', countType: 'g' },
          { name: 'carrot2', count: '1', countType: 'pcs' },
          { name: 'milk2', count: '100', countType: 'ml' },
          { name: 'water2', count: '300', countType: 'ml' },
          { name: 'chickenMeat2', count: '400', countType: 'g' }
        ]
      },
      {
        title: 'Gachi3',
        src: 'https://cdn.vuetifyjs.com/images/cards/plane.jpg',
        show: false,
        dialog: false,
        instructions:
          "STEP 1\r\nPut a large saucepan of water on to boil.\r\n\r\nSTEP 2\r\nFinely chop the 100g pancetta, having first removed any rind. Finely grate 50g pecorino cheese and 50g parmesan and mix them together.\r\n\r\nSTEP 3\r\nBeat the 3 large eggs in a medium bowl and season with a little freshly grated black pepper. Set everything aside.\r\n\r\nSTEP 4\r\nAdd 1 tsp salt to the boiling water, add 350g spaghetti and when the water comes back to the boil, cook at a constant simmer, covered, for 10 minutes or until al dente (just cooked).\r\n\r\nSTEP 5\r\nSquash 2 peeled plump garlic cloves with the blade of a knife, just to bruise it.\r\n\r\nSTEP 6\r\nWhile the spaghetti is cooking, fry the pancetta with the garlic. Drop 50g unsalted butter into a large frying pan or wok and, as soon as the butter has melted, tip in the pancetta and garlic.\r\n\r\nSTEP 7\r\nLeave to cook on a medium heat for about 5 minutes, stirring often, until the pancetta is golden and crisp. The garlic has now imparted its flavour, so take it out with a slotted spoon and discard.\r\n\r\nSTEP 8\r\nKeep the heat under the pancetta on low. When the pasta is ready, lift it from the water with a pasta fork or tongs and put it in the frying pan with the pancetta. Don't worry if a little water drops in the pan as well (you want this to happen) and don't throw the pasta water away yet.\r\n\r\nSTEP 9\r\nMix most of the cheese in with the eggs, keeping a small handful back for sprinkling over later.\r\n\r\nSTEP 10\r\nTake the pan of spaghetti and pancetta off the heat. Now quickly pour in the eggs and cheese. Using the tongs or a long fork, lift up the spaghetti so it mixes easily with the egg mixture, which thickens but doesn't scramble, and everything is coated.\r\n\r\nSTEP 11\r\nAdd extra pasta cooking water to keep it saucy (several tablespoons should do it). You don't want it wet, just moist. Season with a little salt, if needed.\r\n\r\nSTEP 12\r\nUse a long-pronged fork to twist the pasta on to the serving plate or bowl. Serve immediately with a little sprinkling of the remaining cheese and a grating of black pepper. If the dish does get a little dry before serving, splash in some more hot pasta water and the glossy sauciness will be revived.",
        products: [
          { name: 'carrot', count: '1', countType: 'pcs' },
          { name: 'milk', count: '100', countType: 'ml' },
          { name: 'water', count: '300', countType: 'ml' },
          { name: 'chickenMeat', count: '400', countType: 'g' }
        ]
      },
      {
        title: 'Gachi1',
        src: 'https://cdn.vuetifyjs.com/images/cards/house.jpg',
        show: false,
        dialog: false,
        instructions:
          "STEP 1\r\nPut a large saucepan of water on to boil.\r\n\r\nSTEP 2\r\nFinely chop the 100g pancetta, having first removed any rind. Finely grate 50g pecorino cheese and 50g parmesan and mix them together.\r\n\r\nSTEP 3\r\nBeat the 3 large eggs in a medium bowl and season with a little freshly grated black pepper. Set everything aside.\r\n\r\nSTEP 4\r\nAdd 1 tsp salt to the boiling water, add 350g spaghetti and when the water comes back to the boil, cook at a constant simmer, covered, for 10 minutes or until al dente (just cooked).\r\n\r\nSTEP 5\r\nSquash 2 peeled plump garlic cloves with the blade of a knife, just to bruise it.\r\n\r\nSTEP 6\r\nWhile the spaghetti is cooking, fry the pancetta with the garlic. Drop 50g unsalted butter into a large frying pan or wok and, as soon as the butter has melted, tip in the pancetta and garlic.\r\n\r\nSTEP 7\r\nLeave to cook on a medium heat for about 5 minutes, stirring often, until the pancetta is golden and crisp. The garlic has now imparted its flavour, so take it out with a slotted spoon and discard.\r\n\r\nSTEP 8\r\nKeep the heat under the pancetta on low. When the pasta is ready, lift it from the water with a pasta fork or tongs and put it in the frying pan with the pancetta. Don't worry if a little water drops in the pan as well (you want this to happen) and don't throw the pasta water away yet.\r\n\r\nSTEP 9\r\nMix most of the cheese in with the eggs, keeping a small handful back for sprinkling over later.\r\n\r\nSTEP 10\r\nTake the pan of spaghetti and pancetta off the heat. Now quickly pour in the eggs and cheese. Using the tongs or a long fork, lift up the spaghetti so it mixes easily with the egg mixture, which thickens but doesn't scramble, and everything is coated.\r\n\r\nSTEP 11\r\nAdd extra pasta cooking water to keep it saucy (several tablespoons should do it). You don't want it wet, just moist. Season with a little salt, if needed.\r\n\r\nSTEP 12\r\nUse a long-pronged fork to twist the pasta on to the serving plate or bowl. Serve immediately with a little sprinkling of the remaining cheese and a grating of black pepper. If the dish does get a little dry before serving, splash in some more hot pasta water and the glossy sauciness will be revived.",
        products: [
          { name: 'carrot', count: '1', countType: 'pcs' },
          { name: 'milk', count: '100', countType: 'ml' },
          { name: 'water', count: '300', countType: 'ml' },
          { name: 'chickenMeat', count: '400', countType: 'g' }
        ]
      },
      {
        title: 'Gachi2',
        src: 'https://cdn.vuetifyjs.com/images/cards/road.jpg',
        show: false,
        dialog: false,
        instructions:
          "STEP 1\r\nPut a large saucepan of water on to boil.\r\n\r\nSTEP 2\r\nFinely chop the 100g pancetta, having first removed any rind. Finely grate 50g pecorino cheese and 50g parmesan and mix them together.\r\n\r\nSTEP 3\r\nBeat the 3 large eggs in a medium bowl and season with a little freshly grated black pepper. Set everything aside.\r\n\r\nSTEP 4\r\nAdd 1 tsp salt to the boiling water, add 350g spaghetti and when the water comes back to the boil, cook at a constant simmer, covered, for 10 minutes or until al dente (just cooked).\r\n\r\nSTEP 5\r\nSquash 2 peeled plump garlic cloves with the blade of a knife, just to bruise it.\r\n\r\nSTEP 6\r\nWhile the spaghetti is cooking, fry the pancetta with the garlic. Drop 50g unsalted butter into a large frying pan or wok and, as soon as the butter has melted, tip in the pancetta and garlic.\r\n\r\nSTEP 7\r\nLeave to cook on a medium heat for about 5 minutes, stirring often, until the pancetta is golden and crisp. The garlic has now imparted its flavour, so take it out with a slotted spoon and discard.\r\n\r\nSTEP 8\r\nKeep the heat under the pancetta on low. When the pasta is ready, lift it from the water with a pasta fork or tongs and put it in the frying pan with the pancetta. Don't worry if a little water drops in the pan as well (you want this to happen) and don't throw the pasta water away yet.\r\n\r\nSTEP 9\r\nMix most of the cheese in with the eggs, keeping a small handful back for sprinkling over later.\r\n\r\nSTEP 10\r\nTake the pan of spaghetti and pancetta off the heat. Now quickly pour in the eggs and cheese. Using the tongs or a long fork, lift up the spaghetti so it mixes easily with the egg mixture, which thickens but doesn't scramble, and everything is coated.\r\n\r\nSTEP 11\r\nAdd extra pasta cooking water to keep it saucy (several tablespoons should do it). You don't want it wet, just moist. Season with a little salt, if needed.\r\n\r\nSTEP 12\r\nUse a long-pronged fork to twist the pasta on to the serving plate or bowl. Serve immediately with a little sprinkling of the remaining cheese and a grating of black pepper. If the dish does get a little dry before serving, splash in some more hot pasta water and the glossy sauciness will be revived.",
        products: [
          { name: 'carrot', count: '1', countType: 'pcs' },
          { name: 'milk', count: '100', countType: 'ml' },
          { name: 'water', count: '300', countType: 'ml' },
          { name: 'chickenMeat', count: '400', countType: 'g' }
        ]
      },
      {
        title: 'Gachi3',
        src: 'https://cdn.vuetifyjs.com/images/cards/plane.jpg',
        show: false,
        dialog: false,
        instructions:
          "STEP 1\r\nPut a large saucepan of water on to boil.\r\n\r\nSTEP 2\r\nFinely chop the 100g pancetta, having first removed any rind. Finely grate 50g pecorino cheese and 50g parmesan and mix them together.\r\n\r\nSTEP 3\r\nBeat the 3 large eggs in a medium bowl and season with a little freshly grated black pepper. Set everything aside.\r\n\r\nSTEP 4\r\nAdd 1 tsp salt to the boiling water, add 350g spaghetti and when the water comes back to the boil, cook at a constant simmer, covered, for 10 minutes or until al dente (just cooked).\r\n\r\nSTEP 5\r\nSquash 2 peeled plump garlic cloves with the blade of a knife, just to bruise it.\r\n\r\nSTEP 6\r\nWhile the spaghetti is cooking, fry the pancetta with the garlic. Drop 50g unsalted butter into a large frying pan or wok and, as soon as the butter has melted, tip in the pancetta and garlic.\r\n\r\nSTEP 7\r\nLeave to cook on a medium heat for about 5 minutes, stirring often, until the pancetta is golden and crisp. The garlic has now imparted its flavour, so take it out with a slotted spoon and discard.\r\n\r\nSTEP 8\r\nKeep the heat under the pancetta on low. When the pasta is ready, lift it from the water with a pasta fork or tongs and put it in the frying pan with the pancetta. Don't worry if a little water drops in the pan as well (you want this to happen) and don't throw the pasta water away yet.\r\n\r\nSTEP 9\r\nMix most of the cheese in with the eggs, keeping a small handful back for sprinkling over later.\r\n\r\nSTEP 10\r\nTake the pan of spaghetti and pancetta off the heat. Now quickly pour in the eggs and cheese. Using the tongs or a long fork, lift up the spaghetti so it mixes easily with the egg mixture, which thickens but doesn't scramble, and everything is coated.\r\n\r\nSTEP 11\r\nAdd extra pasta cooking water to keep it saucy (several tablespoons should do it). You don't want it wet, just moist. Season with a little salt, if needed.\r\n\r\nSTEP 12\r\nUse a long-pronged fork to twist the pasta on to the serving plate or bowl. Serve immediately with a little sprinkling of the remaining cheese and a grating of black pepper. If the dish does get a little dry before serving, splash in some more hot pasta water and the glossy sauciness will be revived.",
        products: [
          { name: 'carrot', count: '1', countType: 'pcs' },
          { name: 'milk', count: '100', countType: 'ml' },
          { name: 'water', count: '300', countType: 'ml' },
          { name: 'chickenMeat', count: '400', countType: 'g' }
        ]
      },
      {
        title: 'Gachi1',
        src: 'https://cdn.vuetifyjs.com/images/cards/house.jpg',
        show: false,
        dialog: false,
        instructions:
          "STEP 1\r\nPut a large saucepan of water on to boil.\r\n\r\nSTEP 2\r\nFinely chop the 100g pancetta, having first removed any rind. Finely grate 50g pecorino cheese and 50g parmesan and mix them together.\r\n\r\nSTEP 3\r\nBeat the 3 large eggs in a medium bowl and season with a little freshly grated black pepper. Set everything aside.\r\n\r\nSTEP 4\r\nAdd 1 tsp salt to the boiling water, add 350g spaghetti and when the water comes back to the boil, cook at a constant simmer, covered, for 10 minutes or until al dente (just cooked).\r\n\r\nSTEP 5\r\nSquash 2 peeled plump garlic cloves with the blade of a knife, just to bruise it.\r\n\r\nSTEP 6\r\nWhile the spaghetti is cooking, fry the pancetta with the garlic. Drop 50g unsalted butter into a large frying pan or wok and, as soon as the butter has melted, tip in the pancetta and garlic.\r\n\r\nSTEP 7\r\nLeave to cook on a medium heat for about 5 minutes, stirring often, until the pancetta is golden and crisp. The garlic has now imparted its flavour, so take it out with a slotted spoon and discard.\r\n\r\nSTEP 8\r\nKeep the heat under the pancetta on low. When the pasta is ready, lift it from the water with a pasta fork or tongs and put it in the frying pan with the pancetta. Don't worry if a little water drops in the pan as well (you want this to happen) and don't throw the pasta water away yet.\r\n\r\nSTEP 9\r\nMix most of the cheese in with the eggs, keeping a small handful back for sprinkling over later.\r\n\r\nSTEP 10\r\nTake the pan of spaghetti and pancetta off the heat. Now quickly pour in the eggs and cheese. Using the tongs or a long fork, lift up the spaghetti so it mixes easily with the egg mixture, which thickens but doesn't scramble, and everything is coated.\r\n\r\nSTEP 11\r\nAdd extra pasta cooking water to keep it saucy (several tablespoons should do it). You don't want it wet, just moist. Season with a little salt, if needed.\r\n\r\nSTEP 12\r\nUse a long-pronged fork to twist the pasta on to the serving plate or bowl. Serve immediately with a little sprinkling of the remaining cheese and a grating of black pepper. If the dish does get a little dry before serving, splash in some more hot pasta water and the glossy sauciness will be revived.",
        products: [
          { name: 'carrot', count: '1', countType: 'pcs' },
          { name: 'milk', count: '100', countType: 'ml' },
          { name: 'water', count: '300', countType: 'ml' },
          { name: 'chickenMeat', count: '400', countType: 'g' }
        ]
      },
      {
        title: 'Gachi2',
        src: 'https://cdn.vuetifyjs.com/images/cards/road.jpg',
        show: false,
        dialog: false,
        instructions:
          "STEP 1\r\nPut a large saucepan of water on to boil.\r\n\r\nSTEP 2\r\nFinely chop the 100g pancetta, having first removed any rind. Finely grate 50g pecorino cheese and 50g parmesan and mix them together.\r\n\r\nSTEP 3\r\nBeat the 3 large eggs in a medium bowl and season with a little freshly grated black pepper. Set everything aside.\r\n\r\nSTEP 4\r\nAdd 1 tsp salt to the boiling water, add 350g spaghetti and when the water comes back to the boil, cook at a constant simmer, covered, for 10 minutes or until al dente (just cooked).\r\n\r\nSTEP 5\r\nSquash 2 peeled plump garlic cloves with the blade of a knife, just to bruise it.\r\n\r\nSTEP 6\r\nWhile the spaghetti is cooking, fry the pancetta with the garlic. Drop 50g unsalted butter into a large frying pan or wok and, as soon as the butter has melted, tip in the pancetta and garlic.\r\n\r\nSTEP 7\r\nLeave to cook on a medium heat for about 5 minutes, stirring often, until the pancetta is golden and crisp. The garlic has now imparted its flavour, so take it out with a slotted spoon and discard.\r\n\r\nSTEP 8\r\nKeep the heat under the pancetta on low. When the pasta is ready, lift it from the water with a pasta fork or tongs and put it in the frying pan with the pancetta. Don't worry if a little water drops in the pan as well (you want this to happen) and don't throw the pasta water away yet.\r\n\r\nSTEP 9\r\nMix most of the cheese in with the eggs, keeping a small handful back for sprinkling over later.\r\n\r\nSTEP 10\r\nTake the pan of spaghetti and pancetta off the heat. Now quickly pour in the eggs and cheese. Using the tongs or a long fork, lift up the spaghetti so it mixes easily with the egg mixture, which thickens but doesn't scramble, and everything is coated.\r\n\r\nSTEP 11\r\nAdd extra pasta cooking water to keep it saucy (several tablespoons should do it). You don't want it wet, just moist. Season with a little salt, if needed.\r\n\r\nSTEP 12\r\nUse a long-pronged fork to twist the pasta on to the serving plate or bowl. Serve immediately with a little sprinkling of the remaining cheese and a grating of black pepper. If the dish does get a little dry before serving, splash in some more hot pasta water and the glossy sauciness will be revived.",
        products: [
          { name: 'carrot', count: '1', countType: 'pcs' },
          { name: 'milk', count: '100', countType: 'ml' },
          { name: 'water', count: '300', countType: 'ml' },
          { name: 'chickenMeat', count: '400', countType: 'g' }
        ]
      },
      {
        title: 'Gachi3',
        src: 'https://cdn.vuetifyjs.com/images/cards/plane.jpg',
        show: false,
        dialog: false,
        instructions:
          "STEP 1\r\nPut a large saucepan of water on to boil.\r\n\r\nSTEP 2\r\nFinely chop the 100g pancetta, having first removed any rind. Finely grate 50g pecorino cheese and 50g parmesan and mix them together.\r\n\r\nSTEP 3\r\nBeat the 3 large eggs in a medium bowl and season with a little freshly grated black pepper. Set everything aside.\r\n\r\nSTEP 4\r\nAdd 1 tsp salt to the boiling water, add 350g spaghetti and when the water comes back to the boil, cook at a constant simmer, covered, for 10 minutes or until al dente (just cooked).\r\n\r\nSTEP 5\r\nSquash 2 peeled plump garlic cloves with the blade of a knife, just to bruise it.\r\n\r\nSTEP 6\r\nWhile the spaghetti is cooking, fry the pancetta with the garlic. Drop 50g unsalted butter into a large frying pan or wok and, as soon as the butter has melted, tip in the pancetta and garlic.\r\n\r\nSTEP 7\r\nLeave to cook on a medium heat for about 5 minutes, stirring often, until the pancetta is golden and crisp. The garlic has now imparted its flavour, so take it out with a slotted spoon and discard.\r\n\r\nSTEP 8\r\nKeep the heat under the pancetta on low. When the pasta is ready, lift it from the water with a pasta fork or tongs and put it in the frying pan with the pancetta. Don't worry if a little water drops in the pan as well (you want this to happen) and don't throw the pasta water away yet.\r\n\r\nSTEP 9\r\nMix most of the cheese in with the eggs, keeping a small handful back for sprinkling over later.\r\n\r\nSTEP 10\r\nTake the pan of spaghetti and pancetta off the heat. Now quickly pour in the eggs and cheese. Using the tongs or a long fork, lift up the spaghetti so it mixes easily with the egg mixture, which thickens but doesn't scramble, and everything is coated.\r\n\r\nSTEP 11\r\nAdd extra pasta cooking water to keep it saucy (several tablespoons should do it). You don't want it wet, just moist. Season with a little salt, if needed.\r\n\r\nSTEP 12\r\nUse a long-pronged fork to twist the pasta on to the serving plate or bowl. Serve immediately with a little sprinkling of the remaining cheese and a grating of black pepper. If the dish does get a little dry before serving, splash in some more hot pasta water and the glossy sauciness will be revived.",
        products: [
          { name: 'carrot', count: '1', countType: 'pcs' },
          { name: 'milk', count: '100', countType: 'ml' },
          { name: 'water', count: '300', countType: 'ml' },
          { name: 'chickenMeat', count: '400', countType: 'g' }
        ]
      },
      {
        title: 'Gachi1',
        src: 'https://cdn.vuetifyjs.com/images/cards/house.jpg',
        show: false,
        dialog: false,
        instructions:
          "STEP 1\r\nPut a large saucepan of water on to boil.\r\n\r\nSTEP 2\r\nFinely chop the 100g pancetta, having first removed any rind. Finely grate 50g pecorino cheese and 50g parmesan and mix them together.\r\n\r\nSTEP 3\r\nBeat the 3 large eggs in a medium bowl and season with a little freshly grated black pepper. Set everything aside.\r\n\r\nSTEP 4\r\nAdd 1 tsp salt to the boiling water, add 350g spaghetti and when the water comes back to the boil, cook at a constant simmer, covered, for 10 minutes or until al dente (just cooked).\r\n\r\nSTEP 5\r\nSquash 2 peeled plump garlic cloves with the blade of a knife, just to bruise it.\r\n\r\nSTEP 6\r\nWhile the spaghetti is cooking, fry the pancetta with the garlic. Drop 50g unsalted butter into a large frying pan or wok and, as soon as the butter has melted, tip in the pancetta and garlic.\r\n\r\nSTEP 7\r\nLeave to cook on a medium heat for about 5 minutes, stirring often, until the pancetta is golden and crisp. The garlic has now imparted its flavour, so take it out with a slotted spoon and discard.\r\n\r\nSTEP 8\r\nKeep the heat under the pancetta on low. When the pasta is ready, lift it from the water with a pasta fork or tongs and put it in the frying pan with the pancetta. Don't worry if a little water drops in the pan as well (you want this to happen) and don't throw the pasta water away yet.\r\n\r\nSTEP 9\r\nMix most of the cheese in with the eggs, keeping a small handful back for sprinkling over later.\r\n\r\nSTEP 10\r\nTake the pan of spaghetti and pancetta off the heat. Now quickly pour in the eggs and cheese. Using the tongs or a long fork, lift up the spaghetti so it mixes easily with the egg mixture, which thickens but doesn't scramble, and everything is coated.\r\n\r\nSTEP 11\r\nAdd extra pasta cooking water to keep it saucy (several tablespoons should do it). You don't want it wet, just moist. Season with a little salt, if needed.\r\n\r\nSTEP 12\r\nUse a long-pronged fork to twist the pasta on to the serving plate or bowl. Serve immediately with a little sprinkling of the remaining cheese and a grating of black pepper. If the dish does get a little dry before serving, splash in some more hot pasta water and the glossy sauciness will be revived.",
        products: [
          { name: 'carrot', count: '1', countType: 'pcs' },
          { name: 'milk', count: '100', countType: 'ml' },
          { name: 'water', count: '300', countType: 'ml' },
          { name: 'chickenMeat', count: '400', countType: 'g' }
        ]
      },
      {
        title: 'Gachi2',
        src: 'https://cdn.vuetifyjs.com/images/cards/road.jpg',
        show: false,
        dialog: false,
        instructions:
          "STEP 1\r\nPut a large saucepan of water on to boil.\r\n\r\nSTEP 2\r\nFinely chop the 100g pancetta, having first removed any rind. Finely grate 50g pecorino cheese and 50g parmesan and mix them together.\r\n\r\nSTEP 3\r\nBeat the 3 large eggs in a medium bowl and season with a little freshly grated black pepper. Set everything aside.\r\n\r\nSTEP 4\r\nAdd 1 tsp salt to the boiling water, add 350g spaghetti and when the water comes back to the boil, cook at a constant simmer, covered, for 10 minutes or until al dente (just cooked).\r\n\r\nSTEP 5\r\nSquash 2 peeled plump garlic cloves with the blade of a knife, just to bruise it.\r\n\r\nSTEP 6\r\nWhile the spaghetti is cooking, fry the pancetta with the garlic. Drop 50g unsalted butter into a large frying pan or wok and, as soon as the butter has melted, tip in the pancetta and garlic.\r\n\r\nSTEP 7\r\nLeave to cook on a medium heat for about 5 minutes, stirring often, until the pancetta is golden and crisp. The garlic has now imparted its flavour, so take it out with a slotted spoon and discard.\r\n\r\nSTEP 8\r\nKeep the heat under the pancetta on low. When the pasta is ready, lift it from the water with a pasta fork or tongs and put it in the frying pan with the pancetta. Don't worry if a little water drops in the pan as well (you want this to happen) and don't throw the pasta water away yet.\r\n\r\nSTEP 9\r\nMix most of the cheese in with the eggs, keeping a small handful back for sprinkling over later.\r\n\r\nSTEP 10\r\nTake the pan of spaghetti and pancetta off the heat. Now quickly pour in the eggs and cheese. Using the tongs or a long fork, lift up the spaghetti so it mixes easily with the egg mixture, which thickens but doesn't scramble, and everything is coated.\r\n\r\nSTEP 11\r\nAdd extra pasta cooking water to keep it saucy (several tablespoons should do it). You don't want it wet, just moist. Season with a little salt, if needed.\r\n\r\nSTEP 12\r\nUse a long-pronged fork to twist the pasta on to the serving plate or bowl. Serve immediately with a little sprinkling of the remaining cheese and a grating of black pepper. If the dish does get a little dry before serving, splash in some more hot pasta water and the glossy sauciness will be revived.",
        products: [
          { name: 'carrot', count: '1', countType: 'pcs' },
          { name: 'milk', count: '100', countType: 'ml' },
          { name: 'water', count: '300', countType: 'ml' },
          { name: 'chickenMeat', count: '400', countType: 'g' }
        ]
      },
      {
        title: 'Gachi3',
        src: 'https://cdn.vuetifyjs.com/images/cards/plane.jpg',
        show: false,
        dialog: false,
        instructions:
          "STEP 1\r\nPut a large saucepan of water on to boil.\r\n\r\nSTEP 2\r\nFinely chop the 100g pancetta, having first removed any rind. Finely grate 50g pecorino cheese and 50g parmesan and mix them together.\r\n\r\nSTEP 3\r\nBeat the 3 large eggs in a medium bowl and season with a little freshly grated black pepper. Set everything aside.\r\n\r\nSTEP 4\r\nAdd 1 tsp salt to the boiling water, add 350g spaghetti and when the water comes back to the boil, cook at a constant simmer, covered, for 10 minutes or until al dente (just cooked).\r\n\r\nSTEP 5\r\nSquash 2 peeled plump garlic cloves with the blade of a knife, just to bruise it.\r\n\r\nSTEP 6\r\nWhile the spaghetti is cooking, fry the pancetta with the garlic. Drop 50g unsalted butter into a large frying pan or wok and, as soon as the butter has melted, tip in the pancetta and garlic.\r\n\r\nSTEP 7\r\nLeave to cook on a medium heat for about 5 minutes, stirring often, until the pancetta is golden and crisp. The garlic has now imparted its flavour, so take it out with a slotted spoon and discard.\r\n\r\nSTEP 8\r\nKeep the heat under the pancetta on low. When the pasta is ready, lift it from the water with a pasta fork or tongs and put it in the frying pan with the pancetta. Don't worry if a little water drops in the pan as well (you want this to happen) and don't throw the pasta water away yet.\r\n\r\nSTEP 9\r\nMix most of the cheese in with the eggs, keeping a small handful back for sprinkling over later.\r\n\r\nSTEP 10\r\nTake the pan of spaghetti and pancetta off the heat. Now quickly pour in the eggs and cheese. Using the tongs or a long fork, lift up the spaghetti so it mixes easily with the egg mixture, which thickens but doesn't scramble, and everything is coated.\r\n\r\nSTEP 11\r\nAdd extra pasta cooking water to keep it saucy (several tablespoons should do it). You don't want it wet, just moist. Season with a little salt, if needed.\r\n\r\nSTEP 12\r\nUse a long-pronged fork to twist the pasta on to the serving plate or bowl. Serve immediately with a little sprinkling of the remaining cheese and a grating of black pepper. If the dish does get a little dry before serving, splash in some more hot pasta water and the glossy sauciness will be revived.",
        products: [
          { name: 'carrot', count: '1', countType: 'pcs' },
          { name: 'milk', count: '100', countType: 'ml' },
          { name: 'water', count: '300', countType: 'ml' },
          { name: 'chickenMeat', count: '400', countType: 'g' }
        ]
      }
    ],
    dialog: false
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
    }
  }
}
</script>

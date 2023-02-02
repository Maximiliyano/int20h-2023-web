<template>
  <v-container fluid>
    <div class="text-center">
      Products
    </div>
    <v-divider />
    <Card/>
  </v-container>
</template>
<script>
import Card from '@/components/Card'
export default {
  name: 'ProductsPage',
  components: { Card }
}
</script>

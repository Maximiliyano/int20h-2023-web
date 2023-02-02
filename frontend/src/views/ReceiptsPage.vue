<template>
  <v-container fluid>
    <div class="text-center">
      Receipts
    </div>
    <Receipts/>
    <v-divider />
  </v-container>
</template>

<script>
import Receipts from '@/components/Receipts'
export default {
  name: 'ReceiptsPage',
  components: { Receipts }
}
</script>

<template>
  <div class="container">
    <order-status :status="0"></order-status>
    <table-number :table-number="tableNumber"></table-number>
  </div>
</template>
<script>
  import OrderStatus from '@/components/OrderItemStatus'
  import TableNumber from '@/components/MealTableNumber'
  export default {
    data () {
      return {
        tableNumber: 23
      }
    },
    components: {
      TableNumber,
      OrderStatus
    },
    methods: {
    },
    created () {}
  }
</script>
<style lang="scss" scoped>
  @import "~@/styles/variable";
</style>

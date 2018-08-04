<template>
  <div class="container">
    <block v-for="order in orderList" :key="order.id">
      <order-item :order="order"></order-item>
    </block>
  </div>
</template>
<script>
  import OrderItem from '@/components/OrderListItem'
  import { orderList } from '@/mock/mockOrderData'
  export default {
    data () {
      return {
        orderList: orderList
      }
    },
    components: {
      OrderItem
    },
    methods: {
    },
    created () {}
  }
</script>
<style lang="scss" scoped>
  @import "~@/styles/variable";
  .container {
    background-color: $primary-white;
  }
</style>

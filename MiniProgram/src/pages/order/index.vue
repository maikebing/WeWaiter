<template>
  <div class="container">
    <block v-for="order in orderList" :key="order.id">
      <order-item :order="order"></order-item>
    </block>
  </div>
</template>
<script>
  import OrderItem from '@/components/OrderListItem'
  // import { orderList } from '@/mock/mockOrderData'
  export default {
    data () {
      return {
        orderList: []
      }
    },
    components: {
      OrderItem
    },
    methods: {
      async getData() {
        console.log('getData@22 获取订单')
        let params = { openid: 'wx12334fdsaf'}
        let orderListRes = await this.$http.get('http://mock.eolinker.com/scQJzZz3b1d68053d700909597f57222c37b858e8b501de?uri=/order/', params)
        console.log('getData@24', orderListRes.data)
        this.orderList = orderListRes.data
      }
    },
    created () {

    },
    onShow() {
      this.getData()
    }
  }
</script>
<style lang="scss" scoped>
  @import "~@/styles/variable";
  .container {
    background-color: $primary-white;
  }
</style>

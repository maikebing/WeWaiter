<template>
  <div class="container">
    <block v-for="order in orderList" :key="order.id">
      <order-item :order="order" @pay-success="payOnSuccess"></order-item>
    </block>
  </div>
</template>
<script>
import OrderItem from '@/components/OrderListItem'
import fly from '@/libs/fly'
// import { orderList } from '@/mock/mockOrderData'
export default {
  data() {
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
      let orderListRes = await fly.get('Orders')
      console.log('getData@24', orderListRes.orders)
      this.orderList = orderListRes.orders
    },
    payOnSuccess() {
      console.log('payOnSuccess@订单列表页：29 ==========> 订单支付成功')
      this.getData()
    }
  },
  created() {},
  onShow() {
    this.getData()
  },
  onLoad() {}
}
</script>
<style lang="scss" scoped>
@import '~@/styles/variable';

.container {
  background-color: $primary-white;
}
</style>

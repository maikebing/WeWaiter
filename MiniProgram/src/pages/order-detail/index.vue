<template>
  <div class="container">
    <order-status :status="order.orderStatus"></order-status>
    <table-number :status="order.orderStatus" :seller="seller"></table-number>
    <div class="we-order-btn-group">
      <order-action :order="order" @pay-success="payOnSuccess" />
    </div>
    <div class="we-order-menu-list">
      <menu-list :menu-list="buyItems" :total="order.totalPrice"></menu-list>
    </div>
  </div>
</template>
<script type="text/babel">
import OrderStatus from '@/components/OrderListItemStatus'
import TableNumber from '@/components/MealTableNumber'
import MenuList from '@/components/MealMenuList'
import OrderAction from '@/components/OrderAction'

export default {
  data() {
    return {
      orderID: '',
      order: {},
      seller: {},
      foods: [],
      buyItems: []
    }
  },
  components: {
    OrderAction,
    TableNumber,
    OrderStatus,
    MenuList
  },
  methods: {
    // getOrderData (id) {
    //   return orderList.find((order) => String(order.id) === id)
    // }
    async getData(id) {
      let orderRes = await this.$http.get(`orders/${id}`)
      // let orderRes = await this.$http.get(`http://mock.eolinker.com/scQJzZz3b1d68053d700909597f57222c37b858e8b501de?uri=/order/${id}`)
      // let orderRes = await this.$http.get(`orders`)
      console.log('getData@49:index', orderRes)
      orderRes.data.seller.avatar = orderRes.data.seller.avatar
      this.seller = orderRes.data.seller
      this.order = orderRes.data.order
      this.order.status = {
        code: orderRes.data.order.statusCode
      }
      let items = orderRes.data.buyItems
      items = items.map(x => {
        x.icon = x.icon
        x.image = x.image
        x.name = x.goodsName
        x.id = x.goodsID
        x.count = x.amount
        x.price = x.unitPrice
        return x
      })
      console.log('items@55', items)
      this.buyItems = items
    },
    payOnSuccess() {
      console.log('payOnSuccess@订单详情页:64 ==========> 订单支付成功')
      this.getData(this.orderID)
    }
  },
  created() {},
  onLoad(options) {
    // this.order = this.getOrderData(options.id)
    this.orderID = options.id
    this.getData(this.orderID)
  },
  onShow() {}
}
</script>
<style lang="scss" scoped>
@import '~@/styles/variable';
.we-order-btn-group {
  margin: 20rpx;
  padding: 23rpx;
  background-color: $primary-white;
}

.we-order-menu-list {
  padding: 0 20rpx;
  margin-bottom: 20rpx;
}
</style>

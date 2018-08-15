<template>
  <div class="container">
    <order-status :status="order.status && order.status.code"></order-status>
    <table-number :status="order.status && order.status.code" :seller="seller"></table-number>
    <div class="we-order-btn-group">
      <order-action :order="order"/>
    </div>
    <div class="we-order-menu-list">
      <menu-list :menu-list="order.foods" :total="order.total_price"></menu-list>
    </div>
  </div>
</template>
<script type="text/babel">
  import OrderStatus from '@/components/OrderListItemStatus'
  import TableNumber from '@/components/MealTableNumber'
  import MenuList from '@/components/MealMenuList'
  import OrderAction from '@/components/OrderAction'

  export default {
    data () {
      return {
        order: {},
        seller: {},
        foods: []
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
      async getData (id) {
        let orderRes = await this.$http.get(`order/${id}`)
        console.log('getData@49:index', orderRes)
        this.seller = orderRes.data.seller
        this.order = orderRes.data
      }
    },
    created () {
    },
    onLoad (options) {
      // this.order = this.getOrderData(options.id)
      this.getData(options.id)
    },
    onShow() {

    }
  }
</script>
<style lang="scss" scoped>
  @import "~@/styles/variable";
  .we-order-btn-group {
    margin: 20px;
    padding: 23px;
    background-color: $primary-white;
  }

  .we-order-menu-list {
    padding: 0 20px;
  }
</style>

<template>
  <div class="container">
    <order-status :status="order.status.code"></order-status>
    <table-number :status="order.status.code" :seller="seller"></table-number>
    <div class="we-order-btn-group">
      <div
        class="we-btn we-btn-default"
        v-if="order.status.code !== 0"
        @click="onOneMoreOrder">再来一单
      </div>
      <div
        class="we-btn we-btn-default"
        v-if="order.status.code === 0 || order.status.code === 1"
        @click="onOrderDishes(order.id)">加菜
      </div>
      <div
        class="we-btn we-btn-pay"
        v-if="order.status.code === 0"
        @click="onPay(order.id)">立即支付
      </div>
    </div>
    <div class="we-order-menu-list">
      <menu-list :menu-list="order.foods" :total="order.total_price"></menu-list>
    </div>
  </div>
</template>
<script type="text/babel">
  import OrderStatus from '@/components/OrderListItemStatus'
  import TableNumber from '@/components/MealTableNumber'
  import {orderList} from '@/mock/mockOrderData'
  import MenuList from '@/components/MealMenuList'
  export default {
    data () {
      return {
        order: {},
        seller: {},
        foods: []
      }
    },
    components: {
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
    .we-btn {
      padding-left: 30px;
      padding-right: 30px;
      line-height: 80px;
      font-size: 32px;
      border-radius: 10px;
    }
    .we-btn-pay {
      float: left;
      /* Rectangle 6: */
      position: static;
      margin-right: 30px;
      background-image: linear-gradient(-94deg, #FE9270 0%, #F26032 100%);
      color: $primary-white;
    }
    .we-btn-default {
      float: left;
      position: static;
      margin-right: 30px;
      color: $primary-black;
      border: 1px solid #9B9B9B;
      background-color: transparent;
    }
  }
  .we-order-menu-list {
    padding: 0 20px;
  }
</style>

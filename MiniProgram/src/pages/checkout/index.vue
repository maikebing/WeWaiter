<template>
  <div class="container">
    <!--<order-status :status="order.currentStatus"></order-status>-->
    <table-number :table-number="order.tableNumber" :status="order.currentStatus"></table-number>
    <div class="we-order-menu-list" style="margin-top: 20rpx">
      <menu-list :menu-list="selectedFoods" :total="total"></menu-list>
    </div>
    <div class="we-button-fixed-bottom" @click="toPay()">
      微信支付 ￥{{total}}
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
        selectedFoods: [],
      }
    },
    computed:{
      total: function() {
        return this.selectedFoods.reduce((acc, current) => acc += current.price, 0)
      }
    },
    components: {
      TableNumber,
      OrderStatus,
      MenuList
    },
    methods: {
      getOrderData (id) {
        return orderList.find((order) => String(order.id) === id)
      },
      toPay () {
        console.log('toPay@40 ==========> 提交订单，服务器端生成订单之后，给前端返回微信支付信息')
        let params = {
          timeStamp: '',
          nonceStr: '',
          package: '',
          signType: 'MD5',
          paySign: '',
        }
        wx.showToast({
          title: '正在生成订单',
          icon: 'loading',
          duration: 1000
        })
        wx.requestPayment({
          ...params,
          success(res) {
            console.log('success@19')
          },
          fail(res) {
          }
        })
        setTimeout(()=>{
          wx.navigateTo({url: '/pages/order-detail/main?id=2'})
        }, 1000)
      }
    },
    created () {
      let selectedFoods = wx.getStorageSync('selectFoods')
      console.log('created@50', selectedFoods)
      this.selectedFoods = selectedFoods
    },
    onLoad (options) {
    }
  }
</script>
<style lang="scss" scoped>
  @import "~@/styles/variable";

  .we-button-fixed-bottom {
    /* Rectangle: */
    background: #13CE66;
    font-size: 36px;
    text-align: center;
    color: white;
    height: 110px;
    line-height: 110px;
    position: fixed;
    bottom: 0;
    width: 100%;
  }

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

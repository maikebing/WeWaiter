<template>
  <div class="container">
    <!--<order-status :status="order.currentStatus"></order-status>-->
    <table-number :seller="seller"></table-number>
    <div class="we-order-menu-list">
      <menu-list :menu-list="selectFoods" :total="total"></menu-list>
    </div>
    <div class="we-dining-details-box">
    <dining-details
      :dining-details-list="diningDetailsList"
      @select-meal-style="onSelectMealStyle"
      @select-tableware="onSelectTableWare"></dining-details>
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
  import DiningDetails from '@/components/diningdetails/diningdetails'
  import MenuList from '@/components/MealMenuList'
  export default {
    data () {
      return {
        order: {},
        selectFoods: [],
        // 餐具数量id
        tableWareId: '',
        // 用餐方式
        mealStyleId: '',
        seller: {
          avatar: ''
        },
        index: 0,
        diningDetailsList: [
          {
            id: '',
            name: ''
          }
        ]
      }
    },
    computed: {
      total: function () {
        return this.selectFoods.reduce((acc, current) => acc += current.price * current.count, 0)
      }
    },
    components: {
      TableNumber,
      OrderStatus,
      MenuList,
      DiningDetails
    },
    methods: {
      bindPickerChange: function (e) {
        console.log('picker发送选择改变，携带值为', e.detail)
      },
      onSelectMealStyle (value) {
        console.warn('发生用餐方式选择事件', value)
        this.mealStyleId = value
      },
      onSelectTableWare (value) {
        console.warn('发生餐具选择事件', value)
        this.tableWareId = value
      },
      async getData (id) {
        console.log('getData@37', id)
        let orderRes = await this.$http.get(`order/${id}`)
        this.seller = orderRes.data.seller
        this.order = orderRes.data
        this.selectFoods = orderRes.data.foods
      },
      async getDiningDetailsListData () {
        let diningDetailsListRes = await this.$http.get('diningdeails')
        this.diningDetailsList = diningDetailsListRes.data
      },
      async toPay () {
        wx.showLoading({
          title: '订单创建中'
        })
        // let orderParams = {
        //   codeid: 'ww12354325431',
        //   openid: 'wx12314351432',
        //   foods: this.selectFoods,
        //   tableWareId: this.tableWareId,
        //   mealStyleId: this.mealStyleId
        // }
        let buyItems = this.selectFoods.map(x=>({amount:x.count, goodsID: x.id}))
        let orderParams = {
          seatID: '342c501a-3365-4c2f-816f-2aaf51ea7a31',
          userID: '342c501a-3365-4c2f-816f-2aaf51ea7a39',
          buyItems,
          sellerID: '342c501a-3365-4c2f-816f-2aaf51ea7a39',
          tableWareId: this.tableWareId,
          mealStyleId: this.mealStyleId
        }
        let orderRes = await this.$http.post('orders', orderParams)
        console.log('toPay@44', orderRes)
        wx.hideLoading()

        // let payRes = await this.$http.get(`pay/${orderRes.orderID}/`)
        // wx.requestPayment({
        //   ...payRes.data,
        //   success(res) {
        //     console.log('success@19')
        //   },
        //   fail(res) {
        //   }
        // })
        wx.redirectTo({url: `/pages/order-detail/main?id=${orderRes.orderID}`})
      }
    },
    onLoad (options) {
      console.log('onLoad@85', options)
      if (options.order_id) {
        this.getData(options.order_id)
      } else {
        this.selectFoods = wx.getStorageSync('selectFoods')
        this.seller = wx.getStorageSync('seller')
      }
      this.getDiningDetailsListData()
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
    margin-top: 20px;
  }
  .we-dining-details-box {
    padding: 0 20px;
    margin-top: 20px;
  }
</style>

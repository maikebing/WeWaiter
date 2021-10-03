<template>
  <div>
    <div
      class="we-btn we-btn-default"
      v-if="order.orderStatus === 1"
      @click="onOneMoreOrder(order.orderID)"
    >
      再来一单
    </div>
    <!--<div-->
    <!--class="we-btn we-btn-default"-->
    <!--v-if=" order.status &&  order.status.code === 0"-->
    <!--@click="onOrderDishes(order.id)">加菜-->
    <!--</div>-->
    <div
      class="we-btn we-btn-pay"
      v-if="order.orderStatus === 0"
      @click="onPay(order.orderID)"
    >
      立即支付
    </div>
  </div>
</template>
<script>
export default {
  name: 'order-action',
  props: {
    order: {
      type: Object
    }
  },
  methods: {
    onRedirectToDetail(id) {
      wx.navigateTo({
        url: `../order-detail/main?id=${id}`
      })
    },
    async onPay(id) {
      let self = this
      wx.showLoading({
        title: '正在加载'
      })
      let payRes = await this.$http.get(`TenPayV3/JsApi/${id}/`)
      wx.requestPayment({
        timeStamp: payRes.data.timeStamp,
        nonceStr: payRes.data.nonceStr,
        package: payRes.data.package,
        signType: 'MD5',
        paySign: payRes.data.paySign,
        success: function (res) {
          // success
          console.log(res)
          // wx.navigateTo({url: `/pages/order-detail/main?id=${id}`});
          self.$emit('pay-success')
        },
        fail: function (res) {
          // fail
          console.log(res)
          wx.showLoading({
            title: res
          })
        },
        complete: function (res) {
          // complete
          console.log(res)
          wx.hideLoading()
        }
      })
    },
    onOrderDishes(id) {
      wx.navigateTo({
        url: `../goods/main?order_id=${id}`
      })
    },
    onOneMoreOrder(id) {
      wx.navigateTo({
        url: `../checkout/main?order_id=${id}`
      })
    }
  }
}
</script>
<style lang="scss" scoped>
@import '../styles/variable';

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
    background-image: linear-gradient(-94deg, #fe9270 0%, #f26032 100%);
    color: $primary-white;
  }
  .we-btn-default {
    float: left;
    position: static;
    margin-right: 30px;
    color: $primary-black;
    border: 1px solid #9b9b9b;
    background-color: transparent;
  }
}
</style>

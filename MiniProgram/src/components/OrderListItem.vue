
<!--公用组件：订单列表项
      /**
      * @desc 订单列表项
      * @param {array} [order]    - id, 状态, 菜单列表, 金额
      * @example 调用示例
      *  <order-item :order="order""></order-item>
      **/
-->
<template>
  <div>
    <div class="we-box">
      <div
        class="we-order-status"
        @click="onRedirectToDetail(order.order.orderID)"
      >
        <div class="we-icon-box">
          <img :src="imgHost + order.seller.avatar" class="we-icon" />
        </div>
        <div class="we-des">
          <text class="we-des-name">{{ order.seller.name }}</text>
          <text :class="['we-order-status', 'status-' + status]">{{
            statusText
          }}</text>
        </div>
      </div>
      <div class="we-order-des" @click="onRedirectToDetail">
        <text
          >{{ order.buyItems[0].goodsName }} 等
          {{ order.buyItems.length }} 份美食</text
        >
        <div class="we-pay">
          <text>共计</text>
          <text class="we-sum">¥ {{ order.order.totalPrice }}</text>
        </div>
      </div>
      <div class="we-btn-group">
        <order-action
          :order="order.order"
          @pay-success="payOnSuccess"
        ></order-action>
      </div>
    </div>
  </div>
</template>

<script>
import OrderAction from '@/components/OrderAction'
export default {
  components: { OrderAction },
  props: ['order'],
  data() {
    return {
      imgHost: this.$ossUrl
    }
  },
  methods: {
    onRedirectToDetail() {
      wx.navigateTo({
        url: `../order-detail/main?id=${this.order.order.orderID}`
      })
    },
    onPay(id) {
      wx.navigateTo({
        url: `../order/main?id=${id}`
      })
    },
    onOrderDishes(id) {
      wx.navigateTo({
        url: `../meal/main?id=${id}`
      })
    },
    onOneMoreOrder() {
      wx.navigateTo({
        url: '../meal/main'
      })
    },
    payOnSuccess() {
      this.$emit('pay-success')
    }
  },
  computed: {
    total: function () {
      return this.order.buyItems.reduce(function (acc, current) {
        return (acc += current.total)
      }, 0)
    },
    status: function () {
      let status = this.order.order['orderStatus']
      switch (status) {
        case 0:
          return 'unpaid'
        case 1:
          return 'paid'
        case 2:
          return 'completed'
        case 3:
          return 'undone'
        case 4:
          return 'refunded'
      }
    },
    statusText: function () {
      let status = this.order.order['orderStatus']
      switch (status) {
        case 0:
          return '待支付'
        case 1:
          return '已支付'
        case 2:
          return '订单已完成'
        case 3:
          return '订单已取消'
        case 4:
          return '退款成功'
      }
    }
  },
  created() {}
}
</script>

<style lang="scss">
@import '~@/styles/variable';

.status-unpaid {
  color: #ed5933;
}

.status-paid {
  color: $primary-green;
}

.status-completed {
  color: $primary-bright-gray;
}

.status-undone {
  color: $primary-bright-gray;
}

.status-refunded {
  color: $primary-blue;
}

.we-box {
  padding: 29rpx 0 37rpx 26rpx;
  /* Line 5: */
  border-top: 1rpx solid #d3d3d3;
  border-left-width: 0;
  border-right-width: 0;
  overflow: hidden;
  .we-order-status {
    display: flex;
    justify-content: space-between;
    .we-icon-box {
      width: 104rpx;
      height: 104rpx;
      display: flex;
      align-items: center;
      justify-content: center;
      .we-icon {
        /* Rectangle 9: */
        width: 104rpx;
        height: 104rpx;
      }
    }
    .we-des {
      width: 540rpx;
      height: 109rpx;
      line-height: 88rpx;
      padding-right: 26rpx;
      border-bottom: 1rpx solid #d3d3d3;
      display: flex;
      justify-content: space-between;
      .we-des-name {
        /* 一家人美味饭庄: */
        display: block;
        font-size: 36rpx;
        color: $primary-bright-gray;
        font-weight: bold;
        letter-spacing: -0.3rpx;
      }
      .we-order-status {
        /* 待支付: */
        font-size: 36rpx;
      }
    }
  }
  .we-order-des {
    display: flex;
    justify-content: flex-end;
    align-items: center;
    padding-right: 26rpx;
    margin-top: 32rpx;
    line-height: 50rpx;
    font-size: 28rpx;
    color: $primary-bright-gray;
    letter-spacing: -0.23rpx;
    .we-pay {
      display: flex;
      align-items: center;
      justify-content: flex-end;
      margin-left: 114rpx;
      .we-sum {
        margin-left: 20rpx;
        font-size: 36rpx;
        font-weight: bold;
      }
    }
  }
  .we-btn-group {
    padding-right: 26rpx;
    margin-top: 30rpx;
    font-size: 32rpx;
    overflow: hidden;
    .we-btn {
      padding-left: 30rpx;
      padding-right: 30rpx;
      line-height: 80rpx;
      font-size: 32rpx;
      border-radius: 10rpx;
    }
    .we-btn-pay {
      float: right;
      /* Rectangle 6: */
      position: static;
      margin-left: 30rpx;
      background-image: linear-gradient(-94deg, #fe9270 0%, #f26032 100%);
      color: $primary-white;
    }
    .we-btn-default {
      float: right;
      position: static;
      margin-left: 30rpx;
      color: $primary-black;
      border: 1rpx solid #9b9b9b;
      background-color: transparent;
    }
  }
}
</style>

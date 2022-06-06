<!--公用组件：订单状态
      /**
      * @desc 订单状态
      * @param {number} [status]    - 状态
      * @example 调用示例
      *  <order-status :status="status"></order-status>
      **/
-->
<template>
  <div>
    <div class="we-container">
      <div class="we-status-box">
        <div :class="['we-status-text', status === 1 ? 'status-paid' : '']">
          {{ statusText }}
        </div>
        <div class="we-status-des">
          <block v-if="status === 1">
            <text>餐厅开始制作您的美食， 请耐心等待</text>
          </block>
          <block v-if="status === 0">
            <text>5分钟内未完成支付，超时自动取消订单</text>
            <text class="we-countdown">{{ countDownValue }}</text>
          </block>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: ['status'],
  data() {
    return {
      time: 5,
      countDownValue: '5:00'
    }
  },
  methods: {
    countDown(second) {
      const s = second % 60
      const m = Math.floor(second / 60)
      return `${`${m}`.slice(-2)}:${`00${s}`.slice(-2)}`
    }
  },
  computed: {
    statusText: function () {
      switch (this.status) {
        case 0:
          return '等待支付'
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
  created() {
    let time = this.time * 60 - 1
    const timer = setInterval(() => {
      this.countDownValue = this.countDown(time--)
      if (time < 0) {
        console.log('倒计时结束！')
        clearInterval(timer)
      }
    }, 1000)
  }
}
</script>

<style lang="scss">
@import '~@/styles/variable';
.status-paid {
  border-bottom-color: $primary-green !important;
}

.we-status-box {
  width: 100%;
  height: 104rpx;
  display: flex;
  margin-top: 8rpx;
  background-color: $primary-dark-gray;
  color: $primary-white;
  .we-status-text {
    height: 0;
    width: 268rpx;
    margin-top: -8rpx;
    font-size: 42rpx;
    line-height: 126rpx;
    padding-left: 32rpx;
    border-bottom: 115rpx solid $primary-grey;
    border-right: 35rpx solid transparent;
  }
  .we-status-des {
    display: flex;
    align-items: center;
    padding: 20rpx 30rpx;
    font-size: 24rpx;
    .we-countdown {
      margin-left: 42rpx;
      font-size: 49rpx;
      color: $primary-white;
    }
  }
}
</style>

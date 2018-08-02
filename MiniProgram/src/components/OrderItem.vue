<!--公用组件：桌号
      /**
      * @desc 点餐桌号
      * @param {number} [tableNumber]    - 桌号
      * @example 调用示例
      *  <table-number :table-number="tableNumber""></table-number>
      **/
-->
<template>
  <div>
    <div class="we-box">
      <div class="we-order-status">
        <div class="we-icon-box">
          <img src="/static/images/icon-logo.svg" class="we-icon"/>
        </div>
        <div class="we-des">
          <text class="we-des-name">一家人美味饭馆</text>
          <text :class="['we-order-status', 'status-' + order.currentStatus]">{{ status }}</text>
        </div>
      </div>
      <div class="we-order-des">
        <text>{{ order.menuList[0] }} 等 {{ order.menuList.length}} 份美食</text>
        <div class="we-pay">
          <text>共计</text>
          <text class="we-sum">¥ {{ order.consumption }}</text>
        </div>
      </div>
      <div class="we-btn-group">
        <button class="we-btn-pay">立即支付</button>
        <button class="we-btn-default">加菜</button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    props: ['order'],
    data () {
      return {}
    },
    methods: {},
    computed: {
      status: function () {
        switch (this.order.currentStatus) {
          case 'unpaid':
            return '待支付'
          case 'paid':
            return '已支付'
          case 'completed':
            return '订单已完成'
          case 'undone':
            return '订单已取消'
          case 'refunded':
            return '退款成功'
        }
      }
    },
    created () {
    }
  }
</script>

<style lang="scss">
  @import "~@/styles/variable";

  .status-unpaid {
    color: #ED5933;
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
    padding: 29px 0 37px 26px;
    /* Line 5: */
    border-top: 1px solid #D3D3D3;
    border-left-width: 0;
    border-right-width: 0;
    overflow: hidden;
    .we-order-status {
      display: flex;
      justify-content: space-between;
      .we-icon-box {
        width: 104px;
        height: 104px;
        display: flex;
        align-items: center;
        justify-content: center;
        border: 1px solid #E7E7E7;
        border-radius: 12px;
        .we-icon {
          /* Rectangle 9: */
          width: 65px;
          height: 72px;
        }
      }
      .we-des {
        width: 540px;
        height: 109px;
        line-height: 88px;
        padding-right: 26px;
        border-bottom: 1px solid #D3D3D3;
        display: flex;
        justify-content: space-between;
        .we-des-name {
          /* 一家人美味饭庄: */
          display: block;
          font-size: 36px;
          color: $primary-bright-gray;
          font-weight: bold;
          letter-spacing: -0.3px;
        }
        .we-order-status {
          /* 待支付: */
          font-size: 36px;
        }
      }
    }
    .we-order-des {
      display: flex;
      justify-content: flex-end;
      align-items: center;
      padding-right: 26px;
      margin-top: 32px;
      line-height: 50px;
      font-size: 28px;
      color: $primary-bright-gray;
      letter-spacing: -0.23px;
      .we-pay {
        display: flex;
        align-items: center;
        justify-content: flex-end;
        margin-left: 114px;
        .we-sum {
          margin-left: 12px;
          font-size: 36px;
          font-weight: bold;
        }
      }
    }
    .we-btn-group {
      padding-right: 26px;
      margin-top: 30px;
      font-size: 32px;
      overflow: hidden;
      button::after{
        border: none;
      }
      button {
        line-height: 80px;
      }
      .we-btn-pay {
        float: right;
        /* Rectangle 6: */
        position: static;
        margin-left: 30px;
        background-image: linear-gradient(-94deg, #FE9270 0%, #F26032 100%);
        color: $primary-white;
      }
      .we-btn-default {
        float: right;
        position: static;
        margin-left: 30px;
        color: $primary-black;
        border: 1px solid #9B9B9B;
        background-color: transparent;
      }
    }
  }
</style>

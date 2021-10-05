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
    <div :class="['we-table-box', status === 1 ? 'status-paid-box' : '']">
      <div class="we-restaurant-des">
        <div class="we-icon-box">
          <img :src="imgHost + seller.avatar" class="we-icon" />
        </div>
        <div class="we-table-des">
          <text class="we-table-des-name">{{ seller.name }}</text>
          <text class="we-table-des-info">{{ seller.description }}</text>
        </div>
      </div>
      <div class="we-table-number-box">
        <div class="we-text-box">
          <text class="we-identifier">#</text>
          <text class="we-identifier">号桌</text>
        </div>
        <div>{{ tableNumber }}</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: ['status', 'seller'],
  data() {
    return {
      imgHost: this.$ossUrl
    }
  },
  methods: {},
  computed: {
    tableNumber() {
      return this.$store.state.seatId
    }
  }
}
</script>

<style lang="scss">
@import '~@/styles/variable';

.status-paid-box {
  background-color: $primary-green !important;
}

.we-table-box {
  padding: 30rpx;
  display: flex;
  justify-content: space-between;
  background-color: $primary-grey;
  color: $primary-white;
  .we-restaurant-des {
    display: flex;
    .we-icon-box {
      width: 120rpx;
      height: 120rpx;
      display: flex;
      align-items: center;
      justify-content: center;
      background: $primary-white;
      border-radius: 12rpx;
      .we-icon {
        /* Rectangle 9: */
        width: 120rpx;
        height: 120rpx;
      }
    }
    .we-table-des {
      max-width: 370rpx;
      margin-left: 22rpx;
      .we-table-des-name {
        /* 一家人美味饭庄: */
        display: block;
        font-weight: 400;
        font-size: 36rpx;
        line-height: 42rpx;
        letter-spacing: -0.3rpx;
      }
      .we-table-des-info {
        /* 餐厅描述: */
        width: 100%;
        overflow: hidden;
        display: -webkit-box;
        -webkit-line-clamp: 2;
        -webkit-box-orient: vertical;
        text-overflow: ellipsis;
        margin-top: 8rpx;
        font-size: 25rpx;
        line-height: 35rpx;
        color: #9a9a9a;
        letter-spacing: -0.2rpx;
      }
    }
  }
  .we-table-number-box {
    /* 23: */
    display: flex;
    align-items: center;
    font-size: 77rpx;
    color: $primary-white;
    letter-spacing: -1.2rpx;
    font-weight: 400;
    .we-text-box {
      display: flex;
      align-items: flex-end;
      flex-direction: column;
      justify-content: center;
      margin-right: 11rpx;
      font-weight: normal;
    }
    .we-identifier {
      /* #: */
      line-height: 30rpx;
      opacity: 0.56;
      font-size: 29rpx;
      color: $primary-white;
      letter-spacing: -0.3rpx;
    }
  }
}
</style>

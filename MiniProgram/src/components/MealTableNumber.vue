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
          <img :src="seller.avatar" class="we-icon"/>
        </div>
        <div class="we-table-des">
          <text class="we-table-des-name">{{seller.name}}</text>
          <text class="we-table-des-info">{{seller.description}}</text>
        </div>
      </div>
      <div class="we-table-number-box">
        <div class="we-text-box">
          <text class="we-identifier">#</text>
          <text class="we-identifier">桌号</text>
        </div>
        <div>{{ seller.table_number }}</div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    props: ['tableNumber', 'status', 'seller'],
    data () {
      return {}
    },
    methods: {},
    computed: {}
  }
</script>

<style lang="scss">
  @import "~@/styles/variable";

  .status-paid-box {
    background-color: $primary-green!important;
  }

  .we-table-box {
    padding: 30px;
    display: flex;
    justify-content: space-between;
    background-color: $primary-grey;
    color: $primary-white;
    .we-restaurant-des {
      display: flex;
      .we-icon-box {
        width: 120px;
        height: 120px;
        display: flex;
        align-items: center;
        justify-content: center;
        background: $primary-white;
        border-radius: 12px;
        .we-icon {
          /* Rectangle 9: */
          width: 120px;
          height: 120px;
        }
      }
      .we-table-des {
        max-width: 370px;
        margin-left: 22px;
        .we-table-des-name {
          /* 一家人美味饭庄: */
          display: block;
          font-weight: 400;
          font-size: 36px;
          line-height: 42px;
          letter-spacing: -0.3px;
        }
        .we-table-des-info {
          /* 餐厅描述: */
          width: 100%;
          overflow: hidden;
          display: -webkit-box;
          -webkit-line-clamp: 2;
          -webkit-box-orient: vertical;
          text-overflow: ellipsis;
          margin-top: 8px;
          font-size: 25px;
          line-height: 35px;
          color: #9A9A9A;
          letter-spacing: -0.2px;
        }
      }
    }
    .we-table-number-box {
      /* 23: */
      display: flex;
      align-items: center;
      font-size: 77px;
      color: $primary-white;
      letter-spacing: -1.2px;
      font-weight: 400;
      .we-text-box {
        display: flex;
        align-items: flex-end;
        flex-direction: column;
        justify-content: center;
        margin-right: 11px;
        font-weight: normal;
      }
      .we-identifier {
        /* #: */
        line-height: 30px;
        opacity: 0.56;
        font-size: 29px;
        color: $primary-white;
        letter-spacing: -0.3px;
      }
    }
  }
</style>

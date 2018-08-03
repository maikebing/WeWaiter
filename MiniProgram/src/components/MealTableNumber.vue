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
    <div class="we-table-box">
      <div class="we-restaurant-des">
        <div class="we-icon-box">
          <img src="/static/images/icon-logo.svg" class="we-icon"/>
        </div>
        <div class="we-table-des">
          <text class="we-des-name">一家人美味饭馆</text>
          <text class="we-des-info">餐厅描述</text>
        </div>
      </div>
      <div class="we-table-number-box">
        <div class="we-text-box">
          <text class="we-identifier">#</text>
          <text class="we-identifier">桌号</text>
        </div>
        <div>{{ tableNumber }}</div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    props: ['tableNumber']
  }
</script>

<style lang="scss">
  @import "~@/styles/variable";

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
          width: 65px;
          height: 72px;
        }
      }
      .we-table-des {
        margin-left: 22px;
        .we-des-name {
          /* 一家人美味饭庄: */
          display: block;
          font-size: 36px;
          letter-spacing: -0.3px;
        }
        .we-des-info {
          /* 餐厅描述: */
          display: block;
          margin-top: 7px;
          font-size: 25px;
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
      .we-text-box {
        display: flex;
        align-items: flex-end;
        flex-direction: column;
        justify-content: center;
        margin-right: 11px;
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

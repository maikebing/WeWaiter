<!--公用组件：菜单列表项
      /**
      * @desc 菜单列表
      * @param {array} [menu]    - 菜单列表
      * @example 调用示例
      *  <menu-item :menu="menu""></menu-item>
      **/
-->
<template>
  <div>
    <div class="we-menu-item-box">
      <div class="we-menu-graphic">
        <img :src="menu.iconUrl"/>
        {{menu.name}}
      </div>
      <div class="we-menu-other">
        <!--<text class="we-menu-norm">{{norm}}份</text>-->
        <text class="we-menu-norm">x {{menu.amount}}</text>
        <text class="we-menu-price">￥ {{menu.price}}</text>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    props: ['menu'],
    data () {
      return {}
    },
    methods: {},
    computed: {
      norm: function () {
        switch (this.menu.norm) {
          case 'large':
            return '大'
          case 'middle':
            return '中'
          case 'small':
            return '小'
        }
      }
    }
  }
</script>

<style lang="scss">
  @import "~@/styles/variable";

  .we-menu-item-box {
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 18px 3px;
    border-bottom: 1px solid $border-bottom-light;
    font-size: 32px;
    color: #1F1F21;
    .we-menu-graphic {
      display: flex;
      align-items: center;
      justify-content: space-between;
      img {
        width: 104px;
        height: 104px;
        margin-right: 24px;
      }
    }
    .we-menu-other {
      display: flex;
      align-items: center;
      justify-content: space-between;
      line-height: 104px;
      /* 大份: */
      font-size: 28px;
      color: #9B9B9B;
      .we-menu-norm {
        margin-right: 40px;
      }
      .we-menu-price {
        /* ￥18: */
        font-size: 36px;
        color: #1F1F21;
      }
    }
  }
</style>

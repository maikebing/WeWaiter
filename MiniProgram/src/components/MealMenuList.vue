<!--公用组件：菜单列表
      /**
      * @desc 菜单列表
      * @param {array} [menuList]    - 菜单列表
      * @example 调用示例
      *  <menu-list :menu-list="menuList" :toatal="total"></menu-list>
      **/
-->
<template>
  <div>
    <div class="we-menu-list-box">
      <block v-for="menu in menuList" :key="menu.id">
        <menu-item :menu="menu"></menu-item>
      </block>
    </div>
    <div class="we-menu-consumption-total">
      <text>小计</text><text class="total">￥ {{ total }}</text>
    </div>
  </div>
</template>

<script>
  import MenuItem from '@/components/MealMenuListItem'
  export default {
    props: ['menuList', 'total'],
    data () {
      return {
      }
    },
    components: {
      MenuItem
    },
    methods: {},
    created () {}
  }
</script>

<style lang="scss">
  @import "~@/styles/variable";

  .we-menu-list-box {
    background-color: $primary-white;
    padding: 30px 30px 0;
  }

  .we-menu-consumption-total {
    display: flex;
    align-items: center;
    justify-content: flex-end;
    padding: 18px 30px;
    background-color: $primary-white;
    line-height: 104px;
    text {
      /* 小计: */
      font-size: 32px;
      color: #1F1F21;
      letter-spacing: -0.27px;
    }
    .total {
      /* ￥54: */
      margin-left: 26px;
      font-weight: bold;
      font-size: 42px;
      color: #1F1F21;
    }
  }
</style>

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
      <block v-for="menu in menuList" :key="menu.buyItemID">
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
  data() {
    return {
      menuList: this.menuList
    }
  },
  components: {
    MenuItem
  },
  methods: {},
  created() {},
  mounted() {
    console.log('mounted@36', this.menuList)
  }
}
</script>

<style lang="scss">
@import '~@/styles/variable';

.we-menu-list-box {
  background-color: $primary-white;
  padding: 30rpx 30rpx 0;
}

.we-menu-consumption-total {
  display: flex;
  align-items: center;
  justify-content: flex-end;
  padding: 18rpx 30rpx;
  background-color: $primary-white;
  line-height: 104rpx;
  text {
    /* 小计: */
    font-size: 32rpx;
    color: #1f1f21;
    letter-spacing: -0.27rpx;
  }
  .total {
    /* ￥54: */
    margin-left: 26rpx;
    font-weight: bold;
    font-size: 42rpx;
    color: #1f1f21;
  }
}
</style>

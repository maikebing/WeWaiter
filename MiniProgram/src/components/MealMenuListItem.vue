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
        <img :src="imgHost + menu.icon" />
        {{ menu.name }}
      </div>
      <div class="we-menu-other">
        <!--<text class="we-menu-norm">{{norm}}份</text>-->
        <text class="we-menu-norm">x {{ menu.count }}</text>
        <text class="we-menu-price">￥ {{ menu.price }}</text>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: ['menu'],
  data() {
    return {
      imgHost: this.$ossUrl
    }
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
@import '~@/styles/variable';

.we-menu-item-box {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 18rpx 3rpx;
  border-bottom: 1rpx solid $border-bottom-light;
  font-size: 32rpx;
  color: #1f1f21;
  .we-menu-graphic {
    display: flex;
    align-items: center;
    justify-content: space-between;
    img {
      width: 104rpx;
      height: 104rpx;
      margin-right: 24rpx;
    }
  }
  .we-menu-other {
    display: flex;
    align-items: center;
    justify-content: space-between;
    line-height: 104rpx;
    /* 大份: */
    font-size: 28rpx;
    color: #9b9b9b;
    .we-menu-norm {
      margin-right: 40rpx;
    }
    .we-menu-price {
      /* ￥18: */
      font-size: 36rpx;
      color: #1f1f21;
    }
  }
}
</style>

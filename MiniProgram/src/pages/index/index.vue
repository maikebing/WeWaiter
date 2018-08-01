<template>
  <div class="container">
    <div class="we-img-box">
      <image src="../../../static/images/background.png"></image>
    </div>
    <div class="we-des">
      <text class="title">扫码一下 自助点餐</text>
      <text>自由 随心 的电子菜单</text>
    </div>
  </div>
</template>
<script>
  export default {
    data () {
      return {}
    },
    components: {
    },
    methods: {
    },
    created () {}
  }
</script>
<style lang="scss">
  @import "~@/styles/variable";
  .we-img-box {
    width: 100%;
    margin-top: 30rpx;
    image {
      width: 100%;
    }
  }
  .we-des {
    width: 100%;
    margin: 89rpx auto;
    text-align: center;
    .title {
      /* 扫码一下 自助点餐: */
      display: block;
      font-size: 49rpx;
      color: $primary-black;
      letter-spacing: 0;
    }
  }
</style>

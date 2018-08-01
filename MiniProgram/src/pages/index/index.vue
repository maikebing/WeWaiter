<template>
  <div class="container">
    <div class="we-img-box">
      <img src="../../../static/images/background.png"/>
    </div>
    <div class="we-des">
      <text class="title">扫码一下 自助点餐</text>
      <text class="subtitle">自由 随心 的电子菜单</text>
    </div>
    <button class="btn-scan">
      <img src="../../../static/images/icon-scan-code.svg" class="icon"/>
      <text>开始点餐</text>
    </button>
  </div>
</template>
<script>
  export default {
    data () {
      return {}
    },
    components: {},
    methods: {},
    created () {
    }
  }
</script>
<style lang="scss">
  @import "~@/styles/variable";

  .we-img-box {
    width: 100%;
    margin-top: 15px;
    image {
      width: 100%;
    }
  }

  .we-des {
    width: 100%;
    margin: 45px auto;
    text-align: center;
    .title {
      /* 扫码一下 自助点餐: */
      display: block;
      font-size: 25px;
      color: $primary-black;
      letter-spacing: 0;
    }
    .subtitle {
      /* 自由 随心 的电子菜单: */
      display: block;
      margin-top: 5px;
      font-size: 18px;
      color: #9A9A9A;
      letter-spacing: 2.3px;
    }
  }

  .btn-scan {
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 3px 53px;
    /* Rectangle 6: */
    background-image: linear-gradient(-90deg, #FE9270 0%, #F26032 100%);
    border-radius: 6px;
    text {
      /* 开始点餐: */
      font-size: 24px;
      color: $primary-white;
    }
    .icon {
      display: block;
      width: 24px;
      height: 24px;
      margin-right: 15px;
      line-height: 33px;
    }
  }
</style>

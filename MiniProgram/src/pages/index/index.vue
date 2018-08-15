<template>
  <div class="container">
    <div class="we-img-box">
      <img src="/static/images/background.png"/>
    </div>
    <div class="we-des">
      <text class="title">扫码一下 自助点餐</text>
      <text class="subtitle">自由 随心 的电子菜单</text>
    </div>
    <button class="btn-scan" @click="onHandleScan">
      <img src="/static/images/icon-scan-code.svg" class="icon"/>
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
    methods: {
      onHandleScan () {
        wx.navigateTo({
          url: '../goods/main?id=1'
        })
      }
    },
    created () {
    }
  }
</script>
<style lang="scss">
  @import "~@/styles/variable";

  page {
    background-color: $primary-white!important;
    .container {
      background-color: $primary-white;
      padding-bottom: 80px;
    }
    .we-img-box {
      width: 100%;
      /*margin-top: 20px;*/
      image {
        width: 100%;
        height: 559px;
      }
    }

    .we-des {
      width: 100%;
      margin: 40px auto;
      text-align: center;
      .title {
        /* 扫码一下 自助点餐: */
        display: block;
        font-size: 49px;
        color: $primary-black;
        letter-spacing: 0;
        font-weight: bold;
      }
      .subtitle {
        /* 自由 随心 的电子菜单: */
        display: block;
        margin-top: 10px;
        font-size: 36px;
        color: #9A9A9A;
        letter-spacing: 4.6px;
      }
    }

    .btn-scan {
      display: flex;
      align-items: center;
      justify-content: center;
      line-height: 123px;
      padding-left: 106px;
      padding-right: 106px;
      font-size: 48px;
      /* Rectangle 6: */
      background-image: linear-gradient(-90deg, #FE9270 0%, #F26032 100%);
      border-radius: 12px;
      text {
        /* 开始点餐: */
        color: $primary-white;
      }
      .icon {
        display: block;
        width: 48px;
        height: 48px;
        margin-right: 30px;
        line-height: 67px;
      }
    }
  }
</style>

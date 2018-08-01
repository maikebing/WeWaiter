<template>
  <view class="user-card">
    <view class="avatar-wrapper">
      <image src="/static/images/user-avatar.png"></image>
    </view>
    <view class="detail">
      <view class="z-row">
        <view class="name">漩涡鸣人</view>
        <!--<view class="border">档次:123</view>-->
      </view>
      <view class="z-row">手机号：13999564234</view>
    </view>
  </view>
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
<style lang="scss" scoped>
  @import "~@/styles/variable";
  .user-card {
    display: flex;
    /* Mask: */
    background-image: linear-gradient(-90deg, #FE9270 1%, #F26032 100%);
    padding: 60px;
  }
  .detail {
    color: white;
    font-size: 28px;
    margin-left: 60px;
  }
  .name {
    font-size: 42px;
    margin-right: 10px;
    font-weight: bold;
  }
  .z-row {
    display: flex;
    align-items: center;
    flex-wrap: wrap;
    font-size: 32px;
  }
  .border {
    border: 1px solid white;
    padding-left: 8px;
    padding-right: 8px;
    height: 44px;
    border-radius: 8px;
  }
  cell-flat {
    width: 100%
  }

  .avatar-wrapper {
    width: 120px;
    height: 120px;
    flex-shrink: 0;
  }
  .avatar-wrapper image{
    width: 100%;
    height: 100%;
    border-radius: 100%;
    border: 8px solid white;
  }

  .z-button {
    height: 100px;
    /* 立即付款: */
    font-size: 36px;
    color: #FFFFFF;
    letter-spacing: 0.54px;
    background: $primary-color;
    border-radius: 12px;
    width: 100%;
    text-align: center;
    line-height: 100px;
  }
  .blank .avatar-wrapper image{
    border: 0
  }

  .blank .detail {
    display: flex;
    flex-grow: 1;
    align-items: center;
  }

</style>

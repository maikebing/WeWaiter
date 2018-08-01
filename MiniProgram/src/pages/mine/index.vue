<template>
  <view class="user-card">
    <view class="avatar-wrapper">
      <image src="../../images/user-avatar.png"></image>

    </view>
    <view class="detail">
      <view class="z-row">
        <view class="name">kkkkkkkkkkk</view>
        <view class="border">档次:123</view>
      </view>
      <view class="z-row">手机号：6502</view>
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
<style>


  .user-card {
    display: flex;
    background-color: #CF0C0C;
    padding: 30rpx;
  }
  .detail {
    color: white;
    font-size: 28rpx;
    margin-left: 60rpx;
  }
  .name {
    font-size: 42rpx;
    margin-right: 10rpx;
  }
  .z-row {
    display: flex;
    align-items: center;
    flex-wrap: wrap;
  }
  .border {
    border: 1px solid white;
    padding-left: 8rpx;
    padding-right: 8rpx;
    height: 44rpx;
    border-radius: 8rpx;
  }
  cell-flat {
    width: 100%
  }

  .avatar-wrapper {
    width: 120rpx;
    height: 120rpx;
    flex-shrink: 0;
  }
  .avatar-wrapper image{
    width: 100%;
    height: 100%;
    border-radius: 100%;
    border: 8rpx solid white;
  }

  .z-button {
    height: 100rpx;
    /* 立即付款: */
    font-size: 36rpx;
    color: #FFFFFF;
    letter-spacing: 0.54rpx;
    background: #CF0C0C;
    border-radius: 12rpx;
    width: 100%;
    text-align: center;
    line-height: 100rpx;
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

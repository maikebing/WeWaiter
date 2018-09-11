<template>
  <view class="user-card">
    <view class="avatar-wrapper">
      <image :src="user.avatarUrl"></image>
    </view>
    <view class="detail">
      <view class="z-row">
        <view class="name">{{user.nickName}}</view>
        <!--<view class="border">档次:123</view>-->
      </view>
      <!--<view class="z-row">手机号：13999564234</view>-->
    </view>
  </view>
</template>
<script>
  export default {
    data () {
      return {
        user: {
          nickName: '',
          avatarUrl: ''
        }
      }
    },
    components: {
    },
    methods: {
      getUserData () {
        let user = wx.getStorageSync('user')
        if (user) {
          this.user = user.wechat
        }
      }
    },
    onShow () {
      this.getUserData()
    },
    created () {}
  }
</script>
<style lang="scss" scoped>
  @import "~@/styles/variable";
  .user-card {
    display: flex;
    flex-direction: column;
    align-items: center;
    /* Mask: */
    background-image: linear-gradient(-90deg, #FE9270 1%, #F26032 100%);
    padding: 60px;
  }
  .detail {
    margin-top: 20px;
    color: white;
    font-size: 28px;
  }
  .name {
    font-size: 34px;
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
    width: 145px;
    height: 145px;
    border-radius: 100%;
    border: 8px solid white;
    overflow: hidden;
    flex-shrink: 0;
  }
  .avatar-wrapper image{
    width: 100%;
    height: 100%;
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

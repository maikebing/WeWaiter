<template>
  <view class="user-card">
    <view class="avatar-wrapper">
      <!--<image :src="user.avatarUrl"></image>-->
      <open-data type="userAvatarUrl"></open-data>
    </view>
    <view class="detail">
      <view class="z-row">
        <!--<view class="name">{{user.nickName}}</view>-->
        <open-data type="userNickName"></open-data>
        <!--<view class="border">档次:123</view>-->
      </view>
      <!--<view class="z-row">手机号：13999564234</view>-->
    </view>
  </view>
</template>
<script>
export default {
  data() {
    return {
      user: {
        nickName: '',
        avatarUrl: ''
      }
    }
  },
  components: {},
  methods: {
    getUserData() {
      let user = wx.getStorageSync('user')
      if (user) {
        this.user = user.wechat
      }
    }
  },
  onShow() {
    this.getUserData()
  },
  created() {}
}
</script>
<style lang="scss" scoped>
@import '~@/styles/variable';
.user-card {
  display: flex;
  flex-direction: column;
  align-items: center;
  /* Mask: */
  background-image: linear-gradient(-90deg, #fe9270 1%, #f26032 100%);
  padding: 60rpx;
}
.detail {
  margin-top: 20rpx;
  color: white;
  font-size: 28rpx;
}
.name {
  font-size: 34rpx;
}
.z-row {
  display: flex;
  align-items: center;
  flex-wrap: wrap;
  font-size: 32rpx;
}
.border {
  border: 1px solid white;
  padding-left: 8rpx;
  padding-right: 8rpx;
  height: 44rpx;
  border-radius: 8rpx;
}
cell-flat {
  width: 100%;
}

.avatar-wrapper {
  width: 145rpx;
  height: 145rpx;
  border-radius: 100%;
  border: 8rpx solid white;
  overflow: hidden;
  flex-shrink: 0;
}
.avatar-wrapper image {
  width: 100%;
  height: 100%;
}

.z-button {
  height: 100px;
  /* 立即付款: */
  font-size: 36rpx;
  color: #ffffff;
  letter-spacing: 0.54rpx;
  background: $primary-color;
  border-radius: 12rpx;
  width: 100%;
  text-align: center;
  line-height: 100rpx;
}
.blank .avatar-wrapper image {
  border: 0;
}

.blank .detail {
  display: flex;
  flex-grow: 1;
  align-items: center;
}
</style>

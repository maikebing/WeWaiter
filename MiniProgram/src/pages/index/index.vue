<template>
  <div class="container">
    <div class="we-img-box">
      <img src="/static/images/background.png" />
    </div>
    <div class="we-des">
      <text class="title">扫码一下 自助点餐</text>
      <text class="subtitle">自由 随心 的电子菜单</text>
    </div>
    <button
      class="btn-scan"
      open-type="getUserInfo"
      @getuserinfo="bindGetUserInfo"
    >
      <img src="/static/images/icon-scan-code.svg" class="icon" />
      <text>开始点餐</text>
    </button>
  </div>
</template>
<script>
import fly from '@/libs/fly'

export default {
  data() {
    return {
      user: {
        wechat: {}
      }
    }
  },
  components: {},
  methods: {
    bindGetUserInfo(e) {
      let self = this
      if (e.mp.detail.userInfo) {
        self.user = {
          wechat: e.mp.detail.userInfo
        }
        wx.setStorageSync('user', self.user)
        this.onHandleScanTest()
      } else {
        wx.showModal({
          title: '温馨提示',
          showCancel: true,
          content: '为了您正常使用WeWaiter码上点餐功能,请先同意授权',
          success: function (res) {
            if (res.confirm) {
              wx.openSetting({
                success: function (res) {
                  if (res.authSetting['scope.userInfo']) {
                    console.log('已授权')
                  } else {
                    console.log('未授权')
                  }
                }
              })
            } else if (res.cancel) {
              console.log('用户点击取消')
            }
          }
        })
      }
    },
    /**
     *
     * @param res 是wx.login 成功返回的 response
     */
    // 调用登录接口
    wechatLogin() {
      return new Promise((resolve, reject) => {
        wx.login({
          success(res) {
            // 发送 res.code 到后台换取 openId, sessionKey, unionId
            fly
              .post('/WeiXinApp/Login', { code: res.code })
              .then(authRes => {
                console.log('auth Res @91==========> ', authRes)
                if (authRes.token) {
                  wx.setStorageSync('token', authRes.token)
                  wx.setStorageSync('imgHost', authRes.imageHost)
                }
                resolve('token获取成功')
              })
              .catch(error => {
                console.log('@11', error)
                console.log('/WeiXinApp/Login 获取 token 失败 @166')
                reject(error)
              })
          },
          fail(error) {
            console.log('fail@157', error)
            wx.showToast({
              icon: 'none',
              title: '微信登陆失败'
            })
          }
        })
      })
    },
    onHandleScan() {
      let self = this
      wx.scanCode({
        onlyFromCamera: true,
        success: res => {
          // Get tableNumber and seatId and save them to vuex
          console.log('success@99', res)
          if (res.result) {
            let sellerId = this.getParameterByName('id', res.result)
            let seatId = this.getParameterByName('seatid', res.result)
            console.log('success@103', sellerId)
            console.log('success@103', seatId)
            self.$store.commit('SET_SEAT_ID', seatId)
            // self.$store.commit('SET_TABLE_NUMBER', result.tableNumber)
            self.$store.commit('SET_SELLER_ID', sellerId)
            // navigate to goods
            wx.navigateTo({
              url: '../goods/main?id=1'
            })
          }
        }
      })
    },
    onHandleScanTest() {
      let self = this
      self.$store.commit('SET_SEAT_ID', '1')
      // self.$store.commit('SET_TABLE_NUMBER', result.tableNumber)
      self.$store.commit('SET_SELLER_ID', 'dcef72558a124cd49f5033bdec56432a')
      // navigate to goods
      wx.navigateTo({
        url: '../goods/main?id=1'
      })
    },
    getParameterByName(name, url) {
      if (!url) url = window.location.href
      name = name.replace(/[\[\]]/g, '\\$&')
      var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url)
      if (!results) return null
      if (!results[2]) return ''
      return decodeURIComponent(results[2].replace(/\+/g, ' '))
    }
  },
  created() {
    this.wechatLogin()
  }
}
</script>
<style lang="scss">
@import '~@/styles/variable';

page {
  background-color: $primary-white !important;
  .container {
    background-color: $primary-white;
    padding-bottom: 80rpx;
  }
  .we-img-box {
    width: 100%;
    /*margin-top: 20px;*/
    image {
      width: 100%;
      height: 559rpx;
    }
  }

  .we-des {
    width: 100%;
    margin: 40px auto;
    text-align: center;
    .title {
      /* 扫码一下 自助点餐: */
      display: block;
      font-size: 49rpx;
      color: $primary-black;
      letter-spacing: 0;
      font-weight: bold;
    }
    .subtitle {
      /* 自由 随心 的电子菜单: */
      display: block;
      margin-top: 10px;
      font-size: 36rpx;
      color: #9a9a9a;
      letter-spacing: 4.6px;
    }
  }

  .btn-scan {
    display: flex;
    align-items: center;
    justify-content: center;
    line-height: 123rpx;
    padding-left: 106rpx;
    padding-right: 106rpx;
    font-size: 48rpx;
    /* Rectangle 6: */
    background-image: linear-gradient(-90deg, #fe9270 0%, #f26032 100%);
    border-radius: 12rpx;
    text {
      /* 开始点餐: */
      color: $primary-white;
    }
    .icon {
      display: block;
      width: 48rpx;
      height: 48rpx;
      margin-right: 30rpx;
      line-height: 67rpx;
    }
  }
}
</style>

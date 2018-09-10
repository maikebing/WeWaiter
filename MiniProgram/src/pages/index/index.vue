<template>
  <div class="container">
    <div class="we-img-box">
      <img src="/static/images/background.png"/>
    </div>
    <div class="we-des">
      <text class="title">扫码一下 自助点餐</text>
      <text class="subtitle">自由 随心 的电子菜单</text>
    </div>
    <button class="btn-scan" open-type="getUserInfo" @getuserinfo="bindGetUserInfo">
      <img src="/static/images/icon-scan-code.svg" class="icon"/>
      <text>开始点餐</text>
    </button>
  </div>
</template>
<script>
  import fly from '@/libs/fly'
  export default {
    data () {
      return {
        user: {
          wechat: {}
        }
      }
    },
    components: {},
    methods: {
      bindGetUserInfo (e) {
        let self = this
        if (e.mp.detail.userInfo) {
          self.user = {
            wechat: e.mp.detail.userInfo
          }
          wx.setStorageSync('user', self.user)
          this.onHandleScan()
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
      wechatLogin () {
        return new Promise((resolve, reject) => {
          wx.login({
            success (res) {
              // 发送 res.code 到后台换取 openId, sessionKey, unionId
              fly.post('/WeiXinApp/Login', {code: res.code})
                .then(authRes => {
                  console.log('auth Res @91==========> ', authRes)
                  if (authRes.token) {
                    wx.setStorageSync('token', authRes.token)
                  }
                  resolve('token获取成功')
                })
                .catch(error => {
                  console.log('@11', error)
                  console.log('/WeiXinApp/Login 获取 token 失败 @166')
                  reject(error)
                })
            },
            fail (error) {
              console.log('fail@157', error)
              wx.showToast({
                icon: 'none',
                title: '微信登陆失败'
              })
            }
          })
        })
      },
      onHandleScan () {
        let self = this
        wx.scanCode({
          onlyFromCamera: true,
          success: (res) => {
            // Get tableNumber and seatId and save them to vuex
            let result = JSON.parse(res.result)
            if (result) {
              self.$store.commit('SET_SEAT_ID', result.seatId)
              self.$store.commit('SET_TABLE_NUMBER', result.tableNumber)
              // navigate to goods
              wx.navigateTo({
                url: '../goods/main?id=1'
              })
            }
          }
        })
      }
    },
    created () {
      this.wechatLogin()
    }
  }
</script>
<style lang="scss">
  @import "~@/styles/variable";

  page {
    background-color: $primary-white !important;
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

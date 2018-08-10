import Vue from 'vue'
import App from './App'
import fly from '@/libs/fly'
Vue.prototype.$http = fly // 将fly实例挂在vue原型上
Vue.config.productionTip = false
App.mpType = 'app'

const app = new Vue(App)
app.$mount()
Vue.prototype.getList = function () {
  wx.showLoading({
    title: '加载中',
  })
  this.$http.get('sell#!method=get').then((res)=>{
    this.restaurant = res.data.data.restaurant;
    this.goods = res.data.data.goods;
    this.seller = res.data.data.seller;
    this.ratings= res.data.data.ratings
    wx.hideLoading();
  }).catch((e)=>{
    console.log(e)
  })
}
export default {
  // 这个字段走 app.json
  config: {
    // 页面前带有 ^ 符号的，会被编译成首页，其他页面可以选填，我们会自动把 webpack entry 里面的入口页面加进去
    pages: ['pages/index/main', '^pages/order/main', 'pages/mine/main', 'pages/meal/main', 'pages/order-detail/main'],
    window: {
      backgroundTextStyle: 'light',
      navigationBarBackgroundColor: '#fff',
      navigationBarTitleText: 'WeWaiter',
      navigationBarTextStyle: 'black'
    },
    tabBar: {
      color: '#909090',
      selectedColor: '#ED5933',
      borderStyle: 'white',
      backgroundColor: '#F7F7FA',
      list: [
        {
          pagePath: 'pages/index/main',
          iconPath: 'static/images/home.png',
          selectedIconPath: 'static/images/home.png',
          text: '首页'
        },
        {
          pagePath: 'pages/order/main',
          iconPath: 'static/images/order.png',
          selectedIconPath: 'static/images/order.png',
          text: '订单'
        },
        {
          pagePath: 'pages/mine/main',
          iconPath: 'static/images/mine.png',
          selectedIconPath: 'static/images/mine.png',
          text: '我的'
        }
      ]
    }
  }
}

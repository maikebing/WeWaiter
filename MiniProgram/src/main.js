import Vue from 'vue'
import App from './App'

Vue.config.productionTip = false
App.mpType = 'app'

const app = new Vue(App)
app.$mount()

export default {
  // 这个字段走 app.json
  config: {
    // 页面前带有 ^ 符号的，会被编译成首页，其他页面可以选填，我们会自动把 webpack entry 里面的入口页面加进去
    pages: ['^pages/index/main', 'pages/order/main', 'pages/mine/main'],
    window: {
      backgroundTextStyle: 'light',
      navigationBarBackgroundColor: '#fff',
      navigationBarTitleText: 'WeWaiter',
      navigationBarTextStyle: 'black'
    },
    tabBar: {
      color: '#909090',
      selectedColor: '#ED5933',
      backgroundColor: '#fff',
      boxShadow: '0 0 4px #000',
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

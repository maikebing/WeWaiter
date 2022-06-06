import Vue from 'vue'
import App from './App'

import store from './store'
import fly from './libs/fly'
import config from './config'
import './weui.css'

Vue.prototype.$store = store
Vue.prototype.$http = fly // 将fly实例挂在vue原型上
Vue.prototype.$ossUrl = config.imgHost

Vue.config.productionTip = false
App.mpType = 'app'

const app = new Vue(App)
app.$mount()

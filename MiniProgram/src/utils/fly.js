import Vue from 'vue'
var Fly=require("flyio/dist/npm/wx.js") //wx.js为flyio的微信小程序入口文件
var fly=new Fly(); //创建fly实例
//添加拦截器
fly.interceptors.request.use((config,promise)=>{
    //给所有请求添加自定义header
    config.headers["X-Tag"]="flyio";
    return config;
})
//配置请求基地址
// Vue.prototype.$http=fly
fly.config.baseURL="https://www.easy-mock.com/mock/5aded45053796b38dd26e970/"
// let baseURL = `http://mock.eolinker.com/scQJzZz3b1d68053d700909597f57222c37b858e8b501de?uri=`
// fly.config.baseURL = baseURL
export default fly

let Fly = require('./wx') //wx.js为您下载的源码文件
let baseURL = `https://www.easy-mock.com/mock/5b625eb1c906ba51424f8f6f/wewaiter`
let fly = new Fly() //创建fly实例
const app = getApp()
//添加拦截器
fly.interceptors.request.use((request) => {
  console.log('@9', app)
  let token = wx.getStorageSync('token')
  if (token) {
    //给所有请求添加自定义header
    request.headers['Authorization'] = `JWT ${token}`
  }
  return request
})
fly.interceptors.response.use(
  (response) => {
    // if (typeof (response.data) === 'string' && response.data !== '') {
    //   response.data = JSON.parse(response.data)
    // }
    wx.hideLoading()
    return response.data
  },
  (err) => {
    switch(err.status) {
      case 0:
        wx.showToast({
          title: '网络错误',
          icon: 'none',
          mask: true,
          duration: 2000
        })
        break
      case 1:
        wx.showToast({
          title: '请求超时',
          icon: 'none',
          mask: true,
          duration: 2000
        })
        break
      case 500:
        wx.showToast({
          title: '服务器错误',
          mask: true,
          icon: 'none',
          duration: 3000
        })
        break
      case 403:
        wx.showToast({
          title: '请登陆',
          mask: true,
          icon: 'none',
          duration: 2000
        })
        setTimeout(()=>{
          wx.navigateTo({
            url: '/pages/login/main'
          })
        },1000)
        break
    }
    return err
  }
)
//配置请求基地址
fly.config.baseURL = baseURL
export default fly

const apiHost = process.env.VUE_APP_API_BASE_URL
console.log(apiHost)
const imgHost = wx.getStorageSync('imgHost') || ''
console.log(imgHost)
const config = {
  apiHost,
  imgHost
}

export default config

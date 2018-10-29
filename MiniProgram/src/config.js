const apiHost = 'https://api.cokco.cn/api'
const imgHost = wx.getStorageSync('imgHost') || ''
const config = {
  apiHost,
  imgHost
}

export default config

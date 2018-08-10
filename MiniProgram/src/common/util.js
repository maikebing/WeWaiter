// 解析url参数
export function urlParse () {
  var url = window.location.search
  var obj = {}
  var reg = /[?&][^?&]+=[^?&]+/g
  var arr = url.match(reg)
  arr.forEach((item) => {
    let temp = item.substring(1).split('=')
    let key = decodeURIComponent(temp[0])
    let value = decodeURIComponent(temp[1])
    obj[key] = value
  })
  console.log(obj)
  return obj
}

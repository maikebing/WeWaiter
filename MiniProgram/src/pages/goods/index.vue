<template>
  <div id="app">
    <!--<div class="container">-->

    <!--</div>-->
    <meal-table-number
      :table-number="tableNumber"
      :seller="seller"
    ></meal-table-number>
    <!--<div class="tab">-->
    <!--<div class="tab-item" style="" :class="{active:changeNav == index}" v-for="(item,index) in navList" :key="index"-->
    <!--:data-current="index" @click="swichNav">-->
    <!--{{item.name}}-->
    <!--</div>-->
    <!--</div>-->
    <goods :goods="goods"></goods>
    <!--<goods v-if="changeNav==0"></goods>-->
    <!--<ratings v-if="current==1" :seller="seller"></ratings>-->
    <!--<seller v-if="current==2" :seller="seller"></seller>-->
  </div>
</template>
<script>
import header from '@/components/header/header'
import goods from '@/components/goods/goods'
import ratings from '@/components/ratings/ratings'
import seller from '@/components/seller/seller'
import fly from '@/libs/fly'
import MealTableNumber from '@/components/MealTableNumber'

export default {
  data() {
    return {
      goods: {},
      seller: {},
      navList: [{ name: '菜单' }, { name: '评价' }, { name: '商家' }],
      changeNav: 0,
      current: null,
      tableNumber: 23,
      id: null
    }
  },
  methods: {
    swichNav(e) {
      const current = e.currentTarget.dataset.current
      this.changeNav = current
      this.current = current
    },
    getParameterByName(name, url) {
      if (!url) url = window.location.href
      name = name.replace(/[\[\]]/g, '\\$&')
      var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url)
      if (!results) return null
      if (!results[2]) return ''
      return decodeURIComponent(results[2].replace(/\+/g, ' '))
    },
    async getData(sellerId, seatId) {
      let res = await fly.get('sellers', {
        id: sellerId,
        seatid: seatId
      })
      res.seller.seller.avatar = res.seller.seller.avatar
      res.seller.goods = res.seller.catalogs.map(x => {
        console.log('@52', x)
        x.id = 'ww' + x.catalogID
        x.name = x.catalogName
        x.foods = x.goods.map(y => {
          y.id = y.goodsID
          y.price = y.sellingPrice
          y.sellCount = y.stock
          y.icon = y.icon
          return y
        })
        return x
      })
      console.log('getData@54', res)
      this.goods = res.seller.goods
      this.seller = res.seller.seller
      this.tableNumber = res.seller.seat.seatNumber
      console.log('getData@78', this.tableNumber)
      wx.setStorageSync('seller', res.seller)
    }
  },
  onReady() {
    let sellerId = this.$store.state.sellerId
    let seatId = this.$store.state.seatId
    console.log('onReady@75', sellerId)
    this.getData(sellerId, seatId)
  },
  components: {
    MealTableNumber,
    'v-header': header,
    'goods': goods,
    'ratings': ratings,
    'seller': seller
  },
  onLoad(options) {
    let self = this
    this.id = options.id
    if (options.q) {
      let url = decodeURIComponent(options.q)
      console.log('onLoad@85', url)
      let sellerId = this.getParameterByName('id', url)
      let seatId = this.getParameterByName('seatid', url)
      console.log('success@103', sellerId)
      console.log('success@103', seatId)
      self.$store.commit('SET_SEAT_ID', seatId)
      // self.$store.commit('SET_TABLE_NUMBER', result.tableNumber)
      self.$store.commit('SET_SELLER_ID', sellerId)
    }
  }
}
</script>
<style lang="stylus" scoped>
page {
  background-color: white;
}

#app {
  height: 100vh;
  width: 100%;
  padding-bottom: 65rpx;
  overflow: hidden;

  .tab {
    display: flex;
    justify-content: space-around;
    align-items: center;
    width: 100%;
    height: 80rpx;
    text-align: center;
    position: relative;

    &:after {
      display: block;
      position: absolute;
      left: 0;
      bottom: 0;
      width: 100%;
      border-top: 1rpx solid rgba(7, 17, 27, 0.1);
      content: '';
    }

    .tab-item {
      font-size: 28rpx;
      color: rgb(77, 85, 93);
      line-height: 28rpx;
    }

    .active {
      color: rgb(240, 20, 20);
      font-weight: 500;
    }
  }
}
</style>

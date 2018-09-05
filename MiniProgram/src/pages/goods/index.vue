<template>
  <div id="app">
    <!--<div class="container">-->

    <!--</div>-->
    <meal-table-number :table-number="tableNumber" :seller="seller"></meal-table-number>
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
    data () {
      return {
        goods: {},
        seller: {},
        navList: [{name: '菜单'}, {name: '评价'}, {name: '商家'}],
        changeNav: 0,
        current: null,
        tableNumber: 23,
        id: null
      }
    },
    methods: {
      swichNav (e) {
        const current = e.currentTarget.dataset.current
        this.changeNav = current
        this.current = current
      },
      async getData (id) {
        let res = await fly.get('sellers', {
          id: '342c501a-3365-4c2f-816f-2aaf51ea7a39',
          seatid: '342c501a-3365-4c2f-816f-2aaf51ea7a31'
        })
        res.goods = res.catalogs.map(x => {
          console.log('@52', x)
          x.id = 'ww' + x.catalogID
          x.name  = x.catalogName
          x.foods = x.goods.map(y=>{
            y.id = y.goodsID
            y.price = y.sellingPrice
            y.sellCount = y.stock
            return y
          })
          return x
        })
        console.log('getData@54', res)
        this.goods = res.goods
        this.seller = res.seller
        this.tableNumber = res.table_number
        wx.setStorageSync('seller', res.seller)
      }

    },
    created () {
      this.getData(this.id)
    },
    components: {
      MealTableNumber,
      'v-header': header,
      goods: goods,
      ratings: ratings,
      seller: seller
    },
    onLoad (options) {
      this.id = options.id
    }
  }
</script>
<style lang="stylus" scoped>

  page
    background-color white

  #app
    height 100vh
    width 100%
    padding-bottom 65px
    overflow hidden

    .tab
      display flex
      justify-content space-around
      align-items center
      width 100%
      height 80px
      text-align center
      position relative
      &:after
        display block
        position absolute
        left 0
        bottom 0
        width 100%
        border-top 1px solid rgba(7, 17, 27, 0.1)
        content ''
      .tab-item
        font-size 28px
        color rgb(77, 85, 93)
        line-height 28px
      .active
        color rgb(240, 20, 20)
        font-weight 500

</style>

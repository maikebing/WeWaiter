<template>
  <div id="app">
    <!--<div class="container">-->

    <!--</div>-->
    <meal-table-number :table-number="tableNumber"></meal-table-number>
    <!--<div class="tab">-->
      <!--<div class="tab-item" style="" :class="{active:changeNav == index}" v-for="(item,index) in navList" :key="index"-->
           <!--:data-current="index" @click="swichNav">-->
        <!--{{item.name}}-->
      <!--</div>-->
    <!--</div>-->
    <goods></goods>
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
  import fly from '@/utils/fly'
  import MealTableNumber from '@/components/MealTableNumber'

  export default {
    data () {
      return {
        goods: {},
        seller: {},
        navList: [{name: '菜单'}, {name: '评价'}, {name: '商家'}],
        changeNav: 0,
        current: null,
        tableNumber: 23
      }
    },
    methods: {
      swichNav (e) {
        const current = e.currentTarget.dataset.current
        this.changeNav = current
        this.current = current
        //  console.log(current)
      }

    },
    created () {
      fly.get('sell#!method=get').then((res) => {
        console.log('@43', res)
        this.goods = res.data.data.goods
        this.seller = res.data.data.seller
      }).catch((e) => {
        console.log(e)
      })
    },
    components: {
      MealTableNumber,
      'v-header': header,
      goods: goods,
      ratings: ratings,
      seller: seller
    }
  }
</script>
<style lang="stylus" scoped>

  page
    background-color white
  #app
    height 100vh
    width 100%
    overflow hidden

    .tab
      display flex
      justify-content space-around
      align-items center
      width 100%
      height 80 px
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
        font-size 28 px
        color rgb(77, 85, 93)
        line-height 28 px
      .active
        color rgb(240, 20, 20)
        font-weight 500

</style>

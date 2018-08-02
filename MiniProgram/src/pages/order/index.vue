<template>
  <div>
    <block v-for="order in orderList" :key="order.id">
      <order-item :order="order"></order-item>
    </block>
  </div>
</template>
<script>
  import OrderItem from '@/components/OrderItem'
  export default {
    data () {
      return {
        orderList: [
          {
            id: 1,
            currentStatus: 'unpaid',
            menuList: ['西蓝花', '鱼丸', '虾丸', '鱼豆腐'],
            consumption: 99
          }, {
            id: 2,
            currentStatus: 'paid',
            menuList: ['西蓝花', '鱼丸', '虾丸', '千页豆腐'],
            consumption: 199
          }, {
            id: 3,
            currentStatus: 'completed',
            menuList: ['鱼丸', '西蓝花', '虾丸'],
            consumption: 299
          }, {
            id: 4,
            currentStatus: 'undone',
            menuList: ['千页豆腐', '西蓝花', '鱼丸', '虾丸'],
            consumption: 399
          }, {
            id: 5,
            currentStatus: 'refunded',
            menuList: ['毛肚', '西蓝花', '鱼丸', '虾丸', '千页豆腐'],
            consumption: 499
          }
        ]
      }
    },
    components: {
      OrderItem
    },
    methods: {
    },
    created () {}
  }
</script>
<style lang="scss">
  @import "~@/styles/variable";
</style>

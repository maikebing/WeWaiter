<!--公用组件：订单状态
      /**
      * @desc 订单状态
      * @param {number} [status]    - 状态
      * @example 调用示例
      *  <order-status :status="status"></order-status>
      **/
-->
<template>
  <div>
    <div class="we-box">
    </div>
  </div>
</template>

<script>
  export default {
    props: ['status'],
    data () {
      return {}
    },
    methods: {},
    computed: {
      status: function () {
        switch (this.order.currentStatus) {
          case 0:
            return 'unpaid'
          case 1:
            return 'paid'
          case 2:
            return 'completed'
          case 3:
            return 'undone'
          case 4:
            return 'refunded'
        }
      }
    },
    created () {
    }
  }
</script>

<style lang="scss">
  @import "~@/styles/variable";
</style>

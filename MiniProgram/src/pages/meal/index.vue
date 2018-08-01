<template>
  <div class="container">
    <table-number :table-number="tableNumber"></table-number>
  </div>
</template>
<script>
  import TableNumber from '@/components/MealTableNumber'
  export default {
    data () {
      return {
        tableNumber: 23
      }
    },
    components: {
      TableNumber
    },
    methods: {},
    created () {
    }
  }
</script>
<style lang="scss">
  @import "~@/styles/variable";
</style>

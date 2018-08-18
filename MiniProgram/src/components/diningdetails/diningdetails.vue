<template>
  <div class="dining-details">
    <div class="weui-cell weui-cell_select">
      <div class="weui-cell__hd weui-cell__hd_in-select-after">
        <div class="weui-label">用餐人数</div>
      </div>
      <div class="weui-cell__bd">
        <picker @change="bindPickerChange" :value="index" :range="array">
          <div class="weui-select weui-select_in-select-after">{{array[index]}}</div>
        </picker>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    data () {
      return {
        index: 0,
        array: ['美国', '中国', '巴西', '日本']
      }
    },
    methods: {
      bindPickerChange: function(e) {
        console.log('picker发送选择改变，携带值为', e.detail.value)
      }
    },
    created () {
    }
  }
</script>

<style lang="scss" scoped>
  @import "~@/styles/variable";
  .dining-details {
    background-color: $primary-white;
    padding: 0 30px;
  }

  .weui-select {
    padding-right: 40px;
    border-right-width: 0;
    text-align: right;
    /* 2人: */
    font-size: 36px;
    color: #1F1F21;
  }
  .weui-label {
    /* 用餐人数: */
    width: auto;
    font-size: 32px;
    color: #1F1F21;
    letter-spacing: -0.27px;
  }
</style>

<template>
  <div class="dining-details-box">
    <div class="dining-details">
      <div class="weui-cell weui-cell_select">
        <div class="weui-cell__hd weui-cell__hd_in-select-after">
          <div class="weui-label">用餐人数</div>
        </div>
        <div class="weui-cell__bd">
          <picker @change="bindPickerChange" :value="index" :range="diningDetailsList" range-key="name">
            <div class="weui-select weui-select_in-select-after">{{diningDetailsList[index].name}}</div>
          </picker>
        </div>
      </div>
    </div>
    <div class="weui-cells weui-cells_after-title">
      <radio-group @change="bindRadioChange">
        <label class="weui-cell weui-check__label" v-for="item in radioItems" :key="value">
          <radio class="weui-check" :value="item.value" :checked="item.checked"/>

          <div class="weui-cell__hd weui-check__hd_in-checkbox">
            <icon class="weui-icon-checkbox_circle" type="circle" size="23" v-if="!item.checked"></icon>
            <icon class="weui-icon-checkbox_success" type="success" size="23" v-if="item.checked"></icon>
          </div>
          <div class="weui-cell__bd">{{item.name}}</div>
        </label>
      </radio-group>
    </div>
  </div>
</template>

<script>
  export default {
    props: {
      diningDetailsList: {
        type: Array,
        default: function () {
          return [
            {
              id: '',
              name: ''
            }
          ]
        }
      }
    },
    data () {
      return {
        index: 0,
        radioItems: [
          {name: '店内用餐', value: '0'},
          {name: '打包带走', value: '1', checked: true}
        ]
      }
    },
    methods: {
      bindPickerChange: function (e) {
        console.log('picker发送选择改变，携带值为', e.target.value)
        let index = e.target.value
        this.$emit('select-tableware', this.diningDetailsList[index].id)
      },
      bindRadioChange: function (e) {
        console.log('radio发生change事件，携带value值为：', e)
        let radioItems = this.radioItems
        for (let i = 0, len = radioItems.length; i < len; ++i) {
          radioItems[i].checked = radioItems[i].value === e.target.value
        }
        this.radioItems = radioItems
        this.$emit('select-meal-style', e.target.value)
      }
    },
    created () {
    }
  }
</script>

<style lang="scss" scoped>
  @import "~@/styles/variable";

  .dining-details-box {
    background-color: $primary-white;
    padding: 0 30px 0;
    .dining-details {
      padding: 30px 0;
      border-bottom: 1px solid #D3D3D3;
    }
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

  .weui-cells {
    position: static;
    border-bottom-width: 0;
  }
  radio-group {
    display: flex;
    padding: 38px 0 44px;
    /* 店内用餐: */
    font-size: 32px;
    color: #1F1F21;
    letter-spacing: -0.27px;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    border-bottom-width: 0;
    .weui-cell {
      position: static;
    }
  }
</style>

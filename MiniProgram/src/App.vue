<script>
  export default {
    created () {
      console.log('app启动')
    }

  }
</script>

<style>
  @import './common/fonts/iconfont3.css';
  @import './common/fonts/iconfont2.css';
  @import './common/fonts/iconfont.css';

  .container {
    height: 100%;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    padding: 0;
    box-sizing: border-box;
  }

  /* this rule will be remove */
  /** {*/
  /*transition: width 2s;*/
  /*-moz-transition: width 2s;*/
  /*-webkit-transition: width 2s;*/
  /*-o-transition: width 2s;*/
  /*}*/

  /*!**app.wxss**!*/
  /*.container {*/
  /*height: 100%;*/
  /*display: flex;*/
  /*flex-direction: column;*/
  /*align-items: center;*/
  /*justify-content: space-between;*/
  /*padding: 200rpx 0;*/
  /*box-sizing: border-box;*/
  /*}*/

  .container {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    padding: 0;
    box-sizing: border-box;
  }

  /* this rule will be remove */
  * {
    transition: width 2s;
    -moz-transition: width 2s;
    -webkit-transition: width 2s;
    -o-transition: width 2s;
  }

  page {
    background-color: #F3EFEE;
  }
</style>

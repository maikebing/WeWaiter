<template>
  <div class="sprinner">
    <div class="spinner">
      <div class="bounce1"></div>
      <div class="bounce2"></div>
      <div class="bounce3"></div>
    </div>
  </div>
</template>

<script>
export default {}
</script>

<style>
.spinner {
  position: absolute;
  left: 280rpx;
  top: 0;
  width: 70rpx;
  text-align: center;
  display: inline-block;
}
.spinner view {
  width: 7rpx;
  height: 7rpx;
  background-color: #c0c0c0;
  border-radius: 50%;
  display: inline-block;
  -webkit-animation: sk-bouncedelay 1s infinite ease-in-out both;
  animation: sk-bouncedelay 1s infinite ease-in-out both;
}
.spinner .bounce1 {
  -webkit-animation-delay: -0.32s;
  animation-delay: -0.32s;
}
.spinner .bounce2 {
  -webkit-animation-delay: -0.16s;
  animation-delay: -0.16s;
}
@keyframes sk-bouncedelay {
  0%,
  80%,
  100% {
    -webkit-transform: scale(0);
    transform: scale(0);
  }
  40% {
    -webkit-transform: scale(0.8);
    transform: scale(0.8);
  }
}
</style>

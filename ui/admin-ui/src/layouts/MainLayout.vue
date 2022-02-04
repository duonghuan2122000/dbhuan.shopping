<template>
  <div id="main-layout">
    <left-menu />
    <div id="main">
      <header-layout />
      <router-view />
    </div>
  </div>
</template>

<script>
import LeftMenu from "./LeftMenu";
import HeaderLayout from "./HeaderLayout";
export default {
  components: {
    LeftMenu,
    HeaderLayout,
  },
  setup() {},
};
</script>

<style lang="scss">
@import "@/assets/scss/layouts/MainLayout.scss";
</style>
<template>
  <div class="common-layout">
    <el-container>
      <el-aside class="aside" width="200px">
        <AkromaSide />
      </el-aside>
      <el-container>
        <el-header class="header">
          <h1>Akroma Desktop</h1>
        </el-header>
        <el-main>
          <router-view />
          <HelloPhotino msg="main..." />
        </el-main>
      </el-container>
    </el-container>
  </div>
  <!-- <div id="app">
    <HelloPhotino msg="Hello to Photino.Vue" />
  </div> -->
</template>

<script lang="ts">
import { defineComponent } from "vue";
import HelloPhotino from "./components/HelloPhotino.vue";
import AkromaSide from "./components/AkromaSide.vue";
import "./assets/main.css";

export default defineComponent({
  name: "App",
  components: {
    HelloPhotino,
    AkromaSide,
  },
  setup() {
    // store.dispatch("loadProjects");
    // store.dispatch("loadEmployees");
    // store.dispatch("loadAssignments");
    return {};
  },
});
</script>

<style>
body {
  margin: 0 auto;
  padding: 0;
}

#app {
  font-family: "Helvetica Neue", Helvetica, "PingFang SC", "Hiragino Sans GB",
    "Microsoft YaHei", "微软雅黑", Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

.aside {
  padding: 0px;
}

.header {
  text-align: left;
  background-color: #337ecc;
}

.header h1 {
  color: #fff;
  font-size: 1.5em;
}
</style>

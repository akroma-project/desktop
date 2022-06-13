<template>
  <nav>
    <el-menu default-active="2">
      <el-menu-item index="2">
        <el-icon><DataAnalysis /></el-icon>
        <router-link to="/">Portfolo</router-link>
      </el-menu-item>
      <el-menu-item index="3">
        <el-icon><Wallet /></el-icon>
        <router-link to="/accounts">Accounts</router-link>
      </el-menu-item>
      <el-menu-item index="3">
        <el-icon><Upload /></el-icon>
        <router-link to="/send">Send</router-link>
      </el-menu-item>
      <el-menu-item index="3">
        <el-icon><CircleCheck /></el-icon>
        <router-link to="/receive">Receive</router-link>
      </el-menu-item>
    </el-menu>
  </nav>
</template>

<script lang="ts" setup></script>

<style scoped></style>

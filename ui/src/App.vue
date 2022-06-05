<template>
  <div id="app">
    <HelloPhotino msg="Hello to Photino.Vue" />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import HelloPhotino from "./components/HelloPhotino.vue";
import "./assets/main.css";

export default defineComponent({
  name: "App",
  components: {
    HelloPhotino,
  },
  setup() {
    // store.dispatch("loadProjects");
    // store.dispatch("loadEmployees");
    // store.dispatch("loadAssignments");
    return {};
  },
});
</script>

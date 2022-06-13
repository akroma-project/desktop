import { createApp } from "vue";
import App from "./App.vue";
import store from "./store";
import ElementPlus from "element-plus";
import "element-plus/dist/index.css";
import "element-plus/theme-chalk/dark/css-vars.css";
import axios from "axios";
import VueAxios from "vue-axios";
import router from "./router";
import { sendMessage } from "./remoting";
import * as ElementPlusIconsVue from "@element-plus/icons-vue";

const app = createApp(App);
app.provide("sendMessage", sendMessage);
for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
  app.component(key, component);
}
app.use(store);
app.use(VueAxios, axios);
app.use(router);
app.use(ElementPlus);
app.mount("#app");

import { createApp } from "vue";
import App from "./App.vue";
import store from "./store";
import ElementPlus from "element-plus";
import "element-plus/dist/index.css";
import axios from "axios";
import VueAxios from "vue-axios";
import router from "./router";

createApp(App)
  .use(store)
  .use(VueAxios, axios)
  .use(router)
  .use(ElementPlus)
  .mount("#app");

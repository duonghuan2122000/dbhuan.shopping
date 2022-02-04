/**
 * Main js
 * createdBy: dbhuan 27/01/2022
 */

import '@/assets/fontawesome/css/fontawesome.min.css';
import '@/assets/fontawesome/css/solid.min.css';

import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.min.js';

import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

createApp(App).use(store).use(router).mount("#app");

import { createApp } from 'vue'
import App from './App.vue'
import router from "./router/index"
import './index.css'
import store from "./store/index"
import { library } from "@fortawesome/fontawesome-svg-core";
import AlertBox from "./components/errors/AlertBox.vue";
import { fas } from "@fortawesome/free-solid-svg-icons";
import { fab } from "@fortawesome/free-brands-svg-icons";
import { far } from "@fortawesome/free-regular-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import PrimeVue from 'primevue/config';
import Dialog from 'primevue/dialog';
import AutoComplete from'primevue/autocomplete';

library.add(fas, fab, far);

createApp(App)
.use(store)
.use(router)
.use(PrimeVue)
.component('Dialog', Dialog)
.component('AutoComplete', AutoComplete)
.component("AlertBox", AlertBox)
.component("font-awesome-icon", FontAwesomeIcon)
.mount('#app')
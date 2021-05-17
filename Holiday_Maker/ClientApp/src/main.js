import { createApp } from 'vue'
import App from './App.vue'
import router from "./router/index"
import './index.css'
import store from "./store/index"
import { library } from "@fortawesome/fontawesome-svg-core";
import { faBaby, faBed, faCoffee, faHamburger, faMinusSquare, faPhone, faPlusSquare, faSquare, faStar, faSwimmer, faSwimmingPool, faUserSecret } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import AlertBox from "./components/errors/AlertBox.vue";




library.add(faStar, faCoffee, faSwimmer, faHamburger, faPlusSquare, faSquare, faBed, faMinusSquare, faBaby);

createApp(App)
.component("font-awesome-icon", FontAwesomeIcon)
.component("AlertBox", AlertBox) //Globally registered component
.use(store)
.use(router)
.mount('#app')
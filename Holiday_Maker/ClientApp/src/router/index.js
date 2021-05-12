import { createRouter, createWebHistory } from 'vue-router'
import Searchbar from '/src/components/Searchbar.vue'
const routes = [
    {
        path: '/Searchbar',
        name: 'Searchbar',
        component: Searchbar,
    }
]
const router = createRouter({
    history: createWebHistory(),
    routes,
})
export default router
import { createRouter, createWebHistory } from 'vue-router'
import Hotels from '/src/components/pages/Hotels.vue'
import Searchbar from '/src/components/Searchbar.vue'
const routes = [
    {
        path: '/Searchbar',
        name: 'Searchbar',
        component: Searchbar,
    },
    {
        path: '/Hotels',
        name: 'Hotels',
        component: Hotels,
    }
]
const router = createRouter({
    history: createWebHistory(),
    routes,
})
export default router
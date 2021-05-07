import { createRouter, createWebHistory } from 'vue-router'
import API from '/src/components/API.vue'
const routes = [
    {
        path: '/API',
        name: 'API',
        component: API,
    }
]
const router = createRouter({
    history: createWebHistory(),
    routes,
})
export default router
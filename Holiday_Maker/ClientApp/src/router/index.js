import { createRouter, createWebHistory } from 'vue-router'
import Hotels from '/src/components/pages/Hotels.vue'
import StoreTest from '/src/components/pages/StoreTest.vue'
import Accommodation from '/src/components/pages/Accommodation.vue'
import NotFound from '/src/components/pages/NotFound.vue'
import Favorite from '/src/components/FavoriteButton.vue'
import Searchbar from '/src/components/Searchbar.vue'
import LoginRegister from '/src/components/pages/LoginRegister.vue'
import Logout from '/src/components/logins/Logout.vue'

const routes = [
    {
        path: '/',
        name: '',
        component: Searchbar,
    },
    {
        path: '/hotels',
        name: 'Hotels',
        component: Hotels,
    },
    {
        path: '/storetest',
        name: 'StoreTest',
        component: StoreTest,
    },
    {
        path: "/accommodation/:id",  // <-- notice the colon
        name: "Accommodation",
        component: Accommodation,
        props: true,
    },
    {
        path: "/:catchAll(.*)",
        component: NotFound,
    },
    {
        path: '/searchbar',
        name: 'Searchbar',
        component: Searchbar,
    },
    {
        path: '/Favorite',
        name: 'Favorite',
        component: Favorite,
    },
    {
        path: '/Login',
        name: 'LoginRegister',
        component: LoginRegister,
    },
    {
        path: '/Logout',
        name: 'Logout',
        component: Logout,
    },
]
const router = createRouter({
    history: createWebHistory(),
    routes,
})
export default router
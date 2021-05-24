import { createRouter, createWebHistory } from 'vue-router'
import Hotels from '/src/components/pages/Hotels.vue'
import StoreTest from '/src/components/pages/StoreTest.vue'
import Accommodation from '/src/components/pages/Accommodation.vue'
import NotFound from '/src/components/pages/NotFound.vue'
import Favorite from '/src/components/FavoriteButton.vue'
import Searchbar from '/src/components/Searchbar.vue'
import LoginRegister from '/src/components/pages/LoginRegister.vue'
import Logout from '/src/components/logins/Logout.vue'
import Booking from '/src/components/pages/Booking.vue'

const routes = [
    {
        path: '/',
        name: 'Home',
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
        path: "/accommodation/:id",
        name: "Accommodation",
        component: Accommodation,
        props: true,
    },
    {
        path: "/booking/:id",
        name: "Booking",
        component: Booking,
        props: true,
    },
    {
        path: "/:catchAll(.*)",
        component: NotFound,
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
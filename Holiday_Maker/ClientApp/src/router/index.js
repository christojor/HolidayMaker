import { createRouter, createWebHistory } from 'vue-router'
import Hotels from '/src/components/pages/Hotels.vue'
import Accommodation from '/src/components/pages/Accommodation.vue'
import NotFound from '/src/components/pages/NotFound.vue'
import MyFavorites from '/src/components/Profile/MyFavorites.vue'
import Searchbar from '/src/components/Searchbar.vue'
import LoginRegister from '/src/components/pages/LoginRegister.vue'
import Logout from '/src/components/logins/Logout.vue'
import Booking from '/src/components/pages/Booking.vue'
import MyBookings from '/src/components/Profile/MyBookings.vue'
import MyPage from '/src/components/pages/MyPage.vue'
import UserRemoval from '/src/components/logins/RemoveUser.vue'

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
        path: "/accommodation/:id",
        name: "Accommodation",
        component: Accommodation,
        props: true,
    },
    {
        path: "/accommodation/booking/:id",
        name: "Booking",
        component: Booking,
        props: true,
    },
    {
        path: "/:catchAll(.*)",
        component: NotFound,
    },
    {
        path: '/MyFavorites',
        name: 'MyFavorites',
        component: MyFavorites,
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
    {
        path: '/UserRemoval',
        name: 'User Removed',
        component: UserRemoval,
    },

  {
    path: '/MyBookings',
    name: 'MyBookings',
    component: MyBookings
  },
  {
    path: '/MyPage',
    name: 'MyPage',
    component: MyPage
  }
]
const router = createRouter({
  history: createWebHistory(),
  routes
})
export default router

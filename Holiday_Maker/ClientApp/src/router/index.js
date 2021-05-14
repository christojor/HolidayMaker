import { createRouter, createWebHistory } from 'vue-router'
import Hotels from '/src/components/pages/Hotels.vue'
import StoreTest from '/src/components/pages/StoreTest.vue'
import Accommodation from '/src/components/pages/Accommodation.vue'
import NotFound from '/src/components/pages/NotFound.vue'

import Searchbar from '/src/components/Searchbar.vue'
const routes = [
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
    },
    {
        path: '/searchbar',
        name: 'Searchbar',
        component: Searchbar,
    }
]
const router = createRouter({
    history: createWebHistory(),
    routes,
})
export default router
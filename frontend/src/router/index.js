import Vue from 'vue'
import VueRouter from 'vue-router'
import { authGuard } from '@/auth/authGuard'

Vue.use(VueRouter)

/**
 * Used to route the various displays for the application.
 * Add in your additional views and add the appropriate auth guard in here
 * @type {[{path: string, component: (function(): Promise<{readonly default?: {name: string}}>), meta: {title: string}, name: string}, {path: string, component: (function(): Promise<{readonly default?: {name: string}}>), meta: {title: string}, name: string}]}
 */
const routes = [
  {
    path: '/',
    name: 'Home',
    beforeEnter: authGuard('/home'),
    component: () => import('../views/AboutPage.vue'),
    meta: {
      title: 'Home Page'
    }
  },
  {
    path: '/login',
    beforeEnter: authGuard('/home')
  },
  {
    path: '/home',
    name: 'Home Page',
    component: () => import('../views/HomePage.vue'),
    beforeEnter: authGuard(null),
    meta: {
      title: 'Home Page'
    }
  },
  {
    path: '/receipts',
    name: 'Receipts Page',
    component: () => import('../views/ReceiptsPage.vue'),
    beforeEnter: authGuard(),
    meta: {
      title: 'Receipts Page'
    }
  },
  {
    path: '/products',
    name: 'Products Page',
    component: () => import('../views/ProductsPage.vue'),
    beforeEnter: authGuard(),
    meta: {
      title: 'Products Page'
    }
  },
  {
    path: '/another',
    name: 'Another Page',
    component: () => import('../views/AnotherPage.vue'),
    beforeEnter: authGuard(),
    meta: {
      title: 'Another Page'
    }
  },
  {
    path: '*',
    name: 'Page Not Found',
    component: () => import('../views/NotFoundPage.vue'),
    meta: {
      title: 'No Page found'
    }
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router

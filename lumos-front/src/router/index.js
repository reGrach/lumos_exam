import Vue from 'vue'
import VueRouter from 'vue-router'
import FutureExam from '@/views/FutureExam.vue'
import PassedExam from '@/views/PassedExam.vue'
import About from '@/views/About.vue'


Vue.use(VueRouter)

const routes = [
  {
    path: '/future',
    name: 'Я сдам',
    component: FutureExam
  },
  {
    path: '/passed',
    name: 'Я сдала',
    component: PassedExam
  },
  {
    path: '/about',
    name: 'О портале',
    component: About
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router

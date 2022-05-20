import Vue from 'vue'
import VueRouter from 'vue-router'
import online from '../views/listPage/online.vue'
import offline from '../views/listPage/offline.vue'
import mall from '../views/listPage/mall.vue'
import diseaseInfo from '../views/listPage/diseaseInfo.vue'
import Home from '../views/listPage/Home.vue'
import News from '../views/listPage/News.vue'
import Login from '@/components/Login.vue'
import Register from '@/components/Register.vue'
import InquiryBelongDoc from "../views/listPage/InquiryDoctor.vue";
import InquiryBelongPatient from "../views/listPage/InquiryPatient.vue";
import searchAddress from '@/components/searchAddress.vue'
import updateUserD from '@/components/updateUserD.vue'
import hospitaldialog from '../components/hospitaldialog.vue'
import doctordialog from '../components/doctordialog.vue'
import PreDatadialog from '../components/PreDatadialog.vue'
import healthReport from '../components/healthReport.vue'
import healthAdvice from '../components/healthAdvice.vue'
import updateUser from '../components/updateUser.vue'
import updateBMI from '../components/updateBMI.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/Home',
    name: 'Home',
    component: Home,
    meta: {
      title:"首页",
      tx:5
    }
  },
  {
    path: '/',
    name: 'Login',
    component: Login,
  },
  {
    path: '/Register',
    name: 'Register',
    component: Register,
  },
  {
    path: '/News',
    name: 'News',
    component: News,
    meta: {
      title:"新闻",
      tx:6
    }
  },
  {
    path: '/mall',
    name: 'mall',
    component: mall,
    meta: {
      title:"健康商城",
      tx:2
    }
  },
  {
    path: '/diseaseInfo',
    name: 'diseaseInfo',
    component: diseaseInfo,
    meta: {
      title:"疾病信息",
      tx:1
    }
  },
  {
    path: '/online',
    name: 'online',
    component: online,
    meta: {
      title:"线上问诊",
      tx:4
    }
  },
  {
    path: '/offline',
    name: 'offline',
    component: offline,
    meta: {
      title:"线下预约",
      tx:3
    }
  },
  {
    path:'/InquiryBelongDoc',
    name:'InquiryBelongDoc',
    component: InquiryBelongDoc
  },
  {
    path:'/InquiryBelongPatient',
    name:'InquiryBelongPatient',
    component: InquiryBelongPatient
  },
  {
    path: '/homepage',
    name: 'Homepage',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/listPage/Homepage.vue')
  },    
  {
    path: '/records',
    name: 'records',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/listPage/records.vue')
  }, 
  {
    path: '/docEdit',
    name: 'doceEit',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/listPage/docEdit.vue')
  },
  {
    path: '/admin1',
    name: 'admin1',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/listPage/admin1.vue')
  },
  {
    path: '/admin2',
    name: 'admin2',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/listPage/admin2.vue')
  },
  {
    path:'/searchAddress',
    name:'searchAddress',
    component:searchAddress
  },
  {
    path:'/updateUserD',
    name:'updateUserD',
    component:updateUserD
  },
  {
    path: '/information1',
    name: 'information1',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/listPage/information1.vue')
  },
  {
    path: '/information2',
    name: 'information2',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/listPage/information2.vue')
  },
  {
    path: '/information3',
    name: 'information3',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/listPage/information3.vue')
  },
  {
    path:'/hospitaldialog',
    name:'hospitaldialog',
    component:hospitaldialog
  },
  {
    path:'/doctordialog',
    name:'doctordialog',
    component:doctordialog
  },
  {
    path:'/PreDatadialog',
    name:'PreDatadialog',
    component:PreDatadialog
  },
  {
    path:'/healthReport',
    name:'healthReport',
    component:healthReport
  },
  {
    path:'/healthAdvice',
    name:'healthAdvice',
    component:healthAdvice
  },
  {
    path:'/updateUser',
    name:'updateUser',
    component:updateUser
  },
  {
    path:'/updateBMI',
    name:'updateBMI',
    component:updateBMI
  },
]

const router = new VueRouter({
  routes
})

export default router


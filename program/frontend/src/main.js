import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
//import axios from 'axios'
//import VueAxios from 'vue-axios'
//import { axios } from './axios/axios.js';
import Vuex from 'vuex'


Vue.use(ElementUI)

Vue.config.productionTip = false

//Vue.use(VueAxios, axios)
//Vue.$http=axios

Vue.use(Vuex)

// require('./mocks/index.js')

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')

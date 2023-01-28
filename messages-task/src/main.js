import Vue from 'vue'
import VueRouter from 'vue-router'
import store from './store/store'

Vue.use(VueRouter);

import App from './App.vue'
import Login from './components/Login.vue'
import Home from './components/Home.vue'

const router = new VueRouter({
    mode: 'history',
    routes: [  
        {
            path: '/',
            component: Home
        },
        {
            name:'login',
            path: '/login',
            component: Login
        },

        {
            path: '*',
            redirect: '/'
        },

    ]
});

//Vue.use(VueRouter)
   
Vue.config.productionTip = false



new Vue({
    router,
    store,
    render: h => h(App),
}).$mount('#app')

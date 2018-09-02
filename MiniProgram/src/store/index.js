import Vue from 'vue'
import Vuex from 'vuex'
import user from './modules/user'
import merchant from './modules/merchant'
import getters from './getters'

Vue.use(Vuex)

const store = new Vuex.Store({
  modules: {
    user,
    merchant
  },
  getters
})

export default store

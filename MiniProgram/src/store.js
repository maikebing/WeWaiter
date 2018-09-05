import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

const store = new Vuex.Store({
  state: {
    seatId: null,
    tableNumber: null
  },
  mutations: {
    SET_SEAT_ID (state, id) {
      state.seatId = id
    },
    SET_TABLE_NUMBER (state, number) {
      state.tableNumber = number
    }
  }
})

export default store

// user module
const user = {
  state: {
    seatId: '4282457273b74df292dbd1de9b00f383',
    tableNumber: null
  },
  mutations: {
    SET_SEAT_ID (state, id) {
      state.id = id
    },
    SET_TABLE_NUMBER (state, number) {
      state.tableNumber = number
    }
  },
  actions: {}
}
export default user

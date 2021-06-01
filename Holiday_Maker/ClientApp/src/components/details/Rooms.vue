<template>
  <b>AVAILABLE ROOMS</b>
  <div v-for="room in rooms" :key="room">
    <div class="flex flex-wrap overflow-hidden border-black border-2 p-1 m-1">
      <div class="w-1/2 overflow-hidden p-2">
        <img class="rounded-md roomImg" :src="room.imgSrc" />
      </div>

      <div class="w-1/2 overflow-hidden p-4">
        <button
          class="float-right bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full"
          @click="addToBooking(room)"
        >
          Book Room
        </button>
        <div>
          <b>Room Type:</b> {{ room.roomType.name }}<br />
          <b>Number of Guests: </b> {{ room.nbrOfGuests }}<br />
          <b>Number of Extra Beds:</b> {{ room.nbrOfExtraBeds }}<br />
          <b>Price:</b> {{ room.price }}€ <br />
          <div v-if="room.isRefundable == true"><b>Refund:</b> Yes<br /></div>
          <div v-if="room.isRefundable == false"><b>Refund:</b> No<br /></div>
          <b>Description:</b> {{ room.description }}<br />
          <b>Extras at extra price: </b>
          <div class="rounded-t-md bg-green-1 search-div shadow-xl w-2/8">
            <div class="text-green-500">
               <div class="selectBox" @click="toggledisplay" @mouseover="sortExtras">
                    <select>
                        <option>Select Extras</option>
                    </select>
                    <div class="overSelect"></div>
            </div>
              <div
                :class="{ show: toggle }"
                id="checkboxes"
                @click="handleSubmit"
              >
                <div
                  v-for="Extra in Extras"
                  :key="Extra"
                  class="flex items-center"
                >
                  <input
                    type="checkbox"
                    :id="Extra.Extra"
                    v-model="Extra.Checked"
                  />
                  <label :for="Extra.Extra">&nbsp;{{ Extra.Extra }}, price: {{Extra.Price}}</label>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <!-- <extrasPrices class="extra"></extrasPrices> -->
</template>


<script>

export default {
  data() {
    return {
      toggle: true,
      Extras: [],
    };
  },
  props: {
    rooms: {
      type: Object,
      required: true,
    },
    extrasList: Object
  },
  methods: {
    addToBooking(room) {
      this.$store.state.bookedRooms.push(room);
    },
    toggledisplay(){
      this.toggle=!this.toggle
    },
    handleSubmit(){
      let filter = {
        PropExtras: this.Extras
      }
    },
    sortExtras(){
      this.Extras = [];

      if(this.extrasList[0].selfCatering){
        this.Extras.push({ Extra: "Self-Catering", Checked: false, Price: 5})
      }
      if(this.extrasList[0].halfBoard){
        this.Extras.push({ Extra: "Half-Board", Checked: false, Price: 10})
      }
      if(this.extrasList[0].fullBoard){
        this.Extras.push({ Extra: "Full-board", Checked: false, Price: 15})
      }
      if(this.extrasList[0].extraBed){
        this.Extras.push({ Extra: "Extra bed", Checked: false, Price: 5})
      }
      if(this.extrasList[0].crib){
        this.Extras.push({ Extra: "Crib", Checked: false, Price: 5})
      }
      if(this.extrasList[0].allInclusive){
        this.Extras.push({ Extra: "Self-Catering", Checked: false, Price: 20})
      }
      if(this.extrasList[0].breakfast){
        this.Extras.push({ Extra: "Breakfast", Checked: false, Price: 5})
      }

    }
  }
};
</script>
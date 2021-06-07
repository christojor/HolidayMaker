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
          Add Room
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
               <div style="text-align:left;margin-left:10px" v-for="Extra in Extras" :key="Extra">
                 <input type="checkbox" style="margin-right:10px" id="{{Extra.Name}}" :value="Extra.Checked">
                 <label for="{{Extra.Name}}">{{Extra.Name}} {{"+"}} {{Extra.Price}} {{Extra.Currency}}</label>
               </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>

export default {
  mounted(){
    this.sortExtras();
  },

  data() {
    return {
      // toggle: true,
      Extras: [
        { Name: "Self-Catering", Checked: false, Price: 5, Currency:"€"},
        { Name: "Half-Board",  Checked: false, Price: 10, Currency:"€"},
        { Name: "Full-board",  Checked: false, Price: 15, Currency:"€"},
        { Name: "Extra bed",  Checked: false, Price: 5, Currency:"€"},
        { Name: "Crib", Checked: false, Price: 5, Currency:"€"},
        { Name: "Self-Catering", Checked: false, Price: 20, Currency:"€"},
        { Name: "Breakfast", Checked: false, Price: 5, Currency:"€"}
      ],
    };
  },

  props: {
    rooms: {
      type: Object,
      required: true,
    },
    extrasList: {
      type: Object,
      required: true,
    },
    extrasPerRoom: Object
  },
  methods: {
    addToBooking(room) {
      this.$store.state.bookedRooms.push(room);
    },
    // toggledisplay(){
    //   this.toggle=!this.toggle
    // },
    // handleSubmit(){
    //   let filter = {
    //     PropExtras: this.Extras
    //   }
    // },
    sortExtras(){
      this.Extras = [];

      if(this.extrasList[0].selfCatering){
        this.Extras.push({ Name: "Self-Catering", Checked: false, Price: 5, Currency: "€"})
      }
      if(this.extrasList[0].halfBoard){
        this.Extras.push({ Name: "Half-Board", Checked: false, Price: 10, Currency: "€"})
      }
      if(this.extrasList[0].fullBoard){
        this.Extras.push({ Name: "Full-board", Checked: false, Price: 15, Currency: "€"})
      }
      if(this.extrasList[0].extraBed){
        this.Extras.push({ Name: "Extra bed", Checked: false, Price: 5, Currency: "€"})
      }
      if(this.extrasList[0].crib){
        this.Extras.push({ Name: "Crib", Checked: false, Price: 5, Currency: "€"})
      }
      if(this.extrasList[0].allInclusive){
        this.Extras.push({ Name: "Self-Catering", Checked: false, Price: 20, Currency: "€"})
      }
      if(this.extrasList[0].breakfast){
        this.Extras.push({ Name: "Breakfast", Checked: false, Price: 5, Currency: "€"})
      }

    },
  }
};
</script>
<template>
<div class="flex flex-wrap overflow-hidden divide-y-2 divide-gray-300 border-2 rounded-md border-black shadow-md p-4 bg-green-1">

  <div class="w-full overflow-hidden">
    <h2 class="text-xl text-green-6">Price Details</h2>
  </div>

  <div class="w-full overflow-hidden">
    <h1>{{ nbrOfNights }} nights x {{ price }}€</h1>
    <h1>Price of Extras: {{ allExtrasPrice() }}€</h1>
    <h1>Price: {{ totalPrice }}€</h1>
    <h1>Tax (20%): {{ priceTax }}€</h1>
    <h1><b>Total: {{ totalPriceInclTax }}€</b></h1>
  </div>

  <div class="w-full overflow-hidden">
    <!-- Column Content -->
  </div>

</div>
</template>

<script>
export default {

  props: {
    roomPrices: {
      type: Object,
      required: true,
      }
    },

    methods:{
      roomExtrasPrice(id){
        let price = 0
        this.extrasPrice.filter(extra => {if(extra.roomId == id){price += extra.price}})
        return price
      },
      allExtrasPrice(){
        let price = 0
        this.extrasPrice.filter(extra => price += extra.price)
        return price
      }
    },
  
  computed:{
    extrasPrice(){
      return this.$store.state.extrasPrice
    },
    price(){
        return this.roomPrices.reduce((sum, room) => {
            return sum += room.price;
        }, 0);
    },
      totalPrice(){
        return this.roomPrices.reduce((sum, room) => {
            return sum += (room.price * this.nbrOfNights) + this.roomExtrasPrice(room.id);
        }, 0);
        
    },
    totalPriceInclTax(){
      var totalPrice = 0;
        return this.roomPrices.reduce((sum, room) => {
            totalPrice += ((room.price * this.nbrOfNights) + this.roomExtrasPrice(room.id)) * 1.2;
            this.$store.commit("setTotalPrice", totalPrice);
            return totalPrice;
        }, 0);
    },
    priceTax(){
        return this.roomPrices.reduce((sum, room) => {
            return sum += ((room.price * this.nbrOfNights) + this.roomExtrasPrice(room.id)) * 0.2;
        }, 0);
    },
    nbrOfNights(){
      return this.$store.state.nbrOfNights
    }
  }  
}

</script>
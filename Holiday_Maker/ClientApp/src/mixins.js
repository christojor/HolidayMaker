export default {

    methods: {
       
       currentDate(incrementDay) {
        const current = new Date();

        if (incrementDay > 0){
            current.setDate(current.getDate() + incrementDay);
        }

        var monthWithLeadingZero = (current.getMonth() < 10 ? '0' : '') + (current.getMonth() + 1);
        var dayWithLeadingZero = (current.getDate() < 10 ? '0' : '') + current.getDate();

        const date = current.getFullYear() + "-" + monthWithLeadingZero + "-" + dayWithLeadingZero;

        return date;
      },

      currentDateTime() {
        const current = new Date();

        const date = this.currentDate()
        const time = current.getHours() + ":" + current.getMinutes() + ":" + current.getSeconds();
        const dateTime = date + " " + time
        
        return dateTime;
      },

      setMinMaxCheckDate(checkIn, checkOut){
        document.getElementById("checkIn").setAttribute("min", checkIn);
        document.getElementById("checkOut").setAttribute("min", checkOut);
      },

      isLoggedIn(){
         return this.$store.state.isLoggedIn;
       }
    }
 }
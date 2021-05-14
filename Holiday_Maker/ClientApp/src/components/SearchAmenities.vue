<template>
    <div class="filter-box">
        <div class="multipleSelection drop-box">
            <div class="selectBox" @click="toggledisplay">
                    <select>
                        <option>Select Amenities</option>
                    </select>
                    <div class="overSelect"></div>
            </div>

            <div :class="{show : toggle}" id="checkboxes" @click="handleSubmit">
                
                <div v-for="Ameniti in Amenities" :key="Ameniti" class="flex items-center">
                    <input type="checkbox" :id="Ameniti.Ameniti" v-model="Ameniti.Checked"/>
                    <label :for="Ameniti.Ameniti">&nbsp;{{Ameniti.Ameniti}}</label>
                </div>
            </div>
        </div>
    </div>
</template>

   <script>

export default{
    data(){
        return{
            toggle: true,
            Amenities: [
                {Ameniti: 'Entertainment', Checked: false},
                {Ameniti: 'Resturants', Checked: false},
                {Ameniti: 'WiFi', Checked: false},
                {Ameniti: 'Pool', Checked: false},
                {Ameniti: 'Gym', Checked: false},
                {Ameniti: 'KidClub', Checked: false},
                
            ],
        }
    },
    methods:{
        toggledisplay(){
            this.toggle=!this.toggle
        },
        handleSubmit(){
            let filter = {
                PropAmenities: this.Amenities
            }
            
            this.$emit('filter-search', filter);
        }
    }
}

</script>
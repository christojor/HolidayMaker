<template>
    <div class="filter-box">
        <div class="multipleSelection drop-box">
            <div class="selectBox" @click="toggledisplay">
                    <select>
                        <option>Select Amenities</option>
                    </select>
                    <div class="overSelect"></div>
            </div>

            <div :class="{show : toggle}" id="checkboxes">
                
                <div v-for="Amenity in Amenities" :key="Amenity" class="flex items-center">
                    <input type="checkbox" :id="Amenity.Amenity" v-model="Amenity.Checked" @change="handleSubmit"/>
                    <label :for="Amenity.Amenity">&nbsp;{{Amenity.Amenity}}</label>
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
                {Amenity: 'Entertainment', Checked: false},
                {Amenity: 'Resturants', Checked: false},
                {Amenity: 'WiFi', Checked: false},
                {Amenity: 'Pool', Checked: false},
                {Amenity: 'Gym', Checked: false},
                {Amenity: 'KidClub', Checked: false},
                
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
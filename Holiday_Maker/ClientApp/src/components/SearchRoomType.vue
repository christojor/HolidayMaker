<template>
    <div class="filter-box">
        <div class="multipleSelection drop-box">
            <div class="selectBox" @click="toggledisplay">
                    <select>
                        <option>Select room type</option>
                    </select>
                    <div class="overSelect"></div>
            </div>

            <div :class="{show : toggle}" id="checkboxes" @click="handleSubmit">
                
                <div v-for="Rooms in RoomTypes" :key="Rooms" class="flex items-center">
                    <input type="checkbox" :id="Rooms.Type" v-model="Rooms.Checked"/>
                    <label :for="Rooms.Type">&nbsp;{{Rooms.Type}}</label>
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
            RoomTypes: [
                {Type: 'Single', Checked: false},
                {Type: 'Doubble', Checked: false},
                {Type: 'Suite', Checked: false},
                {Type: 'Shared', Checked: false},
            ],
        }
    },
    methods:{
        toggledisplay(){
            this.toggle=!this.toggle
        },
        handleSubmit(){
            
            let filter = {
                PropRooms: this.RoomTypes
            }
            
            this.$emit('filter-search', filter);
        }
    }
}

</script>
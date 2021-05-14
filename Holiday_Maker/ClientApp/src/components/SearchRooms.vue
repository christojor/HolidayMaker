<template>
    <div class="filter-box">
        <div class="multipleSelection drop-box">
            <div class="selectBox" @click="toggledisplay">
                    <select>
                        <option>Select Rooms</option>
                    </select>
                    <div class="overSelect"></div>
            </div>

            <div :class="{show : toggle}" id="checkboxes" @click="handleSubmit">
                
                <div v-for="Room in Rooms" :key="Room" class="flex items-center">
                    <input type="checkbox" :id="Room.Room" v-model="Room.Checked"/>
                    <label :for="Room.Room">&nbsp;{{Room.Room}}</label>
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
            Rooms: [
                {Room: 'Room 1', Checked: false},
                {Room: 'Room 2', Checked: false},
                {Room: 'Room 3', Checked: false},
                {Room: 'Room 4', Checked: false},
                {Room: 'Room 5', Checked: false},
                
                
            ],
        }
    },
    methods:{
        toggledisplay(){
            this.toggle=!this.toggle
        },
        handleSubmit(){
            let filter = {
                PropRoom: this.Rooms
            }
            
            this.$emit('filter-search', filter);
        }
    }
}

</script>
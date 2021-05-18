<template>
    <div class="filter-box">
        <div class="multipleSelection drop-box">
            <div class="selectBox" @click="toggledisplay">
                    <select>
                        <option>Select extras</option>
                    </select>
                    <div class="overSelect"></div>
            </div>

            <div :class="{show : toggle}" id="checkboxes" @click="handleSubmit">
                
                <div v-for="Extra in Extras" :key="Extra" class="flex items-center">
                    <input type="checkbox" :id="Extra.Extra" v-model="Extra.Checked"/>
                    <label :for="Extra.Extra">&nbsp;{{Extra.Extra}}</label>
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
            Extras: [
                {Extra: 'Self-Catering', Checked: false},
                {Extra: 'HalfBoard', Checked: false},
                {Extra: 'FullBoard', Checked: false},
                {Extra: 'All-Inclusive', Checked: false},
                {Extra: 'Breakfast', Checked: false},
                {Extra: 'ExtraBed', Checked: false},
                {Extra: 'Crib', Checked: false},
            ],
        }
    },
    methods:{
        toggledisplay(){
            this.toggle=!this.toggle
        },
        handleSubmit(){
            let filter = {
                PropExtras: this.Extras
            }
            
            this.$emit('filter-search', filter);
        }
    }
}

</script>
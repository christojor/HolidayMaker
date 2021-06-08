<template>
    <div class="rounded-t-md bg-green-1 search-div shadow-xl w-2/8">
        <div class="text-green-500">
            <div style="text-align:left;margin-left:10px" v-for="Extra in Extras" :key="Extra">
                <input type="checkbox" style="margin-right:10px" :v-model="Extra.Checked" @change="setExtra(Extra)">
                <label>{{Extra.Name}} {{"+"}} {{Extra.Price}} {{Extra.Currency}}</label>
            </div>
        </div>
    </div>
</template>

<script>

export default{
    mounted(){
        this.sortExtras();
    },
    data(){
        return{
            Extras: [],
        }
    },
    props:{
        extrasList: {
            type: Object,
            required: true,
        },
        },
        methods:{
        setExtra(Extra){
            Extra.Checked = !Extra.Checked

            if(Extra.Checked)
            {
                this.$emit('addExtra', Extra)
            }  
            else
            {
                this.$emit('removeExtra', Extra)
            }     
            
        },
        sortExtras(){
            this.Extras = []
            
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
}
</script>

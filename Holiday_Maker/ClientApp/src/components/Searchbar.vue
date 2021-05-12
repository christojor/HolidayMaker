<template>
            <h1>Search for hotels</h1>

        <div style="display:flex;border:solid">
            <div style="flex:1;padding:1em;border:solid;padding-top:2.5%">
                <input v-model="destination" type="text" placeholder="Enter your destination">
            </div>
            <div style="flex:1;padding:1em;border:solid">
                <p>Check in date</p>
                <input v-model="check_in" type="date">
            </div>
            <div style="flex:1;padding:1em;border:solid">
                <p>Check out date</p>
                <input v-model="check_out" type="date">
            </div>
            <div style="flex:1;padding:1em;border:solid">
                <p>Number of guests</p>
                <select v-model="selected">
                    <option disabled value="">Number of guests</option>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                </select>

            </div>
        </div>
    <div>
        <h2>results</h2>
        <p>Destination is: {{destination}}</p>
        <p>check in date is {{check_in}}</p>
        <p>check out date is {{check_out}}</p>
        <p>nunber of guests: {{selected}}</p>
    </div>
</template>

<script>
export default {
    data() {

        return {
            destination: '',
            check_in: '',
            check_out: '',
            selected: '',
        }
        
    },
}
</script>
<style>
.dropdown:hover > .dropdown-content {
	display: block;
}
</style>

<template>
<div class="dropdown inline">
    <button class="navbarThemesButton bg-green-2 hover:bg-green-500 py-3 rounded-full">
        <span>TRIP THEMES</span>
    </button>
    	<ul :class="{contentMargin:this.$store.state.isLoggedIn}" class="dropdown-content absolute hidden text-gray-700 pt-1 content">
		<li><router-link class="theme-item bg-gray-200 hover:bg-gray-400 py-2 px-4 block whitespace-no-wrap content-link" @click="searchHunting" to="/hotels">Hunting trips</router-link></li>
		<li><router-link class="theme-item bg-gray-200 hover:bg-gray-400 py-2 px-4 block whitespace-no-wrap content-link" @click="searchFitness" to="/hotels">Fitness trips</router-link></li>
		<li><router-link class="theme-item bg-gray-200 hover:bg-gray-400 py-2 px-4 block whitespace-no-wrap content-link" @click="searchParty" to="/hotels">Party trips</router-link></li>
	</ul>
</div>
</template>

<script>
export default ({
	methods: {
		async searchHunting(){
			let response = await fetch('https://localhost:44323/api/Accomodations?theme=hunting');
            let queriedAccomodations = await response.json();

			this.updateAccomodations(queriedAccomodations)
		},
		async searchFitness(){
			let response = await fetch('https://localhost:44323/api/Accomodations?theme=fitness');
            let queriedAccomodations = await response.json();

			this.updateAccomodations(queriedAccomodations)
		},
		async searchParty(){
			let response = await fetch('https://localhost:44323/api/Accomodations?theme=party');
            let queriedAccomodations = await response.json();

			this.updateAccomodations(queriedAccomodations)
		},
		updateAccomodations(queriedAccomodations) {
			this.$store.commit("updateAccomodations", queriedAccomodations);
		},
	}
})
</script>

<template>
<div class="dropdown inline">
    <button class="theme-button">
        <span>TRIP THEMES</span>
    </button>
    	<ul class="bg-green-1 dropdown-content absolute hidden text-gray-700 pt-1 content">
		<li><a @click='showHuntingThemes' class="theme-item bg-gray-200 hover:bg-gray-400 py-2 px-4 block whitespace-no-wrap content-link">Hunting trips</a></li>
		<li><a @click='showFitnessThemes' class="theme-item bg-gray-200 hover:bg-gray-400 py-2 px-4 block whitespace-no-wrap content-link">Fitness trips</a></li>
		<li><a @click='showPartyThemes' class="theme-item bg-gray-200 hover:bg-gray-400 py-2 px-4 block whitespace-no-wrap content-link">Party trips</a></li>

	</ul>
</div>
</template>

<script>
export default {
	methods: {
    	async showHuntingThemes() {
		let rawResponse = await fetch('https://localhost:44323/api/Accomodations?theme=hunting');
    	let getAccomodations = await rawResponse.json();
		},
		async showFitnessThemes() {
		let rawResponse = await fetch('https://localhost:44323/api/Accomodations?theme=fitness');
    	let getAccomodations = await rawResponse.json();
		},
		async showPartyThemes() {
		let rawResponse = await fetch('https://localhost:44323/api/Accomodations?theme=party');
    	let getAccomodations = await rawResponse.json();
		},
	}
}
</script>

<style>
.dropdown:hover > .dropdown-content {
	display: block;
}
</style>
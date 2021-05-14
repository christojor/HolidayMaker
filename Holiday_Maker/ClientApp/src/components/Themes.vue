<style>
.dropdown:hover > .dropdown-content {
	display: block;
}
</style>

<template>
<div class="dropdown inline">
    <button class="theme-button">
        <span>TRIP THEMES</span>
    </button>
    	<ul class="bg-green-1 dropdown-content absolute hidden text-gray-700 pt-1 content">
		<li><a class="theme-item bg-gray-200 hover:bg-gray-400 py-2 px-4 block whitespace-no-wrap content-link">Hunting trips</a></li>
		<li><a class="theme-item bg-gray-200 hover:bg-gray-400 py-2 px-4 block whitespace-no-wrap content-link">Fitness trips</a></li>
	</ul>
</div>
</template>

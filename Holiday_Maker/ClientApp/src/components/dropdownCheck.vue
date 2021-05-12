<template>
  <div class="filter-box">
    <p>Tick an option</p>
    <div>
      <div>
        <div class="flex items-center">
          <input type="checkbox" id="checkbox" v-model="checked" />
          <label for="checkbox">Self-Catering</label>
        </div>
        <div class="flex items-center">
          <input type="checkbox" id="checkbox" v-model="checked" />
          <label for="checkbox">Halfboard</label>
        </div>
        <div>
          <div class="flex items-center">
            <input type="checkbox" id="checkbox" v-model="checked" />
            <label for="checkbox">Fullboard</label>
          </div>
        </div>
        <div class="flex items-center">
          <input type="checkbox" id="checkbox" v-model="checked" />
          <label for="checkbox">All-inclusive</label>
        </div>
        <div class="flex items-center">
          <input type="checkbox" id="checkbox" v-model="checked" />
          <label for="checkbox">Breakfast</label>
        </div>
        <div class="flex items-center">
          <input type="checkbox" id="checkbox" v-model="checked" />
          <label for="checkbox">Extrabed</label>
        </div>
        <div class="flex items-center">
          <input type="checkbox" id="checkbox" v-model="checked" />
          <label for="checkbox">Crib</label>
        </div>
      </div>
    </div>
  </div>
</template>
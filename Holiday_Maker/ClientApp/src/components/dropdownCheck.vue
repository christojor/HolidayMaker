<template>
<div class="filter-box">
    <div class="multipleSelection">
      <div class="selectBox" @click="toggledisplay">
        <select>
          <option>Select extras</option>
        </select>
        <div class="overSelect"></div>
      </div>

    <div :class="{show : toggle}" id="checkboxes">
        <div class="flex items-center">
          <input type="checkbox" id="first"/>
          <label for="first">&nbsp;Self-Catering</label>
        </div>
        <div class="flex items-center">
          <input type="checkbox" id="second"/>
          <label for="second">&nbsp;Halfboard</label>
        </div>
        <div>
          <div class="flex items-center">
            <input type="checkbox" id="second"/>
            <label for="second">&nbsp;Fullboard</label>
          </div>
        </div>
        <div class="flex items-center">
          <input type="checkbox" id="third"/>
          <label for="third">&nbsp;All-inclusive</label>
        </div>
        <div class="flex items-center">
          <input type="checkbox" id="fourth"/>
          <label for="fourth">&nbsp;Breakfast</label>
        </div>
        <div class="flex items-center">
          <input type="checkbox" id="fifth"/>
          <label for="fifth">&nbsp;Extrabed</label>
        </div>
        <div class="flex items-center">
          <input type="checkbox" id="sixth"/>
          <label for="sixth">&nbsp;Crib</label>
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
  
    
    }
  },
  methods:{
    toggledisplay(){
      this.toggle=!this.toggle
    
    }
  }
}

</script>
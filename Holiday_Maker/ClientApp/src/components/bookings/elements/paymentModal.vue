<template>
  <div>
    <button
      class="text-white rounded bg-pink-500 px-6 py-4 font-sans font-semibold shadow-lg hover:bg-pink-400 outline-none active:outline-none focus:outline-none"
      @click="toggleModal = !toggleModal"
    >
      Open Modal
    </button>
    <div
      class="fixed overflow-x-hidden overscroll-y-auto inset-0 flex justify-center items-center z-50"
      v-if="toggleModal"
    >
      <div class="relative mx-auto w-auto max-w-2xl">
        <div class="bg-white w-full rounded shadow-2xl flex flex-col">
            <div class="text-2xl font-bold"><font-awesome-icon :icon="['fas', 'check-circle']" size="lg" style="color: #52B788;"/>Payment Done</div>
            
          <span
            >You've received SEK60.00 worth of Wolt credits. You will get another SEK60.00 after making a purchase. The credits are in your account and can be used with your next order. The credits are valid until Jun 27, 2021.</span
          >
          <button
            class="rounded bg-green-500 text-white px-6 mt-1 py-2 w-3/12 m-auto mb-3 shadow-lg hover:bg-green-400 outline-none active:outline-none focus:outline-none"
            @click="toggleModal = false"
          >
            Close
          </button>
        </div>
      </div>
    </div>

    <div
      v-if="toggleModal"
      class="absolute z-40 inset-0 opacity-25 bg-black"
    ></div>
  </div>
</template>



<script>
export default {
  name: "modal",
  data() {
    return {
      toggleModal: false,
    };
  },
  methods: {},
};
</script>
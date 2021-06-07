<template>
  <div>
    <div
      class="fixed overflow-x-hidden overscroll-y-auto inset-0 flex justify-center items-center z-50"
      v-if="toggleModal"
    >
      <div class="relative mx-auto w-auto max-w-2xl">
        <div
          class="bg-white w-full rounded shadow-2xl flex flex-col space-y-5"
          style="padding: 20px"
        >
          <div class="text-2xl font-bold text-center">
            <font-awesome-icon
              :icon="['fas', 'check-circle']"
              size="lg"
              style="color: #52b788"
            />
            Payment Done
          </div>

          <span class="text-center"
            >Thank you, your payment has been succesful. A confirmation email
            has been sent to {{GetUserEmail}}</span
          >
          <button
            class="rounded bg-green-500 text-white px-6 mt-1 py-2 w-3/12 m-auto mb-3 shadow-lg hover:bg-green-400 outline-none active:outline-none focus:outline-none"
            @click="toggleModalMethod"
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
  props: {
    toggleModal: Boolean,
  },


  methods: {
    toggleModalMethod() {
      var toggleModal = false;
      this.$emit("emitToggle", toggleModal);
    },
  },
};
</script>
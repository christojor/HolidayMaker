<template>
  <div v-for="accomodation in accomodations" :key="accomodation">
    <div v-if="id == accomodation.id">
      <div class="flex flex-wrap overflow-hidden mt-3">
        <div class="w-1/6 overflow-hidden">
          <!-- Column Content -->
        </div>

        <div
          class="w-4/6 overflow-hidden shadow-md rounded-md divide-y bg-green-1"
        >
          <div class="w-full overflow-hidden xl:my-1 xl:px-1 xl:w-full">
            <h2 class="uppercase text-lg p-1" style="font-weight: bold">
              {{ accomodation.name }}
              <StarIcon class="h-5 w-5 text-blue-500"/>
              
            </h2>
          </div>

          <div class="w-full overflow-hidden xl:my-1 xl:px-1 xl:w-full p-2">
            <img
              :src="accomodation.imgSrc"
              class="img-fluid rounded-md"
              style="width: 300px; height: auto"
            />
          </div>

          <div class="w-full overflow-hidden xl:my-1 xl:px-1 xl:w-full p-1">
            <h2><b>DESCRIPTION</b></h2>
            {{ accomodation.description }}
          </div>

          <div class="flex flex-wrap overflow-hidden xl:my-1 xl:px-1 xl:w-full divide-x">
            <div
              class="w-1/2 overflow-hidden p-1"
              v-for="amenity in accomodation.amenities"
              :key="amenity"
            >
              <table class="table-auto">
                <thead>
                  <tr>
                    <th align="left">AMENITIES</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td>Entertainment:</td>
                    <td>{{ amenity.entertainment }}</td>
                  </tr>
                  <tr>
                    <td>Kid Club:</td>
                    <td>{{ amenity.kidClub }}</td>
                  </tr>
                  <tr>
                    <td>Gym:</td>
                    <td>{{ amenity.gym }}</td>
                  </tr>
                  <tr>
                    <td>Pool:</td>
                    <td>{{ amenity.pool }}</td>
                  </tr>
                  <tr>
                    <td>WiFi</td>
                    <td>{{ amenity.wiFi }}</td>
                  </tr>
                  <tr>
                    <td>Restaurant:</td>
                    <td>{{ amenity.resturant }}</td>
                  </tr>
                </tbody>
              </table>
            </div>
            <div
              class="w-1/2 overflow-hidden p-1"
              v-for="extra in accomodation.extras"
              :key="extra"
            >
              <table class="table-auto">
                <thead>
                  <tr>
                    <th align="left">EXTRAS</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td>Self Catering:</td>
                    <td>{{ extra.selfCatering }}</td>
                  </tr>
                  <tr>
                    <td>Half Board:</td>
                    <td>{{ extra.halfBoard }}</td>
                  </tr>
                  <tr>
                    <td>Full Board:</td>
                    <td>{{ extra.fullBoard }}</td>
                  </tr>
                  <tr>
                    <td>All Inclusive:</td>
                    <td>{{ extra.allInclusive }}</td>
                  </tr>
                  <tr>
                    <td>Breakfast:</td>
                    <td>{{ extra.breakfast }}</td>
                  </tr>
                  <tr>
                    <td>Extra Bed:</td>
                    <td>{{ extra.extraBed }}</td>
                  </tr>
                  <tr>
                    <td>Crib:</td>
                    <td>{{ extra.crib }}</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>

        <div class="w-1/6 overflow-hidden">
          <!-- Column Content -->
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { StarIcon } from '@heroicons/vue/solid'

export default {
  props: ["id"],

components: { 
 StarIcon 
  },

  computed: {
    accomodations() {
      return this.$store.state.accomodations;
    },
  },
};
</script>
<template>
    <div v-for="amenity in amenities" :key="amenity">

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
</template>

<script>
export default {
    props: {
            amenities: {
                type: Object,
                required: true,
            },
        },
};
</script>
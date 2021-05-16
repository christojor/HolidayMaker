<template>

<div  v-for="extra in extras" :key="extra">
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
    
</template>

<script>
export default {
     props: {
            extras: {
                type: Object,
                required: true
            },
        },
    
}
</script>
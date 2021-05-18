export function getByName(list, filter) {
    if (!filter.PropName) return list
    return list.filter(item => (item.name.toLowerCase()).includes(filter.PropName.toLowerCase()))
}
export function getByStars(list, filter) {
    if (!filter.PropStars) return list
    return list.filter(item => item.starRating <= filter.PropStars)
}
export function getByRating(list, filter) {
    if (!filter.PropRating) return list
    return list.filter(item => item.guestRating >= filter.PropRating)
} 
export function getByMinPrice(list, filter) {
    if (!filter.PropMinPrice) return list
    if(filter.PropMinPrice == 0){ 
        return list
    }
    else if(filter.PropMinPrice == 3000){ 
        return list.filter(item => item.rooms.filter(item => item.price > 3000).length > 0) 
    }
    return list.filter(item => item.rooms.filter(item => item.price >= filter.PropMinPrice).length > 0)
} 
export function getByMaxPrice(list, filter) {
    if (filter.PropMaxPrice == null) return list
    if(filter.PropMaxPrice == 0){ 
        return null 
    }
    else if(filter.PropMaxPrice == 3000){ 
        return list.filter(item => item.rooms.filter(item => item.price > 0).length > 0) 
    }
    return list.filter(item => item.rooms.filter(item => item.price <= filter.PropMaxPrice).length > 0)
}
export function getByAmenities(list, filter) {
    if (!filter.PropAmenities) return list
    var checkedAmenities = filter.PropAmenities.filter(item => item.Checked == true)
    var checkedAmenitiesNames = []
    checkedAmenities.filter(item => checkedAmenitiesNames.push(item.Amenity))
    console.log(checkedAmenitiesNames[0])
    
    var amenitieslist = []
    list.filter(item => amenitieslist.push(item.amenities[0]))

    if(checkedAmenitiesNames.includes("Entertainment") == true){
        amenitieslist = amenitieslist.filter(a => a.entertainment == true)
    }
    if(checkedAmenitiesNames.includes("Resturants") == true){
        amenitieslist = amenitieslist.filter(a => a.resturant == true)
    }
    if(checkedAmenitiesNames.includes("WiFi") == true){
        amenitieslist = amenitieslist.filter(a => a.wiFi == true)
    }
    if(checkedAmenitiesNames.includes("Pool") == true){
        amenitieslist = amenitieslist.filter(a => a.pool == true)
    }
    if(checkedAmenitiesNames.includes("Gym") == true){
        amenitieslist = amenitieslist.filter(a => a.gym == true)
    }
    if(checkedAmenitiesNames.includes("KidClub") == true){
        amenitieslist = amenitieslist.filter(a => a.kidClub == true)
    }
    
    console.log(amenitieslist)

    return list.filter(item => amenitieslist.filter(a => a.accomodationId == item.id).length > 0)
}
export function getByExtras(list, filter) {
    if (!filter.PropAmenities) return list
    var checkedAmenities = filter.PropAmenities.filter(item => item.Checked == true)
    var checkedAmenitiesNames = []
    checkedAmenities.filter(item => checkedAmenitiesNames.push(item.Amenity))
    console.log(checkedAmenitiesNames[0])
    
    var amenitieslist = []
    list.filter(item => amenitieslist.push(item.amenities[0]))

    if(checkedAmenitiesNames.includes("Entertainment") == true){
        amenitieslist = amenitieslist.filter(a => a.entertainment == true)
    }
    if(checkedAmenitiesNames.includes("Resturants") == true){
        amenitieslist = amenitieslist.filter(a => a.resturant == true)
    }
    if(checkedAmenitiesNames.includes("WiFi") == true){
        amenitieslist = amenitieslist.filter(a => a.wiFi == true)
    }
    if(checkedAmenitiesNames.includes("Pool") == true){
        amenitieslist = amenitieslist.filter(a => a.pool == true)
    }
    if(checkedAmenitiesNames.includes("Gym") == true){
        amenitieslist = amenitieslist.filter(a => a.gym == true)
    }
    if(checkedAmenitiesNames.includes("KidClub") == true){
        amenitieslist = amenitieslist.filter(a => a.kidClub == true)
    }
    
    console.log(amenitieslist)

    return list.filter(item => amenitieslist.filter(a => a.accomodationId == item.id).length > 0)
}
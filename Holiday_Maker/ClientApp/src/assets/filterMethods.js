export function getByName(list, filter) {
    if (!filter.PropName) return list
    return list.filter(item => (item.name.toLowerCase()).includes(filter.PropName.toLowerCase()))
}
export function getByStars(list, filter) {
    if (!filter.PropStars) return list
    return list.filter(item => item.starRating >= filter.PropStars)
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
    else if(filter.PropMinPrice == 2000){ 
        return list.filter(item => item.rooms.filter(item => item.price > 2000).length > 0) 
    }
    return list.filter(item => item.rooms.filter(item => item.price >= filter.PropMinPrice).length > 0)
} 
export function getByMaxPrice(list, filter) {
    if (filter.PropMaxPrice == null) return list
    if(filter.PropMaxPrice == 0){ 
        return null 
    }
    else if(filter.PropMaxPrice == 2000){ 
        return list.filter(item => item.rooms.filter(item => item.price > 0).length > 0) 
    }
    return list.filter(item => item.rooms.filter(item => item.price <= filter.PropMaxPrice).length > 0)
}
export function getByAmenities(list, filter) {
    if (!filter.PropAmenities) return list
    var checkedAmenities = filter.PropAmenities.filter(item => item.Checked == true)
    var checkedAmenitiesNames = []
    checkedAmenities.filter(item => checkedAmenitiesNames.push(item.Amenity))
    
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

    return list.filter(item => amenitieslist.filter(a => a.accomodationId == item.id).length > 0)
}
export function getByExtras(list, filter) {
    if (!filter.PropExtras) return list
    var checkedExtras = filter.PropExtras.filter(item => item.Checked == true)
    var checkedExtrasNames = []
    checkedExtras.filter(item => checkedExtrasNames.push(item.Extra))
    
    var extraslist = []
    list.filter(item => extraslist.push(item.extras[0]))

    if(checkedExtrasNames.includes("Self-Catering") == true){
        extraslist = extraslist.filter(e => e.selfCatering == true)
    }
    if(checkedExtrasNames.includes("HalfBoard") == true){
        extraslist = extraslist.filter(e => e.halfBoard == true)
    }
    if(checkedExtrasNames.includes("FullBoard") == true){
        extraslist = extraslist.filter(e => e.fullBoard == true)
    }
    if(checkedExtrasNames.includes("All-Inclusive") == true){
        extraslist = extraslist.filter(e => e.allInclusive == true)
    }
    if(checkedExtrasNames.includes("Breakfast") == true){
        extraslist = extraslist.filter(e => e.breakfast == true)
    }
    if(checkedExtrasNames.includes("ExtraBed") == true){
        extraslist = extraslist.filter(e => e.extraBed == true)
    }
    if(checkedExtrasNames.includes("Crib") == true){
        extraslist = extraslist.filter(e => e.crib == true)
    }

    return list.filter(item => extraslist.filter(e => e.accomodationId == item.id).length > 0)
}
export function getByRooms(list, filter) {
    if (!filter.PropRooms) return list
    var checkedRooms = filter.PropRooms.filter(item => item.Checked == true)
    var checkedRoomsNames = []
    checkedRooms.filter(item => checkedRoomsNames.push(item.Type))
    
    var roomslist = []
    var returnlist = [] 
    list.filter(item => roomslist.push(...item.rooms))

    console.log(roomslist)

    if(checkedRoomsNames.includes("Single") == true){
        returnlist.push(roomslist.filter(r => r.roomTypeId == 1))
    }
    if(checkedRoomsNames.includes("Double") == true){
        returnlist.push(roomslist.filter(r => r.roomTypeId == 2))
    }
    if(checkedRoomsNames.includes("Suite") == true){
        returnlist.push(roomslist.filter(r => r.roomTypeId == 3))
    }
    if(checkedRoomsNames.includes("Shared") == true){
        returnlist.push(roomslist.filter(r => r.roomTypeId == 4))
    }

    returnlist = returnlist.flat()

    if(!returnlist.length) return list

    return list.filter(item => returnlist.filter(r => r.accomodationId == item.id).length > 0)
}
export function getByBeach(list, filter) {
    if (!filter.DistanceBeach) return list
    if (filter.DistanceBeach == 0 || filter.DistanceBeach == 5000) return list
    return list.filter(item => item.distanceToBeach <= filter.DistanceBeach)
} 
export function getByCity(list, filter) {
    if (!filter.DistanceCity) return list
    if (filter.DistanceCity == 0 || filter.DistanceCity == 5000) return list
    return list.filter(item => item.distanceToCenter <= filter.DistanceCity)
} 
export function getByWifi(list, filter) {
    if (!filter.PropWifi || filter.PropWifi == 0) return list

    var wifiHotels = list.filter(item => item.amenities.filter(a => a.wiFi == true).length > 0)

    return wifiHotels.filter(item => item.amenities.filter(a => a.wifiQualities.filter(w => w.wifiRating >= filter.PropWifi).length > 0).length > 0)
}
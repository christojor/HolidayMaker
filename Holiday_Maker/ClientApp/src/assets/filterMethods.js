export function getByName(list, filter) {
    if (!filter.PropName) return list
    return list.filter(item => item.name == filter.PropStars)
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
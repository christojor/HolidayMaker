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
    return list.filter(item =>  item.rooms.price >= filter.PropMinPrice)
} 
export function getByMaxPrice(list, filter) {
    if (!filter.PropMaxPrice) return list
    return list.filter(item => item.rooms.price <= filter.PropMaxPrice)
}
<template>
    <div>
        <div
        class="fixed overflow-x-hidden overscroll-y-auto inset-0 flex justify-center items-center z-50"
        v-if="toggleModal"
        >
        <div class="relative mx-auto w-80 max-w-2xl">
            <div
            class="bg-white w-full rounded shadow-2xl flex flex-col space-y-5"
            style="padding: 20px"
            >
                <div class="text-2xl font-bold text-center">
                    <font-awesome-icon
                    :icon="['fas', 'heart']"
                    size="lg"
                    style="color: #52b788"
                    />
                    Save Favorite
                </div>

                <span class="text-center"
                    >Select list to save favorite</span
                >
                <select @click="SortListNames" v-model="groupName">
                    <option disabled value="">Select group</option>
                    <option v-for="list in groupList"  :value="list" :key="list">{{list}}</option>
                </select>

                <span class="text-center" style="margin-top: 20px"
                    >Create new list</span
                >
                <input type="text" v-model="newList" placeholder="NewListName">
                    <div>
                        <button
                            v-if="newList == ''"
                            disabled
                            class="rounded bg-gray-700 text-white py-2 w-5/12 m-auto shadow-lg outline-none active:outline-none focus:outline-none"
                            style="margin-right:10px; cursor: none"
                        >
                            Create and Save
                        </button>
                        <button
                            v-else
                            class="rounded bg-green-500 text-white py-2 w-5/12 m-auto shadow-lg hover:bg-green-400 outline-none active:outline-none focus:outline-none"
                            style="margin-right:10px"
                            @click="toggleModalMethod(true)"
                        >
                            Create and Save
                        </button>


                        <button
                            v-if="newList != '' || groupName == ''"
                            disabled
                            class="rounded bg-gray-700 text-white py-2 w-3/12 m-auto shadow-lg outline-none active:outline-none focus:outline-none"
                            style="margin-right:10px"
                        >
                            Save
                        </button>
                        <button
                            v-else
                            class="rounded bg-green-500 text-white py-2 w-3/12 m-auto shadow-lg hover:bg-green-400 outline-none active:outline-none focus:outline-none"
                            style="margin-right:10px"
                            @click="toggleModalMethod(true)"
                        >
                            Save
                        </button>
                        
                        <button
                            class="rounded bg-gray-500 text-white py-2 w-3/12 m-auto shadow-lg hover:bg-red-500 outline-none active:outline-none focus:outline-none"
                            @click="toggleModalMethod(false)"
                        >
                            Cancel
                        </button>
                    </div>
                </div>
            </div>
        </div>

        <div
        v-if="toggleModal"
        class="z-40 inset-0 opacity-25 bg-black fixed"
        ></div>
    </div>
</template>



<script>
export default {

    mounted(){
        this.SortListNames();
    },

    data(){
        return{
            groupList: [],
            newList: '',
            groupName: '',
            FavList: []
        }
    },
    props: {
        toggleModal: Boolean,
        accomodationObject: Object
    },
    computed:{
        GetUserFavorites(){
            return this.$store.state.userFavorites;
        }
    },

    methods: { 
        toggleModalMethod(toggleIcon) {
            if(toggleIcon == true){
                if(this.newList != ''){
                    this.groupName = this.newList
                    this.SetFavorite(this.groupName)
                    let toggleModal = false
                    this.$emit("emitToggle", toggleModal, toggleIcon)
                }

                else if(this.groupName != ''){
                    this.SetFavorite(this.groupName)

                    let toggleModal = false
                    this.$emit("emitToggle", toggleModal, toggleIcon)
                }
                else{
                    toggleIcon = false
                    let toggleModal = false
                    this.$emit("emitToggle", toggleModal, toggleIcon)
                }
            }
            else{
                let toggleModal = false;
                this.$emit("emitToggle", toggleModal, toggleIcon)
            }

            this.newList = ''
            this.groupName = ''

        },
            async SetFavorite(groupName){
                let data = { userId: this.$store.state.userId, accomodationId: this.accomodationObject.id, groupName: groupName };
                let rawResponse = await fetch('https://localhost:44323/api/User/favorites', {
                // tell the server we want to send/create data
                method: 'post',
                // and that we will send data json formatted
                headers: { 'Content-Type': 'application/json' },
                // the data encoded as json
                body: JSON.stringify(data)
            });
        },
        SortListNames(){
            if(this.GetUserFavorites == null){
                this.FavList = []
            }
            else{
               this.FavList = this.GetUserFavorites.userFavorite; 
            }
            
            this.FavList.forEach(item => {if(!this.groupList.includes(item.groupName)){this.groupList.push(item.groupName)}})
        }
    },

};
</script>
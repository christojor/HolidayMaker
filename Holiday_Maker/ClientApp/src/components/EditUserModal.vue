<template>
    <div>
        <div
        class="fixed overflow-x-hidden overscroll-y-auto inset-0 flex justify-center items-center z-50"
        v-if="toggleModal"
        >
        <div class="relative mx-auto max-w-2xl">
            <div
            class="bg-white w-full rounded shadow-2xl flex flex-col space-y-5"
            style="padding: 20px"
            >
            
                <span class="text-center">
                    <div class="text-2xl font-bold text-center">

                    Edit user
                </div>
                </span>
                <label for="UserName">Username</label>
                <input style="background: #f6f6f6; border-style: solid; border-color: black; border-width: 1px; border-radius: 5px" name="UserName" type="text" v-model="Username" />
                <label for="Email">Email</label>
                <input style="background: #f6f6f6; border-style: solid; border-color: black; border-width: 1px; border-radius: 5px" name="Email" type="text" v-model="Email"/>
                    <div>
                        <label style="margin-right: 112px" for="FirstName">First name</label>
                        <label for="LastName">Last name</label>
                        <br>
                        <input style="margin-right: 10px; background: #f6f6f6; border-style: solid; border-color: black; border-width: 1px; border-radius: 5px" name="FirstName" type="text" v-model="FirstName"/>
                        <input style="background: #f6f6f6; border-style: solid; border-color: black; border-width: 1px; border-radius: 5px" name="LastName" type="text" v-model="LastName"/>
                    </div>
                    <div>
                        <label style="margin-right: 130px" for="Country">Country</label>
                        <label for="City">City</label>
                        <br>
                        <input style="margin-right: 10px; background: #f6f6f6; border-style: solid; border-color: black; border-width: 1px; border-radius: 5px" name="Country" type="text" v-model="Country"/>
                        <input style="background: #f6f6f6; border-style: solid; border-color: black; border-width: 1px; border-radius: 5px" name="City" type="text" v-model="City"/>
                    </div>
                    <div>
                        <label style="margin-right: 88px" for="StreetAddress">Street address</label>
                        <label for="ZipCode">Zipcode</label>
                        <br>
                        <input style="margin-right: 10px; background: #f6f6f6; border-style: solid; border-color: black; border-width: 1px; border-radius: 5px" name="StreetAddress" type="text" v-model="StreetAddress"/>
                        <input style="background: #f6f6f6; border-style: solid; border-color: black; border-width: 1px; border-radius: 5px" name="ZipCode" type="text" v-model="ZipCode"/>
                    </div>
                <div style="width: 100%; text-align: center;">
                    <button @click="UpdateUserInfo(); ToggleModal();" class="rounded bg-green-500 text-white py-2 w-5/12 m-auto shadow-lg outline-none active:outline-none focus:outline-none hover:bg-green-700" style="margin-right:10px">Save</button>
                    <button @click="ToggleModal" class="rounded bg-gray-500 text-white py-2 w-5/12 m-auto shadow-lg outline-none active:outline-none focus:outline-none hover:bg-red-500">Cancel</button>
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
        this.Username = this.GetUserInfo.userName;
        this.Email = this.GetUserInfo.email;
        this.FirstName = this.GetUserInfo.firstName;
        this.LastName = this.GetUserInfo.lastName;
        this.Country = this.GetUserInfo.country;
        this.City = this.GetUserInfo.city;
        this.StreetAddress = this.GetUserInfo.streetAddress;
        this.ZipCode = this.GetUserInfo.zipCode;
    },

    data(){
        return{
            Username: null,
            Email: null,
            FirstName: null,
            LastName: null,
            Country: null,
            City: null,
            StreetAddress: null,
            ZipCode: null
        }
    },

    props: {
        toggleModal: Boolean,
    },
    computed:{
        GetUserInfo(){
            return this.$store.state.user;
        }
    },

    methods: {
        ToggleModal(){
            this.$emit('toggleEmit', false);
        },

    
        async UpdateUserInfo(){
            let userData = {id: this.$store.state.userId, userName: this.Username, email: this.Email, firstName: this.FirstName, lastName: this.LastName, country: this.Country, city: this.City, streetAddress: this.StreetAddress, zipCode: this.ZipCode, memberTypeId: this.$store.state.user.memberTypeId, memberPoints: this.$store.state.user.memberPoints};
            await fetch('https://localhost:44323/api/User/UpdateUserInfo', {
                method: 'put',
                headers: {'Content-Type': 'application/json'},
                body: JSON.stringify(userData)
            });

            this.$store.commit('setUser', userData);

        },
    },

};
</script>
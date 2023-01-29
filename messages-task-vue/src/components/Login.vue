<template>
    <div id="login">
        <a href="#" @click="toogle()">{{showLinkText}}</a>
         <div>
            <p><span>{{showLoginRegisterTextForm}}</span></p>
            <div>
                <label for="email">Email:</label><input @input="change" id="email-input" v-model="user.email" type="text" name="email" />
                <label for="pass">Password:</label><input v-model="user.password" type="password" name="pass" />
                <button v-if="isRegister" @click="login()"><span>Login</span></button>
                <button v-else @click="register()"><span>Register</span></button>
            </div>
         </div>
         <div style="color:red">
             {{errorText}}
         </div>
    </div>
</template>

<script>
    import { mapActions } from "vuex";
    import { User, api_register, api_login } from '../js/api.js'
    export default {
        name: 'loginPage',
        components: {
            
        },
        created() {
           this.user = new User();
        },
        computed: {
            showLinkText() {
                return (this.isRegister) ? "Register" : "Login";   
            },
            showLoginRegisterTextForm() {
                return (this.isRegister) ? "Fill the Login Form :" : "Fill the Register Form :";
            }
        },
        data() {
            return {
                user: null,
                isRegister: true,
                isValidEmail:false,
                errorText:""
            }
    },
    methods: {
        ...mapActions(['setMainUser']),
        login(){
             api_login(this.user,this.resultAPIpersist);
        },
        register() {
            api_register(this.user,this.resultAPIpersist);

        },
        toogle() {
            this.isRegister = (this.isRegister) ? false : true;
        },
        change() {
            var pattern = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/;
            var test = this.user.email.match(pattern);
            (test != null) ? this.isValidEmail = true : this.isValidEmail = false

        },
        resultAPIpersist(user) {
            console.log("result API persist");
            if (user.email == undefined) {
                this.errorText = user;
            }
            else {
                var mainUser = new User(user.id, user.email, undefined, user.totalNotif);
                this.setMainUser(mainUser);
                this.$router.push('/');
            }
            
        }
    }
        
    }
</script>


<template>
    <div id="home">
        <profil @update="reloadMessages"></profil>
        <div class="sending">
            <p>Send a message</p>
            <div class="sending-box">
                <div class="box">
                    <label>Recipient : </label>
                    <select v-model="selectedUserId" @input="change">
                        <option v-for="u in usersExeceptMe" :key="u.id" :value="u.id">{{u.email}}</option>
                    </select>
                </div>
                <div class="box">
                    <label>&nbsp;Body : </label>
                    <textarea v-model="messageText" cols="50" placeholder="Body of message"></textarea>
                </div>
                <div style="margin-left:3px;" class="box">
                    <button v-bind:disabled="inSendingProcess" @click="sendMessage()"><span>Send Message</span></button>
                </div>
                <div class="box" v-if="confirmText!=''" style="color:green">
                    {{confirmText}}
                </div>
            </div>
        </div>
        <div class="list-messages-box">
            <p>list of messages</p>
            <div class="list-messages" v-for="m in messages" :key="m.id">
                <div class="box">
                    <span>From : </span><b>{{m.senderEmail}}</b>
                </div>
                <div class="box">
                    <label>&nbsp;Body : </label>
                    <textarea cols="50" readonly v-model="m.body"></textarea>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import profil from '../components/global/Profil.vue'
    import { User, Message, api_setMessage, api_getMessages, api_getUsers } from '../js/api.js'
    export default {
        name: 'homePage',
        components: {
            profil
        },
        data() {
            return {
                messages: [],
                users: [],
                selectedUserId:"",
                messageText: "",
                confirmText: "",
                inSendingProcess:false
            }
        },
        created() {
            if (this.$store.state.user != null) {
                api_getUsers(this.resultUsersAPI);
                api_getMessages(this.$store.state.user, this.resultMessagesAPI)
            }

        },
        computed: {
            usersExeceptMe(){
                var arr  = [];
                this.users.forEach((user) => {  
                    if (this.$store.state.user != null && user.id != this.$store.state.user.id) {
                        if (this.selectedUserId == "") this.selectedUserId = user.id;
                        arr.push(new User(user.id, user.email));
                    }
                    
                });
                return arr;
            }
            /*
            isDisabled() {
                return (this.inSendingProcess) ? true : false
            }
            */

        },
        methods: {
            sendMessage() {
                console.log("send Message");
                var userReceipt = this.users.find(item => item.id == this.selectedUserId);
                var mess = new Message(null, this.$store.state.user.email, this.messageText, userReceipt.id);
                this.inSendingProcess = true;
                api_setMessage(mess,this.resultMessagesPersistAPI);

            },
            resultMessagesPersistAPI() {
                this.confirmText = "message sent";
                this.messageText = "";
                var self = this;
                setTimeout(function () {
                    self.confirmText = "";
                    self.inSendingProcess = false;
                }, 500);
            },
            resultMessagesAPI(data) {
                console.log("result API message");
                data.forEach((obj) => {
                    var mess = new Message(obj.id,obj.senderEmail,obj.body);
                    this.messages.push(mess);
                });
            },
            resultUsersAPI(data) {
                console.log("eezrrezr");
                data.forEach((obj) => {
                    this.users.push(new User(obj.id,obj.email));
                });
                
            },
            reloadMessages() {
                var toto = "tata";
                console.log(toto);
                this.messages = [];
                api_getMessages(this.$store.state.user, this.resultMessagesAPI);
            },
            change(event) {
               event.target.value;
                
            }
        },
    }
</script>


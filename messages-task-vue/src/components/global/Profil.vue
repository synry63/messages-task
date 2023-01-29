<template>
    <div id="profil">
        <b>{{getUserWelcome}}</b><span> you have <a href="#" @click="reloadMessages()">{{notificationText}}</a></span>
        <div>
            <a href="#" @click="logout()"><span>Logout</span></a>
        </div>
    </div>
</template>

<script>
    import { mapGetters } from "vuex";
    import { mapActions } from "vuex";
    import { api_userNotificationReset,api_logout } from '../../js/api.js'
    import { hubMessageChange } from '../../js/message-hub.js'


    export default {
        name: 'ProfilWidget',

        watch: {
            "$store.state.user": {
              handler: function(user) {
                if(user==null){
                    this.$router.push('/login');
                }
              },
              immediate: true
            }
        },
        created() {
            hubMessageChange(this.refreshTotalNotif); 
        },
        data() {
            return {
                totalNotification: 0
            }
        },
        methods: {
            ...mapActions(['setMainUser']),
            logout(){
                var self = this;
                var user = this.$store.state.user;
                api_logout(user,function(data){
                    if(data==true){
                        self.setMainUser(null);
                    }
                    
                });
                
            },
            refreshTotalNotif(total, userId) {
                if (this.$store.state.user.id == userId) {
                    this.totalNotification = total;
                }
            },
            reloadMessages() {
                api_userNotificationReset(this.$store.state.user.id, this.resultResetAPI);
                this.$emit('update');
            },
            resultResetAPI(total) {
                console.log("resultResetAPI");
                this.totalNotification = total;
            }
        },
        computed: {
        ...mapGetters(['getUserWelcome']),
            notificationText() {
                return (this.totalNotification > 1) ? this.totalNotification + " new messages" : this.totalNotification + " new message"
            }
        }
    }
</script>


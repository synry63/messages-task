<template>
        <div id="app">
            <img alt="Intesa Sanpaolo" src="./assets/Intesa_Sanpaolo.png">
            <router-view></router-view>
        </div>
</template>

<script>
    

    export default {
        name: 'App',
        components: {
            
        }
    }
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
        width:1000px;
        margin:auto;
    }
    #login {
        width: 550px;
        margin:auto;
        text-align:left;
    }
    #profil {
        text-align:right;
    }
    #home{
        text-align:left;
    }
    #home p{
        color:black;
    }
    .box {
        display: inline-table;
        vertical-align: top;
    }
    .sending-box{
        border:1px solid black;
        padding:5px;
    }
    .list-messages {
        border: 1px solid black;
        padding: 5px;
        margin-top:5px;
    }
    .box label {
        vertical-align: top;
    }
</style>

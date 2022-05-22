<template>
  <body class="footer">
    <hr>
    <ul class="footer-ul">
      <router-link class="logoS" :to="{ name: 'Home' }">Logo</router-link>
    </ul>
    <ul class="footer-ul-links">
        <li>CinemaVerse</li>
        <li>Check out our blogs</li>
        <li>Our Community</li>
        <li>Our Company</li>
        <li>© CinemaVerse, Inc. 2021. <br> We love our users!</li>
    </ul>
    <ul class="footer-ul">
        <li><a href="https://www.facebook.com/"><img src="../../assets/Icons/facebook.png"></a></li>
        <li><a href="https://twitter.com/home"><img src="../../assets/Icons/instagram.png" ></a></li>
        <li><a href="https://www.instagram.com/"><img src="../../assets/Icons/reddit.png"></a></li>
        <li><a href="https://www.reddit.com/"><img src="../../assets/Icons/twitter.png"></a></li>
    </ul>
</body>
</template>

<style>
    .footer{
        background-color: #140d3b;
        display: flex;
        flex-direction: column;
        padding:50px;
    }
    .footer hr{
        width:85%;
        align-self: center;
        margin: 30px;
    }
    .footer-ul{
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        margin-top:50px;
    }
    .footer-ul-links{
        display: flex;
        justify-content: space-around;
        margin-top:50px;
        color: blanchedalmond;
    }
    .footer ul li a img{
        width: 25px;
        height:25px;
    }
    .footer-ul li {
        margin-left: 100px;
    }
    ul li {
    list-style-type: none;
    }
    ul li a{
      text-decoration: none;
    }

    @media screen and (max-width: 1000px) {
    .footer{
        display: flex;
        flex-direction: column;
        padding:50px;
    }
    .footer hr{
        width:85%;
        align-self: center;
        margin: 30px;
    }
    .footer-ul{
        display: flex;
        margin-top:50px;
    }
    .footer-ul-links{
        display: flex;
        flex-wrap: wrap;
        justify-content: space-between;
        margin-top:50px;
    }

    .footer-ul-links li{
        padding: 20px;
        width: 80%;
        margin-left: 10%;
        margin-right: 10%;
        text-align: center;
    }

    .footer ul li a img{
        width: 25px;
        height:25px;
        margin-top: 10px;
    }
    .footer-ul li {
      display: flex;
      justify-content: space-around;
      padding: 25px;
      width: 80%;
      margin-left: 10%;
      margin-right: 10%;
    }

    .logoS{
      display: flex;
      justify-content: space-around;
      padding: 25px;
      width: 80%;
      margin-left: 10%;
      margin-right: 10%;
    } 

    ul li {
    list-style-type: none;
    }
    ul li a{
      text-decoration: none;
    }
    }
</style>

<script>


export default {
  name: "Footer",
  components: {
  },
  data() {
    return {};
  },
  created() {},
  mounted() {},
  methods: {},
  watch: {},
};
</script>

<template>
    <div class="nav">
        <div class="logo">
            <img src="../assets/logo.png"  alt="济病通在线问诊" width=18% height=16% >
            <span class="logo_name">济病通在线问诊</span>
        </div>
        <div class="navBar">
            <el-menu :default-active="this.$route.path" class="el-menu-demo"  router mode="horizontal" @select="handleSelect" active-text-color="#409EFF">
                <el-menu-item v-for="(item, i) in navList" :key="i" :index="item.name">
                  <template slot="title">                   
                    <span> {{ item.navItem }}</span>
                  </template>
                </el-menu-item>
            </el-menu>
            <div class="line"></div>
        </div>
        <div class="ava">
            <img :src="url" width="50px" height="50px" @click="move">
        </div>
    </div>
</template>

<script>
  export default {
    name:"Navigation",
    data() {
      return {
       url:'https://ui-avatars.com/api/?size=60&length=1&bold=true&background=6699CC&color=ffffff&rounded=true&name=User' ,
       navList: [
        { name: "/Home", navItem: "首页" },
        { name: "/online", navItem: "线上问诊" },
        { name: "/offline", navItem: "线下预约" },
        { name: "/mall", navItem: "健康商城" },
        { name: "/diseaseInfo", navItem: "疾病信息" },
      ],
      };
    },
    methods: {
      handleSelect(key, keyPath) {
        console.log(key, keyPath);
      },
      move()//进入个人信息界面
      {
        this.$router.push('/information1');
      }
    }
  }
</script>

<style lang="less" scoped>
.line{
  width:200px;
}
.nav{
   overflow-x:hidden;
}
/deep/.line{
  width:50%;
}
.navBar{
    position:absolute;
    left:45%;
    top:3%;
    min-width:800px;
   
}
/deep/.el-menu-item{
     font-family:"微软雅黑";
    font-size:18px;   
}
.logo{
    position:absolute;
    left:10%;
    top:3%;
}
.logo_name{
    font-family:"幼圆";
    font-size:30px;
}
img{
    vertical-align:middle;
}
.ava{
    position:absolute;
    left:90%;
    top:4%;
    cursor: pointer;
}
</style>
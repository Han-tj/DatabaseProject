<template>
  <div class="docList">
    <Navigation></Navigation>
     <div class="pic">
            <el-carousel :interval="4000"  height="350px" indicator-position="outside">
            <el-carousel-item v-for="item in imagesBox" :key="item.id">
            <img :src="item.idView" class="image">
            </el-carousel-item>
            </el-carousel>
    </div>
    <div class="announce">
        <announcement
        ref="listItem" :dataList="newList"></announcement>
    </div>
    <div class="pa">
        <Patients></Patients>
    </div>
    <div class="acid">
        <acid @onSubmit = submitForm></acid>
    </div>
    
    
  </div>
</template>

<style scoped>
.docList{
  overflow-y: scroll;
}
.pa{
    position: absolute;
    top:500px;
    left:900px;
}
.acid{
    position: absolute;
    top:970px;
    left:900px;
}
.announce{
    position:absolute;
    top:500px;
    left:250px;

}
.button1{
    position:absolute;
    top:10px;
    left:900px;
}
.online{
    position:relative;
    top:465px;
    left:260px;
}
.partition{
    position:absolute;
    left:0%;
    top:10px;
    font-family:"微软雅黑";
    font-size:25px;
}
.bu{
    font-size:18px;
}
 .link-top {
     position:absolute;
    left:0px;
    top:50px;
    width: 1000px;
    height: 100px;
    border-top: solid #ACC0D8 2px;
        }
.offline{
     position:relative;
    top:1080px;
    left:240px;
}
.select{
    position: absolute;
    left:17%;
    top:18%
}
.card{
    position:absolute;
    left:-55px;
    top:50px;
}
.card1{
    position: absolute;
    left:-55px;
    top:50px
}
.search{
    position:absolute;
    left:45%;
    top:18%
}
img {
  /*设置图片宽度和浏览器宽度一致*/
  width: 100%;
  height: inherit;
}
.page{
    position: absolute;
    left:70%;
    top:100%
}
.pic{
    position:absolute;
    width:99.4%;
    height:auto;
    top:110px;
}
</style>

<script>
import Navigation from "@/components/Navigation.vue";
import announcement from '@/components/announcement.vue';
import Patients from '@/components/patients_know.vue';
import acid from '@/components/n_acid.vue'
import {getNoticeFun, sendAcidFormFun} from '@/service/userService.js';

export default {
  name: "Home",
  components: {
    Navigation,
    announcement,
    Patients,
    acid
  },
  data() {
    return {
      newList: [],
      isFormVisible:false,
       imagesBox:[
            { id:0,idView:require("@/assets/photo1.png") },
            { id:1,idView:require("@/assets/photo2.png") },
      ]
    };
  },
  created() {
    this.getDataList();
  },
  methods: {
  getDataList(){
    getNoticeFun(
    ).then(res=>{
      for(let i of res.result){
        this.newList.push({
          name:i.notice_name,
          content:i.content,
          time:i.time,   
        }
        );
      }
    }).catch(err=>{
        console.log(err);
    });
  },
    submitForm(mes){//该函数得到了核酸预约单并发送
      mes.patId = this.$store.state.userId//在表单中加入用户id
      console.log(mes)
      sendAcidFormFun({
        pati_id:mes.patId,
        hos_name:mes.region,
        status:1//已完成
      }).
      then(res =>{//间歇性bug
        console.log(typeof(res.result))
        if(res.result === 1) this.$message({
          message:'预约成功',
          type:'success'
        })
      })
      .catch(err => {
        console.log(err)
      })
    },
  },
};
</script>

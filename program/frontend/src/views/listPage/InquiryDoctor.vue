<template>
  <div>
    <div class="navigation">
      <div class="image">
        <img :src="`http://106.14.45.227:8080/${num}.png`" height="44px">
      </div>
      <inquiry_navigation_doc></inquiry_navigation_doc>
    </div>
    <div class="text">
      <inquiry_title></inquiry_title>
      <text_box></text_box>
<!--      <chatroom></chatroom>-->
    </div>
    <div class="record">
      <div class="tab_pos">
        <tabs></tabs>
      </div>
    </div>
  </div>


</template>

<script>
import {getDocInfoData} from "@/service/userService";
import text_box from "@/components/text_box";
import inquiry_record from "@/components/medicalrecord_form";
import tabs from "@/components/tabs";
import inquiry_title from "@/components/inquiry_title";
import inquiry_navigation_doc from "@/components/inquiry_navigation_doc";
export default {
  name: "Inquiry",
  components:{
    inquiry_title,
    text_box,
    inquiry_record,
    tabs,
    inquiry_navigation_doc,
  },
  data(){
    return{
      num:null,
    }
  },
  created() {
    getDocInfoData({
      id:this.$store.state.inquiry.doctorId
    }).then(res=>{
      let temp=res.result.picture_url;
      if(temp.length==32){
        this.num=res.result.picture_url.substring(27,28);
      }
      else{
        this.num=res.result.picture_url.substring(27,29);
      }
      this.num = temp
    }).catch(err=>{
      console.log(err);
    })
  }
}
</script>
<style scoped>

.navigation{
  position: absolute;
  padding-top: 10px;
  /*top:10px;*/
  width:64px;
  height: 98.5%;
  background: RGB(70,80,105);

  /*background: RGB(236,245,255);*/
}
.image{
  padding-top: 15px;
  padding-left: 10px;
}
.text{
  position: absolute;
  top:0;
  left: 64px;
  bottom: 0;
  width: 65%;
  height: 100%;
  box-shadow: 0 2px 4px rgba(0, 0, 0, .12);
  overflow: hidden
}

.record{
  position: absolute;
  padding: 0;
  margin: 0;
  top:0;
  right:0;
  bottom: 0;
  width: 30%;
  border: 0;
  overflow: hidden
}
.tab_pos{
  position: relative;
  margin: auto;
  top:15px;
  left:20px;
  overflow: hidden
}

</style>

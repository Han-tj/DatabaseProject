<template>
  <div class="docList">
    <Navigation></Navigation>
    <div class="select">
      <myselect
        :selectedOptions="options"
        :selectedData="hosList"
        @selectData="changeData"
      >
      </myselect>
    </div>
    <div class="search">
        <mysearch
        :selectedOptions="options"
        :selectedData="hosList"
        @selectData="changeData"></mysearch>
    </div>
    <div class="card">
      <cardHos ref="listItem" :dataList="hosData">
        <el-button type="primary" class="button" @click="showForm" >预约</el-button>
      </cardHos>
      <myform  :isVisible="isFormVisible" @formSubmit='submitForm' @formClose='closeForm' ></myform>
    </div>
  </div>
</template>

<style scoped>
.docList{
  overflow-y: scroll;
}
.select{
    position: absolute;
    left:17%;
    top:18%
}
.card{
    position:absolute;
    left:14%;
    top:23%
}
.search{
    position:absolute;
    left:45%;
    top:18%
}
.page{
    position: absolute;
    left:70%;
    top:100%
}
</style>

<script>
import Navigation from "@/components/Navigation.vue";
import myselect from "@/components/singleSelect.vue";
import mysearch from '@/components/searchingSelect.vue'
import myform from "@/components/orderFormHos.vue";
import {getHosFun,sendOfflineReFun} from "@/service/userService.js";
import cardHos from '@/components/hosList.vue';

export default {
  name: "offline",
  components: {
    myselect,
    myform,
    Navigation,
    mysearch,
    cardHos
  },
  data() {
    return {
      hosList: [],
      hosData: [],
      options: [],
      isFormVisible:false,
    };
  },
  created() {
    this.getDataList();
  },
  methods: {
    getDataList(){
      getHosFun(
      ).then(res=>{
        let count=1;
        for(let i of res.result){
          this.hosList.push({
            name:i.hos_name,
            index:i.hos_Loc,
            tel:'电话：'+i.tel,
            pic:count,                   //以便图片路径拼接
            intro:i.introduction,    
          }
          );
          count++;
        }
        this.hosData = this.hosList;
        this.getOptions()
      }).catch(err=>{
         console.log(err);
      });
    },
    getOptions(){
      let obj = {}
       this.options.push(
        {value:'全部',
        label:'全部'
        }
      )
      for(let i of this.hosList){
        if(!obj[i.index]){
          obj[i.index] = 1
          this.options.push({
            value:i.index,
            label:i.index
          })
        }
      }
    },
    changeData(newdata) {
      this.hosData = newdata;
    },
    showForm(mes){
      this.isFormVisible = true
      this.$refs.listItem.recordLocation(mes)
    },
    closeForm(){
      this.isFormVisible = false
    },
    submitForm(mes){
      mes.hosname = this.$refs.listItem.lastCardInfo._name
      sendOfflineReFun({
        pati_id:this.$store.state.userId,
        hos_name:mes.hosname,
        department:mes.region,
        time:mes.date1,
        status:1//已完成的意思
      })
      .then(res => {
        if(res.result === 1 ) this.$message({
          message:'提交成功',
          type:'success'
        })
      })
      .catch(err =>{
        console.log(err)
      })
    },
  },
};
</script>

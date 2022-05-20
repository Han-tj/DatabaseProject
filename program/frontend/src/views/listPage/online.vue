<template>
  <div class="docList">
    <Navigation></Navigation>
    <div class="select">
      <myselect
        :selectedOptions="options"
        :selectedData="docList"
        @selectData="changeData"
      >
      </myselect>
    </div>
    <div class="search">
        <mysearch
        :selectedOptions="options"
        :selectedData="docList"
        @selectData="changeData"></mysearch>
    </div>
    <div class="card">
      <cardList ref="listItem" :dataList="docData">
        <el-button type="primary" class="button" @click="showForm" >预约</el-button>
      </cardList>
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
    left:10%;
    top:23%;

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
import cardList from "@/components/docList.vue";
import myselect from "@/components/singleSelect.vue";
import mysearch from '@/components/searchingSelect.vue'
import myform from "@/components/orderForm.vue";
import {getDocDataFun} from "@/service/userService.js";
import {postReservationFun} from '@/service/userService.js';

export default {
  name: "online",
  components: {
    cardList,//卡片列表
    myselect,//筛选框
    myform,//弹出表单
    Navigation,
    mysearch,//搜索框
  },
  data() {
    return {
      docList: [],
      docData: [],
      options: [],
      isFormVisible:false
    };
  },
  created() {
    this.getDataList();
  },
  methods: {
    getDataList(){
      getDocDataFun(
      ).then(res=>{//从后端请求到医生信息 也是筛选/搜索时直接处理的数据
      let count = 1
        for(let i of res.result){
          this.docList.push({//这里不直接复制，而是将department属性改名为index 以便检索
            id:i.doctor_ID,
            name:i.doctor_name,
            title:i.title,
            index:i.department,
            sex:i.sex,
            workingAge:i.working_age,
            hos:i.hos_name,
            pic:count,//图片直接放url不能请求到 需要重写 这里记录了一个编号 在docList会用到
            intro:i.introduction,    
          }
          );
          count++
        }
        console.log(this.docList)
        this.docData = this.docList;//这里是展示的数据
        this.getOptions()
      }).catch(err=>{
         console.log(err);
      });
    },
    getOptions(){//获得所有可能的index
        let obj = {}
        this.options.push({value:'全部', label:'全部'})
        for(let i of this.docList){
          if(!obj[i.index]){
            obj[i.index] = 1
            this.options.push({
              value:i.index,
              label:i.index
              })
          }
        }
    },
    changeData(newdata) {//当筛选完毕后 更新展示数据
      this.docData = newdata;
    },
    showForm(mes){ 
      this.isFormVisible = true//弹出表单
      this.$refs.listItem.recordLocation(mes)//告知卡片列表子组件 要求对本页面的点击事件mes进行定位 
    },
    closeForm(){//表单子组件关闭后 父组件处同步更新 否则不能重复点击
      this.isFormVisible = false
    },
    submitForm(mes){//获得了表单
    //向表单信息添加新信息
    
      mes.docId = this.$refs.listItem.lastCardInfo._id
      console.log(mes.docId)
       postReservationFun({
        pati_id:this.$store.state.userId,                 
        doctor_id:mes.docId,  
        time:mes.date1,
        status:1//待确认的意思
      }).then(res=>{
        if(res.result === true) this.$message({
          message:'提交成功',
          type:'success'
        })
      }).catch(err=>{
        console.log(err);
      })
    },
  },
};
</script>

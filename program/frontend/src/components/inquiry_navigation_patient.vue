<template>
<div>

  <el-menu default-active="1-4-1"
           class="el-menu-vertical-demo"
           :collapse="isCollapse"
           width="76.8px"
           style="padding-top: 10px"
           background-color="RGB(70,80,105)">
    <el-menu-item
        @click="dialogAssessVisible=true"
        index="2">
      <i class="el-icon-star-off"></i>
      <span slot="title">评价</span>
    </el-menu-item>
    <el-dialog title="问诊评价" center :visible.sync="dialogAssessVisible" width="30%">
      <el-form :model="formAssess" :disabled="formAssessDisabled">
        <el-form-item label="医生态度" :label-width="formLabelWidth">
            <el-rate
                :texts="docAttitude"
                v-model="formAssess.value1"
                :colors="colors"
                show-text>
            </el-rate>
        </el-form-item>
        <el-form-item label="病情分析" :label-width="formLabelWidth">
          <el-rate
              :texts="diseaseAnalyses"
              v-model="formAssess.value2"
              :colors="colors"
              show-text>
          </el-rate>
        </el-form-item>
        <el-form-item label="诊疗方案" :label-width="formLabelWidth">
          <el-rate
              :texts="treatment"
              v-model="formAssess.value3"
              :colors="colors"
              show-text>
          </el-rate>
        </el-form-item>
        <el-form-item label="更多评价" :label-width="formLabelWidth">
          <el-input
              type="textarea"
              class="input"
              v-model="formAssess.more"
              :autosize="{ minRows: 2, maxRows: 4}"
          ></el-input>
        </el-form-item>
        <el-form-item>
          <div class="button">
            <el-button type="primary" @click="submit">生成</el-button>
            <el-button @click="clearAllContent">清空</el-button>
          </div>
        </el-form-item>
      </el-form>
    </el-dialog>
    <el-menu-item index="3" @click="quit">
      <i class="el-icon-back"></i>
      <span slot="title">退出</span>
    </el-menu-item>
  </el-menu>
</div>
</template>

<script>
import {postRateDataFun} from "../service/userService";

export default {
name: "inquiry_navigation",
  data() {
    return {
      isCollapse: true,
      dialogAssessVisible:false,//对话框可见属性
      formAssessDisabled:false,//评价表单禁用设置
      formLabelWidth: '120px',//表单标签宽度
      formAssess:{
        time:'',//提交时间
        more:'',//更多评价
        content:'',
        value1:null,//医生态度rate
        value2:null,//病情分析rate
        value3:null,//诊疗方案rate
      },
      colors: ['#99A9BF', '#F7BA2A', '#FF9900'],
      docAttitude:['极差','失望','一般','很好','满意'],
      diseaseAnalyses:['极差','失望','一般','标准','精准'],
      treatment:['不满','失望','一般','很好','满意']
    };
  },
  methods: {
    postRate(){//上传评价表
      postRateDataFun({
        pati_id:this.$store.state.inquiry.patientId,
        doctor_id:this.$store.state.inquiry.doctorId,
        time:this.formAssess.time,
        content:this.formAssess.content
      }).then(res=>{
        console.log(res);
      }).catch(err=>{
        console.log(err);
      })
    },
    submit(){//提交评价表单
      if(this.formAssess.value1==0||this.formAssess.value2==0||this.formAssess.value3==0){
        this.$message({
          message: '请评价好问诊各项信息再提交',
          type: 'warning'
        });
      }else{
        console.log(this.formAssess.value3+'_'+this.formAssess.value2);
        let date=new Date().getDate();
        let month=new Date().getMonth()+1;
        let year=new Date().getFullYear();
        this.formAssess.time=month+'-'+date+'-'+year;//获取当前上传日前
        this.formAssess.content='医生态度：' +this.docAttitude[this.formAssess.value1]+'-'
            +'病情分析：'+this.diseaseAnalyses[this.formAssess.value2]+'-'
            +'诊疗方案：'+this.treatment[this.formAssess.value3]+'——'
            +'更多评价：'+this.formAssess.more;//拼接评价内容
        this.postRate();//post评价表
        this.formAssessDisabled=true;
        this.dialogAssessVisible = false;
      }
    },
    clearAllContent(){//清空评价表单
      this.formAssess.value1=null;
      this.formAssess.value2=null;
      this.formAssess.value3=null;
      this.formAssess.more='';
    },
    quit(){
      clearInterval(this.$store.state.inquiry.chatroomId);
      this.$router.push('/Home');
    }
  }
}
</script>

<style scoped>
.el-menu-vertical-demo:not(.el-menu--collapse) {
  width: 200px;
  min-height: 400px;
}
/deep/ .el-rate__icon{
  font-size: 35px;
}
.button{
  position: relative;
  width: 50%;
  left: 33%;
}
.input{
  width: 210px;
}
.el-menu-item.is-active {
  background-color: RGB(70,80,105) !important;
}
.el-menu-item:hover {
  background-color: RGB(70,80,105) !important;
}

</style>

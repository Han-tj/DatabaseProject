<template>
  <div>
    <el-menu default-active="1-4-1"
             class="el-menu-vertical-demo"
             :collapse="isCollapse"
             width="76.8px"
             style="padding-top: 10px"
             background-color="RGB(70,80,105)">
      <el-menu-item
          @click="dialogReportVisible=true"
          index="1">
        <i class="el-icon-warning-outline"></i>
        <span slot="title">举报</span>
      </el-menu-item>
      <el-dialog title="举报患者" center :visible.sync="dialogReportVisible" width="30%">
        <el-form :model="formReport" :disabled="formReportDisabled">
          <el-form-item label="举报类型" :label-width="formLabelWidth">
            <el-radio v-model="formReport.radio" label="1">人格侮辱</el-radio>
            <el-radio v-model="formReport.radio" label="2">内容色情</el-radio>
            <el-radio v-model="formReport.radio" label="3">故意引战</el-radio>
            <el-radio v-model="formReport.radio" label="4">胡搅蛮缠</el-radio>
          </el-form-item>
          <el-form-item label="举报理由" :label-width="formLabelWidth">
            <el-input
                type="textarea"
                v-model="formReport.desc"
                class="input"
                :autosize="{ minRows: 2, maxRows: 4}"
            ></el-input>
          </el-form-item>
          <el-form-item>
            <div class="button">
              <el-button type="primary" @click="submit">生成</el-button>
              <el-button @click="clearAllReportContent">清空</el-button>
            </div>
          </el-form-item>
        </el-form>
      </el-dialog>
      <el-menu-item index="3" @click="quit">
        <i class="el-icon-back"></i>
        <span slot="title">结束</span>
      </el-menu-item>
    </el-menu>
  </div>
</template>

<script>
import {postReportDataFun} from "../service/userService";

export default {
  name: "inquiry_navigation_patient",
  data() {
    return {
      isCollapse: true,
      dialogReportVisible:false,//举报对话可见
      formReport:{//举报表单
        time:'',//举报时间
        desc:'',//举报理由
        content:'',//举报内容
        radio:0,
      },
      text:['人格侮辱','内容色情','故意引战','胡搅蛮缠'],//举报单选文字表
      formLabelWidth: '120px',//表单标签宽度
      formReportDisabled:false//举报表单禁用设置
    };
  },
  methods: {
    submit(){//提交举报
      if(this.formReport.radio!=0&&this.formReport.content!=''){
        let date=new Date().getDate();
        let month=new Date().getMonth()+1;
        let year=new Date().getFullYear();
        this.formReport.time=month+'-'+date+'-'+year;
        this.formReport.content=this.text[this.formReport.radio-1]+'——'+this.formReport.desc;
        console.log(this.formReport.content);
        postReportDataFun({
          pati_id:this.$store.state.inquiry.patientId,
          doctor_id:this.$store.state.inquiry.doctorId,
          time:this.formReport.time,
          content:this.formReport.content,
        }).then(res=>{
          console.log(res);
        }).catch(err=>{
          console.log(err);
        })
        this.dialogReportVisible = false;//关闭举报对话
        this.formReportDisabled=true;//举报表单禁用
        console.log('submit!report')
      }
      else{//没有完整填写举报表单
        this.$message({
          message: '请完整填写举报相关信息再提交',
          type: 'warning'
        });
      }
    },
    clearAllReportContent(){//清空举报表单
      this.formReport.radio=0;
      this.formReport.desc='';
    },
    quit(){
      clearInterval(this.$store.state.inquiry.chatroomId);//停止轮询
      this.$router.push('/homepage');//退出，跳转到主页
    }
  }
}
</script>

<style scoped>
.el-menu-vertical-demo:not(.el-menu--collapse) {
  width: 200px;
  min-height: 400px;
}
::v-deep .el-rate__icon{
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

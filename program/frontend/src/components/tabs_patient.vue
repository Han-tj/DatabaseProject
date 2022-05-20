<template>
  <div class="tabs">
    <el-tabs v-model="activeName" >
      <el-tab-pane label="查看病历" name="first" >
        <el-form :model="diseaseDecidedForm" size="mini" label-width="90px" >
          <el-form-item label="患者姓名：">
            <span>{{diseaseDecidedForm.patientName}}</span>
          </el-form-item>
          <el-form-item label="患者主诉：">
            <span>{{diseaseDecidedForm.desc}}</span>
          </el-form-item>
          <el-form-item label="诊断疾病：">
            <span>{{diseaseDecidedForm.disease}}</span>
          </el-form-item>
          <el-form-item label="所属科室：">
            <span>{{diseaseDecidedForm.department}}</span>
          </el-form-item>
          <el-form-item label="相应症状：">
            <el-checkbox-group v-model="diseaseDecidedForm.type" disabled>
              <el-checkbox label="头痛"></el-checkbox>
              <el-checkbox label="头昏"></el-checkbox>
              <el-checkbox label="心悸"></el-checkbox>
              <el-checkbox label="胸闷"></el-checkbox>
              <el-checkbox label="胸痛"></el-checkbox>
              <el-checkbox label="发热"></el-checkbox>
              <el-checkbox label="咳嗽"></el-checkbox>
              <el-checkbox label="咳痰"></el-checkbox>
              <el-checkbox label="鼻衄"></el-checkbox>
              <el-checkbox label="耳鸣"></el-checkbox>
              <el-checkbox label="眼花"></el-checkbox>
              <el-checkbox label="乏力"></el-checkbox>
              <el-checkbox label="消瘦"></el-checkbox>
              <el-checkbox label="浮肿"></el-checkbox>
              <el-checkbox label="呕吐"></el-checkbox>
              <el-checkbox label="尿痛"></el-checkbox>
              <el-checkbox label="便秘"></el-checkbox>
              <el-checkbox label="腹泻"></el-checkbox>
              <el-checkbox label="多饮"></el-checkbox>
              <el-checkbox label="多食"></el-checkbox>
              <el-checkbox label="多尿"></el-checkbox>
              <el-checkbox label="皮疹"></el-checkbox>
              <el-checkbox label="呼吸困难"></el-checkbox>
              <el-checkbox label="关节肿痛"></el-checkbox>
              <el-checkbox label="视力模糊"></el-checkbox>
              <el-checkbox label="四肢麻木"></el-checkbox>
            </el-checkbox-group>
          </el-form-item>
        </el-form>
        <el-form :model="buttonForm" size="mini" label-width="90px" :disabled="preButtonDiabled">
          <div class="button">
            <el-button size="medium" type="primary" @click="getPre">生成</el-button>
          </div>
        </el-form>
      </el-tab-pane>

      <el-tab-pane label="查看处方"  name="second" :disabled="includeTabDisabled" >
        <div class="form_body">
          <el-form :model="includeForm" size="mini" label-width="90px" >
            <el-form-item label="患者姓名：">
              <span>{{diseaseDecidedForm.patientName}}</span>
            </el-form-item>
            <el-form-item label-position="top"  label="初步诊断：">{{diseaseDecidedForm.disease}}</el-form-item>
          </el-form>
          <el-form label-position="top" :model="includeForm" size="mini" label-width="90px" >
            <el-form-item  label="处理意见：">
              <el-table
                  :data="includeForm.data">
                <el-table-column
                    fixed
                    prop="name"
                    width="160px"
                    label="药品">
                </el-table-column>
                <el-table-column
                    fixed
                    prop="num"
                    width="70px"
                    label="数量/盒">
                </el-table-column>
                <el-table-column
                    fixed
                    prop="method"
                    width="180px"
                    label="用法">
                </el-table-column>
              </el-table>
            </el-form-item>
            <el-form :model="buttonForm" size="mini" label-width="90px" >
              <div class="twoButton">
                <el-button size="medium" type="primary" @click="getDrugs" :disabled="includeButtonDiabled">获取处方</el-button>
                <el-button size="medium" @click="autoAddDrugsToCart" :disabled="addDrugsDisabled">一键加购</el-button>
              </div>
            </el-form>
          </el-form>
        </div>
     </el-tab-pane>
      <el-tab-pane label="医生信息" name="third">
      <doc_info></doc_info>
      </el-tab-pane>
    </el-tabs>
  </div>

</template>

<script>
import doc_info from "./doc_info";
import {getDrugsIncludedListDataFun,getPreDataFun,getPatientInfoDataFun,postAutoAddDataFun} from "@/service/userService";
import {} from "@/service/userService";
export default {
  name: "tabs_patient",
  components:{
    doc_info
  },
  data() {
    return {
      activeName: 'third',//tab的初始位置
      preButtonDiabled:false,//病历表button禁用设置
      includeButtonDiabled:false,//处方表button禁用设置
      includeTabDisabled:true,//处方tab单元的禁用设置
      addDrugsDisabled:true,
      buttonForm:{},//单独的按钮表单
      includeForm:{//处方表单
        data:[],//存储药品表格数据
      },
      diseaseDecidedForm: {//病历表单
        patientName:this.$store.state.inquiry.patientName,//病人姓名（通过store中patientId与调用getPatient接口获取）
        disease: '等待医生填写',//疾病
        department:'等待医生填写',//科室
        type:[],//症状多选框数组
        desc: '等待医生填写'//主诉
      }
    };
  },
  methods: {
    getDrugs(){//获取处方信息
      getDrugsIncludedListDataFun({
        pre_id:this.$store.state.inquiry.preId
      }).then(res=>{
        if(res.result.length!=0){//当成功获取到处方信息时
          for(let i=0;i<res.result.length;i++){
            this.includeForm.data.push({//装入药品表格数据
              name:res.result[i].medicine_name,
              num:res.result[i].quantity,
              method:res.result[i].content
            })
          }
          this.includeButtonDiabled=true;//将刷新处方获取按钮禁用
          this.addDrugsDisabled=false;//将一键购药开放
        }
      }).catch(err=>{
        console.log(err);
      })
    },
    getPre(){//获取病历
      getPreDataFun({
        pati_id:this.$store.state.inquiry.patientId,
        doctor_id:this.$store.state.inquiry.doctorId
      }).then(res=>{
        console.log(res);
        if(res.result.prescription_ID!=null){//当成功获取到病历信息时
          this.diseaseDecidedForm.department=res.result.department;//装入科室信息
          this.$store.commit("editInquiryPreId",res.result.prescription_ID);//装入处方id信息，存到store，供处方组件使用
          let content=res.result.prescription_Content;//获取content
          let temp=content.split('——');//处理content
          this.diseaseDecidedForm.desc=temp[0];//第一部分：患者主诉
          this.diseaseDecidedForm.disease=temp[1];//第二部分：诊断疾病
          let index=temp[2].split('-');//处理第三部分（由多选框数组构成）
          for(let i=0;i<index.length;i++){//装入
            this.diseaseDecidedForm.type.push(index[i]);
          }
          this.preButtonDiabled=true;//设置病历刷新按钮禁用
          this.includeTabDisabled=false;//设置处方tab单元可用
        }
      }).catch(err=>{
        console.log(err);
      })
    },
    autoAddDrugsToCart(){
      postAutoAddDataFun({
        pati_id:this.$store.state.inquiry.patientId,
        pre_id:this.$store.state.inquiry.preId
      }).then(res=>{
        this.addDrugsDisabled=true;
        this.$message({
          message:'自动加购成功',
          type:'success'
        })
        console.log(res);
      }).catch(err=>{
        console.log(err);
      })
    }
  },
  mounted() {
    //
  }
}
</script>

<style scoped>
.tabs{
  position: relative;
  width: 90%;
  height: 100%;
}
/deep/.tab_pos{
  left:0px;
  right: 0px;
}
/deep/.el-tabs__item{
  font-weight: bolder;
  padding: 0 15px;
}

/deep/.el-checkbox{
  margin-right: 6px;
}
/deep/.el-form--label-top .el-form-item__label{
  padding-left: 10px;
}
.button{
  position: relative;
  width: 50%;
  left: 43%;
}
.twoButton{
  position: relative;
  width: 50%;
  left: 24%;
}
</style>

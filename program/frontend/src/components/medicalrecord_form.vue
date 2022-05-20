<template>
  <div class="form_body">
    <el-form :model="diseaseDecidedForm" size="mini" label-width="90px" :disabled="writeDisabled">
      <el-form-item label="患者姓名：">
        <span>{{this.$store.state.inquiry.patientName}}</span>
      </el-form-item>
      <el-form-item label="患者主诉：">
        <el-input
            placeholder="请输入内容"
            class="input"
            v-model="diseaseDecidedForm.desc"
            clearable>
        </el-input>
<!--        <el-input-->
<!--            class="input"-->
<!--            type="textarea"-->
<!--            v-model="diseaseDecidedForm.desc"-->
<!--            placeholder="请输入"-->
<!--        ></el-input>-->
      </el-form-item>
      <el-form-item label="诊断疾病：">
        <el-select v-model="diseaseDecidedForm.disease" filterable placeholder="请选择疾病">
          <el-option
              v-for="item in diseases"
              :key="item.label"
              :label="item.label"
              :value="item.label">
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="所属科室：">
        <el-select v-model="diseaseDecidedForm.department" filterable placeholder="请选择科室">
          <el-option
              v-for="item in departments"
              :key="item.label"
              :label="item.label"
              :value="item.label">
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="相应症状：">
        <el-checkbox-group v-model="diseaseDecidedForm.type">
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
      <el-form-item>
        <el-button size="medium" type="primary" @click="onSubmit">生成</el-button>
        <el-button size="medium" @click="clearAllContent">清空</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import {postPreDataFun,getDiseaseListDataFun,getDepartmentListDataFun} from "@/service/userService";
export default {
  name: "inquiry_record",
  data() {
    return {
      departments:[],//所有科室
      diseases:[],//所有疾病
      diseaseDecidedForm: {
        disease: '',//疾病
        department:'',//科室
        type: [],//症状
        content:'',
        time:'',
        desc: '',//患者主诉
      },
      writeDisabled:false,//病历表单禁用设置
    }
  },
  created() {
    this.load();//加载用于选择/筛选的疾病信息，药品信息，科室信息
  },
  methods: {
    postPre(){
      postPreDataFun({//上传病历信息
        Pati_ID:this.$store.state.inquiry.patientId,
        Doctor_ID:this.$store.state.inquiry.doctorId,
        department:this.diseaseDecidedForm.department,
        time:this.diseaseDecidedForm.time,
        content:this.diseaseDecidedForm.content
      }).then(res=>{
        let preId=res.result.prescription_ID;
        this.$store.commit("editInquiryPreId",preId);
        console.log(res);
      }).catch(err=>{
        console.log(err);
      })
    },
    load(){//预加载
      getDiseaseListDataFun(//加载所有疾病
      ).then(res=>{
        for(let i=0;i<res.result.length;i++){
          this.diseases.push({
            // "value":"选项"+i,
            "label":res.result[i].disease_Name
          })
          // console.log(this.diseases);
        }
      }).catch(err=>{
        console.log(err);
      })
      getDepartmentListDataFun(//加载所有科室
      ).then(res=>{
        for(let i=0;i<res.result.length;i++){
          this.departments.push({
            "label":res.result[i].department,
          })
        }
        // console.log(this.departments);
      }).catch(err=>{
      })
    },
    onSubmit() {//提交病历表单
      let date=new Date().getDate();
      let month=new Date().getMonth()+1;
      let year=new Date().getFullYear();
      this.diseaseDecidedForm.time=month+'-'+date+'-'+year;
      let content=this.diseaseDecidedForm.desc+'——'+this.diseaseDecidedForm.disease+'——';
      let i=0;
      for(i=0;i<this.diseaseDecidedForm.type.length-1;i++){
        content=content+this.diseaseDecidedForm.type[i]+'-';
      }
      content=content+this.diseaseDecidedForm.type[i];
      this.diseaseDecidedForm.content=content;
      this.$store.commit("editDiseaseDecided",this.diseaseDecidedForm.disease);
      this.postPre();
      this.writeDisabled=true;
      this.$store.commit("editInquiryIncludeDisabled",false);
      console.log('submit!');
    },
    clearAllContent(){//清空病历表单内容
      this.diseaseDecidedForm.desc='';
      this.diseaseDecidedForm.disease='';
      this.diseaseDecidedForm.department='';
      this.diseaseDecidedForm.type=[];
    }
  },

}
</script>

<style scoped>
/*.form_body{*/
/*  width: 99%;*/
/*  height: 100%;*/
/*  border: 0;*/
/*  left:20px;*/
/*  font-family: "微软雅黑";*/
/*  overflow: auto;*/
/*}*/
/*/deep/.el-form-item{*/
/*  font-size: 10px;*/
/*  margin-bottom: 1px;*/
/*}*/
/*/deep/.el-form-item--mini.el-form-item{*/
/*  margin-bottom: 6px;*/
/*}*/
.el-textarea__inner{
  font-family:"Microsoft";
  font-size:20px;
}
.input{
  width: 199px;
}

</style>

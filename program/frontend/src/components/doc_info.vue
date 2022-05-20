<template>
  <div class="form_body">
    <el-form ref="doc" :model="doc" size="mini" label-width="90px" >
      <el-form-item label="医生姓名：">
        <span>{{doc.name}}</span>
      </el-form-item>
      <el-form-item label="医生性别：">
        <span>{{doc.sex}}</span>
      </el-form-item>
      <el-form-item label="从医年龄：">
        <span>{{doc.workAge}}</span>
      </el-form-item>
<!--      <el-form-item label="身份证号：">-->
<!--        <span>{{doc.identi}}</span>-->
<!--      </el-form-item>-->
      <el-form-item label="就职医院：">
        <span>{{doc.hos}}</span>
      </el-form-item>
      <el-form-item label="所属科室：">
        <span>{{doc.department}}</span>
      </el-form-item>
      <el-form-item label="担任职称：">
        <span>{{doc.workBench}}</span>
      </el-form-item>
      <el-form-item label="医生简介：">
        <span>{{doc.intro}}</span>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import {getDocInfoData} from "@/service/userService";

export default {
  name: "doc_info",
  data(){
    return{
      doc:{
        Id:'',
        name:'',
        sex:'',
        workAge:'',
        hos:'',
        department:'',
        workBench:'',
        identi:'',//身份证号
        intro:'',
      },
      form:{

      },
      docInfo:[]
    }
  },
  created() {
    this.getDocInfo();
  },
  methods:{
    getDocInfo(){
      getDocInfoData({
        id:this.$store.state.inquiry.doctorId
      }).then(res=>{
        console.log("ok");
        console.log(res);
        this.doc.Id=res.result.doctor_ID;
        // this.doc.identi=res.result.identification;
        this.doc.name=res.result.doctor_name;
        this.doc.workAge=res.result.working_age+'年';
        this.doc.sex=res.result.sex;
        this.doc.workBench=res.result.title;
        this.doc.hos=res.result.hos_name;
        this.doc.department=res.result.department;
        this.doc.intro=res.result.introduction;
        this.$store.commit("editInquiryDocName",this.doc.name);
      }).catch(err=>{
        console.log(err);
      })
    }
  }
}
</script>

<style scoped>

</style>

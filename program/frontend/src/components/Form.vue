<template>
  <el-dialog :visible.sync="visible" @close="onClose">
    <el-form ref="form" :model="form" label-width="80px" >
      <el-form-item label="新闻标题">
        <el-input v-model="form.name"></el-input>
      </el-form-item>
      <el-form-item label="修改内容">
        <el-input v-model="form.content"></el-input>
      </el-form-item>
      <el-form-item label="修改时间">
        <el-col :span="11">
          <el-date-picker
            type="date"
            placeholder="选择日期"
            v-model="form.date1"
            style="width: 100%"
          ></el-date-picker>
        </el-col>
        <el-col class="line" :span="2">-</el-col>
        <el-col :span="11">
          <el-time-picker
            placeholder="选择时间"
            v-model="form.date2"
            style="width: 100%"
          ></el-time-picker>
        </el-col>
      </el-form-item>
      
      <el-form-item >
        <div class="sub">
        <el-button type="primary" @click="onSubmit">提交</el-button>
        <el-button @click="visible = false">取消</el-button>
        </div>
      </el-form-item>
    </el-form>
  </el-dialog>
</template>

<script>
import {postNoticeFun} from '@/service/userService';
export default {
    
  data() {
    return {
      form: {
        name: "",
        date1: "",
        date2: "",
        content:"",
        delivery: false,
        desc: "",
      },
      visible: false,
    };
  },
  props: {
    isVisible: {
      type: Boolean,
      default: false,
    },
  },
  methods: {

  onSubmit() {
      this.visible = false;
      console.log("Mingzi "+this.form.name)
      
         let date=new Date().getDate();
        let month=new Date().getMonth()+1;
        let year=new Date().getFullYear();
        let time=month+'-'+date+'-'+year;
        this.form.date1=time;
        this.postNotice(this.form.name,this.form.date1,this.form.content)
        this.form.date1=year+'-'+month+'-'+date;

      
    },
    postNotice(name,date,content1){
        postNoticeFun({
        noticeName:name, //要改
        content:content1,  //要改
        time:date,


      }).then(res=>{
        console.log(res);
        this.$message({
          message: '编辑成功，请刷新查看最新信息！',
          type: 'success'
        });
      }).catch(err=>{
        console.log(err);
      })
    },
  onClose(){//加一个beforeclose以及防止误触 
      this.$emit('formClose',false)
    },
    // post_reservation(){
    //   postReservatinoFun({
    //     pati_id:"111", //要改
    //     doctor_id:"112",  //要改
    //     time:this.form.data1,


    //   }).then(res=>{
    //     console.log(res);
    //   }).catch(err=>{
    //     console.log(err);
    //   })


 
  },
  watch: {
    isVisible() {
      this.visible = this.isVisible;
    },
  },
};
</script>

<style scoped>
</style>

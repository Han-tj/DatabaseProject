<template>
  <el-table 
    :data="records"
    width="100%"
    height="645px">
    <el-table-column
      label="日期"
      prop="time">
    </el-table-column>
    <el-table-column
      label="姓名"
      prop="pati_name">
    </el-table-column>
    <el-table-column
      label="ID"
      prop="pati_id"
      width="100">
    </el-table-column>
    <el-table-column
      align="center">
      <template slot-scope="scope">
          <div v-if="scope.row.status==='2' ">
            <el-button
            size="mini"
            type="primary"
            @click="move(scope.row)">开始问诊</el-button>
            <el-button
            size="mini"
            type="danger"
            disabled
            @click="handleDelete(scope.row)" >拒绝</el-button>
          </div> 
          <div v-if="scope.row.status==='0' ">
            <el-button
            size="mini"
            disabled
            @click="handleEdit(scope.row)">已取消</el-button>
          </div> 
          <div v-if="scope.row.status==='1' ">
            <el-button
            size="mini"
            type="success"
            @click="handleEdit(scope.row)">同意</el-button>
            <el-button
            size="mini"
            type="danger"
            @click="handleDelete(scope.row)" >拒绝</el-button>
          </div> 
      </template>
    </el-table-column>
  </el-table>
</template>

<script>
import {getRecordsFun} from "@/service/userService.js";
import {updateReservationFun} from "@/service/userService.js";
  export default {
    name: 'Table',
    data() {
      return {
        records:[],
        search: '',
        is_edited:0,
      }
    },
    created(){
      this.getDataList();
    },
methods: {
  move(row){
   this.$store.commit("editInquiryPatiId",row.pati_id);
   this.$store.commit("editInquiryPatientName",row.pati_name);
   this.$router.push("/InquiryBelongDoc");
  },
  handleEdit(row) {
    console.log("第一行的号：");
    console.log(row.num);
    console.log(row.status);
    this.updateStatus(row.num,'2');
    this.is_edited=1;

  },
  handleDelete(row) {
    console.log("第一行的号：");
    console.log(row.num);
    
    this.updateStatus(row.num,'0');
  },
  updateStatus(num,toNum){
    console.log(num)
  updateReservationFun({
    reservation_number:num,
    status:toNum,
  }).then(res=>{
    console.log("修改成功!");
  }).catch(err=>{
    console.log(err);
  })
  },


  getDataList(){
	getRecordsFun({doctor_id:this.$store.state.userId}).then(res=>{
    for(let i of res.result)
		{this.records.push({
      pati_id:i.pati_ID,
			pati_name:i.pati_name,
      time:i.reservation_Time.toString().substring(0,10),
      status:i.status,
      num:i.reservation_Number,
      
			
		});}
      }).catch(err=>{
         console.log(err);
      });
    },
    },
  }
</script>
<style lang="scss" scoped>
$grey: #777777;
  .el-table {
      box-shadow: 2px 5px 20px rgba($grey, .5);
    }
</style>
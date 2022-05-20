<template>
  <el-container>
    <el-row>
        <el-row
          v-for="(appointment, RESERVATION_NUMBER) in subReservationsList.slice(
          (currentPage - 1) * pagesize,
          currentPage * pagesize
        )"
          :key="RESERVATION_NUMBER"
        >
          <div class="onlineBox">
            <el-col :span="4">
              <el-avatar
                shape="square"
                :size="100"
                :src="`http://106.14.45.227:8080/${String(appointment.picturenum)}.png`"
              ></el-avatar>
              <p>姓名：{{ appointment.DOCTOR_NAME }}</p>
            </el-col>
            <el-col :span="10">
              <p>预约单号：{{ appointment.RESERVATION_NUMBER }}</p>
              <p>预约时间：{{ appointment.RESERVATION_TIME }}</p>
              <div v-if="appointment.STATUS == '1'">
                预约状态：等待确认
              </div>
              <div v-else-if="appointment.STATUS == '2'">
                预约状态：预约成功
              </div>
              <div v-else-if="appointment.STATUS == '3'">
                预约状态：已完成
              </div>
              <div v-else-if="appointment.STATUS == '4'">
                预约状态：正在进行
              </div>
              <div v-else-if="appointment.STATUS == '0'">
                预约状态：已取消
              </div>
            </el-col>
            <el-col :span="5">
              <br />
              <br />
             
              <br />
            <el-button  type="success" class="button" @click="showDialog(),getDetail(appointment)">医生详情</el-button>
            </el-col>
            <el-col :span="4">
              <br />
              <br />
              <br />
              <div v-if="appointment.STATUS == '1'">
                <el-button type="primary" round @click="cancel(appointment)">取消预约</el-button>
              </div>
              <div v-else-if="appointment.STATUS == '2'">
                <el-button type="danger" round @click="ready(appointment)">开始问诊</el-button>
              </div>
              <div v-else-if="appointment.STATUS == '3'">
                <el-button type="warning" round @click="_showDialog(),get_prescription(appointment)">问诊记录</el-button>
              </div>
              <div v-else-if="appointment.STATUS == '4'">
                <el-button type="danger" round @click="ready(appointment)">开始问诊</el-button>
              </div>
              <div v-else-if="appointment.STATUS == '0'">
                <el-button type="info" round disabled>取消预约</el-button>
              </div>
            </el-col>
          </div>
          <el-col :span="7"><p></p></el-col>
        </el-row>
        <doctordialog :dialogVisible="isDialogVisible" @dialogClick="changeDialog" :dialogData="subDocInoData"></doctordialog>
        <PreDatadialog :_dialogVisible="new_isDialogVisible" @_dialogClick="_changeDialog" :_dialogData="new_subDocInoData"></PreDatadialog>
        <div style="padding-left: 32%">
          <div class="block">
            <el-pagination
              background
              @size-change="handleSizeChange"
              @current-change="handleCurrentChange"
              :current-page="currentPage"
              :page-size="pagesize"
              layout="total,prev, pager, next,jumper"
              :total="subReservationsList.length"
            >
            </el-pagination>
          </div>
        </div>
    </el-row>
  </el-container>
</template>

<script>
import { getPreDataFun } from '@/service/userService'
import { getDocInoFun } from '@/service/userService'
import { updateReservationFun } from '@/service/userService'
import doctordialog from '@/components/doctordialog.vue'
import PreDatadialog from '@/components/PreDatadialog.vue'
  export default {
    name:"onlineAppointment",
    components:{
      doctordialog,
      PreDatadialog,
    },
    data(){
        return{
          subDocInoData:{},
          new_subDocInoData:{},
          isDialogVisible:false,
          new_isDialogVisible:false,
          DocIno:{
            DOCTOR_NAME:'',
            DOCTOR_ID:'',
            newDOCTOR_ID:'',
            TITLE:'',
            HOS_NAME:'',
            DEPARTMENT:'',
            INTRODUCTION:'',
          },
          PreDataIno:{
            prescription_ID:'',
            department:'',
            date:'',
            content:'',
          },
          records:[],
          search: '',
          dialogVisible: false,
          currentPage: 1,
          pagesize: 4,
    }
  },
  props:{
    subReservationsList:{
      type:Array,
      default:function(){
        return {
          
        }
      }
    }
  },
    methods: {
      cancel(appointment) {
        console.log(appointment.RESERVATION_NUMBER);
        this.$confirm('是否取消本次预约？', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        }).then(() => {
          updateReservationFun({
            reservation_number:appointment.RESERVATION_NUMBER,
            status:'0',
          }).then(res=>{
            console.log("修改成功!");
            this.$message({
            type: 'success',
            message: '取消成功!'
          }
          );
          }).catch(err=>{
            console.log(err);
          })
        }).catch(() => {
          this.$message({
            type: 'info',
            message: '取消失败'
          }); 
        });
      },
      wait() {
        this.$message('问诊还未开始');
      },
        
      ready(appointment) {
        this.$message({
          message: '问诊即将开始',
          type: 'success'
        });
        this.$store.commit('editInquiryDocName',appointment.DOCTOR_NAME);
        this.$store.commit('editInquiryDocId',appointment.DOCTOR_ID)
        this.$router.push('/InquiryBelongPatient');
      },
        get_prescription(appointment){//查看问诊记录（得到电子病历、处方）
          getPreDataFun(
                {
                  doctor_id:appointment.DOCTOR_ID,
                  pati_id:this.$store.state.userId,
                }
              ).then(res=>{
                this.PreDataIno.prescription_ID="问诊单号: "+res.result.prescription_ID;
                this.PreDataIno.department="问诊科室: "+res.result.department;
		            this.PreDataIno.date="问诊时间: "+res.result.prescription_Date;
                this.PreDataIno.content="问诊内容: "+res.result.prescription_Content;
                }).catch(err=>{
                  console.log("传输错误4");
              });
           this.new_subDocInoData=this.PreDataIno
        },


        handleSizeChange(page_size) {
            this.pagesize = page_size;
        },
        handleCurrentChange(current_page) {
            this.currentPage = current_page;
        },
        showDialog(){
            this.isDialogVisible = true;
        },
        changeDialog(){
            this.isDialogVisible = false
        },
        _showDialog(){
            this.new_isDialogVisible = true;
        },
        _changeDialog(){
            this.new_isDialogVisible = false
        },
        getDetail(appointment) {
              getDocInoFun(
                {
                  id:appointment.DOCTOR_ID,
                }
              ).then(res=>{
                this.DocIno.DOCTOR_NAME="姓名: "+res.result.doctor_name;
                this.DocIno.TITLE="职称: "+res.result.title;
                this.DocIno.DOCTOR_ID=res.result.doctor_ID;
                this.DocIno.newDOCTOR_ID="ID: "+res.result.doctor_ID;
                this.DocIno.HOS_NAME="就职医院: "+res.result.hos_name;
                this.DocIno.DEPARTMENT="所在工作: "+res.result.department;
                this.DocIno.INTRODUCTION="简介: "+res.result.introduction;
                this.subDocInoData=this.DocIno
                }).catch(err=>{
                  console.log("传输错误4");
              });
        },
    },
    watch: {
    dataList: function () {
      console.log("医生详情watch函数")
      this.$nextTick(function () {
        this.currentPage = 1;
      });
    },
  },
}
</script>

<style scoped>

.block {
  position: relative;
  top: 10px;
  right: 10%;
}
.el-row {
  margin-bottom: 5px;
}
.el-col {
  min-height: 1px;
  border-radius: 4px;
}

.onlineBox {
  width: 110.7%;
  height: 150px;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  text-align: left;
  float: left;
  margin-right: 10px;
  padding: 5px;
  padding-top: 5px;
  padding-left: 20px;
}
</style>
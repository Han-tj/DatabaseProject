<template>
<el-container>
  <el-row>
    <el-row 
    v-for="(appointment,TIME,) 
              in subOfflineAppFunList.slice(
          (currentPage - 1) * pagesize,
          currentPage * pagesize
        )" :key="TIME">
            <div class="onlineBox"> 
                <el-col :span="5">
                    <el-avatar shape="square" 
                      :size="100" 
                      :src="`http://106.14.45.227:8082/${String(appointment.picturenum)}.png`"
                    >
                    </el-avatar>
                    <p>{{appointment.HOS_NAME}}</p>
                </el-col>
                <el-col :span="10">
                    <p>预约时间：{{appointment.TIME}}</p>
                    <p>预约科室：{{appointment.DEPARTMENT}}</p>
                    <div v-if="appointment.STATUS == '1'">
                预约状态：已预约
              </div>
              <div v-else-if="appointment.STATUS == '2'">
                预约状态：已完成
              </div>
              <div v-else-if="appointment.STATUS == '0'">
                预约状态：已取消
              </div>
                </el-col>
            <el-col :span="5">
              <br />
              <br />
              <br />
            <el-button  type="success" class="button" @click="showDialog(),getDetail(appointment)">医院详情</el-button>
            </el-col>
            <el-col :span="4">
              <br />
              <br />
              <br />
              <div v-if="appointment.STATUS == '1'">
                <el-button type="primary" @click="cancel(appointment)">取消预约</el-button>
              </div>
              <div v-else-if="appointment.STATUS == '2'">
                <el-button type="info" disabled>取消预约</el-button>
              </div>
              <div v-else-if="appointment.STATUS == '0'">
                <el-button type="info" disabled>取消预约</el-button>
              </div>
            </el-col>
            </div>
        <el-col :span="7"><p></p></el-col>
      </el-row>
      <hospitaldialog :dialogVisible="isDialogVisible" @dialogClick="changeDialog" :dialogData="subHosInoData"></hospitaldialog>
      <div style="padding-left: 32%">
          <div class="block">
            <el-pagination
              background
              @size-change="handleSizeChange"
              @current-change="handleCurrentChange"
              :current-page="currentPage"
              :page-size="pagesize"
              layout="total,prev, pager, next,jumper"
              :total="subOfflineAppFunList.length"
            >
            </el-pagination>
          </div>
        </div>
  </el-row>
</el-container>
</template>

<script>
import { RectifyOfflineAppFun } from '@/service/userService'
import { getHospitalFun } from '@/service/userService'
import hospitaldialog from '@/components/hospitaldialog.vue'
  export default {
    name:"hospial",
    components:{
      hospitaldialog,
    },
    data(){
        return{
          subHosInoData:{},
          currentPage: 1,
          pagesize: 4,
          isDialogVisible:false,
          HosIno:{
            HOS_NAME:'',
            HOS_LOC:'',
            TEL:'',
            INTRODUCTION:'',
          },
    }
  },
  props:{
    subOfflineAppFunList:{
      type:Array,
      default:function(){
        return []
      }
    }
  },
  methods:{
    cancel(appointment) {
        console.log(appointment.TIME);
        console.log(this.$store.state.userId);
        console.log(appointment.STATUS);
        this.$confirm('是否取消本次预约？', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        }).then(() => {
          RectifyOfflineAppFun({
            pati_id:this.$store.state.userId,
            time:appointment.TIME,
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
        getDetail(appointment) {
              getHospitalFun(
                {
                  hos_name:appointment.HOS_NAME,
                }
              ).then(res=>{
                this.HosIno.HOS_NAME="医院名称： "+res.result.hos_name;
                this.HosIno.HOS_LOC="医院地址： "+res.result.hos_Loc;
                this.HosIno.TEL="联系方式： "+res.result.tel;
                this.HosIno.INTRODUCTION="医院介绍： "+res.result.introduction;
                }).catch(err=>{
                  console.log("传输错误4");
              });
              this.subHosInoData=this.HosIno
        },
    },
  watch: {
    dataList: function () {
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
        height:150px;
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
        text-align: left;
        float: left;
        margin-right: 10px;
        padding: 5px;
        padding-top: 5px;
        padding-left: 20px;
        }
</style>
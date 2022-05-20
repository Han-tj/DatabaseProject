<template>
  <el-container>
    <el-row>
        <el-row
          v-for="(NAT,TIME) in subNATList.slice(
          (currentPage - 1) * pagesize,
          currentPage * pagesize
        )"
          :key="TIME"
        >
          <div class="onlineBox">
            <el-col :span="14">
              <p>检测医院：{{ NAT.HOS_NAME }}</p>
              <p>医院地址：{{ NAT.HOS_LOC }}</p>
              <p>检测时间：{{ NAT.TIME }}</p>
              <div v-if="NAT.STATUS == '1'">
                检测状态：已预约
              </div>
              <div v-else-if="NAT.STATUS == '2'">
                检测状态：已完成
              </div>
              <div v-else-if="NAT.STATUS == '0'">
                检测状态：已取消
              </div>
            </el-col>
            <el-col :span="5">
              <br />
              <br />
              <br />
              <br />
              <br />
            </el-col>
            <el-col :span="4">
              <br />
              <br />
              <br />
              <br />
              <br />
              <div v-if="NAT.STATUS == '1'">
                <el-button type="primary" @click="cancel(NAT)">取消预约</el-button>
              </div>
              <div v-else-if="NAT.STATUS == '2'">
                <el-button type="info" disabled>取消预约</el-button>
              </div>
              <div v-else-if="NAT.STATUS == '0'">
                <el-button type="info" disabled>取消预约</el-button>
              </div>
            </el-col>
          </div>
          <el-col :span="7"><p></p></el-col>
        </el-row>
        <div style="margin-left: 35%">
          <div class="block">
            <el-pagination
              background
              @size-change="handleSizeChange"
              @current-change="handleCurrentChange"
              :current-page="currentPage"
              :page-size="pagesize"
              layout="total,prev, pager, next,jumper"
              :total="subNATList.length"
            >
            </el-pagination>
          </div>
        </div>
    </el-row>
  </el-container>
</template>

<script>
import { RectifyNucleicAppFun } from '@/service/userService'
  export default {
    name:"onlineAppointment",
    data(){
        return{
          currentPage: 1,
          pagesize: 4,
            NAT0Img: require('../assets/NAT-info.png'),
            NAT1Img: require('../assets/NAT-appointment.png'),
            NAT2Img: require('../assets/NAT-already.png'),
    }
  },
    props:{
    subNATList:{
      type:Array,
      default:function(){
        return []
      }
    }
  },
    methods: {
        cancel(NAT) {
        console.log(NAT.TIME);
        this.$confirm('是否取消本次预约？', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        }).then(() => {
          console.log(NAT.TIME);
          RectifyNucleicAppFun({
            pati_id:this.$store.state.userId,
            time:NAT.TIME,
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
.el-avatar{
  margin-top: 20px;
}
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
        width: 172%;
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
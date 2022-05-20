<template>
  <div>
  <el-table
    :data="reportList.filter(data => !search || data.reportTime.toLowerCase().includes(search.toLowerCase()))"
    width="100%"
    height="615px">
    <el-table-column
      label="举报单号"
      prop="reportId">
    </el-table-column>
    <el-table-column
      label="被举报者ID"
      prop="reportedId">
    </el-table-column>
    <el-table-column
      label="举报者ID"
      prop="reporterId">
    </el-table-column>
    <el-table-column
      label="时间"
      prop="reportTime">
    </el-table-column>
    <!-- <el-table-column
      label="内容"
      prop="reportConetnt">
    </el-table-column> -->
    <el-table-column
      align="center">
      <!-- <template slot="header" slot-scope="scope">
        <el-input
          v-model="search"
          size="mini"
          placeholder="输入关键字搜索"/>
      </template> -->
      <template slot-scope="scope">
        <el-button
          size="mini"
          type="primary"
          @click="dialogVisible = true,getInfo(scope.row)" >详情</el-button>
        <!-- <el-button
          size="mini"
          type="danger"
          @click="handleDelete(scope.row)">删除</el-button> -->
      </template>
    </el-table-column>
  </el-table>
    <el-dialog
    title="详细信息"
    :visible.sync="dialogVisible"
    width="30%"
    :before-close="handleClose">
    <p>举报单号：{{num}}</p>
    <p>被举报者ID：{{isreported}}</p>
    <p>举报者ID：{{reported}}</p>
    <p>举报时间：{{time}}</p>
    <p>举报内容：{{content}}</p>
    <span slot="footer" class="dialog-footer">
      <el-button @click="dialogVisible = false">取 消</el-button>
      <el-button type="primary" @click="dialogVisible = false">确 定</el-button>
    </span>
  </el-dialog>
  </div>
</template>

<script scoped>
import {getReportListDataFun} from "@/service/userService";
  export default {
    name: 'Table',
    data() {
      return {
        dialogVisible: false,
        reportList:[],
        search: '',
        num:'',
        isreported:'',
        reported:'',
        time:'',
        content:'',
      }
    },
    created(){
      this.getReportList();
    },
    methods: {
      getInfo(row){
        this.num=row.reportId
        this.isreported=row.reportedId
        this.reported=row.reporterId
        this.time=row.reportTime
        this.content=row.reportContent
      },
      showDialog(mes){ 
      this.isDialogVisible = true//弹出表单
      // this.$refs.listItem.recordLocation(mes)//告知卡片列表子组件 要求对本页面的点击事件mes进行定位 
    },
      handleEdit(index, row) {
        console.log(index, row);
      },
      handleDelete( row) {
        console.log(row);
        
      },
      getReportList(){
        getReportListDataFun(
        ).then(res=>{
          for(let i=0;i<res.result.length;i++){
            this.reportList.push({
              reportId:res.result[i].report_Number,//举报id
              reporterId:res.result[i].doctor_ID,//举报者id
              reportedId:res.result[i].pati_ID,//被举报者id
              reportContent:res.result[i].report_Content,//举报内容
              reportTime:res.result[i].report_Time.substring(0,10),//举报时间
            })
          }
          // console.log(this.reportList);
        }).catch(err=>{
          console.log(err);
        })
      }
    },
  }
</script>
<style lang="scss" scoped>
$grey: #777777;
  .el-table {
      box-shadow: 2px 5px 20px rgba($grey, .5);
    }
</style>

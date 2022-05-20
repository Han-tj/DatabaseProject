<template>
  <div>
  <el-table
    :data="noticeList.filter(data => !search || data.noticeTime.toLowerCase().includes(search.toLowerCase()))"
    width="100%"
    height="615px">
    <el-table-column
      label="标题"
      prop="noticeName">
    </el-table-column>
    <el-table-column
      label="内容"
      prop="noticeContent"
      width="450">
    </el-table-column>
    <el-table-column
      label="时间"
      prop="noticeTime"
      width="150">
    </el-table-column>
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
          @click="showForm" 
          >编辑</el-button>
        <el-button
          size="mini"
          type="danger"
          @click="handleDelete(scope.row)">删除</el-button>
      </template>
    </el-table-column>
  </el-table>
  <!-- <myform  :isVisible="isFormVisible" @formSubmit='submitForm' @formClose='closeForm' ></myform> -->
  <myform  :isVisible="isFormVisible"></myform>
  </div>
</template>

<script scoped>

import {getNoticeListDataFun,postNoticeDataFun} from "@/service/userService";
import {deleteNoticeFun} from "@/service/userService";
import myform from "@/components/Form.vue";
export default {
    name: 'Table',
    components:{
      myform,
    },
    data() {
      return {
        isFormVisible:false,
        noticeList:[],

        search: '',
        submit:{
          name:'111',
          content:'1111',
          time:'',
          
        }
      }
    },
  created() {
    this.getNoticeList();
  },
  methods: {
    showForm(mes){ 
      this.isFormVisible = true//弹出表单
      // this.$refs.listItem.recordLocation(mes)//告知卡片列表子组件 要求对本页面的点击事件mes进行定位 
    },
      getNoticeList(){
        getNoticeListDataFun(
        ).then(res=>{
          for(let i=0;i<res.result.length;i++){
            this.noticeList.push({
              noticeId:res.result[i].notice_ID,
              noticeName:res.result[i].notice_name,
              noticeContent:res.result[i].content,
              noticeTime:res.result[i].time,
            })
          }
          console.log("新闻结果："+this.noticeList);
        }).catch(err=>{
          console.log(err);
        })
      },
      submitNotice(){
        let date=new Date().getDate();
        let month=new Date().getMonth()+1;
        let year=new Date().getFullYear();
        this.submit.time=month+'-'+date+'-'+year;
        // this.submit.time=year+'.'+month+'.'+date;
        postNoticeDataFun({
          noticeName:this.submit.name,
          content:this.submit.content,
          time:this.submit.time
        }).then(res=>{
          console.log(res);
        }).catch(err=>{
          console.log(err);
        })
      },
      handleEdit(index, row) {
        console.log(index, row);
      },
      handleDelete(row) {
        console.log("ssg"+row.noticeId);
         deleteNoticeFun({
          noticeID:row.noticeId,
        }).then(res=>{
          console.log(res);
          console.log("删除成功");
        }).catch(err=>{
          console.log(err);
        })
        this.$message({
          message: '删除成功，请刷新页面查看最新页面！',
          type: 'success'
        });
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

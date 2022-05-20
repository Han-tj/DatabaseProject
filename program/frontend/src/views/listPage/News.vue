<template>
  <div>
    <Navigation></Navigation>
    <el-container  style=" width:70% ; position:absolute;left:15%;top:18%;border: 1px solid #eee" >
      <el-main>
        <!--下面的slice很关键,实现了分页-->
        <el-table ref="multipleTable"
                  :data="docList.slice((currentPage-1)*pageSize,currentPage*pageSize)"
                  tooltip-effect="dark"
                  style="width: 100%">
          <el-table-column  align="center" prop="time" label="日期" width= 300px>
          </el-table-column>
          <el-table-column  align="left"  prop="name" label="新闻公告"  width= 700px>
            <template slot-scope="scope">
              <!--点击进行响应弹出通告具体界面-->
              <span @click="showDialog(),getDetail(scope.row)" style="cursor: pointer;">
                <a class="link">{{scope.row.name}}</a>
              </span>
            </template>
          </el-table-column>
        </el-table>
        <Idialog :dialogVisible="isDialogVisible" @dialogClick="changeDialog" :dialogData="diaData"></Idialog>
        <!--下面进行表格分页操作-->
        <div style="text-align: center;margin-top: 30px;">
          <el-pagination
              background
              @size-change="handleSizeChange"
              @current-change="handleCurrentChange"
              :current-page="currentPage"
              :page-sizes="[8, 12, 16]"
              :page-size="pageSize"
              layout="total, sizes, prev, pager, next,jumper"
              :total="docList.length">

          </el-pagination>
        </div>
      </el-main>
    </el-container>
  </div>
</template>
<script>
import Navigation from '@/components/Navigation.vue';
import Idialog from "@/components/dialog.vue";
import {getNoticeFun} from '@/service/userService.js';
export default {
  name:"News",
  components:{
    Idialog,
    Navigation,
  },
  props:{
    dataList:{
      type:Array,
      default:function(){
        return []
      }
    }
  },
  data() {
    return {
       isDialogVisible: false,
      docList: [],
      diaData:{},
      docData: [],
      currentPage: 1, //当前页数 ，默认为1
      pageSize: 10, // 每页显示数量
      pageSizes:[8,12,16],//可以选择每页显示的数据条数
      currentPageData: {},//当前页显示内容
      // tableData: Array(20).fill(item),
    }
  },
  created() {
    this.getDataList();
  },
  methods:{
    getDataList(){
    getNoticeFun(
    ).then(res=>{
      for(let i of res.result){
        this.docList.push({
          name:i.notice_name,
          content:i.content,
          time:i.time,   
        }
        );
      }
      console.log(res);
      //console.log(typeof(res.result.pic));
      console.log("ok");
      this.docData = this.docList;
      //console.log(this.docList)
    }).catch(err=>{
        console.log(err);
    });
  },

    handleSizeChange(val){
      this.pageSize=val;
      this.currentPage=1;   //改变页面大小后，跳转回去第一页
      //console.log实时条数显示在控制台
      console.log('每页${val}条');
    },
    //每次切换当前页面的时候，此方法响应，改变当前页
    handleCurrentChange(val){
      this.currentPage=val;
      console.log('当前页:${val}');
    },

    //展示通告，只调用了alert函数，考虑设计一个组件展示信息
    changeDialog(){
      this.isDialogVisible = false
    },
     handleClose(done) {
        this.$confirm('确认关闭？')
          .then(_ => {
            done();
          })
          .catch(_ => {});
      },

    showDialog(){
      this.isDialogVisible = true;
    },
    changeDialog(){
      this.isDialogVisible = false
    },
    getDetail(mes) {
    let _item={
        '内容：':mes.content,
    }
    this.diaData=_item

    },
  }
};
</script>
<style>
.link:hover{color:#66b3ff;}
</style>

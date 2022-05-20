<template>
<div>
  <el-table 
    :data="records"
    style="width: 100%"
    height="645px">
    <el-table-column
      label="日期"
      prop="time"
      width="150">
    </el-table-column>
    <el-table-column
      label="姓名"
      prop="pati_name"
      width="150">
    </el-table-column>
    <el-table-column
      label="ID"
      prop="pati_id"
      width="150%">
    </el-table-column>
    <el-table-column
      align="center">
      <template slot-scope="scope">
        <el-button
          size="mini"
          type="primary"
          @click="showDialog(scope.row)">问诊详情</el-button>
      </template>
     
    </el-table-column>
  </el-table> 
  <el-dialog
      title="详细信息"
      :visible.sync="dialogVisible"
      width="35%"
      :before-close="handleClose">
        <p>患者名字：{{name1}}</p>
        <p>问诊时间：{{time1}}</p>
        <p>患者主诉：{{desc1}}</p>
        <p>症状：{{type1}}</p>
        <p>诊断疾病：{{disease1}}</p>      
        <span slot="footer" class="dialog-footer">
          <el-button @click="dialogVisible = false">取 消</el-button>
          <el-button type="primary" @click="dialogVisible = false">确 定</el-button>
        </span>
      </el-dialog>
      </div>
</template>

<script scoped>
import {getCompletedRecordsFun} from '@/service/userService.js'
  export default {
    name: 'Table',
    data() {
      return {
        records:[],
        search: '',
        dialogVisible: false,
        content1:'',
        name1:'',
        time1:'',
        desc1:'',
        type1:'',
        disease1:'',

      }
    },
    created(){
      this.getDataList();
    },
    methods: {
      showDialog(row){
        console.log(row.content);
        this.dialogVisible = true;
        this.name1=row.pati_name;
        this.time1=row.time;
        this.desc1=row.desc;
        this.type1=row.type;
        this.disease1=row.disease;
        
      },
      handleEdit(index, row) {
        console.log(index, row);
      },
      handleDelete(index, row) {
        console.log(index, row);
      },
      getDataList(){
	getCompletedRecordsFun({ID:this.$store.state.userId}).then(res=>{
    
    for(let i of res.result)
		{ let content=i.prescription_Content;//获取content
      let temp=content.split('——');//处理content
      let index=temp[2].split('-');//处理第三部分（由多选框数组构成）
      let types='';
      let j;
      for(j=0;j<index.length-1;j++){//装入
          types=types+index[j]+',';
      }
      types=types+index[j];
      this.records.push({
      pati_id:i.pati_ID,
			pati_name:i.pati_name,
      department:i.department,//科室
      desc:temp[0],//患者主诉
      disease:temp[1],//疾病
      type:types,//症状
      time:i.prescription_Date.toString().substring(0,10),
      content:i.prescription_Content,
		});}
    console.log(this.records)
		console.log("表格2get成功！")
    // console.log(this.records),
    console.log(res)
        //console.log(typeof(res.result.pic));
        // this.docData = this.docList;
        // this.getOptions()
        //console.log(this.docList)
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
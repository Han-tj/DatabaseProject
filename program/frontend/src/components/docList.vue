<template>
  <div>
    <el-row>
      <el-col
        :span="4"
        v-for="item in dataList.slice((currentPage - 1) * pagesize,currentPage * pagesize)"
        :key="item.id"
        :offset="1"
        type="flex"
        push=1
      >
        <div style="margin-top:30px">
          <el-card :body-style="{ padding: '10px'}" shadow="hover" class="box-card" >
            <div class="image-zone">
              <img :src="`http://106.14.45.227:8080/${String(item.pic)}.png`"  weight=70px  height=70px>
            </div>
            <span>{{ item.name }}</span>
            <p>{{ item.title }}</p>
            <p>{{ item.index}}</p>
            <span id='hiding-id' v-show="false">{{item.id}}</span>
            <div class="botton-zone">
              <el-button-group>
                <slot></slot>
                <el-button  class="button" @click="showDialog(),getDetail(item)">详细</el-button>
              </el-button-group>
            </div>
          </el-card>
        </div>
      </el-col>
    </el-row>
    <infoDialog :dialogVisible="isDialogVisible" @dialogClick="changeDialog" :dialogData="diaData"></infoDialog>
    <div style="margin-left: 35%">
      <div class="block">
        <el-pagination
          background
          @size-change="handleSizeChange"
          @current-change="handleCurrentChange"
          :current-page="currentPage"
          :page-sizes="[8, 12, 16]"
          :page-size="pagesize"
          layout="total, sizes, prev, pager, next,jumper"
          :total="dataList.length"
        >
        </el-pagination>
      </div>
    </div>
  </div>
</template>

<style scoped>
.time {
  font-size: 13px;
  color: #999;
}
.box-card{
  width:200px;
  text-align: center;
  margin-right: 150px;
}

.bottom {
  margin-top: 13px;
  line-height: 12px;
}

.button {
  padding: 5;
  float: left;
}

.docImage {
  float: left;
  width: 50px;
  height: 50px;
  padding: 5px;
}

.clearfix:before,
.clearfix:after {
  display: table;
  content: "";
}

.clearfix:after {
  clear: both;
}
.block{
  position: relative;
  top:30px;
  right:10%;
  padding:10px;
}
</style>

<script>
import infoDialog from "./dialog.vue";

export default {
  name: "cardList",
  data() {
    return {
      currentPage: 1,
      pagesize: 8,
      isDialogVisible:false,
      diaData:{},
      lastCardInfo:{
        _id: -1,
        _name:' '
      }
    };
  },
  props:{
    dataList:{
      type:Array,
      default:function(){
        return []
      }
    }
  },
  components: {
    infoDialog,
  },
  methods: {
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
    getDetail(item) {
      let _item={
        '姓名：':'姓名：'+item.name,
        '性别：':'性别：'+item.sex,
        '职称：':'职称：'+item.title,
        '所在科室：':'所在科室：'+item.index,
        '医龄：':'医龄：'+item.workingAge,
        '所在医院：':'所在医院：'+item.hos,
        '简介：':'简介：'+item.intro,

      }
      this.diaData=_item
    },
    recordLocation(mes){
      console.log(mes.currentTarget.parentElement
                        .parentElement.parentElement.childNodes[4])
      this.lastCardInfo._id = Number(mes.currentTarget.parentElement
                        .parentElement.parentElement.childNodes[4].innerHTML)
      this.lastCardInfo._name = mes.currentTarget.parentElement
                        .parentElement.parentElement.childNodes[1].innerHTML
    },
  },
  watch: {
    dataList: function () {//自动跳转回列表第一页
      this.$nextTick(function () {
        this.currentPage = 1;
      });
    },
  },
};
</script>


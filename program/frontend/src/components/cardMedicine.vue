<template>
  <div>
    <el-row>
      <el-col
        :span="4"
        v-for="item in dataList.slice((currentPage - 1) * pagesize,currentPage * pagesize)"
        :key="item.id"
        :offset="1"
        gutter="20"
      >
        <div style="margin-top:30px ">
          <el-card :body-style="{ padding: '10px' }" shadow="hover" class="box-card" >
            <div class="image-zone">
              <img :src="`http://106.14.45.227:8081/${String(item.pic)}.png`"  weight=70px  height=70px>
            </div>
            <div class="a">
              <span>{{ item.index1 }}</span>
              <p align="center">{{ item.index }}</p>
              <p>价格￥{{ item.price}}</p>
              <span id='hiding-id' v-show="false">{{item.id}}</span>
            </div>
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
    <infoDialog :dialogVisible="isDialogVisible" @dialogClick="changeDialog" :dialogData="diaData" ></infoDialog>
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

.box-card{
  text-align: center;
  width:200px;
  margin-right:450px;
}
.time {
  font-size: 13px;
  color: #999;
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
  name: "cardMed",
  data() {
    return {
      currentPage: 1,
      pagesize: 8,
      isDialogVisible:false,
      diaData:{},
      lastCardInfo:{
        _id: -1,
        _name:' ',
        _price:'',
        _url:'',
      }
    };
  },
  props:{
    dataList:{
      type:Array,
      default:function(){
        return []
      }
    },

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
            '名字：':item.index1,
            '类型：':'类型：'+item.index,
            '价格：': item.price,
            '处方类型：':'处方类型：'+item.prescription_type,
            '适应症：':'适应症：'+item.adaption,
            '库存：':'库存：'+item.inventory+'件',
      }
      this.diaData=_item
    },
    recordLocation(mes){
      this.lastCardInfo._id = Number(mes.currentTarget.parentElement
                        .parentElement.parentElement.childNodes[1].childNodes[3].innerHTML)
      this.lastCardInfo._name = mes.currentTarget.parentElement
                        .parentElement.parentElement.childNodes[1].childNodes[0].innerHTML
      this.lastCardInfo._price = mes.currentTarget.parentElement
                        .parentElement.parentElement.childNodes[1].childNodes[2].innerHTML.replace(/[^0-9]/ig,"")
      this.lastCardInfo._url = mes.currentTarget.parentElement
                        .parentElement.parentElement.childNodes[0].childNodes[0].getAttribute('src')
                        console.log(mes.currentTarget.parentElement
                        .parentElement.parentElement.childNodes[1].childNodes[2].innerHTML)
    },
  },
  watch: {
    dataList: function () {
      this.$nextTick(function () {
        this.currentPage = 1;
      });
    },
  },
};
</script>


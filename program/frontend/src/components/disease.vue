<template>
  <div>
  <el-row>
    <div class="regu">
      <el-col
        :span="7"
        v-for="item in dataList.slice((currentPage - 1) * pagesize,currentPage * pagesize)"
        :key="item.id"
        :offset="0"
        gutter="20"
      >
        <div class="main">
          <div class="ill">
            <span class="text">{{item.index}}</span>
            <div class="image">
              <img src="../assets/ji.png" alt="" />
            </div>
          </div>
          <div class="content">
            <span class="content-text">
              {{item.introduction}}
            </span>
          </div>

          <div class="button">
            <el-popover
              class="button2"
              placement="bottom"
              title="病因"
              width="200"
              trigger="click"
              :content=item.pathogeny
            >
              <el-button slot="reference">病因</el-button>
            </el-popover>

            <el-popover
              placement="bottom"
              title="症状"
              width="200"
              trigger="click"
              :content=item.symptoms
            >
              <el-button slot="reference" style="text-align: center">症状</el-button>
            </el-popover>

            <el-popover
              placement="bottom"
              title="用药"
              width="200"
              trigger="click"
              :content=item.medication
            >
              <el-button slot="reference">用药</el-button>
            </el-popover>

            <el-popover
              placement="bottom"
              title="并发症"
              width="200"
              trigger="click"
              :content=item.complication
            >
              <el-button slot="reference" style="text-align: center">并发症</el-button>
            </el-popover>
          </div>
        </div>
      </el-col>
      </div>
</el-row>
  <div style="margin-left: 35%">
      <div class="block">
        <el-pagination
          background
          @size-change="handleSizeChange"
          @current-change="handleCurrentChange"
          :current-page="currentPage"
          :page-sizes="[6]"
          :page-size="pagesize"
          layout="total, sizes, prev, pager, next,jumper"
          :total="dataList.length"
        >
        </el-pagination>
      </div>
    </div>
</div>
</template>

<script>
export default {
  data() {
    return {
      currentPage: 1,
      pagesize: 6,
      diaData:{},
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
  methods:{
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
};
</script>

<style lang="less" scoped>

.regu{
    width: 1300px;
    position:absolute;
    // padding-top: 40px;
    left:150px;
}

.block{
  position: relative;
  top:660px;
  width: 100px;
  right:-10%;
  margin-bottom:20px;
}
.main {
  width: 300px;
  height: 265px;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  text-align: left;
//   float: left;
  margin-right: 10px;
  padding: 0px;
  background-color: rgb(255, 255, 255);
  position: relative;
  left: 20%;
  top: 20%;
//   margin-top: 50px;
//   transform: translate(-50%, -50%);
}
.el-row{
    width:900px;
}
.ill {
  height: 50px;
  padding-left: 10px;
  padding-top: 10px;
  border-color: #000000;
  border-bottom: thin solid #eceaea;
  background: -webkit-linear-gradient(left, #7fbfff, #c6e2ff);

  .image {
    height: 40px;
    width: 40px;
    border-radius: 50%;
    padding: 10px;
    position: relative;
    top: -15px;
    left: 85%;
    transform: translate(-50%, -50%);
    img {
      width: 100%;
      height: 100%;
      border-radius: 50%;
    }
  }

  .text {
    position: relative;
    font-size: 28px;
    text-align: center;
    margin-top: 100px;
    vertical-align: center;
  }
}

.content {
  height: 150px;
  text-align: left;
  vertical-align: middle;
  padding-top: 2px;
  padding-left: 5px;
  border-radius: 0px;
  border-bottom: thin solid #eceaea;

  .content-text {
    vertical-align: 5px;
    text-align: left;
    font-size: 10px;
  }
}
.button {
  height: 65px;
  border-radius: 4px;
}
.el-button {
  position: relative;
  left: 1px;
  margin-left: 1px;
  margin-top: 7px;
  text-align: center;
}
.el-col{
left: 10px;
// margin-top:10px;
padding-top:40px;
}
</style>
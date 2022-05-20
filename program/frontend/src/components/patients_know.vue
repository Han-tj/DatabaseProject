<template>
    <div>
         <el-card class="box-card">
            <div slot="header" class="clearfix" style="text-align:left">
                <span style="font-size:28px">预约需知</span>
            </div>
            <!-- <div v-for="info in infoList" :key="info" class="text item"> -->
            <div class="word" >
                <pre>
1.APP预约/微信公众号预约：
    进入手机应用市场搜索“济病通”下载安装APP或关注“济病
    通”微信公众号;

2.电话预约：
    （1）专家与普通号预约电话：96320/12320；
    （2）特需门诊专家预约电话：023-89012200;

3.网上预约：
    济病通在线问诊平台；

4.自助机预约：
    门诊区域内自助机，可预约挂号和当日分时段挂号；

5.现场人工预约：
    工作日门诊窗口，工作人员协助预约。
                </pre>
            </div>
        </el-card>
    </div>
</template>

<style scoped>
 .text {
    font-size: 14px;
  }
.word{
text-align:left;
font-size:16px;
font-family:"幼圆";
}
  .item {
    margin-bottom: 18px;
  }

  .clearfix:before,
  .clearfix:after {
    display: table;
    content: "";
  }
  .clearfix:after {
    clear: both
  }

  .box-card {
    width: 480px;
  }
</style>

<script>
export default {
    name:"patients_know",
    data(){
        return{
            data:'1.APP预约/微信公众号预约：进入手机应用市场搜索“重医一院”下载安装APP或关注“重医一院”微信公众号',
           data1:'1.APP预约/微信公众号预约：进入手机应用市场搜索“重医一院”下载安装APP或关注“重医一院”微信公众号',
           data2:'2.电话预约：\n（1）专家与普通号预约电话：96320/12320；\n（2）特需门诊专家预约电话：023-89012200。',
           data3:'3.网上预约：\n（1）重庆市12320健康信息服务平台(www.cq12320.cn)；\n（2）医事通预约平台。',
           data4:'4.自助机预约：\n门诊区域内自助机，可预约挂号和当日分时段挂号。',
           data5:'5.现场人工预约：\n工作日门诊4楼9号窗口，工作人员协助预约。',
        }
    }
}
</script>
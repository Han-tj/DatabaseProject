<template>
  <div class="talk_body">
    <div class="test test-5" id="chatBoard" >
      <div :class="[(item.status==identity)?'btalk':'atalk']" v-for="item in list" :key="item.content"><span >{{item.text}}</span></div>
    </div>
    <div  class="scrollbar" id="content">
    </div>
    <div class="talk_input">
      <el-input
          @keyup.enter.native="up"
          placeholder="请输入内容"
          v-model="value"
          clearable>
      </el-input>
      <div class="button_show">
        <el-dropdown @command="handleCommand">
          <el-button size="mini" >
            快捷语句<i class="el-icon-arrow-down el-icon--right"></i>
          </el-button>
          <el-dropdown-menu slot="dropdown" >
            <el-dropdown-item :command=item.index v-for="item in quickText" :key="item.index">{{item.text}}</el-dropdown-item>
          </el-dropdown-menu>
        </el-dropdown>
        <el-button size="mini" @click="up" style="margin-left: 10px" type="primary">发送</el-button>
      </div>
    </div>
  </div>
</template>

<script>
import {sendChatMesFun, getChatMesFun} from '@/service/userService.js'
export default {
name: "text_box",
  data() {
    return {
      value:'',//发送的内容
      list:[],//消息列表
      // 查询新消息,轮询
      chatRoomId:-1,
      userId:this.$store.state.identity ==='patient'?this.$store.state.inquiry.patientId:this.$store.state.inquiry.doctorId,
      otherId:this.$store.state.identity ==='doctor'?this.$store.state.inquiry.patientId:this.$store.state.inquiry.doctorId,
      identity:this.$store.state.identity,
      quickText:[],
      quickPatiText:[
        {
          index:0,
          text:'您好'
        },
        {
          index:1,
          text:'谢谢！'
        },
        {
          index:2,
          text:'请问您填写好病历了吗?'
        },
        {
          index:3,
          text:'请问您填写好处方了吗?'
        },
        {
          index:4,
          text:'还有什么注意事项吗？'
        }
      ],
      quickDocText:[
        {
          index:0,
          text:'你好'
        },
        {
          index:1,
          text:'有什么症状吗?'
        },
        {
          index:2,
          text:'病历已填写'
        },
        {
          index:3,
          text:'处方已填写'
        },
        {
          index:4,
          text:'有什么药物过敏史吗？'
        },
        {
          index:5,
          text:'近期服用过什么药品吗？'
        }
      ]
    }
  },
  created(){
    this.loadQuickText();
  },
  mounted() {
    // 查看聊天表中是否有信息
    this.buildRoom();
    //轮询接收新消息
    this.chatRoomId = setInterval(() => {
      this.buildRoom();
    }, 1000);
    this.$store.commit("editChatRoomId",this.chatRoomId);
  },
  methods:{
    handleCommand(command){
      this.value=this.value+this.quickText[command].text;
      // this.value=command;
    },
    loadQuickText(){
      if(this.$store.state.identity=='patient'){
        this.quickText=this.quickPatiText;
      }else{
        this.quickText=this.quickDocText;
      }
    },
    buildRoom(){
      getChatMesFun({//向后端请求信息
        client_ID:this.identity === 'patient'?this.userId:this.otherId,
        server_ID:this.identity === 'patient'?this.otherId:this.userId
      }).then(res=>{
        if(res.result.length !== 0){
          this.list.splice(0,this.list.length);
          for(let i of res.result){
            this.list.push({
              text:i.content,
              status:i.tag
            })
          }
          this.$nextTick(() => {//异步更新DOM
            let container;
            container = document.querySelector('.test-5')
            container.scrollTop = container.scrollHeight
          })
        }
      }).catch(err=>{
        console.log(err)
      })
    },
    //发送内容
    up(){
      if(this.value == ''){
        this.$Message.error('请输入您想要发送的内容')
      }else{
        sendChatMesFun({//内容不空 向后端发送
          client_ID:this.identity === 'patient'?this.userId:this.otherId,
          server_ID:this.identity === 'patient'?this.otherId:this.userId,
          content:this.value,
          tag:this.identity
        }).then(res=>{
          let obj = {
            text:this.value,
            status:this.identity
          }
          this.list.push(obj);
          this.value = '';
          this.$nextTick(() => {//渲染
            let container = document.querySelector('.test-5')
            container.scrollTop = container.scrollHeight
          })
        }).catch(err => {
          console.log(err)
        })
      }
    },
  }
};
</script>

<style scoped>
.talk_body {
  position: relative;
  width: 100%;
  height: 95%;
  background: #fff;
  border: 0;
  overflow: auto;
}
.talk_input{
  position: relative;
  height: 15%;
  margin: auto;
  width:95%;
  bottom: 0;
}

.atalk {
  margin: 20px;
  margin-left: 10px;
  margin-left: 30px;
}

.atalk span {
  display: inline-block;
  /*background: #0181cc;*/
  background: RGB(229,229,229);
  border-radius: 10px;
  color: RGB(0,0,0);
  font-family: "造字工房尚雅体演示版常规体";
  padding: 5px 10px;
  font-size: 15px;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  /*font-weight: 700;*/
}

.button_show{
  height: 40px;
  padding-top: 10px;
  left:20px;
  text-align: right;
  bottom:0px;
  padding-right: 2px;
}
.input{
  font-family: "幼圆";
}

.btalk {
  margin: 20px;
  margin-right: 22px;
  text-align: right;
}

.btalk span {
  display: inline-block;
  background: RGB(204,224,255);
/*RGB(0,205,102)*/
  border-radius: 10px;
  color: RGB(31,35,41);
  padding: 5px 10px;
  font-family: "等线";
  font-size: 15px;
  font-family: "造字工房尚雅体演示版常规体";
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
}
::v-deep .upload-demo{
  padding-left: 10px;
  padding-right: 10px;
  width: 50px;
  display: inline;
}
.el-textarea__inner{
  font-family:"Microsoft";
  font-size:60px;
}
.test {
  position: relative;
  top:0;
  top:1%;
  bottom: 1%;
  height: 80%;
  width:99.9%;
  overflow: auto;
  float   : left;
  border  : none;
  margin-bottom: 2%;
}
.scrollbar {
  width : 30px;
  height: 500px;
  margin: 0 auto;
}
.test-5::-webkit-scrollbar {
  /*滚动条整体样式*/
  width : 7px;  /*高宽分别对应横竖滚动条的尺寸*/
  height: 100%;
}
.test-5::-webkit-scrollbar-thumb {
  /*滚动条里面小方块*/
  border-radius   : 10px;
  /*background-color: skyblue;*/
  /*background-color:RGB(168,194,255);*/
  background-color:rgba(64,158,255,0.4);
  background-image: -webkit-linear-gradient(
      45deg,
      rgba(255, 255, 255, 0.2) 25%,
      transparent 25%,
      transparent 50%,
      rgba(255, 255, 255, 0.2) 50%,
      rgba(255, 255, 255, 0.2) 75%,
      transparent 75%,
      transparent
  );
}
.test-5::-webkit-scrollbar-track {
  /*滚动条里面轨道*/
  box-shadow   : inset 0 0 5px rgba(0, 0, 0, 0.2);
  background   : #ededed;
  border-radius: 10px;
}
</style>

<template>
  <div class="title">
    <div class="image">
      <span class="test">{{oppositeName}}</span>
    </div>

  </div>
</template>

<script>
export default {
name: "inquiry_title",
  data(){
    return{
      oppositeName:'',
    }
  },
  created() {
    this.loadOppositeName();
  },
  methods:{
    loadOppositeName(){
      if(this.$store.state.identity=='patient'){
        this.oppositeName=this.$store.state.inquiry.doctorName+'医生';
      }else{
        this.oppositeName=this.$store.state.inquiry.patientName;
      }
      console.log(this.oppositeName);
    }
  },
}
</script>

<style scoped>
.title{
  position: relative;
  padding-top: 20px;
  border-bottom: 1px solid #DCDCDC;
  padding-right: 10px;
  padding-left: 29px;
  height: 5%;
}
.image{
  padding-left:400px;
  padding-bottom: 5px;
}
img{
  vertical-align:middle;
}
.test{
  font-size: 23px;
  padding-left: 10px;
  height: 30px;
  line-height: 30px;
}
.user_pic{
  left:40px;
  width: 150px;
  display: inline;
  vertical-align: middle;
}
.user_name{
  width:150px;
  height:150px;
  font-family:"黑体";
  font-size:25px;
  display: inline;
  vertical-align: middle;
}
.buttoms{
  left:500px;
  text-align: right;
  display: inline;
  vertical-align: middle;
}

</style>

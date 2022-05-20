<template>
    <el-form ref="form" :rules="rules" :model="form" label-width="80px">
        
  <el-form-item label="名字" prop="name">
    <el-input v-model="form.name" clearable :placeholder="this.PaiInoData.PATI_NAME"></el-input>
  </el-form-item>
  <el-form-item label="电话" prop="phone">
    <el-input v-model="form.phone" clearable :placeholder="this.PaiInoData.TEL"></el-input>
  </el-form-item>
  <el-form-item label="密码" prop="password">
    <el-input v-model="form.password" clearable :placeholder="this.PaiInoData.PASSWORD"></el-input>
  </el-form-item>
  
  <el-form-item>
    <el-button>取消</el-button>
    <el-button type="primary" @click="update(),onSubmit()">确认修改</el-button>
  </el-form-item>
</el-form>
</template>

<script>
  export default {
    components: {
  },
    data() {
      var checktel = (rule, value, callback) => {
                if (!(/^1[3|4|5|7|8|9][0-9]\d{4,8}$/.test(value))) {
                    callback(new Error('请输入合法的手机号码'));
                } else {
                    callback();
                }
            };
      return {
        visible:false,
        form: {
          name: '',
          phone: '',
          password:'',
        },

        rules: {
            name: [
              { required: false, //是否必填
                message: '名字不能为空', //规则
                trigger: '长度在 3 到 10 个字符'  //何事件触发
              },
              //可以设置双重验证标准
              { min: 2, max: 10,  message: '长度在 3 到 10 个字符', }
            ],
            phone: [
              { required: false, //是否必填
                validator: checktel,
              },
              //可以设置双重验证标准
              { min: 3, max: 20,  message: '长度在 3 到 20 个字符', }
            ],
      }
      }
    },
    props:{
      PaiInoData:{
        type:Object,
        default:function(){
          return {}
        },
    },
    
},
methods: {
      update() {
        this.$message({
          message: '已修改',
          type: 'success'
        });
      },
          onSubmit() {
          console.log('onSubmit成功')
          this.visible = false
          for(let i in this.form){
            console.log("我在这")
            console.log(i)
            console.log(this.form[i])
          }
          this.$emit('subUpdayeUserform',this.form)

    },
},
watch:{
        PaiInoData(){
          this.form.name = this.PaiInoData.PATI_NAME
          this.form.phone = this.PaiInoData.TEL
          this.form.password = this.PaiInoData.PASSWORD
        }
  }
}
</script>

<style scoped>

</style>

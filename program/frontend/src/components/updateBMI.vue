<template>
    <el-form ref="form" :rules="rules" :model="form" label-width="80px">
        
  <el-form-item label="身高" prop="tall">
    <el-input v-model="form.tall" clearable placeholder="/cm"
     onkeypress='return( /[\d]/.test(String.fromCharCode(event.keyCode)))'
    ></el-input>
  </el-form-item>
  <el-form-item label="体重" prop="weight">
    <el-input v-model="form.weight" clearable placeholder="/kg"
     onkeypress='return( /[\d]/.test(String.fromCharCode(event.keyCode)))'
    ></el-input>
  </el-form-item>
    <el-form-item label="血压" prop="blood">
    <el-input v-model="form.blood" clearable placeholder="/mmHg"
     onkeypress='return( /[\d]/.test(String.fromCharCode(event.keyCode)))'
    ></el-input>
  </el-form-item>
  <el-form-item label="心率" prop="reat">
    <el-input v-model="form.reat" clearable placeholder="次/分钟"
    onkeypress='return( /[\d]/.test(String.fromCharCode(event.keyCode)))'
    ></el-input>
  </el-form-item>
  
  <el-form-item>
    <el-button type="primary" @click="onSubmit();update()">生成</el-button>
    <el-button>取消</el-button>
  </el-form-item>
</el-form>
</template>

<script>
  export default {
    components: {
  },
    data() {
      return {
        form: {
          tall: '',
          weight: '',
          blood: '',
          reat: '',
        },

        rules: {
            tall: [
              { required: true, //是否必填
                message: '身高不能为空', //规则
              },
            ],
            weight: [
              { required: true, //是否必填
                message: '体重不能为空', //规则
              },
            ],
             blood: [
              { required: true, //是否必填
                message: '血压不能为空', //规则
              },
            ],
            reat: [
              { required: true, //是否必填
                message: '心率不能为空', //规则
              },
            ],
      }
      }
    },
    methods: {
      onSubmit() {
        this.$message({
          message: '已生成',
          type: 'success'
        });
      },
      update(){
        $store.state.BMIList.tall.cm=this.form.tall;
        $store.state.BMIList.weight=this.form.weight;
        $store.state.BMIList.blood=this.form.blood;
        $store.state.BMIList.reat=this.form.reat;
      },
    }
  }
</script>

<style scoped>

</style>

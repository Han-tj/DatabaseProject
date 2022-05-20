<template>
  <div>
    <div style="cursor: pointer">
      <img
        src="../assets/acid.jpg"
        width="480px"
        height="290px"
        @click="isFormVisible = true"
      />
    </div>
    <el-dialog :visible.sync="isFormVisible" @close="isFormVisible = false">
      <el-form ref="form" :model="form" label-width="80px">
        <el-form-item label="姓名">
          <el-input v-model="form.name"></el-input>
        </el-form-item>
        <el-form-item label="医院">
          <el-select
            v-model="form.region"
            placeholder="请选择医院"
            style="width: 100%"
          >
            <el-option v-for="(value,index) in hosList" :key="index"
              :label="value"
              :value="value"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="预约时间">
          <el-col :span="11">
            <el-date-picker
              type="date"
              placeholder="选择日期"
              v-model="form.date1"
              style="width: 100%"
            ></el-date-picker>
          </el-col>
          <el-col class="line" :span="2">-</el-col>
          <el-col :span="11">
            <el-time-picker
              placeholder="选择时间"
              v-model="form.date2"
              style="width: 100%"
            ></el-time-picker>
          </el-col>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" @click="onSubmit">提交</el-button>
          <el-button @click="isFormVisible = false">取消</el-button>
        </el-form-item>
      </el-form>
    </el-dialog>
  </div>
</template>

<script>
export default {
  name: "n_acid",

  data() {
    return {
      isFormVisible: false,
      form: {
        name: "",
        date1: "",
        date2: "",
        region:'',
      },
      hosList:['同济大学附属医院','上交附属医院','复旦大学附属医院'
      ,'仁济医院','上海第九人民医院','上海第六人民医院','上海市长征医院']
    };
  },
  methods: {
    onSubmit() {
      this.isFormVisible = false
      this.$emit('onSubmit',this.form)
    },
  },
};
</script>

<style scoped>
</style>
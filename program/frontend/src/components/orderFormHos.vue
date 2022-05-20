<template>
  <el-dialog :visible.sync="visible" @close="onClose">
    <el-form ref="form" :model="form" label-width="80px" >
      <el-form-item label="姓名">
        <el-input v-model="form.name"></el-input>
      </el-form-item>
      <el-form-item label="身份证号">
        <el-input v-model="form.data1"></el-input>
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
      <el-form-item label="科室">
        <el-select v-model="form.region" placeholder="请选择科室" style="width: 100%">
          <el-option label="外科" value="外科"></el-option>
          <el-option label="内科" value="内科"></el-option>
          <el-option label="妇科" value="妇科"></el-option>
          <el-option label="儿科" value="儿科"></el-option>
          <el-option label="消化内科" value="消化内科"></el-option>
          <el-option label="血液内科" value="血液内科"></el-option>
          <el-option label="内分泌科" value="内分泌科"></el-option>
          <el-option label="呼吸内科" value="呼吸内科"></el-option>
          <el-option label="骨科" value="骨科"></el-option>
          <el-option label="神经外科" value="神经外科"></el-option>
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="onSubmit">提交</el-button>
        <el-button @click="visible = false">取消</el-button>
      </el-form-item>
    </el-form>
  </el-dialog>
</template>

<script>
export default {
  data() {
    return {
      form: {
        name: "",
        date1: "",
        date2: "",
        delivery: false,
        desc: "",
        region:'',
      },
      visible: false,
    };
  },
  props: {
    isVisible: {
      type: Boolean,
      default: false,
    },
  },
  methods: {
  onSubmit() {
      this.visible = false
      this.$emit('formSubmit',this.form)
    },
  onClose(){//加一个beforeclose以及防止误触 
      this.$emit('formClose',false)
    },
  },
  watch: {
    isVisible() {
      this.visible = this.isVisible;
    },
  },
};
</script>

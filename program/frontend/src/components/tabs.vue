<template>
  <div class="tabs">
    <el-tabs v-model="activeName" @tab-click="handleClick">
      <el-tab-pane label="病历填写" name="first">
        <medicalrecord_form></medicalrecord_form>
      </el-tab-pane>
      <el-tab-pane label="处方填写" name="second" :disabled="this.$store.state.inquiry.includeDisabled">
        <prescription_form></prescription_form>
      </el-tab-pane>
      <el-tab-pane label="患者信息" name="third">
        <patient_information></patient_information>
      </el-tab-pane>
    </el-tabs>
  </div>

</template>

<script>
import medicalrecord_form from "./medicalrecord_form";
import prescription_form from "./prescription_form";
import patient_information from "./patient_info";
export default {
name: "tabs",
  data() {
    return {
      activeName: 'third'
    };
  },
  components:{
    medicalrecord_form,
    prescription_form,
    patient_information
  },
  methods: {
    handleClick(tab, event) {
      console.log(tab, event);
    }
  }
}
</script>

<style scoped>
.tabs{
  position: relative;
  width: 90%;
  height: 100%;
}
/deep/.tab_pos{
  left:0px;
  right: 0px;
}
/deep/.el-tabs__item{
  font-weight: bolder;
  padding: 0 15px;
}

/deep/.el-checkbox{
  margin-right: 6px;
}
</style>

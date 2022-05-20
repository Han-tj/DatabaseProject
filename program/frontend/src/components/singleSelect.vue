<template>
  <div>
    <el-select
      v-model="selectedValue"
      placeholder="请选择分类标签"
      @change="filterData(selectedValue)"
    >
      <el-option
        v-for="item in selectedOptions"
        :key="item.value"
        :label="item.label"
        :value="item.value"
      >
      </el-option>
    </el-select>
  </div>
</template>

<style>
</style>

<script>
export default {
  data() {
    return {
      selectedValue: "全部",
    };
  },
  props: {
    selectedOptions: {
      type:Array,
      default:function(){
        return []
      }
    },
    selectedData: {
      type:Array,
      default:function(){
        return []
      }
    }
  },
  methods: {
    filterData(this_label) {
      //this.currentPage = 1;
      if (this_label === "全部") this.$emit('selectData',this.selectedData);
      else this.$emit(
          'selectData',
           this.selectedData.filter((item) => {
           return item.index === this_label;})
        )
    },
  },
}
</script>

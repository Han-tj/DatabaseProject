<template>
    <el-calendar v-model="value">
</el-calendar>
</template>
<style lang="scss" scoped>
.el-calendar {
      box-shadow: 2px 5px 10px;
}
</style>
<script>
  export default {
    name: 'Calendar',
    data() {
      return {
        value: new Date()
      }
    }
  }
</script>

<style>
.el-calendar-day {
    box-sizing: border-box;
    padding: 8px;
    height: 50px!important;
}
</style>
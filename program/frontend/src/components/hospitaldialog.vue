<template>
  <div>
    <el-dialog
      title="详细信息"
      :visible.sync="visible"
      width="45%"
      @close="handleClose"
    >
      <div class="intr">
      <ul>
        <li v-for="(value,Key) in dataList" :key=Key>
           {{value}}
        </li>
      </ul>
      </div>
      <span slot="footer" class="dialog-footer">
        <el-button type="primary" @click="visible = false">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<style scoped>
.intr{
  padding:10px;
  font-size: 18px;
  font-family: STKaiti,KaiTi;
}
</style>

<script>
export default {
  data() {
    return {
      visible:false,
      dataList:{}
    };
  },
  props:{
    dialogVisible:{
      type:Boolean,
      default:false
    },
    dialogData:{
      type:Object,
      default:function(){
        return {}
      }
    }
  },
  methods: {
    handleClose() {
        this.$emit('dialogClick',false)
    },
  },
  watch:{
        dialogVisible(){
          this.visible = this.dialogVisible
            },
        dialogData(){
          this.dataList = this.dialogData
         
        }
  }
};
</script>


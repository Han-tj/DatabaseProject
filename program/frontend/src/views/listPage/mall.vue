<template>
  <div class="docList">
    <Navigation></Navigation>
    <div class="select">
      <myselect
        :selectedOptions="options"
        :selectedData="drugList"
        @selectData="changeData"
      >
      </myselect>
    </div>
    <div class="search">
        <mysearch 
        :selectedOptions="options1"
        :selectedData="drugList"
        @selectData="changeData"></mysearch>
    </div>
    <div class="cart">
        <shoppingCart></shoppingCart>
    </div>
    <div class="card">
      <cardMedicine ref="listItem" :dataList="drugData">
        <el-button type="primary" class="button" @click="addCart" >加购</el-button>
      </cardMedicine>
    </div>
  </div>
</template>

<style scoped>
.docList{
  overflow-y: scroll;
}
.select{
    position: absolute;
    left:17%;
    top:18%
}
.card{
    position:absolute;
    left:14%;
    top:23%
}
.cart{
    position:absolute;
    left:85%;
    top:18%
}
.search{
    position:absolute;
    left:45%;
    top:18%
}
.page{
    position: absolute;
    left:70%;
    top:100%
}
</style>

<script>
import Navigation from "@/components/Navigation.vue";
import myselect from "@/components/singleSelect.vue";
import mysearch from '@/components/searchingSelect.vue'
import {getDrugFun} from "@/service/userService.js";
import cardMedicine from '@/components/cardMedicine.vue';
import shoppingCart from '@/components/shoppingCart.vue';

export default {
  name: "mall",
  components: {
    myselect,
    Navigation,
    mysearch,
    shoppingCart,
    cardMedicine,
  },
  data() {
    return {
      drugList: [],
      drugData: [],
      options: [],
      options1:[]
    };
  },
  created() {
    this.getDataList();
  },
  methods: {
    getDataList(){
      getDrugFun(
      ).then(res=>{//index为筛选标签 index1为搜索索引
         for(let i of res.result){
          this.drugList.push({
            id:i.medicine_ID,
            index1:i.medicine_Name,
            index:i.category,
            price:i.price,
            prescription_type:i.prescription_Type,
            adaption:i.adaption_Disease,
            inventory:i.inventory,
            data:i.expirationData,
            pic:parseInt(i.medicine_ID),
          }
          );
        }
        this.drugData = this.drugList;
        this.getOptions()
      }).catch(err=>{
         console.log(err);
      });
    },
       getOptions(){
      this.options.push({value:'全部',label:'全部'})
      this.options1.push({value:'全部',label:'全部'})   
      let obj = {}, obj1 = {}
      for(let i of this.drugList){
        if(!obj[i.index]){
          obj[i.index] = 1
          this.options.push({
            value:i.index,
            label:i.index
          })
        }
      }
      for(let i of this.drugList){
        if(!obj1[i.index1]){
          obj1[i.index1] = 1
          this.options1.push({
            value:i.index1,
            label:i.index1
          })
        }
      }    
    },
    changeData(newdata) {
      this.drugData = newdata;
    },
    addCart(mes){
      this.$refs.listItem.recordLocation(mes)
      let item = {
        drug_name:this.$refs.listItem.lastCardInfo._name,
        drug_id:this.$refs.listItem.lastCardInfo._id,
        drug_price:Number(this.$refs.listItem.lastCardInfo._price),
        drug_url:this.$refs.listItem.lastCardInfo._url
      }
      this.$store.commit('addPro', item)
      this.$message({
        message:'添加成功',
        type:'success'
      })
    },
  },
};
</script>

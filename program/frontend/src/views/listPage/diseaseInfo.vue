<template>
  <div class="docList" >
    <Navigation></Navigation>
    <div class="search">
        <mysearch 
        :selectedOptions="options"
        :selectedData="diseaseList"
        @selectData="changeData"></mysearch>
    </div>
    <div class="dis">
    <disease  :dataList="diseaseData"></disease>
    </div>
  </div>
</template>

<style scoped>
body { overflow-y: scroll; }
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
.dis{
    position: absolute;
    top:180px;
    width:1500px;
}
</style>

<script>
import Navigation from "@/components/Navigation.vue";
import mysearch from '@/components/searchingSelect.vue'
import {getDiseaseFun} from "@/service/userService.js";
import disease from '@/components/disease.vue';

export default {
  name: "diseaseInfo",
  components: {
    Navigation,
    mysearch,
    disease
  },
  data() {
    return {
      diseaseList: [],
      diseaseData: [],
      options: [],
    };
  },
  created() {
    this.getDataList();
  },
  methods: {
      getDataList(){
      getDiseaseFun(
      ).then(res=>{
        for(let i of res.result){
          this.diseaseList.push({
            index:i.disease_Name,
            pathogeny:i.pathogeny,
            symptoms:i.symptoms,
            medication:i.medication,
            introduction:i.introduction,
            complication:i.complication,
          }
          );
        }
        this.diseaseData = this.diseaseList;
        this.getOptions()
      }).catch(err=>{
         console.log(err);
      });
    },
    getOptions(){//获得所有可能的index
        let obj = {}
        this.options.push({value:'全部', label:'全部'})
        for(let i of this.diseaseList){
          if(!obj[i.index]){
            obj[i.index] = 1
            this.options.push({
              value:i.index,
              label:i.index
              })
          }
        }
    },
    changeData(newdata) {
      this.diseaseData = newdata;
    },
  },
};
</script>


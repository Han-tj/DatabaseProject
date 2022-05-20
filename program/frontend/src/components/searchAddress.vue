<template>
<el-form :inline="true" :model="filters">
          <el-form-item>
              <el-row>
             <el-select v-model="filters.value1" clearable placeholder="省/直辖市" @change="getRole($event)">
                <el-option
                v-for="item in select1"
                :key="item.value"
                :label="item.label"
                :value="item.value">
                </el-option>
            </el-select>

            <el-select v-model="filters.value2" filterable
            placeholder="市/县/区" :loading="loading" @change="getList($event)">
                <el-option
                  v-for="item in select2"
                  :key="item.value"
                  :label="item.label"
                  :value="item.value"></el-option>
            </el-select>
            </el-row>
          </el-form-item>
        </el-form>
</template>

<script>
export default {
  data () {
    return {
      select1: select1,
      loading: false,
      filters: {
        value1: '',
        value2: ''
      },
      select2:[]
    }
  },
  methods: {
    getRole (prov) {
      let roles = []
      this.select2= []
      for (var val of allrole) {
        if (prov===val.pro) {
          console.log(val)
          roles.push({label: val.label,value: val.label})
        }
        this.select2 = roles
      }
    },
    getList (opt) {
      console.log(opt)
    }
  }
}
let select1= [
 {value: 'beijing', label: '北京'},
 {value: 'shanghai', label: '上海'},
 {value: 'guangdong', label: '广东'},
 {value: 'zhejiang', label: '浙江'}
]
let allrole= [
  {pro:'beijing',label: '东城区'},{pro: 'beijing',label: '西城区'},
  {pro:'beijing',label: '朝阳区'},{pro: 'beijing',label: '丰台区'},
  {pro:'beijing',label: '石景山区'},{pro: 'beijing',label: '海淀区'},
  {pro:'beijing',label: '顺义区'},{pro: 'beijing',label: '通州区'},
  {pro:'beijing',label: '大兴区'},{pro: 'beijing',label: '房山区'},
  {pro:'beijing',label: '门头沟区'},{pro: 'beijing',label: '昌平区'},
  {pro:'beijing',label: '平谷区'},{pro: 'beijing',label: '密云区'},
  {pro:'beijing',label: '怀柔区'},{pro: 'beijing',label: '延庆区'},
  {pro:'shanghai',label: '黄浦区'},{pro: 'shanghai',label: '徐汇区'},
  {pro:'shanghai',label: '长宁区'},{pro: 'shanghai',label: '静安区'},
  {pro:'shanghai',label: '普陀区'},{pro: 'shanghai',label: '虹口区'},
  {pro:'shanghai',label: '杨浦区'},{pro: 'shanghai',label: '闵行区'},
  {pro:'shanghai',label: '宝山区'},{pro: 'shanghai',label: '嘉定区'},
  {pro:'shanghai',label: '浦东新区'},{pro: 'shanghai',label: '金山区'},
  {pro:'shanghai',label: '松江区'},{pro: 'shanghai',label: '青浦区'},
  {pro:'shanghai',label: '奉贤区'},{pro: 'shanghai',label: '崇明区'},
  {pro:'guangdong',label: '广州市'},{pro: 'guangdong',label: '韶关市'},
  {pro:'guangdong',label: '深圳市'},{pro: 'guangdong',label: '珠海市'},
  {pro:'guangdong',label: '汕头市'},{pro: 'guangdong',label: '佛山市'},
  {pro:'guangdong',label: '江门市'},{pro: 'guangdong',label: '湛江市'},
  {pro:'guangdong',label: '茂名市'},{pro: 'guangdong',label: '肇庆市'},
  {pro:'guangdong',label: '惠州市'},{pro: 'guangdong',label: '梅州市'},
  {pro:'guangdong',label: '汕尾市'},{pro: 'guangdong',label: '河源市'},
  {pro:'guangdong',label: '阳江市'},{pro: 'guangdong',label: '清远市'},
  {pro:'guangdong',label: '东莞市'},{pro: 'guangdong',label: '中山市'},
  {pro:'guangdong',label: '潮州市'},{pro: 'guangdong',label: '揭阳市'},
  {pro:'guangdong',label: '云浮市'},
  {pro:'zhejiang',label: '杭州市'},{pro: 'zhejiang',label: '宁波市'},
  {pro:'zhejiang',label: '温州市'},{pro: 'zhejiang',label: '嘉兴市'},
  {pro:'zhejiang',label: '湖州市'},{pro: 'zhejiang',label: '绍兴市'},
  {pro:'zhejiang',label: '金华市'},{pro: 'zhejiang',label: '衢州市'},
  {pro:'zhejiang',label: '舟山市'},{pro: 'zhejiang',label: '台州市'},
  {pro:'zhejiang',label: '丽水市'},
]

</script>

<style scoped>
.el-row {
    margin-bottom: 5px;
  }
.el-col {
    border-radius: 4px;
  }
</style>
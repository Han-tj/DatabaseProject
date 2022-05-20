import Vue from 'vue'
import Vuex from 'vuex'
import {getCartFun, clearCartFun, addCartFun} from '@/service/userService'
Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    productList:[],
    cartStatus:true,
    identity:'',
    userId:'',
    loading: false,
    inquiry:{
      patientId:'',
      doctorId:'',
      patientName:'',
      doctorName:'',
      preId:'',
      diseaseDecided:'',
      includeDisabled:true,
      chatroomId:-1,
    }
  },
  mutations: {
    setLoadingStatus(state, status){
      state.loading = status
    },
    increment(state,id){
      for(let i of state.productList){
        if(i.pro_id === id) {
          i.pro_num++;
          break;
        }
      }
    },
    subtract(state,id){
      for(let i of state.productList){
        if(i.pro_id === id) {
          i.pro_num--;
          break;
        }
      }
    },
    clear(state,newList){
      state.productList = newList
      if(state.cartStatus === true) {//因为空购物车是不能清空的 故先检查一下 如果本身就是空 那么不用清空直接添加
        clearCartFun({
          Pati_ID: state.userId
        })
        .then(res =>{
          if(res.result === 1) console.log('购物车清空成功') 
        })
        .catch(err=>{
          console.log(err)
        })
      }
      for(let i of newList){//把保留的商品传回数据库
        addCartFun({
          Medicine_ID:i.pro_id,
          Pati_ID:state.userId,
          quantity:i.pro_num
        }).
        then(res=>{
        })
        .catch(err=>{
          console.log(err)
        })
      }
    },
    editPatientId(state,id){
      state.userId=id;
      state.identity='patient';
      state.inquiry.patientId = id;
      console.log(state.userId)
    },
    editDoctorId(state,id){
      console.log(id)
      state.userId=id;
      state.identity='doctor';
      state.inquiry.doctorId = id;
    },
    editAdminId(state, id){
      state.userId =id
      state.identity = 'admin'
    },
    getAllPro(state, id){//只有病人可以请求 所以不能从state请求
      getCartFun({
        ID: id
      })
      .then(res => {
        if(res.result.objects !== null) {
          console.log("feikong")
          for(let i of res.result.objects){
            console.log(i)
            state.productList.push({
              pro_id:i.medicine_ID,
              pro_name:i.medicine_name,
              pro_num:Number(i.quantity),
              select:true,
              pro_img:`http://106.14.45.227:8081/${String(i.medicine_ID)}.png`,
              pro_price:Number(i.price)
            })
          }
        }
        else state.cartStatus = false
      })
      .catch(err => {
        console.log(err)
      })
    },
    addPro(state, obj){
      let k = false
      for(let i of state.productList){
        if(i.pro_id == obj.drug_id) {
          i.pro_num ++ 
          k = true //原商品存在购物车中，合并
          break
        }
      }
      if(!k) {
        state.productList.push({
          pro_id:obj.drug_id,
          pro_name:obj.drug_name,
          pro_num:1,
          select:true,
          pro_img:obj.drug_url,
          pro_price:obj.drug_price
        })
      }
    },
    editDiseaseDecided(state,disease){
      state.inquiry.diseaseDecided=disease
    },
    editInquiryPreId(state,preId){
      state.inquiry.preId=preId;
    },
    editInquiryPatientName(state,name){
      state.inquiry.patientName=name;
    },
    editInquiryDocName(state,name){
      state.inquiry.doctorName=name;
    },
    editInquiryIncludeDisabled(state,disabled){
      state.inquiry.includeDisabled=disabled;
    },
    editChatRoomId(state,id){
      state.inquiry.chatroomId=id;
    },
    editInquiryDocId(state,id){
      state.inquiry.doctorId=id;
    },
    editInquiryPatiId(state,id){
      state.inquiry.patientId=id;
    }
  },
  getters:{
    totalPrice(state){
      let price = 0;
      for (let i of state.productList) {
        if(i.select === true)
        price += i.pro_num * i.pro_price;
      }
      return price.toFixed(2);
    }
  },
})

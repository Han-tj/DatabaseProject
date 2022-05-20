<template>
  <div>
    <div>
	<el-button type="primary" @click="showCart" >购物车</el-button>
    </div>
    <el-dialog
      title="我的购物车"
      :visible.sync="visible"
      width="60%"
      @close="handleClose"
    >
      <div class="infoDisplay">
        <form action="#" method="post">
          <table class="form">
            <thead>
              <tr>
                <th width="8%">选择</th>
                <th width="50%">商品</th>
                <th width="13%">单价（元）</th>
                <th width="15%">数量</th>
                <th width="14%">金额（元）</th>
              </tr>
            </thead>
            <tbody id="cart-goods-list">
              <tr v-for="cart in $store.state.productList" :key="cart.pro_id">
                <td>
                  <input
                    type="checkbox"
                    name="good-id"
                    :value="1"
                    v-model="cart.select"
                  />
                </td>
                <td class="goods">
                  <div class="goods-image">
                    <img :src="cart.pro_img" />
                  </div>
                  <div class="goods-information">
                    <h3>{{ cart.pro_name }}</h3>
                  </div>
                </td>
                <td>
                  <span class="price"
                    >￥<em class="price-em">{{
                      cart.pro_price.toFixed(2)
                    }}</em></span
                  >
                </td>
                <td>
                  <div class="combo">
                    <input
                      type="button"
                      name="minus"
                      value="-"
                      class="combo-minus"
                      @click="
                        cart.pro_num < 2 ? (cart.pro_num = 1) : sub(cart.pro_id)
                      "
                    />
                    <input
                      type="text"
                      name="count"
                      v-model.number="cart.pro_num"
                      class="combo-value"
                    />
                    <input
                      type="button"
                      name="plus"
                      value="+"
                      class="combo-plus"
                      @click="add(cart.pro_id)"
                    />
                  </div>
                </td>
                <td>
                  <strong class="amount"
                    >￥<em class="amount-em">{{
                      (cart.pro_price * cart.pro_num).toFixed(2)
                    }}</em></strong
                  >
                </td>
              </tr>
            </tbody>
            <tfoot v-show="$store.state.productList.length != 0">
              <tr>
                <td colspan="2">
                  <label>
                    <input type="checkbox" name="all" v-model="isSelectAll" />
                    <span>全选</span>
                  </label>
                  &nbsp;
                  <el-button type="danger" icon="el-icon-delete" circle @click="del"></el-button>
                </td>
                <td colspan="3">
                  <span>合计：</span>
                  <strong id="total-amount"
                    >￥<em id="total-amount-em">{{ $store.getters.totalPrice }}</em></strong
                  >
                  &nbsp;        
                  <el-button  type="primary" @click="buy">立即结算</el-button>
                </td>
              </tr>
            </tfoot>
          </table>
        </form>
        <div v-show="$store.state.productList.length === 0">
          购物车还是空的哦
        </div>
      </div>
    </el-dialog>
  </div>
</template>

<script>
export default {
  data() {
    return {
      visible: false,
      space:'&nbsp'
    };
  },
  computed: {
    isSelectAll: {
      get() {
        return this.$store.state.productList.every(function (val) {
          return val.select === true;
        });
      },
      set(newValue) {
        for (let i = 0; i < this.$store.state.productList.length; i++) {
          this.$store.state.productList[i].select = newValue;
        }
      },
    },
  },
  methods: {
	add(id){
		this.$store.commit("increment",id)
	},
	sub(id){
		this.$store.commit("subtract",id)
	},
  buy() {
      let x = 0;
      this.$prompt("请输入密码", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
      })
      .then(() => {
          this.$message({
            type: "success",
            message: "购买成功！",
          });
        let newArr = [];//记录要购买的物品
        for (let i = 0; i < this.$store.state.productList.length; i++) {
          if (this.$store.state.productList[i].select === false) {
            newArr.push(this.$store.state.productList[i]);
          }
        }
		    this.$store.commit("clear",newArr)
        })
      .catch(() => {
          this.$message({
            type: "info",
            message: "取消支付",
          });
        });
    },
    del () {
      if (confirm("确定要删除吗")) {
        let newArr = [];
        for (let i = 0; i < this.$store.state.productList.length; i++) {
          if (this.$store.state.productList[i].select === false) {
            newArr.push(this.$store.state.productList[i]);
          }
        }
		  this.$store.commit("clear",newArr)
      this.$message({
        message:'删除成功',
        type:'success'
      })
      }
    },
    showCart() {
      this.visible = true
    },
    handleClose() {
      this.visible = false;
    },
  },
};
</script>

<style scoped>
/* /deep/ */
.el-dialog {
  height: 70%;
}
.infoDisplay {
  overflow: auto;
  width: 860px;
  height: 400px;
}

#main {
  padding: 30px 0px;
}

#cart {
  background: #ffffff;
  padding: 40px;
}

#cart h1 {
  line-height: 40px;
  padding: 0px 0px 10px 0px;
}

table.form {
  border-collapse: collapse;
  empty-cells: show;
  margin: 20px 0px;
  padding: 0px;
  table-layout: fixed;
  width: 100%;
}

table.form th,
table.form td {
  border-bottom: 1px solid #dddddd;
  padding: 15px 10px;
  text-align: left;
}

table.form {
  border-top: 3px solid #dddddd;
}

.goods .goods-image img {
  border: 1px solid #dddddd;
  float: left;
  height: 100px;
  margin: 0px 20px 0px 0px;
}

.goods .goods-information {
  float: left;
}

.goods .goods-information ul {
  color: #666666;
  font-size: 12px;
  line-height: 20px;
  margin: 10px 0px 0px 0px;
}

.price,
.amount,
#total-amount {
  color: #e00000;
}

#total-amount {
  font-size: 22px;
}

.price em,
.amount em,
#total-amount em {
  font-style: normal;
}

.combo .combo-minus,
.combo .combo-value,
.combo .combo-plus {
  background: #ffffff;
  border: 1px solid #dddddd;
  color: #333333;
  float: left;
  font-weight: bold;
  margin: 0px;
  outline: none;
  text-align: center;
}

.combo .combo-minus,
.combo .combo-plus {
  font-size: 16px;
  height: 26px;
  line-height: 26px;
  padding: 0px;
  width: 24px;
}

.combo .combo-value {
  border-left: none;
  border-right: none;
  height: 20px;
  line-height: 20px;
  padding: 2px;
  width: 40px;
}

#cart-delete {
  margin-left: 20px;
}

#settlement {
  background: #e00000;
  border: none;
  color: #ffffff;
  float: right;
  font-size: 16px;
  height: 40px;
  line-height: 40px;
  margin: 0px;
  outline: none;
  padding: 0px;
  width: 160px;
}
</style>
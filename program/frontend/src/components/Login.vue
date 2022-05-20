<template>
  <div>
    <div class="login_background">
      <img :src="imgSrc" width="100%" height="100%" alt="" />
    </div>
    <div class="login_box">
      <!-- 头像区域 -->
      <div class="avatar_box">
        <img src="../assets/logo2.png" alt="" />
      </div>
      <!-- 登录表单区域 -->
      <el-form
        ref="loginFormRef"
        :model="loginForm"
        :rules="loginFormRules"
        label-width="0px"
        class="login_form"
      >
        <el-tabs v-model="activeName" @tab-click="handleClick">
          <el-tab-pane label="患者登录" name="first">
            <!-- 用户名 -->
            <el-form-item prop="username">
              <el-input
                v-model="loginForm.username"
                prefix-icon="el-icon-user"
              ></el-input>
            </el-form-item>
            <!-- 密码 -->
            <el-form-item prop="password">
              <el-input
                v-model="loginForm.password"
                prefix-icon="el-icon-lock"
                type="password"
              ></el-input>
            </el-form-item>
            <!-- 按钮区域 -->
            <el-form-item class="btns">
              <el-button type="primary" @click="Plogin">登录</el-button>
              <el-button type="primary" @click="toRegister">注册</el-button>
              <el-button type="info" @click="resetloginForm">重置</el-button>
            </el-form-item>
          </el-tab-pane>
          <el-tab-pane label="医生登录" name="second">
            <!-- 用户名 -->
            <el-form-item prop="username">
              <el-input
                v-model="loginForm.username"
                prefix-icon="el-icon-user"
              ></el-input>
            </el-form-item>
            <!-- 密码 -->
            <el-form-item prop="password">
              <el-input
                v-model="loginForm.password"
                prefix-icon="el-icon-lock"
                type="password"
              ></el-input>
            </el-form-item>
            <!-- 按钮区域 -->
            <el-form-item class="btns">
              <el-button type="primary" @click="Dlogin">登录</el-button>
              <el-button type="primary" @click="toRegister">注册</el-button>
              <el-button type="info" @click="resetloginForm">重置</el-button>
            </el-form-item>
          </el-tab-pane>
        </el-tabs>
      </el-form>
    </div>
  </div>
</template>

<script>
import { loginPFun,loginDFun } from "../service/userService.js"
export default {
  data() {
    return {
      //这是登录表单的数据绑定对象
      loginForm: {
        username: "",
        password: "",
      },
      //这是表单的验证规则对象
      loginFormRules: {
        //验证用户ID是否合法
        username: [
          { required: true, message: "请输入用户ID", trigger: "blur" },
          {
            min: 3,
            max: 10,
            message: "长度在 3 到 10 个字符",
            trigger: "blur",
          },
        ],
        //验证密码是否合法
        password: [
          { required: true, message: "请输入登录密码", trigger: "blur" },
          {
            min: 6,
            max: 15,
            message: "长度在 6 到 15 个字符",
            trigger: "blur",
          },
        ],
      },
      activeName: "first",
      imgSrc: require("../assets/bg2.png"),
    };
  },
  methods: {
    //点击重置按钮，重置登录
    resetloginForm() {
      this.$refs.loginFormRef.resetFields();
    },
    //患者登录
    Plogin() {
      loginPFun({
        id: this.loginForm.username,
        password: this.loginForm.password,
      })
        .then((res) => {
           if (res.result === true){
          //window.sessionStorage.setItem("token", res.data.token);
            this.$notify({
              title: "提示",
              message: "用户登录成功",
              type: 'success',
              duration: 3000,
            });
            if(this.loginForm.username.substring(0,5) == 'Admin'){
              this.$router.push('/admin1');//要改
              this.$store.commit('editAdminId', this.loginForm.username)
            }
            else{
              this.$router.push("/Home");
              this.$store.commit("editPatientId",this.loginForm.username);//更改id
              this.$store.commit('getAllPro',this.loginForm.username)//请求购物车
            }
            this.$store.commit('setLoadingStatus',true)
          }
          else  {
            this.$notify({
              title: "提示",
              message: "用户登录失败",
              type: 'error',
              duration: 3000,
            });
          }
          console.log(res);
        })
        .catch((err) => {
          this.$notify({
            title: "提示",
            message: "用户访问错误",
            type: 'error',
            duration: 3000,
          });
          console.log(err);
        });
    },

    Dlogin() {
      console.log({
        id: this.loginForm.username,
        password: this.loginForm.password,
      }

      )
        loginDFun({
        id: this.loginForm.username,
        password: this.loginForm.password,
      })
        .then((res) => {
           if (res.result === true){
          //window.sessionStorage.setItem("token", res.data.token);
          this.$notify({
            title: "提示",
            message: "用户登录成功",
            type: 'success',
            duration: 3000,
          });
          this.$router.push("/homepage");
          this.$store.commit('editDoctorId',this.loginForm.username);
          this.$store.commit('setLoadingStatus',true)
          }
          else  {
            this.$notify({
              title: "提示",
              message: "用户登录失败",
              type: 'error',
              duration: 3000,
            });
          }
          console.log(res);
        })
        .catch((err) => {
          this.$notify({
            title: "提示",
            message: "用户访问错误",
            type: 'error',
            duration: 3000,
          });
          console.log(err);
        });     
    },
    toRegister() {
      this.$router.push("/register");
    },
    handleClick(tab, event) {//切换事件时可以根据身份不同做一些事情 
      console.log(tab, event);
    },
  },
};
</script>

<style lang="less" scoped>
.login_background {
  width: 100%;
  height: 100%;
  z-index: -1;
  position: absolute;
}

.login_box {
  width: 450px;
  height: 300px;
  background-color: #fff;
  opacity: 0.9;
  border-radius: 5px;
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(10%, -40%);
  z-index: 1;
  border: 1px solid #d8d2d2;
}

.avatar_box {
  height: 130px;
  width: 130px;
  border: 1px solid #d8d2d2;
  border-radius: 50%;
  padding: 10px;
  box-shadow: 0 0 10px #ddd;
  position: absolute;
  left: 50%;
  transform: translate(-50%, -65%);
  background-color: #fff;
  img {
    width: 100%;
    width: 100%;
    border-radius: 50%;
    background-color: #eeeeee;
  }
}

.login_form {
  position: absolute;
  bottom: 0;
  width: 100%;
  padding: 0 20px;
  box-sizing: border-box;
}

.btns {
  display: flex;
  justify-content: flex-end;
}
</style>
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
       <div class="pos">
      <el-tabs v-model="activeName" @tab-click="handleClick">
        <el-tab-pane label="患者注册" name="first">
          <el-form
            ref="loginForm1"
            :model="loginForm1"
            :rules="loginForm1Rules"
            label-width="80px"
            :inline="true"
            size="medium"
            class="login_form1"
          >
            <!-- 身份证 -->
            <el-form-item prop="identification" label="身份证号">
              <el-input
                v-model="loginForm1.identification"
                prefix-icon="el-icon-user"
              ></el-input>
            </el-form-item>
            <!-- 姓名 -->
            <el-form-item prop="username" label="姓名">
              <el-input
                v-model="loginForm1.username"
                prefix-icon="el-icon-user"
              ></el-input>
            </el-form-item>
            <!-- 电话号码 -->
            <el-form-item prop="telephone" label="电话号码">
              <el-input
                v-model="loginForm1.telephone"
                prefix-icon="el-icon-user"
              ></el-input>
            </el-form-item>
            <!-- 性别 -->
            <el-form-item label="性别">
              <el-radio v-model="loginForm1.sex" label="1">男</el-radio>
              <el-radio v-model="loginForm1.sex" label="2">女</el-radio>
            </el-form-item>
            <!-- 密码 -->
            <el-form-item prop="password" label="密码">
              <el-input
                v-model="loginForm1.password"
                prefix-icon="el-icon-lock"
                type="password"
              ></el-input>
            </el-form-item>
            <!-- 确认密码 -->
            <el-form-item prop="rePassword" label="确认密码">
              <el-input
                v-model="loginForm1.rePassword"
                prefix-icon="el-icon-lock"
                type="password"
                class="length"
              ></el-input>
            </el-form-item>
            <!-- 按钮区域 -->
            <el-form-item class="btns">
              <el-button type="text" @click="toLogin">已有账号，登陆</el-button>
              <el-button type="primary" @click="register1('loginForm1')"
                >注册</el-button
              >
              <el-button type="info" @click="resetloginForm1">重置</el-button>
            </el-form-item>
          </el-form>
        </el-tab-pane>

        <el-tab-pane label="医生注册" name="second">
          <el-form
            ref="loginForm2"
            :model="loginForm2"
            :rules="loginForm2Rules"
            label-width="80px"
            :inline="true"
            size="mini"
            class="login_form2"
          >
            <!-- 身份证 -->
            <el-form-item prop="identification" label="身份证号">
              <el-input
                v-model="loginForm2.identification"
                prefix-icon="el-icon-user"
              ></el-input>
            </el-form-item>
            <!-- 姓名 -->
            <el-form-item prop="username" label="姓名">
              <el-input
                v-model="loginForm2.username"
                prefix-icon="el-icon-user"
              ></el-input>
            </el-form-item>
            <!-- 电话号码 -->
            <el-form-item prop="telephone" label="电话号码">
              <el-input
                v-model="loginForm2.telephone"
                prefix-icon="el-icon-user"
              ></el-input>
            </el-form-item>
            <!-- 性别 -->
            <el-form-item label="性别">
              <el-radio v-model="loginForm2.sex" label="1">男</el-radio>
              <el-radio v-model="loginForm2.sex" label="2">女</el-radio>
            </el-form-item>
            <!-- 医院 -->
            <el-form-item prop="hospital" label="工作医院">
              <el-input
                v-model="loginForm2.hospital"
                prefix-icon="el-icon-office-building"
              ></el-input>
            </el-form-item>
            <!-- 科室 -->
            <el-form-item prop="department" label="科室">
              <el-input
                v-model="loginForm2.department"
                prefix-icon="el-icon-office-building"
              ></el-input>
            </el-form-item>
            <!-- 职称 -->
            <el-form-item prop="title" label="职称">
              <el-input
                v-model="loginForm2.title"
                prefix-icon="el-icon-office-building"
              ></el-input>
            </el-form-item>
            <!-- 工龄 -->
            <el-form-item prop="workingAge" label="工龄">
              <el-input
                v-model="loginForm2.workingAge"
                prefix-icon="el-icon-office-building"
              ></el-input>
            </el-form-item>
            <!-- 密码 -->
            <el-form-item prop="password" label="密码">
              <el-input
                v-model="loginForm2.password"
                prefix-icon="el-icon-lock"
                type="password"
              ></el-input>
            </el-form-item>
            <!-- 确认密码 -->
            <el-form-item prop="rePassword" label="确认密码">
              <el-input
                v-model="loginForm2.rePassword"
                prefix-icon="el-icon-lock"
                type="password"
              ></el-input>
            </el-form-item>
            <!-- 按钮区域 -->
            <el-form-item class="btns">
              <el-button type="text" @click="toLogin">已有账号，登陆</el-button>
              <el-button type="primary" @click="register2('loginForm2')"
                >注册</el-button
              >
              <el-button type="info" @click="resetloginForm2">重置</el-button>
            </el-form-item>
          </el-form>
        </el-tab-pane>
      </el-tabs>
       </div>
      <!-- </el-form> -->
    </div>
      <!-- 表单区域 -->

  </div>
</template>

<script>
import { registerPFun, registerDFun } from "../service/userService.js";
export default {
  data() {
    //在data里面定义两个校验器,检验两次密码是否一致
    var validatePass1 = (rule, value, callback) => {
      if (value !== this.loginForm1.password) {
        callback(new Error("两次输入密码不一致!"));
      } else {
        callback();
      }
    };
    var validatePass2 = (rule, value, callback) => {
      if (value !== this.loginForm2.password) {
        callback(new Error("两次输入密码不一致!"));
      } else {
        callback();
      }
    };
    return {
      //这是注册表单的数据绑定对象
      loginForm1: {
        username: "",
        password: "",
        rePassword: "",
        telephone: "",
        identification: "",
        sex: "",
      },
      loginForm2: {
        username: "",
        password: "",
        rePassword: "",
        telephone: "",
        identification: "",
        sex: "",
        hospital: "",
        workingAge: "",
        title: "",
        department: "",
      },
      //这是表单的验证规则对象
      loginForm1Rules: {
        //验证姓名是否合法
        username: [
          { required: true, message: "请输入姓名", trigger: "blur" },
          {
            min: 2,
            max: 5,
            message: "长度在 2 到 5 个字符",
            trigger: "blur",
          },
          {
            validator: function (rule, value, callback) {
              //校验中文的正则：/^[\u4e00-\u9fa5]{0,}$/
              if (/^[\u4e00-\u9fa5]+$/.test(value) == false) {
                callback(new Error("请输入中文"));
              } else {
                //校验通过
                callback();
              }
            },
            trigger: "blur",
          },
        ],
        //验证身份证是否合法
        identification: [
          { required: true, message: "请输入身份证号", trigger: "blur" },
          {
            min: 18,
            max: 18,
            message: "长度在 18 个字符",
            trigger: "blur",
          },
          {
            validator: function (rule, value, callback) {
              //校验身份证的正则：(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)
              if (
                /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/.test(value) == false
              ) {
                callback(new Error("请输入正确的身份证号"));
              } else {
                //校验通过
                callback();
              }
            },
            trigger: "blur",
          },
        ],
        //验证电话号码是否合法
        telephone: [
          { required: true, message: "请输入电话号码", trigger: "blur" },
          {
            min: 11,
            max: 11,
            message: "长度在 11 个字符",
            trigger: "blur",
          },
          {
            validator: function (rule, value, callback) {
              //校验数字的正则：^[0-9]*$
              if (/^[0-9]*$/.test(value) == false) {
                callback(new Error("请输入正确的电话号码"));
              } else {
                //校验通过
                callback();
              }
            },
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
          {
            validator: function (rule, value, callback) {
              //校验密码的正则: ^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,15}$
              if (
                /^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,15}$/.test(value) ==
                false
              ) {
                callback(
                  new Error("请输入包含字母和数字的组合，不能使用特殊字符")
                );
              } else {
                //校验通过
                callback();
              }
            },
            trigger: "blur",
          },
        ],
        //确认密码是否正确
        rePassword: [
          { required: true, message: "请再次确认密码", trigger: "blur" },
          {
            min: 6,
            max: 15,
            message: "长度在 6 到 15 个字符",
            trigger: "blur",
          },
          { validator: validatePass1, trigger: "blur" },
        ],
      },

      //这是表单的验证规则对象
      loginForm2Rules: {
        //验证姓名是否合法
        username: [
          { required: true, message: "请输入姓名", trigger: "blur" },
          {
            min: 2,
            max: 5,
            message: "长度在 2 到 5 个字符",
            trigger: "blur",
          },
          {
            validator: function (rule, value, callback) {
              //校验中文的正则：/^[\u4e00-\u9fa5]{0,}$/
              if (/^[\u4e00-\u9fa5]+$/.test(value) == false) {
                callback(new Error("请输入中文"));
              } else {
                //校验通过
                callback();
              }
            },
            trigger: "blur",
          },
        ],
        //验证身份证是否合法
        identification: [
          { required: true, message: "请输入身份证号", trigger: "blur" },
          {
            min: 18,
            max: 18,
            message: "长度在 18 个字符",
            trigger: "blur",
          },
          {
            validator: function (rule, value, callback) {
              //校验身份证的正则：(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)
              if (
                /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/.test(value) == false
              ) {
                callback(new Error("请输入正确的身份证号"));
              } else {
                //校验通过
                callback();
              }
            },
            trigger: "blur",
          },
        ],
        //验证电话号码是否合法
        telephone: [
          { required: true, message: "请输入身份证号", trigger: "blur" },
          {
            min: 11,
            max: 11,
            message: "长度在 11 个字符",
            trigger: "blur",
          },
          {
            validator: function (rule, value, callback) {
              //校验电话号码的正则：/^[0-9]*$/  ^(13[0-9]|14[5|7]|15[0|1|2|3|4|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$
              if (
                /^(13[0-9]|14[5|7]|15[0|1|2|3|4|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$/.test(
                  value
                ) == false
              ) {
                callback(new Error("请输入正确的电话号码"));
              } else {
                //校验通过
                callback();
              }
            },
            trigger: "blur",
          },
        ],
        //验证工作医院是否合法
        hospital: [
          { required: true, message: "请输入工作医院", trigger: "blur" },
          {
            min: 4,
            message: "工作医院不能为空",
            trigger: "blur",
          },
          {
            validator: function (rule, value, callback) {
              //校验中文的正则：/^[\u4e00-\u9fa5]{0,}$/
              if (/^[\u4e00-\u9fa5]+$/.test(value) == false) {
                callback(new Error("请输入中文"));
              } else {
                //校验通过
                callback();
              }
            },
            trigger: "blur",
          },
        ],
        //验证工龄是否合法
        workingAge: [
          { required: true, message: "请输入工龄", trigger: "blur" },
          {
            min: 1,
            max: 2,
            message: "工龄不能为空",
            trigger: "blur",
          },
          {
            validator: function (rule, value, callback) {
              //校验数字的正则：/^[0-9]*$/
              if (/^[0-9]+$/.test(value) == false) {
                callback(new Error("请输入数字"));
              } else {
                //校验通过
                callback();
              }
            },
            trigger: "blur",
          },
        ],
        //验证职称是否合法
        title: [
          { required: true, message: "请输入职称", trigger: "blur" },
          {
            min: 2,
            message: "请填写正确的职称",
            trigger: "blur",
          },
          {
            validator: function (rule, value, callback) {
              //校验中文的正则：/^[\u4e00-\u9fa5]{0,}$/
              if (/^[\u4e00-\u9fa5]+$/.test(value) == false) {
                callback(new Error("请输入中文"));
              } else {
                //校验通过
                callback();
              }
            },
            trigger: "blur",
          },
        ],
        //验证科室是否合法
        department: [
          { required: true, message: "请输入科室名", trigger: "blur" },
          {
            min: 2,
            message: "科室名不能为空",
            trigger: "blur",
          },
          {
            validator: function (rule, value, callback) {
              //校验中文的正则：/^[\u4e00-\u9fa5]{0,}$/
              if (/^[\u4e00-\u9fa5]+$/.test(value) == false) {
                callback(new Error("请输入中文"));
              } else {
                //校验通过
                callback();
              }
            },
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
          {
            validator: function (rule, value, callback) {
              //校验密码的正则: ^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,15}$
              if (
                /^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,15}$/.test(value) ==
                false
              ) {
                callback(
                  new Error("请输入包含字母和数字的组合，不能使用特殊字符")
                );
              } else {
                //校验通过
                callback();
              }
            },
            trigger: "blur",
          },
        ],
        //确认密码是否正确
        rePassword: [
          { required: true, message: "请再次确认密码", trigger: "blur" },
          {
            min: 6,
            max: 15,
            message: "长度在 6 到 15 个字符",
            trigger: "blur",
          },
          { validator: validatePass2, trigger: "blur" },
        ],
      },
      passwordType: "password",
      capsTooltip: false,
      loading: false,
      redirect: undefined,
      activeName: "first",
      imgSrc: require("../assets/bg.png"),
      radio: "1",
    };
  },
  methods: {
    handleClick(tab, event) {
      console.log(tab, event);
    },
    //跳转到登录界面
    toLogin() {
      this.$router.push("/");
    },
    //点击重置按钮，重置登录
    resetloginForm1() {
      this.$refs.loginForm1.resetFields();
    },
    //点击重置按钮，重置登录
    resetloginForm2() {
      this.$refs.loginForm2.resetFields();
    },
    //患者注册功能
    register1(loginForm1) {
      this.$refs[loginForm1].validate((valid, wrongstring) => {
        // 获取loginform的实例（el-form），找到validate方法，根据验证规则rules校验是否valid
        if (valid) {
          //this.loading = true;
          registerPFun({
            name: this.loginForm1.username,
            password: this.loginForm1.password,
            tel: this.loginForm1.telephone,
            identification: this.loginForm1.identification,
            sex: this.loginForm1.sex,
          })
            .then((res) => {
              if (res.result === false) {
                this.$notify({
                  title: "提示",
                  message: "用户已注册过账号，无须再注册！",
                  type: 'warning',
                  duration: 3000,
                });
              } else {
                this.$store.commit('editPatientId',res.result)
                this.$router.push("/Home"); //注册成功路由实现跳转
                this.$store.commit('getAllPro',res.result)
                this.$message({
                  showClose: true,
                  message: `注册成功！请记住您的ID：${res.result}`,
                  type: "success",
                  duration:0,
                });
              }
              console.log(res);
            })
            .catch((err) => {
              this.$notify({
                title: "提示",
                message: "用户访问错误",
                type: 'error',
                duration: 0,
              });
              console.log(err);
            });
        } else {
          console.log(valid, wrongstring);
          console.log("error submit!!");
          return false;
        }
      });
    },

    //医生注册功能
    register2(loginForm2) {
      this.$refs[loginForm2].validate((valid, wrongstring) => {
        // 获取loginform2的实例（el-form），找到validate方法，根据验证规则rules校验是否valid
        if (valid) {
          registerDFun({
            name: this.loginForm2.username,
            password: this.loginForm2.password,
            identification: this.loginForm2.identification,
            sex: this.loginForm2.sex,
            workingAge: this.loginForm2.workingAge,
            title: this.loginForm2.title,
            hosname: this.loginForm2.hospital,
            department: this.loginForm2.department,
          })
            .then((res) => {
               if (res.result === false) {
                this.$notify({
                  title: "提示",
                  message: "用户已注册过账号，无须再注册！",
                  type: 'warning',
                  duration: 3000,
                });
              } else {
                this.$store.commit('editDoctorId',res.result)
                this.$router.push("/homepage"); //注册成功路由实现跳转
                this.$message({
                  showClose: true,
                  message: `注册成功！请记住您的ID：${res.result}`,
                  type: "success",
                  duration:0,
                });
              }
              console.log(res);
            })
            .catch((err) => {
              this.$notify({
                title: "提示",
                message: "用户访问错误",
                type: "error",
                duration: 3000,
              });
              console.log(err);
            });
        } else {
          console.log(valid, wrongstring);
          console.log("error submit!!");
          return false;
        }
      });
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
  width: 700px;
  height: 350px;
  background-color: #ffffff;
  opacity: 0.9;
  border-radius: 5px;
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(-85%, -35%);
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
  transform: translate(-50%, -70%);
  background-color: #fff;
  img {
    width: 100%;
    width: 100%;
    border-radius: 50%;
    background-color: #eeeeee;
  }
}

.login_form1 {
  width: 100%;
  padding: 40px 10px;
  align-self: center;
  box-sizing: border-box;
}

.login_form2 {
  width: 100%;
  padding: 15px 35px;
  box-sizing: border-box;
}

.btns {
  display: flex;
  justify-content: flex-end;
}
.pos{
  position: absolute;

  padding: 10px;
}
</style>
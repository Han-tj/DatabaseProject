import axios from 'axios'; 
import router from '../router';
import Vue from 'vue';
import qs from 'qs';
//import store from '../store/index';

//import Storage from '../utils/storages';


// 错误状态码处理提示
class MessageTip extends Vue {
  static messageTipInstance = null;
  messageTip = null;

  static instance() {
    if (!this.messageTipInstance) {
      this.messageTipInstance = new MessageTip();
    }
    this.messageTipInstance;
  }

  // 提示信息
  msgInfo(msg) {
    this.messageTip && this.messageTip.close();
    this.messageTip = this.$message({
      showClose: true,
      message: msg,
      type: 'error',
      center: true
    });
  }

  // 错误信息
  errorInfo(errorCode) {
    this.messageTip && this.messageTip.close();
    let msg = '';
    switch (errorCode) {
      case '400':
        msg = '请求错误';
        break;
      case '401':
        msg = '登录会话过期，请重新登录';
        break;
      case '403':
        msg = '拒绝访问';
        break;
      case '404':
        msg = '请求地址出错';
        break;
      case '408':
        msg = '请求超时';
        break;
      case '500':
        msg = '服务器内部错误';
        break;
      case '501':
        msg = '服务器未实现';
        break;
      case '502':
        msg = '网络错误';
        break;
      case '503':
        msg = '服务不可用';
        break;
      case '504':
        msg = '网关超时';
        break;
      case '505':
        msg = 'HTTP版本不受支持';
        break;
    }
    this.messageTip = this.$message({
      showClose: true,
      message: msg,
      type: 'error',
      center: true
    });
  }
}

const messageTip = new MessageTip();

axios.defaults.headers.post['Content-Type'] = 'application/json';

axios.defaults.withCredentials = true;
axios.defaults.baseURL = '/api';
axios.defaults.timeout = 5000;
// 请求拦截器
axios.interceptors.request.use(
  config => {
    if(config.method === 'post') {
      config.data = qs.stringify(config.data)
      config.url += '?' + config.data 
    }
    else {
      config.params = qs.stringify(config.params)
      config.url += '?' + config.params
    }
    //config.headers.token = localStorage.getItem('$token_info');
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);

// 响应拦截器
axios.interceptors.response.use(
  response => {
    response.data = {
      result:response.data,
      code:`${response.status}`
    }
    if (response && response.data && response.data.code !== '200') {
      response.data.msg && messageTip.msgInfo(response.data.msg);
      console.log(response)
      return Promise.reject(response.data);
    }
    return response.data;
  },
  error => {
    console.log(error)
    console.log(error.response)
    if (
      error &&
      error.response &&
      error.response.status &&
      messageTip.errorInfo(error.response.status)
    ) {
      return Promise.reject(error);
    }
  }
);
export default axios;
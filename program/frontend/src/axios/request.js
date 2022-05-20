import axios from './axios';
export default {
  // get请求
  get(url, param) {
    return new Promise((resolve, reject) => {
      axios({
        method: 'get',
        url,
        params: param
      })
        .then((res = {}) => {
          if (res.code !== '200') reject(res);
          resolve(res);
        })
        .catch(_ => {
          reject(_)});
    });
  },
  // post请求
  post(url, param) {
    return new Promise((resolve, reject) => {
      axios({
        method: 'post',
        url,
        data: param,
      })
        .then((res = {}) => {
          if (res.code !== '200') reject(res);
          resolve(res);
        })
        .catch(_ => reject(_));
    });
  },
};
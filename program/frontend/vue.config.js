module.exports = {
    publicPath : './',
    devServer: {
        overlay: { // 让浏览器 overlay 同时显示警告和错误
         warnings: true,
         errors: true
        },
        open:true,
        host: "localhost",
        port: 8080, // 端口号
        proxy: { //配置多个跨域
            '/api': {
                target: "http://100.67.89.103",
                changeOrigin: true,
                ws: true,//websocket支持
                pathRewrite: {
                    '^/api': '/'
                }
            },
        }
      }
  }
  
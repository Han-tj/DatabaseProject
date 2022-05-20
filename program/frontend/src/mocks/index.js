import Mock from "mockjs";
import { getDocList,getDocOption } from "./response/doc.js"

//Mock.mock("/data/userList.josn",'get',getDocList )
Mock.mock("/api/Patient/GetDoctorList",'get',{
    code:'200',
    result:getDocList} )
Mock.mock("/api/Patient/GetDepartmentList",'get',{
    code:'200',
    result:getDocOption} )
Mock.mock("/api/Patient/GetImg",'post',{
    code:'200',
    url:"https://i.loli.net/2021/07/09/fN1mFXC27l4EMPi.jpg",
})
Mock.mock('/api/User/GetChatContent','post',{
  
      content:'haha',
      speaker:'patient'
    
    
})
Mock.mock('/api/User/checkNewMes','post',
    true
)
Mock.mock('/api/User/sendChatMes','post',
    true
)

export default Mock;
import url from '../axios/url';
import request from '../axios/request';

export function getDocDataFun(params) {
    return request.get(url.patient.getDocListData, params);
  }

export function getDocOptionFun(params) {
    return request.get(url.patient.getDocOptionData, params);
  }

export function getDrugFun(params){
  return request.get(url.patient.getDrugData,params);
}

export function getHosFun(params){
  return request.get(url.patient.getHosData,params);
}

export function getNoticeFun(params){
  return request.get(url.patient.getNoticeData,params);
}

export function getDiseaseFun(params){
  return request.get(url.patient.getDiseaseData,params);
}

export function postReservationFun(params){
  return request.post(url.patient.postReservationData,params);
}

export function loginPFun(params){
  return request.get(url.patient.patientLogin,params);
}

export function loginDFun(params){
  return request.get(url.patient.doctorLogin,params);
}

export function registerPFun(params){
  return request.post(url.patient.patientRegister,params);
}

export function registerDFun(params){
  return request.post(url.patient.doctorRegister,params);
}

export function sendAcidFormFun(params){
  return request.post(url.patient.sendAcidForm, params)
}

export function sendOfflineReFun(params){
  return request.post(url.patient.sendOffineReservation, params)
}

export function sendChatMesFun(params){
  return request.post(url.alluser.sendChatMes, params)
}

export function getChatMesFun(params){
  return request.get(url.alluser.getChatMes, params)
}

export function getCartFun(params){
  return request.get(url.patient.getCart, params)
}

export function clearCartFun(params){
  return request.post(url.patient.clearCart, params)
}

export function addCartFun(params){
  return request.post(url.patient.addCart, params)
}

export function getPatientInfoDataFun(params){
  return request.get(url.doctor.getPatientInfoData,params);
}
export function postPreDataFun(params){
  return request.post(url.doctor.postPreData,params);
}

export function postMedicineIncludedDataFun(params){
  return request.post(url.doctor.postMedicineIncludedData,params);
}

export function postReportDataFun(params){
  return request.post(url.doctor.postReportData,params);
}

export function getDocInfoData(params){
  return request.get(url.patient.getDocInfoData,params);
}

export function getDrugsIncludedListDataFun(params){
  return request.get(url.patient.getDrugsIncludedListData,params);
}

export function postRateDataFun(params){
  return request.post(url.patient.postRateData,params);
}

export function getPreDataFun(params){
  return request.get(url.patient.getPreData,params);
}

export function getDiseaseListDataFun(params){
  return request.get(url.patient.getDiseaseListData,params);
}

export function getDepartmentListDataFun(params){
  return request.get(url.patient.getDepartmentListData,params);
}

export function getPatientInfoFun(params){
  return request.get(url.patient.getPatientInfo,params);
}

export function postAutoAddDataFun(params){ 
  return request.post(url.patient.postAutoAddData,params);
}

export function getDrugListDataFun(params){
  return request.get(url.patient.getDrugListData,params);
}

export function getNATFun(params){
  return request.get(url.patient.getNAT,params);
}
export function getReportListDataFun(params){
  return request.get(url.admin.getReportListData,params);
}
export function getNoticeListDataFun(params){
  return request.get(url.admin.getNoticeListData,params);
}
export function postNoticeDataFun(params){
  return request.post(url.admin.postNoticeData,params);
}

export function getDocFun(params){
  return request.get(url.patient.getDoctorData,params)
}

export function getRecordsFun(params){
  return request.get(url.patient.getRecordsData,params)
}

export function getCompletedRecordsFun(params){
  return request.get(url.patient.getCompletedRecordsData,params)
}

export function updateReservationFun(params){
  return request.post(url.patient.updateReservationData,params)
}

export function postNoticeFun(params){
  return request.post(url.patient.postNoticeData,params)
}

export function deleteNoticeFun(params){
  return request.post(url.patient.deleteNotice,params)
}

export function getPatiBMIFun(params){
  return request.get(url.patient.getPatiBMI,params)
}

export function getPaiInoFun(params){
  return request.get(url.patient.getPaiIno,params)
}

export function getOfflineAppFun(params){
  return request.get(url.patient.getOfflineApp,params)
}

export function getReservationsFun(params){
  return request.get(url.patient.getReservations,params)
}

export function postPaiInoFun(params){
  return request.post(url.patient.postPaiIno,params)
}

export function RectifyOfflineAppFun(params){
  return request.post(url.patient.postRectifyOfflineApp,params)
}

export function RectifyNucleicAppFun(params){
  return request.post(url.patient.postRectifyNucleicApp,params)
}

export function getDocInoFun(params){
  return request.get(url.doctor.getDocIno,params)
}

export function getHospitalFun(params){
  return request.get(url.patient.getHospital,params)
}
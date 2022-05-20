import Mock from "mockjs"

export const getDocList = () => {

    const Random = Mock.Random;
    let docList = [];

    for (let i = 1; i <= 48; i++) {

        let newData = {
            "id":i,
            "info":{
                "name": Random.cname(),
                "age":Random.natural(25,65),
                "level|1":["主任医师","副主任医师","主治医师","住院医师"],
                "profession|1":["皮肤科","内科","消化科"]
            },
        }
        docList.push(newData)
    }

    return Mock.mock(docList);
}

export const getDocOption = () =>{
    const Random = Mock.Random;
    let docOpiton = ['全部','皮肤科','消化科','内科'];
    return Mock.mock(docOpiton);
}
export interface UserDiary {
    userDiaryId:number,
    diaryTitle:string,
    diaryContent:string,
    diaryDataTime:string,
    insertionDate:string,
    userId:number
}

export interface UserDiaryResult {
    userDiaryId:number,
    diaryTitle:string,
    diaryContent:string,
    diaryDate:string,
    diaryTime:string,
    insertionDate:string,
    userFullName:string
}

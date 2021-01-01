export interface TourModel
{
    id:number;
    name:string;
    startDate:Date;
    endDate:Date;
    distance:number;
    days:number;
    startPlace:string;
    endPlace:string;
    tourPhotos:any[];
}
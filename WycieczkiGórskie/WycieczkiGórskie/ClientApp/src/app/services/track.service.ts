import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { baseUrl } from 'src/environments/environment';
import { AddTourModel } from '../models/add-tour.model';
import { Observable } from 'rxjs';
import { TourModel } from '../models/tour.model';
@Injectable({
  providedIn: 'root'
})
export class TrackService {

constructor(private http:HttpClient){ }

  url = baseUrl + "Tour";

  getTours():Observable<TourModel[]>
  {
    return this.http.get<TourModel[]>(this.url);
  }

  getTour(id:number):Observable<TourModel>
  {
    return this.http.get<TourModel>(this.url+"/"+id);
  }

  postTour(model:any):Observable<any>
  {
    return this.http.post(this.url,model);
  }

  deleteTour(id:number)
  {
    return this.http.delete(this.url+"/"+id);
  }

  postPhoto(model:any):Observable<any>
  {
    return this.http.post(this.url+"/photo",model);
  }

  postVideo(model:any):Observable<any>
  {
    return this.http.post(this.url+"/video",model);
  }

  getVideo(id:number):Observable<any>
  {
    return this.http.get(this.url+"/video?id="+id);
  }

}

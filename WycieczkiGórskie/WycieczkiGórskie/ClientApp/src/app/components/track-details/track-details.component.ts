import {  Component,  OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { TourModel } from 'src/app/models/tour.model';
import { TrackService } from 'src/app/services/track.service';


@Component({
  selector: 'app-track-details',
  templateUrl: './track-details.component.html',
  styleUrls: ['./track-details.component.scss']
})
export class TrackDetailsComponent implements OnInit {

  constructor(private route: ActivatedRoute, private trackService:TrackService,private router:Router) {
   }

  


  ngOnInit(): void {
    const id: Observable<string>  = this.route.params.pipe(map((p)=>p.id)); 

    id.subscribe(response=>{this.trackService.getTour(+response).subscribe(response=>{
      this.track=response;
      this.track.tourPhotos.forEach(element => {
        element.photo="data:image/jpeg;base64,"+element.photo;
      });
    });
    this.id=0;
    this.id= +response;        
    this.displayVideo=true;
    this.trackService.getVideo(this.id).subscribe(response=>{
      if(response==null)
      {
        console.log("FALSE");
        this.displayVideo=false;
      }

    });
    this.video = 'https://localhost:44320/api/Tour/video?id='+this.id;
  });
  
  }
  displayVideo:boolean;
  video:string;
  id:number;
  photo:string;
  track:TourModel;
 usun()
 {
   this.trackService.deleteTour(this.id).subscribe(response=>this.router.navigateByUrl("my-tracks"));
   window.location.reload();
   this.router.navigateByUrl("my-tracks");
 }

 
}

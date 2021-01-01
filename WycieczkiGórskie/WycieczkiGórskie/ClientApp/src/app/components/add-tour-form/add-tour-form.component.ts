import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TrackService } from '../../services/track.service';
import { AddPhotoModel } from '../../models/add-photo.model';
import * as moment from 'moment';
import { Router } from '@angular/router';
@Component({
  selector: 'app-add-tour-form',
  templateUrl: './add-tour-form.component.html',
  styleUrls: ['./add-tour-form.component.scss']
})
export class AddTourFormComponent implements OnInit {

  constructor(private trackService:TrackService,private router:Router) { }

  ngOnInit(): void {
    this.tourForm = new FormGroup({
      name: new FormControl('', Validators.required),
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required),
      distance: new FormControl('', Validators.required),
      startPlace: new FormControl('', Validators.required),
      endPlace: new FormControl('', Validators.required),
      tourPhoto: new FormControl(''),
      tourVideo: new FormControl('')
    });
    
  }

  tourForm: FormGroup;
  file: File;
  submit() {
    this.trackService.postTour(this.tourForm.value).subscribe(resp=>{
      this.tourForm.value.tourPhoto.forEach(element => {
        let model : AddPhotoModel={
        tourId:resp,
        tourPhoto:element,
      }
      this.trackService.postPhoto(this.toFormData(model)).subscribe();
      
      });
      let model2 : AddPhotoModel = {
        tourId:resp,
        tourPhoto:this.tourForm.value.tourVideo
      }
      this.trackService.postVideo(this.toFormData(model2)).subscribe();
      this.tourForm.value.name="";
      this.tourForm.value.startDate="";
      this.tourForm.value.endDate="";
      this.tourForm.value.distance="";
      this.tourForm.value.startPlace="";
      this.tourForm.value.endPlace="";
      this.tourForm.value.tourPhoto="";
      this.tourForm.value.tourVideo="";
    });
  }

  toFormData<T>(formValue: T) {
    const formData = new FormData();
    for (const key of Object.keys(formValue)) {
      const value = formValue[key];
      formData.append(key, value);
    }
    return formData;
  }
}

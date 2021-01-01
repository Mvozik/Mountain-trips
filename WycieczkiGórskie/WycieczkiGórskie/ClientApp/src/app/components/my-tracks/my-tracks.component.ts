import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import * as moment from 'moment';
import { TrackService } from 'src/app/services/track.service';
import { TourModel } from '../../models/tour.model';
@Component({
  selector: 'app-my-tracks',
  templateUrl: './my-tracks.component.html',
  styleUrls: ['./my-tracks.component.scss']
})
export class MyTracksComponent implements OnInit {

  constructor(private httpClient:TrackService) { }

  ngOnInit(): void {
    this.tourForm = new FormGroup({
      startDate: new FormControl(''),
      endDate: new FormControl(''),
    });
    moment(this.tourForm.value.startDate).format("YYYY-MM-DD")
    this.httpClient.getTours().subscribe(response => {this.tracks = response;this.filteredTracks=response;
      
      this.tracks.forEach(element => {
        element.startDate = moment(element.startDate).toDate();
        element.endDate = moment(element.endDate).toDate();
      });
  });
  }

  tourForm: FormGroup;
  tracks:TourModel[] = [];
  filteredTracks:TourModel[] = [];
  applyFilter(filterValue:string)
  {
    this.filteredTracks = this.tracks
    .filter(track => track.name.toLowerCase().trim()
    .indexOf(filterValue.toLowerCase().trim()) !== -1);
  }

  filterDate()
  {
    this.filteredTracks = this.tracks
    .filter(track => track.startDate>=this.tourForm.value.startDate && track.startDate<=this.tourForm.value.endDate);
  }

}

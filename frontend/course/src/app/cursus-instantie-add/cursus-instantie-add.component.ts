import { Component, OnInit } from '@angular/core';
import { UploadFileService } from '../shared/api/upload-file.service';

@Component({
  selector: 'app-cursus-instantie-add',
  templateUrl: './cursus-instantie-add.component.html',
  styleUrls: ['./cursus-instantie-add.component.scss']
})
export class CursusInstantieAddComponent implements OnInit {
  file: File = null;
  info: String = '';
  succesResponse: String;
  duplicateCursusResponse: String;
  duplicateInstantieResponse: String;

  constructor(private uploadFileService: UploadFileService) { }

  ngOnInit(): void { }

  onFileChange(event) {
    if (event.target.files.length > 0) {
      this.file = event.target.files[0];
    }
  }

  uploadFile() {
    if (this.file === null) {
      this.info = 'geen bestand geselecteerd';
      return;
    }
    const formData: FormData = new FormData();
    formData.append('file', this.file, this.file.name);

    this.uploadFileService.upload(formData).subscribe(data => {
       var response = data.toString().split('.');
       this.succesResponse = response[0];
       this.duplicateCursusResponse = response[1];
       this.duplicateInstantieResponse = response[2];
      }, error => {
        console.log(error);
    });
  }
}


  
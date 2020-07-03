import { Component, OnInit, ElementRef } from '@angular/core';
import { UploadFileService } from '../shared/api/upload-file.service';
import { ViewChild } from '@angular/core';

@Component({
  selector: 'app-cursus-instantie-add',
  templateUrl: './cursus-instantie-add.component.html',
  styleUrls: ['./cursus-instantie-add.component.scss']
})
export class CursusInstantieAddComponent implements OnInit {
  file: File = null;
  info: String;
  successResponse: String;
  duplicateResponse: String;

  constructor(private uploadFileService: UploadFileService) { }

  ngOnInit(): void { }

  @ViewChild('fileInput') fileInput: ElementRef;

  onFileChange(event) {
    if (event.target.files.length > 0) {
      this.file = event.target.files[0];
    }
    this.clearResponseText();
  }

  clearResponseText() {
    this.info = '';
    this.successResponse = '';
    this.duplicateResponse = '';
  }

  uploadFile() {
    if (this.file === null) {
      this.info = 'geen bestand geselecteerd.';
      return;
    }
    
    if (this.file !== null && this.file.type !== 'text/plain') {
      this.info = 'Bestand is niet in correct formaat.';
      return;
    }
    const formData: FormData = new FormData();
    formData.append('file', this.file, this.file.name);

    this.uploadFileService.upload(formData).subscribe(responseData => {
      if (responseData[0] === 'success') {
        this.successResponse = responseData[1];
        this.duplicateResponse = responseData[2];
      }
      if (responseData[0] === 'error') {
        this.info = responseData[1];
        this.duplicateResponse = responseData[2];
      }
      }, error => {
        console.log(error);
    });

    this.clearFile();
  }

  clearFile() {
    this.fileInput.nativeElement.value = null;
    this.file = null;
  }
}


  
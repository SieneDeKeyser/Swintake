import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UploadFile } from 'src/app/core/files/classes/uploadFile';
import { JobApplication } from 'src/app/core/jobapplications/classes/jobApplication';




@Component({
  selector: 'app-upload-files',
  templateUrl: './upload-files.component.html',
  styleUrls: ['./upload-files.component.css']
})
export class UploadFilesComponent implements OnInit {

  cvFile: UploadFile;
  motivationFile: UploadFile;
  uploadFilesForm: FormGroup;
  jobApplication: JobApplication;
  formDataCV: FormData;
  formDataMotivation: FormData;
  constructor(private formBuilder: FormBuilder) {      

}

  ngOnInit() {
    this.formDataCV = new FormData();
    this.formDataMotivation = new FormData();
    this.uploadFilesForm = this.formBuilder.group({
      cv: [''],
      motivation: ['']
    })
  }

  uploadCV(event){

    for(let file of event.target.files){
      this.formDataCV.append("name", "Name");
      this.formDataCV.append("file", file);
      this.cvFile = new UploadFile();
      this.cvFile.fileType = 'CV';
    }
  }

  uploadMotivationLetter(event){
    for(let file of event.target.files){
      this.formDataMotivation.append("name", "Name");
      this.formDataMotivation.append("file", file);
      this.motivationFile = new UploadFile();
      this.motivationFile.fileType = 'MotivationLetter';
    }
  }

}

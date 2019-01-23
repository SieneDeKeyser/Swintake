import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Candidate } from 'src/app/core/candidates/classes/candidate';
import { CandidateService } from 'src/app/core/candidates/services/candidate.service';

@Component({
  selector: 'app-candidate-create',
  templateUrl: './candidate-create.component.html',
  styleUrls: ['./candidate-create.component.css']
})
export class CandidateCreateComponent implements OnInit {

  candidate: Candidate = new Candidate();
  submitted = false;
  createNewCandidateForm: FormGroup;

  constructor(
    private candidateService: CandidateService,
    private formbuilder: FormBuilder,
    private _router: Router
  ) { }

  ngOnInit() {
    this.createNewCandidateForm = this.formbuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', Validators.required],
      gitHubUserName: [''],
      linkedIn: [''],
      comment: ['']
    });
  }

  create(){
    this.candidateService.addCandidate(this.createNewCandidateForm.value)
    .subscribe(date => {
      this._router.navigateByUrl('/candidates');
    });
  }

  cancel(){
    this._router.navigateByUrl('/candidates');
  }

  get formValues()
  {
    return this.createNewCandidateForm.controls;
  }

  isValid(): boolean{
    this.submitted = true;
    if(this.createNewCandidateForm.invalid)
    {
      return false;
    }
    return true;
  }
}

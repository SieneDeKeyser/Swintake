import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { JobApplication } from 'src/app/core/jobapplications/classes/jobApplication';
import { SelectionStep } from 'src/app/core/jobapplications/classes/selectionStep';
import { JobApplicationService } from 'src/app/core/jobapplications/services/jobapplication.service';
import { ApiUrl } from 'src/app/core/CommonUrl/CommonUrl';


@Component({
  selector: 'app-selection-steps',
  templateUrl: './selection-steps.component.html',
  styleUrls: ['./selection-steps.component.css']
})

export class SelectionStepsComponent implements OnInit {
  @Input() jobapplication: JobApplication;
  @Output() jobapplicationChange = new EventEmitter<JobApplication>();

  selectionStep: SelectionStep;
  nextSelectionStep: string;
  selectionSteps: SelectionStep[];
  submitted = false;
  SelectionStepForm: FormGroup;
  selectionStepToEdit: SelectionStep;

  constructor(private route: ActivatedRoute,
    private formbuilder: FormBuilder,
    private _router: Router,
    private jobApplicationService: JobApplicationService) { }

  orderSelectionStepArray = ["Register CV Screening",
    "Register Phone Screening",
    "Register TestResults",
    "Register First interview",
    "Register Group interview",
    "Register Final decision"];

  ngOnInit() {
    this.nextSelectionStep = this.orderSelectionStepArray[0];
    if (this.jobapplication && this.jobapplication.currentSelectionStep) {
      this.selectionStep = this.jobapplication.currentSelectionStep;
      this.selectionSteps = this.orderSelectionStep();
    };
    this.SelectionStepForm = this.formbuilder.group({
      comment: ['']
    });
  }

  orderSelectionStep(): SelectionStep[] {

    let orderSelectionSteps: SelectionStep[] = new Array<SelectionStep>(this.jobapplication.selectionSteps.length);

    for (let index = 0; index < this.jobapplication.selectionSteps.length; index++) {

      let i = this.orderSelectionStepArray.findIndex(desc => desc === this.jobapplication.selectionSteps[index].description);

      orderSelectionSteps[i] = this.jobapplication.selectionSteps[index];
    }

    this.nextSelectionStep = this.orderSelectionStepArray[this.jobapplication.selectionSteps.length];
    return orderSelectionSteps;
  }

  save() {
    this.jobApplicationService.saveNextSelectionStep(this.jobapplication.id, this.SelectionStepForm.value.comment)
      .subscribe(data => {
        this.jobapplication = data;
        this.selectionSteps = this.orderSelectionStep();
        this.jobapplicationChange.emit(data);
        this.SelectionStepForm.reset();
      }
      );
  }


  accept() {
    this.jobApplicationService.acceptCandidate(this.jobapplication.id)
      .subscribe(data => { this._router.navigateByUrl('/jobapplications') });
  }

  isValid(): boolean {
    this.submitted = true;
    if (this.SelectionStepForm.invalid) {
      return false;
    }
    return true;
  }

  cancel() {
    this._router.navigateByUrl('/jobapplications');
  }

  edit(selectionStep: SelectionStep) {
    if (!this.selectionStepToEdit) {
      this.selectionStepToEdit = selectionStep;
      this.SelectionStepForm.setValue({comment: selectionStep.comment});
    }
    else {
      this.cancelEditing();
    }
  }

  cancelEditing() {
    this.selectionStepToEdit = null;
  }

  saveEdittedComment() {
    this.jobApplicationService.editComment(this.jobapplication.id, this.selectionStepToEdit.description, this.SelectionStepForm.value.comment)
      .subscribe(data => {
        this.jobapplication = data;
        this.selectionSteps = this.jobapplication.selectionSteps;
        this.SelectionStepForm.reset();
        this.selectionStepToEdit = null;
      }
      )
  }
}

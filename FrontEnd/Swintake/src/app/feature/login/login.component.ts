import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { first } from 'rxjs/operators';
import { AuthService } from 'src/app/core/authentication/services/auth.service';

@Component({
  selector: 'ngbd-modal-content',
  template: `
    <div class="modal-header">
      <h4 class="modal-title">{{header}}</h4>
      <button type="button" class="close" aria-label="Close" (click)="activeModal.dismiss('Cross click')">
        <span aria-hidden="true">&times;</span>
      </button>
    </div>
    <div class="modal-body">
      <p>{{message}}</p>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-outline-dark" (click)="activeModal.close('Close click')">Close</button>
    </div>
  `
})
export class NgbdModalContent {

  constructor(public activeModal: NgbActiveModal) { }
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  isSubmitted = false;
  userForm: FormGroup;
  invalidLogin: boolean;
  returnUrl: string;
  loading = false;

  constructor(private formbuilder: FormBuilder,
    private authService: AuthService,
    private route: ActivatedRoute,
    private router: Router,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.userForm = this.formbuilder.group(
      {
        email: ['', [Validators.required, Validators.email]],
        password: ['', Validators.required]
      }
    );

    this.authService.logout();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get formValues() {
    return this.userForm.controls;
  }

  isValid(): boolean {
    this.isSubmitted = true;
    if (this.userForm.invalid) {
      return false;
    }
    return true;
  }

  login(): void {
    this.loading = true;
    const val = this.userForm.value;
    if (val.email && val.password) {
      this.authService.login(val.email, val.password)
        .pipe(first())
        .subscribe(data => {
          this.router.navigate(['/jobapplications']);},
          error => {
          this.open('Oops!','E-mail or Password invalid');
          this.loading = false;
        });
    }
  }

  open(header: string, message: string) {
    const modalRef = this.modalService.open(NgbdModalContent);
    modalRef.componentInstance.header = header;
    modalRef.componentInstance.message = message;
    this.userForm.reset();
    Object.keys(this.userForm.controls).forEach(key => {
      this.userForm.controls[key].setErrors(null)
    });
    this.isSubmitted = false;
  }

  resetPassword(){
    this.open('Reset Password', 'An e-mail has been sent to hello@switchfully.com');
  }
}

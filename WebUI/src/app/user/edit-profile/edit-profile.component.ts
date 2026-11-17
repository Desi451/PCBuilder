import { HttpErrorResponse } from "@angular/common/http";
import { ChangeDetectorRef, Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { AbstractControl, FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { AuthService } from "src/app/core/auth/auth.service";
import { ComputerService } from "src/app/core/service/computer.service";
import { computerView } from "src/app/shared/models/computer.model";
import { updateUser, userInfo } from "src/app/shared/models/user.model";
import { getProblemMessage } from "src/app/shared/utils/problem-details";
import { passwordPolicyHint, passwordPolicyValidator } from "src/app/shared/validators/password.validator";

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class EditProfileComponent implements OnInit{

  userForm!: FormGroup;

  userId: number = 0;
  username: string = '';
  userRank: number = 0;

  changePassword = false;
  readonly passwordHint = passwordPolicyHint;

  computerList: computerView[] = [];
  isDataLoaded = false;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private toastr: ToastrService,
    private formBuilder: FormBuilder,
    private _authService: AuthService,
    private _computerService: ComputerService,
    private cdr: ChangeDetectorRef,
  ) {
    this.initForm();
  }

  initForm() {
    this.userForm = this.formBuilder.group({
      login: ['', [Validators.required, Validators.maxLength(256), Validators.pattern(/^[A-Za-z0-9._-]+$/)]],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(256)]],
      currentPassword: [''],
      newPassword: [''],
      newPasswordRepeat: [''],
    }, { validator: this.passwordMatchValidator });
  }

  ngOnInit(): void {
    this._authService.getUserInfo().subscribe(response => {
      if (!response.userId) {
        this._router.navigateByUrl('login');
        return;
      }

      this.userId = response.userId;
      this.username = response.username;
      this.userRank = response.userRank;
      this.userForm.patchValue({ login: response.username, email: response.email });

      this._computerService.getViewsByUser(response.userId).subscribe(
        (res: computerView[]) => {
          this.computerList = res;
          this.isDataLoaded = true;
          this.cdr.detectChanges();
          this.toastr.success('Computers loaded Successfully!', 'Profile Edit');
        },
        (error) => {
          this.toastr.error('Error fetching computers', 'Profile Edit');
        }
      );
    });
  }

  togglePasswordChange() {
    this.changePassword = !this.changePassword;

    const current = this.userForm.controls['currentPassword'];
    const newPassword = this.userForm.controls['newPassword'];
    const repeat = this.userForm.controls['newPasswordRepeat'];

    if (this.changePassword) {
      current.setValidators(Validators.required);
      newPassword.setValidators([Validators.required, passwordPolicyValidator]);
      repeat.setValidators(Validators.required);
    } else {
      current.clearValidators();
      newPassword.clearValidators();
      repeat.clearValidators();
      this.resetPasswordFields();
    }

    this.userForm.updateValueAndValidity();
  }

  executeForm() {
    if(this.userForm.valid){
      const { login, email, currentPassword, newPassword } = this.userForm.value;
      const res: updateUser = this.changePassword
        ? { login, email, currentPassword, newPassword }
        : { login, email };

      this._authService.update(res).subscribe({
        next: (info: userInfo) => {
          this.username = info.login;
          this.toastr.success('Profile Updated Successfully!', 'Profile Edit');
          if (this.changePassword) {
            this.togglePasswordChange();
          }
        },
        error: (error: HttpErrorResponse) => {
          this.toastr.error(getProblemMessage(error, 'Profile update failed.'), 'Profile Edit');
        }
      });
    }
    else{
      this.toastr.error('Form not valid!');
    }
  }

  passwordMatchValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const newPassword = control.get('newPassword')?.value;
    const repeat = control.get('newPasswordRepeat')?.value;

    return newPassword === repeat ? null : { 'passwordMismatch': true };
  }

  private resetPasswordFields() {
    this.userForm.patchValue({ currentPassword: '', newPassword: '', newPasswordRepeat: '' });
  }
}

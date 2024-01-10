import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { AuthService } from "src/app/core/auth/auth.service";
import { ComputerService } from "src/app/core/service/computer.service";
import { computerView } from "src/app/shared/models/computer.model";
import { updateUser, user } from "src/app/shared/models/user.model";

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss'],
})
export class EditProfileComponent implements OnInit{

  userForm!: FormGroup;
  id: number;

  userId: number = 0;
  username: string = '';
  userRank: number = 0;

  computerList: computerView[] = [];
  isDataLoaded = false;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private toastr: ToastrService,
    private _userService: AuthService,
    private formBuilder: FormBuilder,
    private _authService: AuthService,
    private _computerService: ComputerService,
    private cdr: ChangeDetectorRef,
  ) {
    this.initForm();
    this.id = this._route.snapshot.params['id'];
  }

  initForm() {
    this.userForm = this.formBuilder.group({
      login: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(8)]],
      passwordRepeat: ['', [Validators.required, Validators.minLength(8)]],
    });
  }

  ngOnInit(): void {
    this._authService.getUserInfo().subscribe(response => {
      if (response.userId) {
        this.userId = response.userId;
        this.username = response.username;
        this.userRank = response.userRank;

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

        this._authService.getUser(this.userId).subscribe(
        (res: user) => {
          this.userForm.patchValue(res);
        },
        (error) => {
          this.toastr.error('Error fetching user', 'Profile Edit');
        }
      );
      }
    });


  }

  executeForm() {
    if(this.userForm.valid){
      const res = this.userForm.value as updateUser;
      this._authService.update(res, this.userId).subscribe(
        (res: boolean) => {
          this.toastr.success('Profile Updated Successfully!', 'Profile Edit');
        },
        (error) => {
          this.toastr.error('Error fetching user', 'Profile Edit');
        }
      );

    }
    else{
      this.toastr.error('Form not valid!');
    }
  }
}

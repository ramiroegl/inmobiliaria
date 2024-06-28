import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-new-user',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './new-user.component.html',
  styleUrl: './new-user.component.css'
})
export class NewUserComponent {
  form = new FormGroup({
    email: new FormControl(''),
    name: new FormControl(''),
    lastName: new FormControl(''),
    password: new FormControl('')
  });

  constructor(private userService: UserService) {}

  save(): void {
    const formValue = this.form.value;

    this.userService
      .createUser({
        email: formValue.email!,
        name: formValue.name!,
        lastName: formValue.lastName!,
        password: formValue.password!
      })
      .subscribe(result => {
        alert(result.id);
        this.form.reset();
      });
  }
}

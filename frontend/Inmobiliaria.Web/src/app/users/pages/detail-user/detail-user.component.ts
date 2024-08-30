import { Component, Input } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-detail-user',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './detail-user.component.html',
  styleUrl: './detail-user.component.css'
})
export class DetailUserComponent {
  @Input('id') id: string = '';
  updated: boolean = false;
  form = new FormGroup({
    name: new FormControl<string>(''),
    lastName: new FormControl<string>(''),
    email: new FormControl<string>(''),
    role: new FormControl<'User' | 'Admin'>('User'),
  });

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService
      .getUser(this.id)
      .subscribe(result => {
        this.form.setValue({
          name: result.name,
          lastName: result.lastName,
          email: result.email,
          role: result.role
        });
      });
  }

  update(): void {
    let formValue = this.form.value;
    this.userService.updateUser({
      userId: this.id,
      email: formValue.email!,
      lastName: formValue.lastName!,
      name: formValue.name!,
      role: formValue.role!
    }).subscribe(_ => {
      this.updated = true;
    });
  }
}

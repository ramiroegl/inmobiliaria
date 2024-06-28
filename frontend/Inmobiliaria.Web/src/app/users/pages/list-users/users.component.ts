import { Component } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { User } from '../../../shared/models/user';
import { UserService } from '../../services/user.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent {
  public take: number = environment.DEFAULT_PAGE_SIZE;
  public skip: number = 0;
  public users: User[] = [];
  public hasError: boolean = false;
  public errorMessage?: string;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService
      .getUsers(this.skip, this.take)
      .subscribe(result => {
        this.users = result.data;
      });
  }

  delete(id: string) {
    this.userService
    .deleteUser(id)
    .subscribe(result => {
      if (result.ok) {
        this.users = this.users.filter(user => user.id != id);
        this.hasError = false;
      } else {
        this.hasError = true;
        this.errorMessage = result.error;
      }
    });
  }
}

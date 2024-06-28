import { PaginatedResult } from "./results";

export interface User {
    id: string;
    name: string;
    lastName: string;
    email: string;
    role: 'Admin' | 'User';
}

export interface ListedUsers extends PaginatedResult<User> { }
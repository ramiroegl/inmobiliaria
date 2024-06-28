export interface AuthedUser {
    id: string;
    name: string;
    lastName: string;
    email: string;
    role: 'Admin' | 'User';
}

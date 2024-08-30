export interface UpdateUser {
    userId: string,
    name: string,
    lastName: string,
    email: string,
    role: 'Admin' | 'User'
}

export interface ChangePassword {
    password: string,
    newPassword: string
}

export interface ResetPassword {
    newPassword: string
}

export interface UpdateMe {
    userId: string,
    name: string,
    lastName: string,
    email: string
}
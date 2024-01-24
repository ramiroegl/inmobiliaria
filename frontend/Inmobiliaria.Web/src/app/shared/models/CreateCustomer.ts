import { Identity } from "./Identity";

export interface CreateCustomer {
    email: string;
    names: string;
    lastNames: string;
    identity: Identity;
    civilStatus: string;
    salary: number;
    phoneNumber: string;
}

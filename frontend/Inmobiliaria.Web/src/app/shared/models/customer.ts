import { Identity } from "./Identity";

export interface Customer {
    id: string;
    names: string;
    lastNames: string;
    email: string;
    identity: Identity;
    salary: number;
    phoneNumber: string;
    civilStatus: string;
}

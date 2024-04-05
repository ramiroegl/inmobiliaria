import {AuthedUser} from "./authed-user";

export interface LoginResult {
    user: AuthedUser;
    token: string;
}

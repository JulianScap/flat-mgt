import { Injectable } from "@angular/core";
import { IUserInfo } from "../entities/user-info";

@Injectable()
export class SessionManager {
    private static sessiontoken: string;
    private static userInfo: IUserInfo;

    public setUser(sessiontoken: string, userInfo: IUserInfo): void {
        SessionManager.sessiontoken = sessiontoken;
        SessionManager.userInfo = userInfo;
    }

    public logout() {
        SessionManager.userInfo = null;
        SessionManager.sessiontoken = null;
    }

    public isAuthenticated(): boolean {
        return SessionManager.sessiontoken != null && SessionManager.sessiontoken != "";
    }
}

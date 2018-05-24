import { Injectable } from "@angular/core";
import { IUserInfo } from "../entities/user-info";

@Injectable()
export class SessionManager {
    private static sessiontoken: string;
    private static userInfo: IUserInfo;
    static login: string;

    public setUser(sessiontoken: string, login: string, userInfo: IUserInfo): void {
        SessionManager.sessiontoken = sessiontoken;
        SessionManager.userInfo = userInfo;
        SessionManager.login = login;
    }

    public clearSession() {
        SessionManager.userInfo = null;
        SessionManager.sessiontoken = null;
        SessionManager.login = null;
    }

    public isAuthenticated(): boolean {
        return SessionManager.sessiontoken != null && SessionManager.sessiontoken != "";
    }

    getToken(): string {
        return SessionManager.sessiontoken;
    }
}

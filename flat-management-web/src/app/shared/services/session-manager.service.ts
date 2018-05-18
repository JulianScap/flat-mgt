import { Injectable } from "@angular/core";
import { UserInfo } from "../entities/user-info";

@Injectable()
export class SessionManager {
    private static sessiontoken: string;
    private static userInfo: UserInfo;

    public static setUser(sessiontoken: string, userInfo: UserInfo): void {
        SessionManager.sessiontoken = sessiontoken;
        // Copy the UserInfo
        SessionManager.userInfo = new UserInfo(userInfo);
    }
}

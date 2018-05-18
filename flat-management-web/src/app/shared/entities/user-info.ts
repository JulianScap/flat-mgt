export class UserInfo {
   private _accountName: string;

    get accountName(): string {
        return this._accountName;
    }

    constructor(userInfo?: UserInfo) {
        if (userInfo) {
            this._accountName = userInfo.accountName;
        }
    }
}

import { IUserInfo } from "../shared/entities/user-info";
import { IValidationResult } from "../shared/entities/validation-result";

export interface IAuthenticationResult {
    token: string;
    validationResult: IValidationResult;
    userInfo: IUserInfo;
}

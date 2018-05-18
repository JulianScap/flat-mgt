import { IValidationResult } from "../shared/entities/validation-result";
import { IUserInfo } from "../shared/entities/user-info";

export interface IAuthenticationResult {
    token: string;
    validationResult: IValidationResult;
    userInfo: IUserInfo;
}

import { IMessage } from "./message";

export interface IValidationResult {
    isValid: boolean;
    messages: IMessage[];
}
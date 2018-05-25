import { Component, Input } from "@angular/core";
import { IMessage } from "../entities/message";

@Component({
    selector: 'fm-error',
    templateUrl: './error.component.html'
})

export class ErrorComponent {
    @Input() messages: IMessage[];
}

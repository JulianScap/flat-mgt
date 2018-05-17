import { Component, Input } from "@angular/core";

@Component({
    selector: 'fm-error',
    templateUrl: './error.component.html'
})

export class ErrorComponent {
    @Input() messages: string[];
}

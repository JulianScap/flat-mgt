import { Component, Input } from "@angular/core";
import { IMessage } from "../entities/message";

@Component({
  selector: 'fm-message',
  templateUrl: './message.component.html'
})

export class MessageComponent {
  @Input() messages: IMessage[];

  removeMessage(i: number): void {
    this.messages.splice(i, 1);
  }
}

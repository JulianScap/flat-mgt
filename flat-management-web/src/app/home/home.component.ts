import { Component } from '@angular/core';
import { IMessage } from '../shared/entities/message';

@Component({
  templateUrl: './home.component.html'
})
export class HomeComponent {
  messages: IMessage[];

  onMessage(messages: IMessage[]) {
    this.messages = messages;
  }
}

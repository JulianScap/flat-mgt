import { Component } from '@angular/core';
import { IMessage } from '../shared/entities/message';
import { FlatComponentMode } from '../shared/flat/flatComponentMode.enum';

@Component({
  templateUrl: './home.component.html'
})
export class HomeComponent {
  messages: IMessage[];
  flatFormMode: FlatComponentMode = FlatComponentMode.Edit;

  onMessage(messages: IMessage[]) {
    this.messages = messages;
  }
}

import { Component, OnInit } from '@angular/core';

import {WebPubSubServiceClient} from '@azure/web-pubsub'


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  async ngOnInit():Promise<void> {
    const serviceClient = new WebPubSubServiceClient("Endpoint=https://webpub1.webpubsub.azure.com;AccessKey=spi5sANERUCA4Q7ZarTfKfu6rt+yTVSkbZv5NROi+I0=;Version=1.0;",'first_hub');
    let token = await serviceClient.getClientAccessToken()
    let ws = new WebSocket(token.url);
    ws.onmessage = function (e) {
      var server_message = e.data;
      console.log(server_message);
    }

  }
  
  title = 'AngularAzureWebPubSubDemo';
}

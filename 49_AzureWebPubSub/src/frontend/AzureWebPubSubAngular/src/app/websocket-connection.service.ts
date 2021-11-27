import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { webSocket } from "rxjs/webSocket";


@Injectable({
  providedIn: 'root'
})
export class WebsocketConnectionService {

  private wssLink: string = "wss://webpubsubdemo2021.webpubsub.azure.com:443/client/hubs/first_hub?access_token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE2Mzc5Njk3NjQsImV4cCI6MTYzNzk3MzM2NCwiaWF0IjoxNjM3OTY5NzY0LCJhdWQiOiJodHRwczovL3dlYnB1YnN1YmRlbW8yMDIxLndlYnB1YnN1Yi5henVyZS5jb20vY2xpZW50L2h1YnMvZmlyc3RfaHViIn0.KcAzqR0GJs2tHPaNtrKV3Dk_RP6FgjkeeXOZl7Q-sWo"

  constructor() { }

  public connect(): Observable<any> {

    var observable = new Observable<any>((subcriber) => {

      var subject = webSocket(this.wssLink)

      subject.subscribe(
        msg => subcriber.next(msg),
        err => console.log(err),
        () => console.log('complete')
      );
    })

    return observable
  }
}

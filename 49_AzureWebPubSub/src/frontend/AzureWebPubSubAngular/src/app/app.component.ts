import { Component, OnInit } from '@angular/core';
import { WebsocketConnectionService } from './websocket-connection.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  constructor(private service: WebsocketConnectionService){

  }
  ngOnInit(): void {
    this.service.connect()
                .subscribe((msg)=>{
                  console.log(msg)
                })
  }
}

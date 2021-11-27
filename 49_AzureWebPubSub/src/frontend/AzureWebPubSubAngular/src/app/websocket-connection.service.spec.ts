import { TestBed } from '@angular/core/testing';

import { WebsocketConnectionService } from './websocket-connection.service';

describe('WebsocketConnectionService', () => {
  let service: WebsocketConnectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WebsocketConnectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

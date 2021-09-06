import http from 'k6/http'
import { check, sleep } from 'k6';

export let options = {
    stages: [
        { duration: '10s', target:10}
    ]
}

export default function () {
    console.log('sending')
    // let res = http.get('https://mysampleapp202109.azurewebsites.net/primes/100')
    let res = http.get('https://example.com')
    console.log('done')
    sleep(50)
}
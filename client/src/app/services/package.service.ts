import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PackageService {

  constructor(private  Http: HttpClient) {
  }


  getPackages(expeditor?: string) {
    // console.log(filter);

    return this.Http.get<any>('https://localhost:44336/api/packages?expeditor=' + expeditor
    ).toPromise();
  }

  getByExpeditor(expeditor?: string) {
    return this.Http.get<any>('https://localhost:44336/api/packages/GetByExpeditor?expeditor=' + expeditor
    ).toPromise();

  }

  getFiltru() {
    return this.Http.get<any>('https://localhost:44336/api/packages/Filter'
    ).toPromise();
  }

}

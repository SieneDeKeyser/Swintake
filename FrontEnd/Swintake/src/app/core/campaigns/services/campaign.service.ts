import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Campaign } from '../classes/campaign';
import { Observable } from 'rxjs';
import { ApiUrl } from '../../CommonUrl/CommonUrl';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()

export class CampaignService {

  constructor(private http: HttpClient) { }
  
  addCampaign(campaign: Campaign): Observable<Campaign> {
    delete campaign.id;
    return this.http.post<Campaign>(ApiUrl.urlCampaign, campaign, httpOptions);
  }

  getCampaigns():  Observable<Campaign[]> {
    return this.http.get<Campaign[]>(ApiUrl.urlCampaign)
  }

  getCampaignById(id: string): Observable<Campaign> {
    return this.http.get<Campaign>(`${ApiUrl.urlCampaign}${id}`);
   }

   searchItem (searchTerm:string,listOfItems: Campaign[]):Campaign[]{
    if(!searchTerm){
      return listOfItems;
    }
    return listOfItems.filter(item =>
      item.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
      item.client.toLowerCase().includes(searchTerm.toLowerCase()) ||
      item.startDate.toString().includes(searchTerm.toLowerCase()) ||
      item.classStartDate.toString().includes(searchTerm.toLowerCase())
    ); 
  } 

}
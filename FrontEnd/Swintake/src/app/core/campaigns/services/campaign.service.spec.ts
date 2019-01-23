import { CampaignService } from './campaign.service';
import { HttpClient } from '@angular/common/http';
import { Campaign } from '../classes/campaign';
import { of } from 'rxjs'
import { ApiUrl } from '../../CommonUrl/CommonUrl';

describe('CampaignService', () => {
  let httpClient: HttpClient;
  let campaignservice: CampaignService;

  beforeEach(() => {
    httpClient = ({ get: null, post: null } as unknown) as HttpClient;
    campaignservice = new CampaignService(httpClient);
  });

  fit('should return new campaign', () => {

    let campaign: Campaign = {
      name: 'User',
      client: 'Client',
      startDate: new Date(),
      classStartDate: new Date()
    };
    spyOn(httpClient, 'post').and.callFake((url: string) => {
      expect(url).toBe(ApiUrl.urlCampaign);
      return of(campaign);
    });

    campaignservice.addCampaign(campaign)
      .subscribe((result: Campaign) =>
        expect(result).toEqual(campaign));
  });

  fit('should return list of campaigns', () => {
    spyOn(httpClient, 'get').and.callFake((url: string) => {
      expect(url).toBe(ApiUrl.urlCampaign);
      return of(createFakeCampaigns());
    });

    campaignservice.getCampaigns()
      .subscribe((result: Campaign[]) =>
        expect(result.length).toEqual(2));
  });

  fit('should return a single campaign', () => {
    spyOn(httpClient, 'get').and.callFake((url: string) => {
      expect(url).toBe(`${ApiUrl.urlCampaign}1`);
      return of(createFakeCampaign());
    });

    campaignservice.getCampaignById('1')
    .subscribe((result: Campaign) =>
    expect(result.name).toEqual('User'));
  })

});

function createFakeCampaigns(): Campaign[] {
  return [
    {
      id: '1',
      name: 'User',
      client: 'Client',
      startDate: new Date(),
      classStartDate: new Date()
    },
    {
      id: '2',
      name: 'User2',
      client: 'Client',
      startDate: new Date(),
      classStartDate: new Date()
    }
  ]
}

function createFakeCampaign(): Campaign {
  let campaign: Campaign = 
    {
      id: '1',
      name: 'User',
      client: 'Client',
      startDate: new Date(),
      classStartDate: new Date()
    }
    return campaign;
}
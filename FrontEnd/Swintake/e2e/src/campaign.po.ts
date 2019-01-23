import {browser, by, protractor, element} from 'protractor';
import { Campaign } from 'src/app/core/campaigns/classes/campaign';

export class CampaignPage{
    navigateTo(){
        return browser.get('/campaigns');
    }

    campaign: Campaign = 
    {
        name: 'User',
        client: 'Client',
        startDate: new Date('01/01/2020'),
        classStartDate: new Date('02/02/2020')
    };

    navigateCreateCampaign()
    {
        browser.findElement(by.id('CreateButtonCampaign')).click();
    }

    AddNewCampaign(campaign: Campaign)
    {
        browser.findElement(by.id('inputNameText')).sendKeys(campaign.name);
        browser.findElement(by.id('inputClientText')).sendKeys(campaign.client);
        browser.findElement(by.id('inputStartDate')).sendKeys(campaign.startDate.toDateString());
        browser.findElement(by.id('inputClassStartDate')).sendKeys(campaign.classStartDate.toDateString());
        browser.findElement(by.id('CampaignCreateButton')).click();
        return this;
    }

    expectifCampaignHasbeenAddedToList(campaingName: string)
    {
        expect(browser.wait(protractor.ExpectedConditions.textToBePresentInElement(element(by.id('listcampaings')),campaingName),5000)).toBeTruthy();
        return this;
    }

    performClickOnFirstElementInList(){
        let firstelementInList = element.all(by.id("campaignName")).first();
        firstelementInList.click();
        return this;
    }

    expectIfCampaignSelected(campaignName: string){
        expect(browser.wait(protractor.ExpectedConditions.textToBePresentInElement(element(by.id('detailCampaignName')), campaignName), 5000)).toBeTruthy();
        return this;
    }
}

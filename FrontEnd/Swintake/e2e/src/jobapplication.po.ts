import {browser, by, protractor, element} from 'protractor';

export class JobApplicationPage{
   navigateTo(){
       return browser.get('/candidates');
   }

   performClickOnFirstElementInListCandidates() {
    let firstelementInList = element.all(by.id("candidateFirstName")).first();
    firstelementInList.click();  
    return this;
  }

   navigateCampaignName(){
       browser.findElement(by.id("selectCampaign")).click();
   }

   performClickOnFirstElementInDropDown(){
       browser.findElement(by.cssContainingText('option', 'Java academy 2019')).click();
   }

   submitJobApplication(){
       browser.findElement(by.id("jobapplicationCreateButton")).click();
   }

   expectifJobApplicationHasbeenAddedToList()
   {
       expect(browser.wait(protractor.ExpectedConditions.textToBePresentInElement(element(by.id('campaignNameJobapplication')),"Java academy 2019"),5000)).toBeTruthy();
       return this;
   }

}
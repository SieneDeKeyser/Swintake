import {browser, by, protractor, element} from 'protractor';
import {Candidate} from 'src/app/core/candidates/classes/candidate'

export class CandidatePage{
     navigateTo(){
        return browser.get('/candidates');
    }

    candidate: Candidate = {
        firstName: 'Petar',
        lastName: 'Parker',
        email: 'totallynotspiderman@gmail.com',
        phoneNumber: '0470000000',
        gitHubUserName: 'noYOUarespiderman',
        linkedIn: 'pp',
        comment: 'great candidate'
      };

      navigateCreateCandidate(){
          browser.findElement(by.id('CreateButtonCandidate')).click();
      }

      performClickOnFirstElementInList() {
        let firstelementInList = element.all(by.id("candidateFirstName")).first();
        firstelementInList.click();  
        return this;
      }

      addNewCandidate(candidate: Candidate){
        browser.findElement(by.id('inputFirstNameText')).sendKeys(candidate.firstName);
        browser.findElement(by.id('inputLastNameText')).sendKeys(candidate.lastName);
        browser.findElement(by.id('inputEmailText')).sendKeys(candidate.email);
        browser.findElement(by.id('inputPhoneNumberText')).sendKeys(candidate.phoneNumber);
        browser.findElement(by.id('inputGitHubText')).sendKeys(candidate.gitHubUserName);
        browser.findElement(by.id('inputLinkedInText')).sendKeys(candidate.linkedIn);
        browser.findElement(by.id('inputCommentText')).sendKeys(candidate.comment);
        browser.findElement(by.id('CandidateCreateButton')).click();
        return this;
      }

      expectifCandidateSelected(candidateName: string){
        expect(browser.wait(protractor.ExpectedConditions.textToBePresentInElement(element(by.id('detailCandidateFirstname')),candidateName),5000)).toBeTruthy();
        return this; 
      }

      expectifCandidateHasbeenAddedToList(candidateName: string)
      {
          expect(browser.wait(protractor.ExpectedConditions.textToBePresentInElement(element(by.id('listcandidates')),candidateName),5000)).toBeTruthy();
          return this;
      }
}
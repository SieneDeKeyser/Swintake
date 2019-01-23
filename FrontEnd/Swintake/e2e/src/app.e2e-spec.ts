import { LoginPage } from './login.po';
import { CampaignPage } from './campaign.po';
import { CandidatePage } from './candidate.po';
import { JobApplicationPage } from './jobapplication.po';

fdescribe('workspace-project App', () => {
  let loginPage: LoginPage = new LoginPage();
  let campaignPage: CampaignPage = new CampaignPage();
  let candidatePage: CandidatePage = new CandidatePage();
  let jobapplicationPage: JobApplicationPage = new JobApplicationPage();

  it('should authenticate the user', () => {
    loginPage.navigateTo();
    loginPage.login(loginPage.user)
    .expectIfUserIsLoggedIn('Niels');
  });

  it('should add new created campaing into list', () => {
     campaignPage.navigateTo();
     campaignPage.navigateCreateCampaign();
     campaignPage.AddNewCampaign(campaignPage.campaign)
                 .expectifCampaignHasbeenAddedToList(campaignPage.campaign.name);
  });

  it('should add new created candidate into list', () => {
      candidatePage.navigateTo();
      candidatePage.navigateCreateCandidate();
      candidatePage.addNewCandidate(candidatePage.candidate)
                  .expectifCandidateHasbeenAddedToList(candidatePage.candidate.firstName);
   });
   
  it('should show detail when click on candidate in list', () => {
    candidatePage.navigateTo();
    candidatePage.performClickOnFirstElementInList();
    candidatePage.expectifCandidateSelected(candidatePage.candidate.firstName);
  });

  it('should show detail when click on campaign in list', () => {
    campaignPage.navigateTo();
    campaignPage.performClickOnFirstElementInList();
    campaignPage.expectIfCampaignSelected(campaignPage.campaign.name);
  });

  it('should create jobapplication when selecting campaign on candidate detail', () => {
    jobapplicationPage.navigateTo();
    jobapplicationPage.performClickOnFirstElementInListCandidates();
    jobapplicationPage.navigateCampaignName();
    jobapplicationPage.performClickOnFirstElementInDropDown();
    jobapplicationPage.submitJobApplication();
    jobapplicationPage.expectifJobApplicationHasbeenAddedToList();
  });
 
});

import {browser, by, ElementFinder, element} from 'protractor';
import { User } from 'src/app/core/authentication/classes/user';
import { protractor } from 'protractor/built/ptor';
import { BrowserDynamicTestingModule } from '@angular/platform-browser-dynamic/testing';

export class LoginPage{
    navigateTo(){
        return browser.get('/');
    }

    user: User = {
        Email: 'niels@switchfully.com',
        Password: 'ILoveReinout'
    };

    login(user: User){
        browser.findElement(by.id('emailInput')).sendKeys(user.Email);
        browser.findElement(by.id('passwordInput')).sendKeys(user.Password);
        browser.findElement(by.id('loginButton')).click();
        return this;
    }

    expectIfUserIsLoggedIn(firstName: string)
    {
        expect(browser.wait(protractor.ExpectedConditions.textToBePresentInElement(element(by.id('navbar')),firstName),5000)).toBeTruthy();
        return this;
    }
}
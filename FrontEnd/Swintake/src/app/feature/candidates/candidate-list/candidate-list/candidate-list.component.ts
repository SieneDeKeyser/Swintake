import { Component, OnInit } from '@angular/core';
import { Candidate } from '../../../../core/candidates/classes/candidate';
import { CandidateService } from '../../../../core/candidates/services/candidate.service';

@Component({
  selector: 'app-candidate-list',
  templateUrl: './candidate-list.component.html',
  styleUrls: ['./candidate-list.component.css']
})
export class CandidateListComponent implements OnInit {

  candidates: Candidate[] = [];
  allCandidates: Candidate[] = [];

  constructor(private candidateService: CandidateService) { }

  ngOnInit() {
    this.getAllCandidates();
  }

  getAllCandidates(): void {
    this.candidateService.getCandidates()
      .subscribe(candidates => {
        this.candidates = candidates;
        this.allCandidates = candidates;
      });
  }

  seachByTitle(givenSearchTerm: string) {
    this.candidates = this.candidateService.searchItem(givenSearchTerm,this.allCandidates);
  } 

}

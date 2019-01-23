import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Candidate } from 'src/app/core/candidates/classes/candidate';
import { CandidateService } from 'src/app/core/candidates/services/candidate.service';

@Component({
  selector: 'app-candidate-detail',
  templateUrl: './candidate-detail.component.html',
  styleUrls: ['./candidate-detail.component.css']
})
export class CandidateDetailComponent implements OnInit {
  @Input() candidateId: string;
  candidate: Candidate = new Candidate();


  constructor(   
    private candidateService: CandidateService,
    private route: ActivatedRoute){}

  ngOnInit() {
    this.getCandidateId();
  }

  getCandidateId(): void{
    const id = this.route.snapshot.paramMap.get('id');
    this.candidateService.getCandidateById(id)
       .subscribe(candidate=> this.candidate=candidate)

  }
}

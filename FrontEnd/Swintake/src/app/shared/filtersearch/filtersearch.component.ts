import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged, take, tap } from 'rxjs/operators';

@Component({
  selector: 'app-filtersearch',
  templateUrl: './filtersearch.component.html',
  styleUrls: ['./filtersearch.component.css']
})

export class FiltersearchComponent implements OnInit {

  @Output() value: EventEmitter<string>;

  searchBox : FormControl;

  constructor() {
    this.value = new EventEmitter();
    this.searchBox = new FormControl();
  }

  ngOnInit() {
    this.searchBox.valueChanges
    .pipe(
      debounceTime(300),
      distinctUntilChanged())
    .subscribe(givenValue => this.value.emit(givenValue));    
  }

}
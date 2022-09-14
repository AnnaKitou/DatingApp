import { Component, OnInit } from '@angular/core';
import { tick } from '@angular/core/testing';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';

import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  member: Member;
  user: User;

  constructor(private acoountService: AccountService, private memberService: MembersService) {
  this.acoountService.currentUser$.pipe(take(1)).subscribe(user=>this.user=user)
  
}

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember() {
    this.memberService.getMember(this.user.userName).subscribe(member => {
      this.member = member;
    })
  }

}

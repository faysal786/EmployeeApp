import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailResolver } from './_resolvers/member-detail.resolvers';

export const appRoutes: Routes = [

    { path: 'home', component:  HomeComponent },
    {
        path: '',  // http://localhost:4200
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'members', component: MemberListComponent},
            { path: 'members/:id', component: MemberDetailComponent, resolve: {uses: MemberDetailResolver }},
            { path: 'messages', component:  MessagesComponent },
            { path: 'lists', component:  ListsComponent },
        ]
    },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }

];


/* export const appRoutes: Routes = [

    { path: 'home', component:  HomeComponent },
    { path: 'members', component: MemberListComponent, canActivate: [AuthGuard]},
    { path: 'messages', component:  MessagesComponent },
    { path: 'lists', component:  ListsComponent },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }

]; */

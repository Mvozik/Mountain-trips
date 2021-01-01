import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../../environments/environment';
import { LoginModel } from '../models/login.model';
import { RegisterModel } from "../models/register.model"
import { tap, mapTo, catchError} from "rxjs/operators"
import { Tokens } from "../models/tokens.model"
import { LoginStateModel } from '../models/login-state.model';
import { AppState } from '../app.state';
import { Store } from '@ngrx/store';
import * as LoginStateActions from './../actions/login.actions';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  

  constructor(private http:HttpClient,private store:Store<AppState>)
  {  
    
  }

  private readonly JWT_TOKEN = 'JWT_TOKEN';
  private readonly REFRESH_TOKEN = 'REFRESH_TOKEN';
  
  public loggedUser : string;

  
  url:string = baseUrl + "Identity/";
  
  

  login(loginModel:LoginModel):Observable<any>
  {
    return this.http.post(this.url+"Login",loginModel).pipe(tap(tokens=>this.doLoginUser(loginModel.email,tokens)))
  }
  register(registerModel:RegisterModel):Observable<any>
  {
    return this.http.post(this.url+"Register",registerModel).pipe(tap(tokens=>this.doLoginUser(registerModel.email,tokens)))
  }

  private doLoginUser(username:string,tokens:Tokens)
  {
    let newState : LoginStateModel = {loginState:"1",name:username};
    this.store.dispatch(new LoginStateActions.SetState(newState));
    this.loggedUser = username;
    this.storeTokens(tokens);
    
  }

  private storeTokens(tokens:Tokens)
  {
    localStorage.setItem(this.JWT_TOKEN,tokens.token);
    localStorage.setItem(this.REFRESH_TOKEN,tokens.refreshToken)
  }

  logout()
  {
    
    return this.http.post<any>(this.url+"Logout?refreshToken="+this.getRefreshToken(),{}).pipe(tap(()=>this.doLogoutUser()));
  }

  doLogoutUser()
  {
 
    this.loggedUser=null;
    this.removeTokens();
  }

  getRefreshToken()
  {
    return localStorage.getItem(this.REFRESH_TOKEN);
  }

  removeTokens()
  {
    localStorage.removeItem(this.JWT_TOKEN);
    localStorage.removeItem(this.REFRESH_TOKEN);
  }

  refreshToken()
  {
    
    return this.http.post<any>(this.url+"Refesh-Token",this.getTokens()).pipe(tap((tokens:Tokens)=>{this.storeTokens(tokens);}));
  }

  getTokens()
  {
    let token : Tokens = {
      token:localStorage.getItem(this.JWT_TOKEN),
    refreshToken:localStorage.getItem(this.REFRESH_TOKEN)}
    return token;
  }

  getJwtToken()
  {
    return localStorage.getItem(this.JWT_TOKEN);
  }

  storeJwtToken(token:string)
  {
    localStorage.setItem(this.JWT_TOKEN,token)
  }

}

import { LoginStateModel } from './../models/login-state.model';
import * as LoginStateActions from '../actions/login.actions';

const initialState: LoginStateModel = {
    loginState : localStorage.getItem("LOGIN_STATUS"),
    name : localStorage.getItem("USER_NAME")
}

export function loginReducer(state:LoginStateModel = initialState, action : LoginStateActions.Actions)
{
    switch(action.type){
        case LoginStateActions.SET_STATE:
            localStorage.setItem("LOGIN_STATUS",action.payload.loginState)
            localStorage.setItem("USER_NAME",action.payload.name)
            let signinState : LoginStateModel = { name:action.payload.name, loginState:action.payload.loginState}
            return signinState;

        case LoginStateActions.REMOVE_STATE:
            localStorage.setItem("LOGIN_STATUS","0")
            localStorage.setItem("USER_NAME","")
            let logoutState : LoginStateModel = { name:"", loginState:"0"}
            return logoutState;
        default:
            return state;
        
    }
}
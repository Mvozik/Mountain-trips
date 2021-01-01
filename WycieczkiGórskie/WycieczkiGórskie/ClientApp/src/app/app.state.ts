import { LoginStateModel } from './models/login-state.model';


export interface AppState{
    readonly loginState : LoginStateModel;
}
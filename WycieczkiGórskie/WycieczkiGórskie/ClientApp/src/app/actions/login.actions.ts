import { Action } from '@ngrx/store'
import { LoginStateModel } from '../models/login-state.model'


export const SET_STATE = '[LOGINSTATEMODEL] Set'
export const REMOVE_STATE = '[LOGINSTATEMODEL] Remove'


export class SetState implements Action
{
    readonly type = SET_STATE
    constructor(public payload:LoginStateModel){}
}

export class RemoveState implements Action
{
    readonly type = REMOVE_STATE
    constructor(){}
}

export type Actions = SetState | RemoveState
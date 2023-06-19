using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FSM_Machine<T>
{
    private Enum prevState;
    private Enum currentState;

    Dictionary<Enum, FSM_State<T>> fsmStateDict = new Dictionary<Enum, FSM_State<T>>();

    public void RegistState(Enum eState, FSM_State<T> state)
    {
        if (fsmStateDict.ContainsKey(eState))
            return;

        fsmStateDict.Add(eState, state);
    }

    public void FSM_Start(Enum startState)
    {
        if (fsmStateDict.ContainsKey(startState))
        {
            prevState = startState;
            currentState = startState;

            fsmStateDict[currentState].OnEnter();
        }
    }

    public void FSM_Update()
    {
        if(fsmStateDict.ContainsKey(currentState))
            fsmStateDict[currentState].OnUpdate();
    }

    public void ChangeState(Enum nextState)
    {
        if (currentState.Equals(nextState))
            return;

        if(fsmStateDict.ContainsKey(currentState))
            fsmStateDict[currentState].OnExit();

        prevState = currentState;
        currentState = nextState;

        if (fsmStateDict.ContainsKey(currentState))
            fsmStateDict[currentState].OnEnter();
    }

    public Enum GetCurrentState()
    {
        return currentState;
    }

    public Enum GetPrevState()
    {
        return prevState;
    }
}

public abstract class FSM_State<T>
{
    public T owner;

    public abstract void OnEnter();

    public abstract void OnUpdate();

    public abstract void OnExit();
}
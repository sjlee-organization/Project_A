using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //±âº» ½ºÅÝ
    private int maxHp;
    private int currentHp;

    private int atk;
    private int def;

    private int speed;

    FSM_Machine<Unit> fsm = new FSM_Machine<Unit>();
}

public class IdleState : FSM_State<Unit>
{
    public override void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnExit()
    {
        throw new System.NotImplementedException();
    }
}

public class MoveState : FSM_State<Unit>
{
    public override void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
    public override void OnExit()
    {
        throw new System.NotImplementedException();
    }
}

public class HitState : FSM_State<Unit>
{
    public override void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnExit()
    {
        throw new System.NotImplementedException();
    }
}
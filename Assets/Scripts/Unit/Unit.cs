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

    [SerializeField]
    private float speed;

    private Rigidbody2D rigidbody2d;


    public float Speed => speed;

    protected FSM_Machine<Unit> fsm = new FSM_Machine<Unit>();

    private void Awake()
    {
        FSMInit();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        fsm.FSM_Update();
    }

    void FSMInit()
    {
        IdleState idleState = new IdleState(this);
        MoveState moveState = new MoveState(this);
        HitState hitState = new HitState(this);

        fsm.RegistState(UnitState.Idle, idleState);
        fsm.RegistState(UnitState.Move, moveState);
        fsm.RegistState(UnitState.Hit, hitState);

        fsm.FSM_Start(UnitState.Move);
    }

    public virtual void Move()
    {

    }

    public virtual void Hit()
    {

    }

    protected virtual void KnockBack(Vector2 dir)
    {
        rigidbody2d.AddForce(dir*150, ForceMode2D.Force);
    }

    public void ChangeFSM(UnitState newState)
    {
        fsm.ChangeState(newState);
    }
}

public class IdleState : FSM_State<Unit>
{
    public IdleState(Unit owner)
    {
        this.owner = owner;
    }

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
    public MoveState(Unit owner)
    {
        this.owner = owner;
    }

    public override void OnEnter()
    {
    }

    public override void OnUpdate()
    {
        owner.Move();
    }
    public override void OnExit()
    {
    }
}

public class HitState : FSM_State<Unit>
{
    public HitState(Unit owner)
    {
        this.owner = owner;
    }

    public override void OnEnter()
    {
        owner.Hit();
        owner.ChangeFSM(UnitState.Move);
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {

    }
}
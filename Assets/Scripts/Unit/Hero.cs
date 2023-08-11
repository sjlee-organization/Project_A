using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{
    public override void Move()
    {
        transform.localPosition = new Vector3(transform.localPosition.x + Time.deltaTime * Speed, transform.localPosition.y, transform.localPosition.z);

        base.Move();
    }

    public override void Hit()
    {
        KnockBack(new Vector2(-1, 1));
        base.Hit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Enemy"))
        {
            ChangeFSM(UnitState.Hit);
        }
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public override void Move()
    {
        transform.localPosition = new Vector3(transform.localPosition.x - Speed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
    }

    public override void Hit()
    {
        KnockBack(new Vector2(1, 1));
        base.Hit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ally"))
        {
            ChangeFSM(UnitState.Hit);
        }
    }
}
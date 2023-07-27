using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Unit targetUnit;

    [SerializeField]
    private Vector2 cameraOffset;

    public bool freezePosionX;
    public bool freezePosionY;

    public float moveTime = 1f;

    Vector3 targetPos = new Vector3();

    private void Awake()
    {
        targetPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (targetUnit == null)
            return;

        if (!freezePosionX)
            targetPos.x = targetUnit.transform.position.x + cameraOffset.x;

        if (!freezePosionY)
            targetPos.y = targetUnit.transform.position.y + cameraOffset.y;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime/moveTime);
    }
}
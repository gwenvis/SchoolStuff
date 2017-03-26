using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    [SerializeField] Vector3 moveSpeed = Vector3.zero;
    [SerializeField] float moveTime = 2;
    float currentMoveTime;
    float direction = 1;

    Rigidbody rigid;
    Vector3 currentMoveAmount = Vector3.zero;

	void Start ()
    {
        currentMoveTime = Time.time - moveTime / 2;
        rigid = GetComponent<Rigidbody>();
    }

	void FixedUpdate ()
    {
        if (Time.time >= currentMoveTime + moveTime)
            SwitchDirection();
        ZeroVelocity();
        rigid.MovePosition(transform.position + moveSpeed * direction);
	}

    void ZeroVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void SwitchDirection()
    {
        direction = -direction;
        currentMoveTime = Time.time;
    }
}

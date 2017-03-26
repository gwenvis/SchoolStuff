using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ConstantRotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotateSpeed;
    [SerializeField] private bool lockRotation = true;
    public Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        if (lockRotation)
            rigid.constraints = RigidbodyConstraints.FreezePosition;

        if (rotateSpeed.x == 0)
            rigid.constraints |= RigidbodyConstraints.FreezeRotationX;
        if (rotateSpeed.y == 0)
            rigid.constraints |= RigidbodyConstraints.FreezeRotationY;
        if (rotateSpeed.z == 0)
            rigid.constraints &= RigidbodyConstraints.FreezeRotationZ;

        rigid.maxAngularVelocity = rotateSpeed.x + rotateSpeed.y + rotateSpeed.z;
    }

    void Update()
    {
        rigid.angularVelocity = rotateSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour {

	private Vector3 CurrentCheckpointPos { get; set; }

    void Start()
    {
        SetCheckpoint(transform.position);
    }

    public void SetCheckpoint(Vector3 position)
    {
        CurrentCheckpointPos = position;
    }

    public void RespawnAtCheckpoint()
    {
        transform.position = CurrentCheckpointPos;
        var rigid = GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
}

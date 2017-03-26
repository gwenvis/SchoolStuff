using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float normalSpeed = 10;
    public float quickSpeed = 10000;
    public float jumpHeight = 10;

    Rigidbody rigid;
    float currentSpeed;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        currentSpeed = normalSpeed;
        rigid.maxAngularVelocity = 200;
    }

    void Update()
    {
        if (CanJump() && Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (Input.GetKeyDown(KeyCode.R))
            GetComponent<PlayerCheckpoint>().RespawnAtCheckpoint();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed = quickSpeed;
        else currentSpeed = normalSpeed;


        Roll(Input.GetAxis("Vertical"));
        RollSideways(Input.GetAxis("Horizontal"));      
    }

    bool CanJump()
    {
        Ray raycast = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(raycast, 1.2f);
    }

    void Jump()
    {
        var vel = rigid.velocity;
        vel.y = jumpHeight;
        rigid.velocity = vel;
    }

    void RollSideways(float dir)
    {
        Vector3 direction = Camera.main.transform.forward * -dir;
        rigid.AddTorque(direction * currentSpeed, ForceMode.Force);
    }

    void Roll(float dir)
    {
        Vector3 direction = Camera.main.transform.right * dir;
        rigid.AddTorque(direction * currentSpeed, ForceMode.Force);
    }

    public void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.black;
      

        GUI.Label(new Rect(0, 0, 200, 200), "Score: " + CurrentScore.Score, style);
    }
}

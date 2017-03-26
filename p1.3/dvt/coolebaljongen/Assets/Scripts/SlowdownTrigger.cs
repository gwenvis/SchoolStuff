using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownTrigger : MonoBehaviour
{
    [SerializeField]
    float maxSpeed = 3;

    public void OnTriggerStay(Collider other)
    {
        var reged = other.gameObject.GetComponent<Rigidbody>();
        if (reged)
        {
            Vector3 wantedVelocity = reged.velocity;
            Vector2 clampvelocity = new Vector2(wantedVelocity.x, wantedVelocity.z);
            clampvelocity = Vector2.ClampMagnitude(clampvelocity, maxSpeed);
            wantedVelocity.x = clampvelocity.x;
            wantedVelocity.z = clampvelocity.y;
            reged.velocity = wantedVelocity;
        }
    }

}

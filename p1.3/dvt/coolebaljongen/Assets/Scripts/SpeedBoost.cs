using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField]
    private float boostForce;

    private GameObject target;
    private Rigidbody target_rigid;

    // Use this for initialization
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player");
        if (target)
            target_rigid = target.GetComponent<Rigidbody>();

        if (!target_rigid)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {

    }



    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == target.tag)
        {
            target_rigid.AddForce(transform.forward * boostForce * Time.deltaTime, ForceMode.Force);
        }
    }
}

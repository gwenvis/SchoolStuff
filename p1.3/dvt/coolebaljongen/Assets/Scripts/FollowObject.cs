using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    public Transform target;
    [SerializeField] private float offset = 4;
    [SerializeField] private bool rotatewithcamera = true;

	void Start ()
    {
        
	}
	
    void Update()
    {
        if (rotatewithcamera)
        {
            var rotation = transform.eulerAngles;
            rotation.y = Camera.main.transform.eulerAngles.y;
            rotation.x = Camera.main.transform.eulerAngles.x + 20;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }

	void LateUpdate ()
    {
        transform.position = target.position + (offset * transform.right);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraRotation : MonoBehaviour {

    public float offset;
    public float fmultiplier = 0.8f;
    private Vector3 rotation;
    public Transform target;
    public Rigidbody rigid;
    [SerializeField] bool lerp = false;
    [SerializeField] float lerpSpeed = 2.0f;

    private int totalCoins;
    public static int currentCoins;

	void Start()
    {
        rotation = transform.eulerAngles;
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length + 1;
        currentCoins = totalCoins;

        if (!rigid)
            rigid = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
	}
	
    void LateUpdate()
    {
        rotation.x -= Input.GetAxis("Mouse Y") * 100 * Time.deltaTime;
        rotation.y += Input.GetAxis("Mouse X") * 100 * Time.deltaTime;
        offset -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 100;
        offset = Mathf.Clamp(offset, 0, 20);
        transform.eulerAngles = rotation;
        if (lerp)
            transform.position = Vector3.Lerp(transform.position, RayCam(), lerpSpeed * Time.deltaTime);
        else
            transform.position = RayCam();
        if (rigid)
            SpeedFov();
    }

    Vector3 RayCam()
    {
        Ray ray = new Ray(target.position - transform.forward * 1, -transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, offset))
            return hit.point + transform.forward * 2.0f;

        return target.position + (offset * -transform.forward);
    }

    void SpeedFov()
    {
        float speed = rigid.velocity.magnitude;
        float wantedFOV = 60 + speed * fmultiplier;
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, Mathf.Clamp(wantedFOV, 60, 110), 0.8f *Time.deltaTime);
    }
}

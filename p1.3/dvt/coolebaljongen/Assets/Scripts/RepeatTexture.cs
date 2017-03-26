using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatTexture : MonoBehaviour {

	void Start ()
    {
        Material mat = new Material(GetComponent<MeshRenderer>().material);
        mat.mainTextureScale = new Vector2(transform.localScale.z, transform.localScale.x);
        GetComponent<MeshRenderer>().material = mat;
	}
}

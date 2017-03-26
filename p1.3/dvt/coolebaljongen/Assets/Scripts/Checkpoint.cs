using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Color bottomColor, topColor;
    public Vector3 wantedScale, wantedPosition;

    bool animate = false;

    void Start()
    {
        var meshrenderer = GetComponent<MeshRenderer>();
        var mesh = GetComponent<MeshFilter>().mesh;

        Texture2D text = new Texture2D(1024, 1024, TextureFormat.RGBAFloat, false);

        for (int i = 0; i < text.height; i++)
        {
            float l = (float)(i + 1) / (float)text.height;

            for (int j = 0; j < text.width; j++)
            {
                text.SetPixel(j, i, Color.Lerp(bottomColor, topColor, l));
                text.alphaIsTransparency = true;
            }
        }

        text.filterMode = FilterMode.Bilinear;
        text.wrapMode = TextureWrapMode.Clamp;

        text.Apply(false);
        Material mat = new Material(meshrenderer.material);
        mat.mainTexture = text;
        meshrenderer.material = mat;

        wantedPosition = transform.position + wantedPosition;
    }

    void Update()
    {
        if (!animate)
            return;

        transform.position = Vector3.Lerp(transform.position, wantedPosition, 2 * Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, wantedScale, 2 * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        var pc = other.gameObject.GetComponent<PlayerCheckpoint>();
        if (pc)
        {
            var checkpointpos = transform.position;
            checkpointpos.y += 1;
            pc.SetCheckpoint(checkpointpos);
            animate = true;
        }
    }
}

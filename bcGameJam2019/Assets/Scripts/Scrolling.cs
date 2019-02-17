using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr= GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.y += Time.deltaTime;

        mat.mainTextureOffset = offset;
    }
}

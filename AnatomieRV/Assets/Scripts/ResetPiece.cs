using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPiece : MonoBehaviour
{
    Vector3 posOrigin;
    Quaternion rotOrigin;
    Transform parent;

    public SphereCollider resetSphere;

    // Start is called before the first frame update
    void Start()
    {
        posOrigin = transform.localPosition;
        rotOrigin = transform.localRotation;
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckResetPos()
    {
        if ((transform.position - (resetSphere.center + resetSphere.transform.position)).sqrMagnitude < resetSphere.radius * resetSphere.radius)
        {
            ResetPos();
        }
    }

    void ResetPos()
    {
        transform.SetParent(parent);
        transform.localPosition = posOrigin;
        transform.localRotation = rotOrigin;
    }
}

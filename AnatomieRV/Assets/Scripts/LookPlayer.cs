using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    public GameObject VRCamera;
    public GameObject FallbackCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (VRCamera.activeInHierarchy)
            transform.LookAt(VRCamera.transform);
        else
            transform.LookAt(FallbackCamera.transform);
        transform.Rotate(0, 180, 0);
    }
}

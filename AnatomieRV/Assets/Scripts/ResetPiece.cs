using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPiece : MonoBehaviour
{
    Vector3 posOrigin;
    Quaternion rotOrigin;
    Vector3 scaleOrigin;
    Transform parent;
    
    public CapsuleCollider resetCapsule;

    // Start is called before the first frame update
    void Start()
    {
        posOrigin = transform.localPosition;
        rotOrigin = transform.localRotation;
        scaleOrigin = transform.localScale;
        parent = transform.parent;
    }

    public void CheckResetPos()
    {
        if(resetCapsule.ClosestPoint(transform.position) == transform.position)
        {
            ResetPos();
        }
    }

    public void ResetPos()
    {
        StartCoroutine(LerpPos());
    }

    public void Rescale(Vector3 SkeletonSize)
    {
        if(transform.parent != parent)
        {
            transform.localScale = new Vector3(scaleOrigin.x * SkeletonSize.x, scaleOrigin.y * SkeletonSize.y, scaleOrigin.z * SkeletonSize.z);
        }
    }

    IEnumerator LerpPos()
    {
        transform.SetParent(parent);
        Vector3 posDepart = transform.localPosition;
        Vector3 scaleDepart = transform.localScale;
        Quaternion rotDepart = transform.localRotation;
        float timeStart = Time.time;
        while(Time.time - timeStart < 0.2)
        {
            transform.localPosition = Vector3.Lerp(posDepart, posOrigin, (Time.time - timeStart)*5);
            transform.localPosition = Vector3.Lerp(scaleDepart, scaleOrigin, (Time.time - timeStart) * 5);
            transform.localRotation = Quaternion.Lerp(rotDepart, rotOrigin, (Time.time - timeStart)*5);
            yield return new WaitForFixedUpdate();
        }
        transform.localPosition = posOrigin;
        transform.localRotation = rotOrigin;
        transform.localScale = scaleOrigin;
    }

    public void ResetPosChangementMode()
    {
        transform.SetParent(parent);
        transform.localPosition = posOrigin;
        transform.localRotation = rotOrigin;
    }
}

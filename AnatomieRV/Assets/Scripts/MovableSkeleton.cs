using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MovableSkeleton : MonoBehaviour
{
    public SteamVR_Action_Vector2 positionAction = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("Position");
    private List<Hand> handsHover = new List<Hand>();
    private bool isInHand = false;
    private Hand AttachedHand = null;
    private Vector3 ScaleOrigin;
    private float coeffScale = 1;

    public float minDezoom = 0.05f;
    public float ZoomCoefficient = 0.1f;

    private ResetPiece[] childs; 

    // Start is called before the first frame update
    void Start()
    {
        childs = GetComponentsInChildren<ResetPiece>();
        ScaleOrigin = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        Hand hand = other.GetComponent<Hand>();
        if (hand != null)
        {
            handsHover.Add(hand);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Hand hand = other.GetComponent<Hand>();
        if (hand != null)
        {
            handsHover.Remove(hand);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Hand hand in handsHover)
        {
            GrabTypes startingGrabType = hand.GetGrabStarting();
            if (startingGrabType == GrabTypes.Grip && !isInHand)
            {
                AttachedHand = hand;
                AttachedHand.transform.localScale = coeffScale * new Vector3(1, 1, 1);
                hand.AttachObject(gameObject, startingGrabType, Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.TurnOnKinematic);
                hand.Hide();
                isInHand = true;
            }
        }
        if (isInHand)
        {
            if (AttachedHand.GetGrabEnding() == GrabTypes.Grip)
            {
                AttachedHand.DetachObject(gameObject);
                AttachedHand.transform.localScale = new Vector3(1, 1, 1);
                AttachedHand.Show();
                AttachedHand = null;
                isInHand = false;
            }
            else
            {
                coeffScale += ZoomCoefficient * positionAction.GetAxis(AttachedHand.handType)[0];

                if (coeffScale < minDezoom)
                {
                    coeffScale = minDezoom;
                }

                AttachedHand.transform.localScale = coeffScale * new Vector3(1, 1, 1);

                foreach(ResetPiece child in childs)
                {
                    child.Rescale(coeffScale * ScaleOrigin);
                }
            }
        }
    }
}

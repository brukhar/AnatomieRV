//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Demonstrates how to create a simple interactable object
//
//=============================================================================

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem.Sample
{
    //-------------------------------------------------------------------------
    [RequireComponent(typeof(Interactable))]
    public class Name : MonoBehaviour
    {
        public string Nom;
        public string Function;

        public Text RightName;
        public Text RightFunction;
        public Text LeftName;
        public Text LeftFunction;

        private TextMesh generalText;
        private TextMesh hoveringText;
        private Vector3 oldPosition;
        private Quaternion oldRotation;

        private float attachTime;

        private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

        private Interactable interactable;

        //-------------------------------------------------
        void Awake()
        {
            var textMeshs = GetComponentsInChildren<TextMesh>();
            generalText = textMeshs[0];
         

            generalText.text = "";
        

            interactable = this.GetComponent<Interactable>();
        }


        //-------------------------------------------------
        // Called when a Hand starts hovering over this object
        //-------------------------------------------------
      /*  private void OnHandHoverBegin(Hand hand)
        {
            generalText.text = "Hovering hand: " + hand.name;
        }


        //-------------------------------------------------
        // Called when a Hand stops hovering over this object
        //-------------------------------------------------
        private void OnHandHoverEnd(Hand hand)
        {
            generalText.text = "No Hand Hovering";
        }


        //-------------------------------------------------
        // Called every Update() while a Hand is hovering over this object
        //-------------------------------------------------
        private void HandHoverUpdate(Hand hand)
        {
            GrabTypes startingGrabType = hand.GetGrabStarting();
            bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

            if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
            {
                // Save our position/rotation so that we can restore it when we detach
                oldPosition = transform.position;
                oldRotation = transform.rotation;

                // Call this to continue receiving HandHoverUpdate messages,
                // and prevent the hand from hovering over anything else
                hand.HoverLock(interactable);

                // Attach this object to the hand
                hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
            }
            else if (isGrabEnding)
            {
                // Detach this object from the hand
                hand.DetachObject(gameObject);

                // Call this to undo HoverLock
                hand.HoverUnlock(interactable);

                // Restore position/rotation
                transform.position = oldPosition;
                transform.rotation = oldRotation;
            }
        }*/


        //-------------------------------------------------
        // Called when this GameObject becomes attached to the hand
        //-------------------------------------------------
        private void OnAttachedToHand(Hand hand)
        {
            generalText.text = Nom;
            if(hand.handType == SteamVR_Input_Sources.RightHand)
            {
                if (RightName)
                    RightName.text = Nom;
                if (RightFunction)
                    RightFunction.text = Function;
            }
            else if(hand.handType == SteamVR_Input_Sources.LeftHand)
            {
                if (LeftName)
                    LeftName.text = Nom;
                if (LeftFunction)
                    LeftFunction.text = Function;
            }
        }



        //-------------------------------------------------
        // Called when this GameObject is detached from the hand
        //-------------------------------------------------
        private void OnDetachedFromHand(Hand hand)
        {
            generalText.text = string.Format("");
            if (hand.handType == SteamVR_Input_Sources.RightHand)
            {
                if (RightName)
                    RightName.text = string.Format("");
                if (RightFunction)
                    RightFunction.text = string.Format("");
            }
            else if (hand.handType == SteamVR_Input_Sources.LeftHand)
            {
                if (LeftName)
                    LeftName.text = string.Format("");
                if (LeftFunction)
                    LeftFunction.text = string.Format("");
            }
        }


        //-------------------------------------------------
        // Called every Update() while this GameObject is attached to the hand
        //-------------------------------------------------
        private void HandAttachedUpdate(Hand hand)
        {
           
        }

      

        //-------------------------------------------------
        // Called when this attached GameObject becomes the primary attached object
        //-------------------------------------------------
        private void OnHandFocusAcquired(Hand hand)
        {
        }


        //-------------------------------------------------
        // Called when another attached GameObject becomes the primary attached object
        //-------------------------------------------------
        private void OnHandFocusLost(Hand hand)
        {
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


namespace Valve.VR.InteractionSystem.Sample
{
    public class MuscleManagement : MonoBehaviour
    {

        private GameObject Model;
        private bool OsActive = true;
        private bool MuscleActive = false;


        public void ShowBones()
        {

            if(OsActive == true)
            {
                OsActive = false;
            }
            else
            {
                OsActive = true;
            }
            Model = GameObject.Find("Muscles");

            foreach (Transform child in Model.transform)
            {
                if(OsActive == true)
                {
                    if (child.ToString().Contains("Box"))
                    {

                        child.gameObject.SetActive(true);
                       
                    }
                }
                else
                {
                    if (child.ToString().Contains("Box"))
                    {

                        child.gameObject.SetActive(false);
                        ResetPiece reset = child.gameObject.GetComponent<ResetPiece>();
                        if (reset != null)
                        {
                            
                            reset.ResetPosChangementMode();
                        }
                       
                    }
                }
                

               /* if (child.ToString().Contains("Mus") || child.ToString().Contains("Oeil"))
                {

                    child.gameObject.SetActive(false);
                    ResetPiece reset = child.gameObject.GetComponent<ResetPiece>();
                    if (reset != null)
                    {
                        reset.ResetPos();
                    }
                }*/

            }
        }

        public void ShowMuscle()
        {
            Model = GameObject.Find("Muscles");
            if (MuscleActive == true)
            {
                MuscleActive = false;
            }
            else
            {
                MuscleActive = true;
            }
            foreach (Transform child in Model.transform)
            {
               /* if (child.ToString().Contains("Box"))
                {
                    child.gameObject.SetActive(false);
                    ResetPiece reset = child.gameObject.GetComponent<ResetPiece>();
                    if (reset != null)
                    {
                        reset.ResetPos();
                    }
                }*/
                if(MuscleActive == true)
                {
                    if (child.ToString().Contains("Mus") || child.ToString().Contains("Oeil"))
                    {
                        child.gameObject.SetActive(true); ;
                    }
                }
                else
                {
                    if (child.ToString().Contains("Mus") || child.ToString().Contains("Oeil"))
                    {
                        child.gameObject.SetActive(false);
                        ResetPiece reset = child.gameObject.GetComponent<ResetPiece>();
                        if (reset != null)
                        {
                            reset.ResetPosChangementMode();
                        }
                        
                    }
                }
                

            }
        }
    }
}


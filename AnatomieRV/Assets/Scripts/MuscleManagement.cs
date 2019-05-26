using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


namespace Valve.VR.InteractionSystem.Sample
{
    public class MuscleManagement : MonoBehaviour
    {

        private GameObject Model;


        public void ShowOnlyBones()
        {
            Model = GameObject.Find("Muscles");

            foreach (Transform child in Model.transform)
            {
                if (child.ToString().Contains("Box"))
                {
                    
                    child.gameObject.SetActive(true);
                }

                if (child.ToString().Contains("Mus") || child.ToString().Contains("Oeil"))
                {

                    child.gameObject.SetActive(false);
                    ResetPiece reset = child.gameObject.GetComponent<ResetPiece>();
                    if (reset != null)
                    {
                        reset.ResetPos();
                    }
                }

            }
        }

        public void ShowOnlyMuscle()
        {
            Model = GameObject.Find("Muscles");
            foreach (Transform child in Model.transform)
            {
                if (child.ToString().Contains("Box"))
                {
                    child.gameObject.SetActive(false);
                    ResetPiece reset = child.gameObject.GetComponent<ResetPiece>();
                    if (reset != null)
                    {
                        reset.ResetPos();
                    }
                }

                if (child.ToString().Contains("Mus") || child.ToString().Contains("Oeil"))
                {
                    child.gameObject.SetActive(true); ;
                }

            }
        }
    }
}


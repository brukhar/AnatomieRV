using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerQuizManager : MonoBehaviour
{
    public string Answer;
    public GameObject Reponse1;
    public GameObject Reponse2;
    public GameObject Reponse3;
    public GameObject Reponse4;
    private GameObject Model;
    private List<GameObject> ListOfReponse = new List<GameObject>();
    private List<GameObject> ListOfBones = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        Model = GameObject.Find("Muscles");
        foreach (Transform child in Model.transform)
        {
            if (child.ToString().Contains("Box"))
            {
                ListOfBones.Add(child.gameObject);
            }
        }
        ListOfReponse.Add(Reponse1);
        ListOfReponse.Add(Reponse2);
        ListOfReponse.Add(Reponse3);
        ListOfReponse.Add(Reponse4);
    }

   public void creerReponse()
    {
        resetText();
        int positionreponse = Random.Range(0, 4);
        ListOfReponse[positionreponse].GetComponent<TextMesh>().text = Answer;
        for(int i = 0; i < ListOfReponse.Count - 1; i++)
        {
            int number = Random.Range(0, ListOfBones.Count);
            bool addreponse = VerifierNomReponse(ListOfBones[number].GetComponent<Valve.VR.InteractionSystem.Sample.Name>().Nom);
            while (addreponse == true)
            {
                number = Random.Range(0, ListOfBones.Count);
                addreponse = VerifierNomReponse(ListOfBones[number].GetComponent<Valve.VR.InteractionSystem.Sample.Name>().Nom);
            }
            AddReponseToGameObject(ListOfBones[number].GetComponent<Valve.VR.InteractionSystem.Sample.Name>().Nom);
        }
        
        
    }

    bool VerifierNomReponse(string nom)
    {

        if (nom == Answer)
        {
            return true;
        }
        else
        {
            return false;
        }
          
     }

    void AddReponseToGameObject(string reponse)
    {
        foreach (GameObject r in ListOfReponse)
        {
            if (r.GetComponent<TextMesh>().text.Length == 0)
            {
                r.GetComponent<TextMesh>().text = reponse;
                break;
            }
        }
    }

    void resetText()
    {
        foreach (GameObject r in ListOfReponse)
        {
           
         r.GetComponent<TextMesh>().text = null;
           
        }
    }
        
    
    // Update is called once per frame
    void Update()
    {
        
    }

}

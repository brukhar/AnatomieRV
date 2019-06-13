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
    private List<GameObject> ListOfMuscle = new List<GameObject>();
    private QuizManagement qm;
    // Start is called before the first frame update
    void Start()
    {

        Model = GameObject.Find("Muscles");
        qm = GameObject.Find("UI").GetComponent<QuizManagement>();
        ListOfReponse.Add(Reponse1);
        ListOfReponse.Add(Reponse2);
        ListOfReponse.Add(Reponse3);
        ListOfReponse.Add(Reponse4);
    }

   public void creerReponse()
    {
        resetText();
        int positionreponse = Random.Range(0, 4);
        string[] splitanswer = Answer.Split(null);
        ListOfReponse[positionreponse].GetComponent<TextMesh>().text = splitanswer[0];
        for(int y  = 1; y < splitanswer.Length; y++)
        {
            ListOfReponse[positionreponse].GetComponent<TextMesh>().text += "\n" + splitanswer[y];
        }
        for(int i = 0; i < ListOfReponse.Count - 1; i++)
        {
            if (qm.OsPressed)
            {
                int number = Random.Range(0, qm.ListOfBones.Count);
                bool addreponse = VerifierNomReponse(qm.ListOfBones[number].GetComponent<Valve.VR.InteractionSystem.Sample.Name>().Nom);
                while (addreponse == true)
                {
                    number = Random.Range(0, qm.ListOfBones.Count);
                    addreponse = VerifierNomReponse(qm.ListOfBones[number].GetComponent<Valve.VR.InteractionSystem.Sample.Name>().Nom);
                }
                AddReponseToGameObject(qm.ListOfBones[number].GetComponent<Valve.VR.InteractionSystem.Sample.Name>().Nom);
            }
            else if(qm.MusclePressed)
            {
                int number = Random.Range(0, qm.ListOfMuscle.Count);
                bool addreponse = VerifierNomReponse(qm.ListOfMuscle[number].GetComponent<Valve.VR.InteractionSystem.Sample.Name>().Nom);
                while (addreponse == true)
                {
                    number = Random.Range(0, qm.ListOfMuscle.Count);
                    addreponse = VerifierNomReponse(qm.ListOfMuscle[number].GetComponent<Valve.VR.InteractionSystem.Sample.Name>().Nom);
                }
                AddReponseToGameObject(qm.ListOfMuscle[number].GetComponent<Valve.VR.InteractionSystem.Sample.Name>().Nom);
            }
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
                string[] splitanswer = reponse.Split(null);
                r.GetComponent<TextMesh>().text = splitanswer[0];
                for (int y = 1; y < splitanswer.Length; y++)
                {
                    r.GetComponent<TextMesh>().text += "\n" + splitanswer[y];
                }
                break;
            }
        }
    }

    public void resetText()
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

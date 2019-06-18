using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManagement : MonoBehaviour
{
    private GameObject Model;
    public GameObject PointDeSpawn;
    public List<GameObject> ListOfBones = new List<GameObject>();
    public List<GameObject> ListOfMuscle = new List<GameObject>();
    public GameObject Tofind;
    public bool OsPressed = false;
    public bool MusclePressed = false;
    // Start is called before the first frame update
    void Start()
    {

        PressOs();
        Model = GameObject.Find("Muscles");
        foreach (Transform child in Model.transform)
        {
            if (child.ToString().Contains("Box"))
            {
                ListOfBones.Add(child.gameObject);
            }

            if(child.ToString().Contains("Mus") || child.ToString().Contains("Oeil"))
            {
                ListOfMuscle.Add(child.gameObject);
            }
        }
    }

    public void GetRandom()
    {
        if(Tofind != null)
        {
            Destroy(Tofind);
        }

        if(!OsPressed && !MusclePressed)
        {
            
        }
        else if(OsPressed)
        {
            int number = Random.Range(0, ListOfBones.Count);
            Tofind = Instantiate(ListOfBones[number], PointDeSpawn.transform.position, ListOfBones[number].transform.rotation);
            GameObject reponse = GameObject.Find("ReponseManager");
            reponse.GetComponent<AnswerQuizManager>().Answer = Tofind.GetComponent<Valve.VR.InteractionSystem.Sample.Name>().Nom;
            Tofind.GetComponent<Rigidbody>().useGravity = true;
            Tofind.GetComponent<Rigidbody>().isKinematic = false;
            Tofind.GetComponent<Rigidbody>().freezeRotation = true;
            Tofind.GetComponent<Valve.VR.InteractionSystem.Sample.Name>().isForquiz = true;
            Destroy(Tofind.GetComponent<ResetPiece>());
            Tofind.transform.localScale = ListOfBones[number].transform.lossyScale;
            Tofind.SetActive(true);
            reponse.GetComponent<AnswerQuizManager>().creerReponse();
        }
        else if(MusclePressed)
        {
            int number = Random.Range(0, ListOfMuscle.Count);
            Tofind = Instantiate(ListOfMuscle[number], PointDeSpawn.transform.position, ListOfMuscle[number].transform.rotation);
            GameObject reponse = GameObject.Find("ReponseManager");
            reponse.GetComponent<AnswerQuizManager>().Answer = Tofind.GetComponent<Valve.VR.InteractionSystem.Sample.Name>().Nom;
            Tofind.GetComponent<Rigidbody>().useGravity = true;
            Tofind.GetComponent<Rigidbody>().isKinematic = false;
            Tofind.GetComponent<Rigidbody>().freezeRotation = true;
            Tofind.GetComponent<Valve.VR.InteractionSystem.Sample.Name>().isForquiz = true;
            Destroy(Tofind.GetComponent<ResetPiece>());
            Tofind.transform.localScale = ListOfMuscle[number].transform.lossyScale;
            Tofind.SetActive(true);
            reponse.GetComponent<AnswerQuizManager>().creerReponse();
        }
       



    }

    public void stopquiz()
    {
        Destroy(Tofind);
        GameObject.Find("NombreReponse").GetComponent<Text>().text = "0";
        GameObject.Find("NombreQuestion").GetComponent<Text>().text = "0";
        GameObject.Find("ReponseManager").GetComponent<AnswerQuizManager>().resetText();
        GameObject.Find("Answer").GetComponent<TextMesh>().text = null;
        
    }

    public void PressOs()
    {
        if(OsPressed ==false)
        {
            ColorBlock color = GameObject.Find("Os").GetComponent<Button>().colors;
            color.normalColor = Color.red;
            GameObject.Find("Os").GetComponent<Button>().colors = color;
            OsPressed = true;
            Debug.Log("True");
        }
        else
        {
            ColorBlock color = GameObject.Find("Os").GetComponent<Button>().colors;
            color.normalColor = Color.blue;
            GameObject.Find("Os").GetComponent<Button>().colors = color;
            OsPressed = false;
            Debug.Log("false");
        }
        
    }

    public void PressMuscle()
    {
        if (MusclePressed == false)
        {
            ColorBlock color = GameObject.Find("Muscle").GetComponent<Button>().colors;
            color.normalColor = Color.red;
            GameObject.Find("Muscle").GetComponent<Button>().colors = color;
            MusclePressed = true;
        }
        else
        {
            ColorBlock color = GameObject.Find("Muscle").GetComponent<Button>().colors;
            color.normalColor = Color.blue;
            GameObject.Find("Muscle").GetComponent<Button>().colors = color;
            MusclePressed = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

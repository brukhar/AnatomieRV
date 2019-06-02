using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManagement : MonoBehaviour
{
    private GameObject Model;
    public GameObject PointDeSpawn;
    private List<GameObject> ListOfBones = new List<GameObject>();
    public GameObject BonesTofind;
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
    }

    public void GetRandomBones()
    {
        if(BonesTofind != null)
        {
            Destroy(BonesTofind);
        }
        int number = Random.Range(0, ListOfBones.Count);
        BonesTofind = Instantiate(ListOfBones[number], PointDeSpawn.transform.position,ListOfBones[number].transform.rotation);
        GameObject reponse = GameObject.Find("ReponseManager");
        reponse.GetComponent<AnswerQuizManager>().Answer = BonesTofind.GetComponent<Valve.VR.InteractionSystem.Sample.Name>().Nom;
        BonesTofind.GetComponent<Rigidbody>().useGravity = true;
        BonesTofind.GetComponent<Rigidbody>().isKinematic = false;
        BonesTofind.GetComponent<Rigidbody>().freezeRotation = true;
        BonesTofind.transform.localScale = ListOfBones[number].transform.lossyScale;
        BonesTofind.SetActive(true);
        reponse.GetComponent<AnswerQuizManager>().creerReponse();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

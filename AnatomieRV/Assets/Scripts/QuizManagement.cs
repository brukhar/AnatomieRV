using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManagement : MonoBehaviour
{
    private GameObject Model;
    public GameObject PointDeSpawn;
    private List<GameObject> ListOfBones = new List<GameObject>();
    private GameObject BonesTofind;
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
        BonesTofind.GetComponent<Rigidbody>().useGravity = true;
        BonesTofind.GetComponent<Rigidbody>().isKinematic = false;
        BonesTofind.transform.localScale = ListOfBones[number].transform.lossyScale;
        BonesTofind.SetActive(true);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

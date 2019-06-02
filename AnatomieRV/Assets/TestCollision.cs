using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
       string nom = collision.gameObject.GetComponent<Valve.VR.InteractionSystem.Sample.Name>().Nom;
       string reponse = GetComponent<TextMesh>().text;
        if(nom == reponse)
        {
            Debug.Log("bonne reponse");            
        }
        else
        {
            Debug.Log("mauvaise reponse");
        }
        Destroy(collision.gameObject);
        GameObject.Find("UI").GetComponent<QuizManagement>().GetRandomBones();
    }
}

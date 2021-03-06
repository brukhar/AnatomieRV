﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        string[] splitanswer = nom.Split(null);
        nom = splitanswer[0];
        for (int y = 1; y < splitanswer.Length; y++)
        {
            nom += "\n" + splitanswer[y];
        }
        string reponse = GetComponent<TextMesh>().text;
        Debug.Log(nom + ".............." + reponse);
        if (nom == reponse)
        {
            int goodreponse = int.Parse(GameObject.Find("NombreReponse").GetComponent<Text>().text) + 1;
            GameObject.Find("NombreReponse").GetComponent<Text>().text = goodreponse.ToString();
            Debug.Log("bonne reponse");
            

        }
        else
        {
            Debug.Log("mauvaise reponse");
        }
        int score = int.Parse(GameObject.Find("NombreQuestion").GetComponent<Text>().text) + 1;
        GameObject.Find("NombreQuestion").GetComponent<Text>().text = score.ToString()  ;
        Destroy(collision.gameObject);
        GameObject.Find("UI").GetComponent<QuizManagement>().GetRandom();
        GameObject.Find("Anwser").GetComponent<TextMesh>().text = "Reponse : " + nom;
    }
}

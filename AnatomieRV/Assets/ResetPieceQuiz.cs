using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPieceQuiz : MonoBehaviour
{
    public GameObject resetposition;
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
        collision.rigidbody.velocity = new Vector3 (0,0,0);
        collision.transform.position = resetposition.transform.position;
    }
}

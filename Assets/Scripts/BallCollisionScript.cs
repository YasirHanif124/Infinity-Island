using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "SBall")
        {
            Destroy(collision.gameObject);
        }
    }
}

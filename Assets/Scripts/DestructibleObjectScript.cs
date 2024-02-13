using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObjectScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }
}

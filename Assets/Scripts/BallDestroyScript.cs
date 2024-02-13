using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator destroyAfterDelay()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}

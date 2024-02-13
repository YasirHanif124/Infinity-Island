using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    private bool isMoving = false;
    private bool isMoved = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BoatCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving == true)
        {
            transform.Translate(transform.forward * 20f * Time.deltaTime);

            if(isMoved == true)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator BoatCoroutine()
    {
        yield return new WaitForSeconds(3f);
        isMoving = true;

        yield return new WaitForSeconds(100f);
        isMoved = true;
    }

}

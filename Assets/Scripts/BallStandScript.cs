using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BallStandScript : MonoBehaviour
{
    public GameObject Ball;
    public GameObject BallStopper;
    public Transform BallPos;
    public bool play;
    public int count;
   

    private void Update()
    {
        if(play == true)
        {
            StartCoroutine(BallCoroutine());
            play = false;
        }
    }

    IEnumerator BallCoroutine()
    {
        
        GameObject b = Ball;
        

        while(true)
        {
            for(int i =0;i<count;i++)
            {
                Instantiate(b,BallPos.position, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
            BallStopper.SetActive(false);

            yield return new WaitForSeconds(3f);
            BallStopper.SetActive(true);
        }
    }
}

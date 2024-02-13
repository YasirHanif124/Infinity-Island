using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounceScript : MonoBehaviour
{
    public AudioSource bouncingSound;

    private void OnCollisionEnter(Collision collision)
    {
        bouncingSound.Play();
    }
}

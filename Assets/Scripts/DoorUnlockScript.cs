using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorUnlockScript : MonoBehaviour
{
    public GameObject Door;
    public GameObject Player;

    public Camera Main;
    public Camera FinalCamera;

    public static bool UnlockTrigger;

    public ParticleSystem UnlockParticle;
    // Start is called before the first frame update
    void Start()
    {
        UnlockTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(UnlockTrigger == true)
        {
            StartCoroutine(FinalDoorCoroutine());
            UnlockTrigger = false;

        }
    }

    IEnumerator FinalDoorCoroutine()
    {
        yield return new WaitForSeconds(1f);

        Player.SetActive(false);
        Main.gameObject.SetActive(false);
        FinalCamera.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        FinalDoorScript.triggerOpen = true;

        yield return new WaitForSeconds(3f);

        UnlockParticle.Play();

        yield return new WaitForSeconds(3f);

        MainLockScript.isUnlocked = true;

        FinalCamera.gameObject.SetActive(false);
        Player.SetActive(true);
        Main.gameObject.SetActive(true);

        Destroy(gameObject);
    }
}

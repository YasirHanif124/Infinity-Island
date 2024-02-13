using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area3Script : MonoBehaviour
{
    public static bool WinLevelTrigger = false;

    public Camera MainCamera;
    public Camera StandCamera;
    public Camera PuzzleCamera;
    public Camera BridgeCamera;
    public Camera ButtonCamera;
    public GameObject Player;
    public GameObject PuzzleSphere;
    public GameObject FinalKey;

    public ParticleSystem sparks1;
    public ParticleSystem sparks2;
    public ParticleSystem RedParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(WinLevelTrigger == true)
        {
            StartCoroutine(WinningCoroutine());
            WinLevelTrigger = false;
        }
    }

    IEnumerator WinningCoroutine()
    {
        yield return new WaitForSeconds(3);
        PuzzleCamera.gameObject.SetActive(false);
        StandCamera.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        sparks1.Stop();
        sparks2.Stop();

        yield return new WaitForSeconds(1.5f);

        RedParticle.Play();

        yield return new WaitForSeconds(3f);

        StandCamera.gameObject.SetActive(false);
        BridgeCamera.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        while(RPlatformScript.direction>0)
        {
            yield return new WaitForSeconds(0.2f);
            RPlatformScript.direction -= 0.1f;
        }

        yield return new WaitForSeconds(3f);

        while(RPlatformScript.direction>-1)
        {
            yield return new WaitForSeconds(0.2f);
            RPlatformScript.direction -= 0.1f;
        }

        yield return new WaitForSeconds(3f);

        Player.SetActive(true);
        BridgeCamera.gameObject.SetActive(false);
        ButtonCamera.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        FinalKey.SetActive(true);

        yield return new WaitForSeconds(2f);

        ButtonCamera.gameObject.SetActive(false);
        MainCamera.gameObject.SetActive(true);
        GunStandScript.isGunStand = false;

        yield return new WaitForSeconds(2f);

        Destroy(PuzzleSphere);

        GameManagerScript.Checkpoint3 = true;
    }
}

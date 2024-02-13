using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Area1Script : MonoBehaviour
{
    public static bool WinLevelTrigger = false;
    public GameObject MainCamera;
    public Camera PuzzleCamera;
    public Camera StandCamera;
    public Camera BridgeCamera;
    public GameObject Player;
    public GameObject GreenKey;
    public GameObject PuzzleSphere;
    public GameObject InvisibleWall;

    public GameObject Ramp;
    public GameObject prop;
    public GameObject prop2;

    public ParticleSystem sparks1;
    public ParticleSystem sparks2;
    public ParticleSystem blueParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(WinLevelTrigger == true)
        {
            StartCoroutine(WinCoroutine());
            WinLevelTrigger = false;
        }
    }

    IEnumerator WinCoroutine()
    {
        yield return new WaitForSeconds(3f);

        PuzzleCamera.gameObject.SetActive(false);
        StandCamera.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        sparks1.Stop();
        sparks2.Stop();

        yield return new WaitForSeconds(1.5f);

        blueParticle.Play();

        yield return new WaitForSeconds(3f);

        GreenKey.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        StandCamera.gameObject.SetActive(false);
        BridgeCamera.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        Ramp.SetActive(false);
        prop.SetActive(false);
        prop2.SetActive(false);
        InvisibleWall.SetActive(false);

        yield return new WaitForSeconds(3f);

        BridgeCamera.gameObject.SetActive(false);
        Player.SetActive(true);
        MainCamera.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        GunStandScript.isGunStand = false;

        Destroy(PuzzleSphere);

        GameManagerScript.Checkpoint1 = true;

    }
}

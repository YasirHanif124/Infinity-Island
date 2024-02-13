using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area2Script : MonoBehaviour
{
    public static bool WinLevelTrigger = false;

    public Camera MainCamera;
    public Camera StandCamera;
    public Camera PuzzleCamera;
    public Camera BridgeCamera;
    public GameObject Player;
    public GameObject PuzzleSphere;
    public GameObject RedKey;

    public GameObject BridgeStopper;
    public GameObject BridgeWall1;
    public GameObject BridgeWall2;

    public ParticleSystem sparks1;
    public ParticleSystem sparks2;
    public ParticleSystem GreenParticle;
    // Start is called before the first frame update
    void Start()
    {
        BridgeWall1.SetActive(true);
        BridgeWall2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(WinLevelTrigger == true)
        {
            StartCoroutine(WinLevelCoroutine());
            WinLevelTrigger = false;
        }
    }

    IEnumerator WinLevelCoroutine()
    {
        yield return new WaitForSeconds(3);
        PuzzleCamera.gameObject.SetActive(false);
        StandCamera.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        sparks1.Stop();
        sparks2.Stop();

        yield return new WaitForSeconds(1.5f);

        GreenParticle.Play();

        yield return new WaitForSeconds(3f);

        RedKey.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        StandCamera.gameObject.SetActive(false);
        BridgeCamera.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        BridgeStopper.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);

        BridgeWall1.SetActive(false);
        BridgeWall2.SetActive(true);
        Player.SetActive(true);
        BridgeCamera.gameObject.SetActive(false);
        MainCamera.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        GunStandScript.isGunStand = false;

        Destroy(PuzzleSphere);

        GameManagerScript.Checkpoint2 = true;
    }
}

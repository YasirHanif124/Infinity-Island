using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool isOpen;
    private bool neverOpen;
    public GameObject LockedLock;
    public GameObject UnlockedLock;
    void Start()
    {
        isOpen = false;
        neverOpen = false;
        LockedLock.SetActive(true);
        UnlockedLock.SetActive(false);
    }

    void Update()
    {
        if(isOpen == true && neverOpen == false)
        {
            StartCoroutine(OpenDoorCoroutine());
            StartCoroutine(LockCoroutine());
            neverOpen = true;
        }
    }

    IEnumerator OpenDoorCoroutine()
    {
        for(int i =0; i< 70;i++)
        {
            transform.eulerAngles -= new Vector3(0, 0, 1f);
            yield return new WaitForSeconds(0.03f);
        }
    }

    IEnumerator LockCoroutine()
    {
        LockedLock.SetActive(false);
        UnlockedLock.SetActive(true);
        yield return new WaitForSeconds(3f);
        UnlockedLock.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStandScript : MonoBehaviour
{
    public static bool isBroken;
    public static bool pressButton;
    public GameObject BrokenState;
    public GameObject FixedState;

    private bool onecheck = false;
    private bool onecheck2 = false;
    // Start is called before the first frame update
    void Start()
    {
        isBroken = true;
        pressButton = false;
        BrokenState.SetActive(true);
        FixedState.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isBroken == false && onecheck == false)
        {
            BrokenState.SetActive(false);
            FixedState.SetActive(true);
            onecheck = true;
        }

        if(isBroken == false && pressButton == true && onecheck2 == false)
        {
            DoorUnlockScript.UnlockTrigger = true;
            onecheck2 = true;
        }
    }
}

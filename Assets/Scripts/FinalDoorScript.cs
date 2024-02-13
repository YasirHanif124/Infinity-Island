using System.Collections;
using UnityEngine;

public class FinalDoorScript : MonoBehaviour
{
    public static bool triggerOpen;
    private Vector3 finalDoorPos;
    private Vector3 initialDoorPos;
    public float duration = 3f;

    // Start is called before the first frame update
    void Start()
    {
        finalDoorPos = new Vector3(137.58f, 19.45f, 50.191f);
        initialDoorPos = transform.position;
        triggerOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerOpen)
        {
            StartCoroutine(MoveDoorCoroutine());
            triggerOpen = false;
        }
    }

    IEnumerator MoveDoorCoroutine()
    {
        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime = Time.time - startTime;
            float t = elapsedTime / duration;
            transform.position = Vector3.Lerp(initialDoorPos, finalDoorPos, t);
            yield return null;
        }

        transform.position = finalDoorPos; // Ensure the door reaches the exact final position
    }
}

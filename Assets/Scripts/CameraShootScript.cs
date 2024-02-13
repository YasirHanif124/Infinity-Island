using System.Collections;
using UnityEngine;

public class CameraShootScript : MonoBehaviour
{
    public GameObject ball;
    public Camera cam;
    private float ballForce = 35f;
    private bool coolDown;
    private Vector3 Direction;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        coolDown = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && coolDown == false)
        {
            Vector3 pos = GetMouseWorldPosition();
            Direction = pos - transform.position;
            Vector3 instantiatePos = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            GameObject newBall = Instantiate(ball, instantiatePos, Quaternion.identity);
            StartCoroutine(CoolDownCoroutine());
            newBall.GetComponent<Rigidbody>().velocity = Direction.normalized * ballForce;
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        else
        {
            return ray.GetPoint(1);
        }
    }

    IEnumerator CoolDownCoroutine()
    {
        coolDown = true;
        yield return new WaitForSeconds(0.5f);
        coolDown = false;
    }
}

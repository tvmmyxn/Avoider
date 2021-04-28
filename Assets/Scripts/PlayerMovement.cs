using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    private Vector3 target;
    private float dashTime;
    private float startDashTime;


    void Start()
    {
        target = transform.position;
        dashTime = startDashTime;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(2))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
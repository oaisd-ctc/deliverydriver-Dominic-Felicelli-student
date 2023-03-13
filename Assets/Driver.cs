using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 250;
    [SerializeField] float moveSpeed = 15;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.Rotate(0, 0, steerAmount);
        }
        else
        {
            transform.Rotate(0, 0, -steerAmount);
        }
        transform.Translate(0, moveAmount, 0);
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = moveSpeed * 0.9f;
    }
    void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.tag == "Booster")
        {
            moveSpeed = moveSpeed * 1.1f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotSpeed;
    public float fuel;
    public ParticleSystem fire;
    private float rotLimit = 90f;
    private Rigidbody2D playerRB;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space)&&fuel>0f)
        {
            playerRB.AddForce(transform.up * speed * Time.deltaTime);
            fuel -= 0.1f;
            fire.Play();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            fire.Stop();
        }

        Vector3 euler = transform.eulerAngles;
        if (euler.z > 180) euler.z = euler.z - 360;
        euler.z = Mathf.Clamp(euler.z, -rotLimit, rotLimit);
        transform.eulerAngles = euler;
        Debug.Log("Velocidad: "+playerRB.velocity);
    }
}

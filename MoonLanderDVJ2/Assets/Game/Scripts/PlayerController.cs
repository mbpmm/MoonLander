using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;
    public float speed;
    public float rotSpeed;
    public float fuel;
    public ParticleSystem fire;
    public LayerMask raycastLayer;
    int rayDistance = 2;
    private float rotLimit = 90f;
    private Rigidbody2D playerRB;
    private Camera cam;
    private CameraFollow camFollow;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        cam = camera.GetComponent<Camera>();
        camFollow = camera.GetComponent<CameraFollow>();
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam.fieldOfView = 40;
        camFollow.boundX = 2f;
        camFollow.boundY = 1.1f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cam.fieldOfView = 70;
        camFollow.boundX = 4.15f;
        camFollow.boundY = 2.3f;
    }
}

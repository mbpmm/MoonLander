using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;
    public GameObject explosion;
    public float speed;
    public float rotSpeed;
    public float fuel;
    public float gravity;
    public float altitude;
    public float velHorizontal;
    public float velVertical;
    public ParticleSystem fire;
    public bool onGround;
    public bool isDestroyed;
    public bool canMove;
    private float altitudeMult=100f;
    private float playerRot;
    private float velLimit = 0.4f;
    private float rotLimit = 90f;
    private float rotLandingLimit = 2.5f;
    private Rigidbody2D playerRB;
    private Camera cam;
    private CameraFollow camFollow;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        cam = camera.GetComponent<Camera>();
        camFollow = camera.GetComponent<CameraFollow>();
        
        canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !onGround)
        {
            transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow)&&!onGround)
        {
            transform.Rotate(Vector3.back * rotSpeed * Time.deltaTime);
        }

        if (((Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.UpArrow) )&& fuel>0f) && canMove)
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
        Debug.Log(playerRB.velocity);
        velHorizontal = playerRB.velocity.x;
        velVertical = playerRB.velocity.y;
        playerRot = transform.rotation.eulerAngles.z;
        playerRB.gravityScale = gravity;
        altitude = transform.position.y * altitudeMult;
        //GetAlt(); NO FUNCIONA NO SE POR QUE
    }

    public void GetAlt()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, -1f*Vector3.up);

        if (hit.collider!=null)
        {
            altitude = hit.distance * 100f;
        }
    }
    public void Explode()
    {
        GameObject expAux;
        expAux = Instantiate(explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Level")
        {
            if (velVertical < -velLimit || velHorizontal < -velLimit || velHorizontal > velLimit || playerRot<-rotLandingLimit || playerRot > rotLandingLimit)
            {
                Explode();
                isDestroyed = true;
            }
            else
            {
                onGround = true;
                canMove = false;
            }
        }
    }
}

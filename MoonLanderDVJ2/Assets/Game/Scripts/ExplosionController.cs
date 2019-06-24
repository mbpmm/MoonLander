using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public float lifeSpan;
    public GameObject cam;
    private CameraShake camShake;
    private float timer;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        camShake = cam.GetComponent<CameraShake>();
        StartCoroutine(camShake.Shake(.3f, .2f));
    }
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer>lifeSpan)
        {
            Destroy(gameObject);
        }
    }
}

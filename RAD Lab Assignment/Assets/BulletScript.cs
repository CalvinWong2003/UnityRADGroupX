using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float bulletSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletSpeed * transform.forward * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Ouch!");
    }
}

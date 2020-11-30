using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float sphereSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * sphereSpeed * Time.deltaTime);
        if(transform.position.y<=-3.5f)
        {
            Destroy(gameObject);
        }
    }
}

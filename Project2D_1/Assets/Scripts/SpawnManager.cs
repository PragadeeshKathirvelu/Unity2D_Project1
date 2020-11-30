using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spherePrefabs;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnSpheres", 2, 1.5f);
    }

    void spawnSpheres()
    {
        int sphereIndex = Random.Range(0, spherePrefabs.Length);
        Instantiate(spherePrefabs[sphereIndex], new Vector3(Random.Range(-8f, 8f), 5f, 0f), spherePrefabs[sphereIndex].transform.rotation);
    }
}

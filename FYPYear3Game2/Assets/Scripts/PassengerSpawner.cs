using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
    public GameObject passenger;
    private float spawnRadius = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 3; i++)
        {
            Vector3 randomPos = Random.insideUnitCircle * spawnRadius;
            Instantiate(passenger, randomPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

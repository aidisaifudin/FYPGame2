using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
    public Transform passenger;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 3; i++)
        {
            var position = new Vector3(Random.Range(-100.0f, 100.0f), 0, Random.Range(-100.0f, 100.0f));
            Instantiate(passenger, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WjTaxiManager : MonoBehaviour
{
    public GameObject passenger;
    public bool passengerInTaxi;
    public GameObject destination;
    //public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        passenger = GameObject.FindGameObjectWithTag("Passenger");
        destination = GameObject.FindGameObjectWithTag("Destination");
        passengerInTaxi = false;
        //arrow.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (passengerInTaxi)
        {
            //passenger.transform.SetParent(this.transform);
            Destroy(passenger);
            Debug.Log("Gone");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Passenger")
        {
            passengerInTaxi = true;
            //arrow.SetActive(true);
        }
    }
}

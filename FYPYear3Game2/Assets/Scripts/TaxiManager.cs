using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiManager : MonoBehaviour
{

    enum TaxiState { NOTINCAR, INCAR} //states of taxi carrying passenger or not

    public bool passengerInCar;
    TaxiState state;

    public GameObject taxi;
    public GameObject passengers;

    private float workTime = 180.0f;
    // Start is called before the first frame update
    void Start()
    {
        state = TaxiState.NOTINCAR;
        passengers = GameObject.FindWithTag("Passenger");
        taxi = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case TaxiState.NOTINCAR:
                taxi.transform.Find("Passenger");
                {
                    if(taxi.transform.Find("Passenger") == null)
                    {

                    }
                    else if (taxi.transform.Find("Passenger") != null)
                    {
                        state = TaxiState.INCAR;
                    }
                }
                break;
            case TaxiState.INCAR:
                taxi.transform.Find("Passenger");
                {
                    if (taxi.transform.Find("Passenger") == null)
                    {
                        state = TaxiState.NOTINCAR;
                    }
                    else if (taxi.transform.Find("Passenger") != null)
                    {

                    }
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Passenger" && state == TaxiState.NOTINCAR)
        {
            passengers.transform.SetParent(this.transform);
        }
    }
}

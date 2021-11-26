using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaxiManager : MonoBehaviour
{


    public Transform passenger;

    public GameObject destination;
    public bool destinationReached;

    public float pickUpRange;

    public static bool passengerOnBoard;
    public static bool passengerInTaxi;

    public Button pickUpButton;
    public Button dropOffButton;

    public float timer;
    private float endDay = 30.0f;

    public GameObject summary;
    void Start()
    {
        pickUpButton.gameObject.SetActive(false);
        dropOffButton.gameObject.SetActive(false);

        destination = GameObject.FindGameObjectWithTag("Destination");

        passengerOnBoard = false;
        passengerInTaxi = false;
        summary.SetActive(false);
    }
    private void Update()
    {
        //check player in range, no passenger in taxi
        Vector3 distanceToPassenger = passenger.position - transform.position;
        if (!passengerOnBoard && distanceToPassenger.magnitude <= pickUpRange && !passengerInTaxi)
        {
            pickUpButton.gameObject.SetActive(true);
        }

        if (passengerOnBoard && destinationReached == true)
        {
            dropOffButton.gameObject.SetActive(true);
        }

        //timer += Time.deltaTime;

        //if(timer == endDay)
        //{
        //    summary.SetActive(true);
        //    Time.timeScale = 0;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destination")
        {
            destinationReached = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Destination")
        {
            destinationReached = false;
            StartCoroutine(EndDay());
        }
    }

    IEnumerator EndDay()
    {
        yield return new WaitForSeconds(5);
        summary.SetActive(true);
        Time.timeScale = 0;
    }
}
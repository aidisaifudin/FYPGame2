using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassengerManager : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player;
    public Transform passengerHolder;
    public Transform camera;

    public GameObject destination;
    public bool destinationReached;

    public float pickUpRange;

    public bool passengerOnBoard;
    public static bool passengerInTaxi;

    public Button pickUpButton;
    public Button dropOffButton;
    void Start()
    {
        pickUpButton.gameObject.SetActive(false);
        dropOffButton.gameObject.SetActive(false);

        destination = GameObject.FindGameObjectWithTag("Destination");

        if (!passengerOnBoard)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (passengerOnBoard)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
        }
    }
    private void Update()
    {
        //check player in range, no passenger in taxi
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!passengerOnBoard && distanceToPlayer.magnitude <= pickUpRange && !passengerInTaxi)
        {
            pickUpButton.gameObject.SetActive(true);
        }
        else
        {
            pickUpButton.gameObject.SetActive(false);
        }

        if (Input.GetButtonDown("PickUp"))
        {
            PickUp();
        }

        if (passengerOnBoard && destinationReached == true)
        {
            dropOffButton.gameObject.SetActive(true);
        }
        else
        {
            dropOffButton.gameObject.SetActive(false);
        }
    }

    private void PickUp()
    {
        passengerOnBoard = true;
        passengerInTaxi = true;

        //make passenger a child of the taxi and hide it
        transform.SetParent(player);
        this.gameObject.SetActive(false);

        //make rigidbody kinematic and boxcollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;
    }

    private void DropOff()
    {
        passengerOnBoard = false;
        passengerInTaxi = false;

        //set parent to null
        transform.SetParent(null);
        this.gameObject.SetActive(true);

        //make rigidbody not kinematic and boxcollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destination")
        {
            destinationReached = true;
        }
    }
}

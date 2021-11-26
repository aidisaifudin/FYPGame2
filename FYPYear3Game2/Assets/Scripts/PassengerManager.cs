using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassengerManager : MonoBehaviour
{

    public Transform player;
    public Button pickUpButton;
    public Button dropOffButton;

    public GameObject summary;

    public TaxiManager passengerOnBoard;
    void Start()
    {
        passengerOnBoard = player.GetComponent<TaxiManager>();
        pickUpButton.gameObject.SetActive(false);
        dropOffButton.gameObject.SetActive(false);


    }

    private void Update()
    {
       
        //if (Input.GetButtonDown("Pick Up Button"))
        //{
        //    PickUp();
        //}

        //if (Input.GetButtonDown("Drop Off Button"))
        //{
        //    DropOff();
        //}
    }


    public void PickUp()
    {

        TaxiManager.passengerOnBoard = true;

        //make passenger a child of the taxi and hide it
        transform.SetParent(player);
        this.gameObject.SetActive(false);

        //make rigidbody kinematic and boxcollider a trigger
 
        pickUpButton.gameObject.SetActive(false);
    }


    public void DropOff()
    {

        TaxiManager.passengerOnBoard = false;

        //set parent to null
        transform.SetParent(null);
        this.gameObject.SetActive(true);

        //make rigidbody not kinematic and boxcollider normal

        dropOffButton.gameObject.SetActive(false);
        StartCoroutine(PassengerReached());
        Destroy(this.gameObject.transform);

        Earning.instance.EarnMoney();
    }
        IEnumerator PassengerReached()
        {
          
            yield return new WaitForSeconds(2);
            Destroy(this.gameObject);
        }
    }
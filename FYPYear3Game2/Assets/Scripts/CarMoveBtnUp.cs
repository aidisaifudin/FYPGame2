using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CarMoveBtnUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float forceMult = 5;
    private Rigidbody rb;

    bool ispressed = false;
    public GameObject player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ispressed)
        {
            rb.AddForce(transform.forward * forceMult);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public float scaleSpeed = 5f;
    public GameObject movePlatForm;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){

            anim.SetBool("Up", true);
            Debug.Log("Play");

            

            Time.timeScale = 0;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            anim.SetBool("Up", false);
            Debug.Log("Play");

        }
    }
}

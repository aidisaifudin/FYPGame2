using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElevatorScript : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public float scaleSpeed = 5f;
    public GameObject movePlatForm;
    public GameObject losePanel;
    public bool hitCar = false;
    void Start()
    {
        hitCar = false;
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

            hitCar = true;
            StartCoroutine(ShowPanel());

        }
        else
        {
            hitCar = false;
            losePanel.SetActive(false);

        }
    }
    IEnumerator ShowPanel()
    {
        yield return new WaitForSeconds(2);
        losePanel.SetActive(true);
        //yield return new WaitForSeconds(2);
        //losePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }
    /* private void OnTriggerExit(Collider other)
     {
         if (other.tag == "Player")
         {

             anim.SetBool("Up", false);
             Debug.Log("Play");

         }
     }*/
}

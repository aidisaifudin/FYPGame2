using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JayWalkerCollider : MonoBehaviour
{
    public GameObject losePanel;
    public bool hitCar = false;


    // Start is called before the first frame update
    void Start()
    {
        hitCar = false;
        
    }


    private void OnTriggerEnter(Collider jaywalker)
    {
        if(jaywalker.gameObject.tag == "Player")
        {
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
        yield return new WaitForSeconds(2);
        losePanel.SetActive(false);
        
    }
}

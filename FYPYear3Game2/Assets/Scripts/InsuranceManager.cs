using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsuranceManager : MonoBehaviour
{
    public GameObject insurancePic;
    public GameObject insurancePanel;
    


    void Awake()
    {
        insurancePanel.gameObject.SetActive(true);
        insurancePic.gameObject.SetActive(false);

    }

    public void PressYes()
    {
        Debug.Log("yes Pressed");
        insurancePic.gameObject.SetActive(true);
        insurancePanel.gameObject.SetActive(false);
    }

    public void PressNo()
    {
        insurancePic.gameObject.SetActive(false);
        insurancePanel.gameObject.SetActive(false);

    }
}

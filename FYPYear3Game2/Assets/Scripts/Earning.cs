using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earning : MonoBehaviour
{
    public Text earningText;
    public Text endOfDayText;

    int earnings = 0;

    public static Earning instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        earningText.text = " Earnings: " + earnings.ToString();
        endOfDayText.text = " Earnings for today: " + earnings.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EarnMoney()
    {
        earnings += 300;
        earningText.text = " Earnings: " + earnings.ToString();
        endOfDayText.text = " Earnings for today: " + earnings.ToString();
    }
}

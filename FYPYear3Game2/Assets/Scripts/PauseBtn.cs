using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseBtn : MonoBehaviour
{
    public void PauseButton()
    {
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
    }
}

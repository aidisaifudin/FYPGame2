using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    public Text text;
    public float fadeSpeed = 5.0f;
    public bool entrance;
    public GameObject canvas;
    public GameObject screenSpace;

    void Awake()
    {
        text = canvas.GetComponentInChildren<Text>();
        text.color = Color.clear;
    }

    void Update()
    {
        ColorChange();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            entrance = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            entrance = false;
            canvas.SetActive(true);
        }
    }

    void ColorChange()
    {
        if (entrance)
        {
            text.color = Color.Lerp(text.color, Color.white, fadeSpeed * Time.deltaTime);
        }

        if (!entrance)
        {
            text.color = Color.Lerp(text.color, Color.clear, fadeSpeed * Time.deltaTime);
        }
    }
}


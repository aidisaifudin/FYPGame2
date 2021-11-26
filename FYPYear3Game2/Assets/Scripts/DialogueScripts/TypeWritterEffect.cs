using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWritterEffect : MonoBehaviour
{
    [SerializeField]private float typewritterSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Coroutine Run(string textToType,TMP_Text textLabel)
    {

       return StartCoroutine(routine:TypeText(textToType,textLabel));
    }
    private IEnumerator TypeText(string textToType,TMP_Text textLabel) 
    {
        textLabel.text = string.Empty;
      
        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime*typewritterSpeed;
            charIndex = Mathf.FloorToInt(t);

            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            textLabel.text = textToType.Substring(charIndex);
            yield return null;
        }
        textLabel.text = textToType;
    }
}
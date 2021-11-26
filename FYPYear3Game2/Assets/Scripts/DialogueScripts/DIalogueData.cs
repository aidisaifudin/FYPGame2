using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DIalogueData : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;
    private TypeWritterEffect typeWritterEffect;
    private ResponseHandler responseHandler;

    private void Start()
    {
        typeWritterEffect = GetComponent<TypeWritterEffect>();
        CloseDialogue();
        ShowDialogue(testDialogue);
    }
    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThourghDialogue(dialogueObject));
    }
    public IEnumerator StepThourghDialogue(DialogueObject dialogueObject)
    {
        
 
        for(int i=0; i< dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typeWritterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponse(dialogueObject.Responses);
        }
        CloseDialogue();
    }
    private void CloseDialogue()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}

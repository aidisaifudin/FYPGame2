
using UnityEngine;

[System.Serializable]
public class Response 
{

    [SerializeField] private string responseText;
    [SerializeField] private DialogueObject dialogueObject;

    public string ResponseText => responseText;
    public DialogueObject DialogueObject => dialogueObject;
    // Start is called before the first frame update

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResponseHandler : MonoBehaviour
{

    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    private DIalogueData dialogueUI;
    public GameObject sheild;

    List<GameObject> tempResponseButton = new List<GameObject>();
    // Start is called before the first frame update
    private void Start()
    {
        dialogueUI = GetComponent<DIalogueData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowResponse(Response[] responses)
    {
        float responseBoxHeight = 0;

        foreach(Response response in responses)
        {
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(call:() => OnPickResponse(response));
            tempResponseButton.Add(responseButton);
            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }
    private void OnPickResponse(Response response) 
    {

        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButton)
        {
            Destroy(button);
        }
        tempResponseButton.Clear();
        dialogueUI.ShowDialogue(response.DialogueObject);

    
    
    
    }
    public void Test()
    {
        sheild.SetActive(true);
        Debug.Log("Hello");
    }
    public void No()
    {
        Debug.Log("No");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour,IReceiveMessage
{
    Text uiText;
    // Start is called before the first frame update
    void Start()
    {
       uiText = GetComponent<Text>();
       uiText.text = ""; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnReceive(string showText){
        uiText.text=showText;
        Debug.Log("Occur");
    }
}

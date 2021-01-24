using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textinput : MonoBehaviour
{
    public string[] data = new string[5];
    public InputField inputword;
    private string myData;
    public Text showText;
    private void Start()
    {
       data[0] = "Wood";
       data[1] = "Fly";
       data[2] = "Over";
       data[3] = "Try";
       data[4] = "Hello";

    }
    void Update()
    {
        myData = inputword.text;
      
    }
    public void ButtonFind()
    {
        if(data[0] == myData)
        {
            isfound();
        }
        else if(data[1]== myData)
        {
            isfound();
        }
        else if(data[2] == myData)
        {
            isfound();
        }
        else if (data[3] == myData)
        {
            isfound();
        }
        else if (data[4] == myData)
        {
            isfound();
        }
        else
        {
            showText.text = " [ " + $"<color=red>{myData}</color>" + " ] " + " is not found. ";
        }


    }   
    
    void isfound()
    {
        showText.text = " [ " + $"<color=green>{myData}</color>" + " ] " + " is found. ";
    }   
   





}

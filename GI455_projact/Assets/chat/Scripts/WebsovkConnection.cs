using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;


public class WebsovkConnection : MonoBehaviour
{
    private WebSocket websocket;
    public InputField inputField;
    public Text textshow;
    public Text textshow2;
    string inputText;
    string inputTextdata;
    bool  check = false;

    void Start()
    {
        
        websocket = new WebSocket("ws://127.0.0.1:51000/");
        websocket.OnMessage += OnMassage;
        websocket.Connect();

    }    
    void Update()
    {
    //sendmassageEnter
        if (Input.GetKeyDown(KeyCode.Return))
        {
             send();
        }
    }
    private void OnDestroy()
    {
        if(websocket != null)
        {
           
          websocket.Close();

        }
    }
    public void OnMassage(object sender,MessageEventArgs messageEventArgs)
    {
        //getData
        inputTextdata = messageEventArgs.Data;  
      
        if ( check == true)
        {
            
            textshow2.text += "\n";
            
             check = false;
            
        }
        else if ( check == false)
        {
              textshow2.text += "\n" + inputTextdata; textshow.text += "\n";
                    
        }

    }
    public void Buttonsend()
    {
    //sendmassageButton
       send();
    }
    public void Exit()
     {
         //Exit
        Application.Quit();

     }
     void send()
     {
          if (websocket.ReadyState == WebSocketState.Open)
            {
               //EmptyCheck
              if(inputField.text !="")
               {
                 websocket.Send(inputField.text);
                 textshow.text += "\n" + inputField.text;
                 inputField.text ="";
                 check = true;
               }
               else if(inputField.text =="")
               {
                  inputField.text ="";
               }           
            }
     }
   
}

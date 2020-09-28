using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button ShowMessage;
    public Button ShowDialog;
    Sample sample = new Sample();
    // Start is called before the first frame update
    void Start()
    {
        ShowMessage.onClick.AddListener( ()=>
        { 
            sample.PluginCallShowMessage("title", "message", "OK", () =>
            {
                Debug.Log("ok button clicked");
            });
        });
        
        ShowDialog.onClick.AddListener( ()=>
        { 
            sample.PluginCallShowDialog("title", "message", "Yes", "No");
        });   
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using AOT;

public class Sample
{
    [DllImport("__Internal")]
    private static extern void ShowMessage (string title, string message, string btn, Callback method);
    [DllImport("__Internal")]
    private static extern void ShowDialog (string title, string message, string yesBtn, string noBtn, Callback method1, Callback method2);
    public delegate void Callback ();

    private static Action okBtnEvent;
    
    [AOT.MonoPInvokeCallbackAttribute(typeof(Callback))]
    static void OKButtonCallback () {
        okBtnEvent?.Invoke();
    }
    
    public void PluginCallShowMessage(string title, string message, string okBtn, Action action)
    {
        okBtnEvent = null;
        okBtnEvent += action;
        ShowMessage(title, message ,okBtn, OKButtonCallback);
    }
    
    [AOT.MonoPInvokeCallbackAttribute(typeof(Callback))] 
    static void YesButtonCallback () {
        Debug.Log("yes button clicked");
    }

    [AOT.MonoPInvokeCallbackAttribute(typeof(Callback))] 
    static void NoButtonCallback () {
        Debug.Log("no button clicked");
    }
    
    public void PluginCallShowDialog(string title, string message, string yesBtn, string noBtn) {
        ShowDialog(title, message, yesBtn, noBtn, YesButtonCallback, NoButtonCallback);
    }

}

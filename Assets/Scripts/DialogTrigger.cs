using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public string text;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // show text    
        Dialog.instance.ShowText(text);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        // hide text
        Dialog.instance.HideText();
    }
}

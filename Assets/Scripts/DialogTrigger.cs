using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public string text;
    public float autoHideDelay = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var father = collision.GetComponent<FatherController>();
        if (father == null || !father.IsHidden)
        {
            // show text    
        	Dialog.instance.ShowText(text, autoHideDelay);

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        // hide text
        Dialog.instance.HideText();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivationZone : MonoBehaviour
{
    public int key = 0;
    public UnityEvent onTriggered;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (key == -1 || key == GameController.instance.currentKey)
        {
            GameController.instance.RemoveCurrentKey();
            onTriggered?.Invoke();
        }
    }
}

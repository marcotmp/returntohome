using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivationZone : MonoBehaviour
{
    public int key = 0;
    public GameController controller;
    public UnityEvent onTriggered;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (key == controller.currentKey)
        {
            onTriggered?.Invoke();
        }
    }
}

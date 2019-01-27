using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int keyType;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.instance.currentKey = keyType;
        Destroy(gameObject);
    }
}

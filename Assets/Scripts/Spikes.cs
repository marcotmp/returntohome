using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private bool hasPlayer = false;
    public float damage = 5f;

    // Update is called once per frame
    void Update()
    {
        if (hasPlayer) GameController.instance.DecreaseEnergy(damage);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        hasPlayer = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        hasPlayer = false;
    }

}

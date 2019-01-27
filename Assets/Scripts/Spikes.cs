using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private bool hasPlayer = false;

    // Update is called once per frame
    void Update()
    {
        if (hasPlayer) GameController.instance.DecreaseEnergy(5);
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

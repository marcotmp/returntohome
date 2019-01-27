using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFlip : MonoBehaviour
{
    public float timeBetweenFlip;
    private float LastFlip;

    // Start is called before the first frame update
    void Start()
    {
        LastFlip = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > LastFlip + timeBetweenFlip)
        {
            Flip();
            LastFlip = Time.time;
        }
    }

    private void Flip()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }
}

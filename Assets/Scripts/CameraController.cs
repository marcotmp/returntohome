using System;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float transitionSpeed;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float deltaTime;

    private float t=1;
    
	// Update is called once per frame
	void Update () {

        if (t <= 1)
        {
            t += Time.deltaTime * transitionSpeed;
            var targetPosition = Vector3.Lerp(startPosition, endPosition, t);

            transform.position = targetPosition;
        }
        else
        {
            transform.position = target.transform.position + offset;
        }
    }

    public void SetTarget(CharacterController target)
    {
        this.target = target.transform;

        startPosition = transform.position;
        endPosition = target.transform.position + offset;
        t = 0;
    }
}

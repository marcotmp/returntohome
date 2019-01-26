using System;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float transitionSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var targetPosition = target.position + offset;

        //targetPosition.z = Mathf.Lerp(transform.position.z, targetPosition.z, Time.deltaTime * transitionSpeed);

        targetPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * transitionSpeed);

		transform.position = targetPosition;
	}

    public void SetTarget(CharacterController target)
    {
        this.target = target.transform;
    }
}

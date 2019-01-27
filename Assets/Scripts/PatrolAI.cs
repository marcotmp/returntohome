using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    private float LeftOffset;
    private float RightOffset;

    private Vector3 MoveToPosition;

    public float speed;
    public float timeBetweenFlip;

    private float stoppedTime;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        LeftOffset = transform.Find("LeftOffset").transform.position.x;
        RightOffset = transform.Find("RightOffset").transform.position.x;
        MoveToPosition = transform.position;
        MoveToPosition.x = RightOffset;
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, MoveToPosition, speed * Time.deltaTime);
            if (transform.position == MoveToPosition)
            {
                isMoving = false;
                stoppedTime = Time.time;
            }
        }
        else if (Time.time > stoppedTime + timeBetweenFlip)
        {
            Flip();
            isMoving = true;
            MoveToPosition.x = transform.position.x == LeftOffset ? RightOffset : LeftOffset;
        }
    }

    private void Flip()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(new Vector3(LeftOffset, transform.position.y), new Vector3(RightOffset, transform.position.y));
    }
}

using UnityEngine;

public class FatherController : MonoBehaviour
{
    private Ladder ladderEntrance;

    private bool IsTraveling;
    private BoxCollider2D box;
    private Vector2 InitialBoxSize;
    private Vector2 InitialBoxOffset;
    private Transform Locker;
    private CharacterController character;
    private bool crouched = false;
    public bool IsHidden = false;

    private void Start()
    {
        character = gameObject.GetComponent<CharacterController>();
        box = gameObject.GetComponent<BoxCollider2D>();
        InitialBoxOffset = box.offset;
        InitialBoxSize = box.size;
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        if (vertical > 0 && ladderEntrance != null && !IsTraveling)
        {
            transform.position = ladderEntrance.Exit.position;
            IsTraveling = true;
        }
        else if (vertical == 0)
        {
            IsTraveling = false;
        }

        var crouch = Input.GetButtonDown("Jump");
        if (crouch)
        {
            crouched = !crouched;
        }

        if (crouched)
        {
            box.size = new Vector2(InitialBoxSize.x, InitialBoxSize.y / 2);
            box.offset = new Vector2(InitialBoxOffset.x, InitialBoxOffset.y - box.size.y / 2);
        }
        else
        {
            box.size = InitialBoxSize;
            box.offset = InitialBoxOffset;
        }
        if (Locker != null && vertical > 0)
        {
            IsHidden = true;
            Locker.GetComponent<SpriteRenderer>().sortingOrder = 2;
            character.canMove = false;
        }
        else if (Locker != null && vertical < 0)
        {
            IsHidden = false;
            Locker.GetComponent<SpriteRenderer>().sortingOrder = -1;
            character.canMove = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            ladderEntrance = null;
        }
        if(collision.tag == "Locker")
        {
            Locker = null;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        ladderEntrance = collision.transform.GetComponent<Ladder>();
        if(collision.tag == "Locker")
        {
            Locker = collision.transform;
        }
    }
}

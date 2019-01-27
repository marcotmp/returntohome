using UnityEngine;

public class FatherController : MonoBehaviour
{
    private Ladder ladderEntrance;

    private bool IsTraveling;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Vertical") > 0 && ladderEntrance != null && !IsTraveling)
        {
            transform.position = ladderEntrance.Exit.position;
            IsTraveling = true;
        }
        else if(Input.GetAxis("Vertical") == 0)
        {
            IsTraveling = false;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            ladderEntrance = null;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        ladderEntrance = collision.transform.GetComponent<Ladder>();
    }
}

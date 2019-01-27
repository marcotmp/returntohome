using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public static Dialog instance;
    public string myText;// { get; private set; }
    public Text dialogText;
    public float letterDelay = 0.1f;
    public Animator animator;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartText();
    }


    public void ShowText(string text, float delay = 0)
    {
        myText = text;
        gameObject.SetActive(true);
        StartCoroutine(TextAnimation(text, delay));

        animator.Play("DialogOpen");
    }

    public void HideText()
    {
        animator.Play("DialogClose");
//        gameObject.SetActive(false);
    }
    
    private IEnumerator TextAnimation(string text, float delay)
    {
        int i = 0;

        myText = text;

        while (i <= text.Length)
        {
            dialogText.text = text.Substring(0, i);
            i++;
            yield return new WaitForSeconds(letterDelay);
        }

        if (delay != 0)
        {
            yield return new WaitForSeconds(delay);
            HideText();
        }
    }
}

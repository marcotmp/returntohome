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

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartText();
    }


    public void ShowText(string text)
    {
        myText = text;
        gameObject.SetActive(true);
        StartCoroutine(TextAnimation(text));
    }

    public void HideText()
    {
        gameObject.SetActive(false);
    }
    
    private IEnumerator TextAnimation(string text)
    {
        int i = 0;

        myText = text;

        while (i <= text.Length)
        {
            dialogText.text = text.Substring(0, i);
            i++;
            yield return new WaitForSeconds(letterDelay);
        }

        //yield return new WaitForSeconds(1);

        //var color = dialogText.color;
        //while (color.a > 0)
        //{
        //    color.a -= 1f * Time.deltaTime;
        //    dialogText.color = color;
        //    yield return new WaitForSeconds(letterDelay);
        //}
    }
}

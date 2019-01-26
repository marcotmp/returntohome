using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public string myText;
    public Text dialogText;
    public float letterDelay = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        StartText();
    }
    
    public void StartText()
    {
        StartCoroutine(TextAnimation());
    }

    private IEnumerator TextAnimation()
    {
        int i = 0;

        while (i <= myText.Length)
        {
            dialogText.text = myText.Substring(0, i);
            i++;
            yield return new WaitForSeconds(letterDelay);
        }

        yield return new WaitForSeconds(1);

        var color = dialogText.color;
        while (color.a > 0)
        {
            color.a -= 1f * Time.deltaTime;
            dialogText.color = color;
            yield return new WaitForSeconds(letterDelay);
        }
    }
}

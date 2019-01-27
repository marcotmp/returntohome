using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public CameraController camera;
    public CharacterController father;
    public CharacterController mother;
    public Image hudCurrentKey;

    public int currentKey { get; private set; } = 0;


    private void Awake()
    {
        instance = this;
    }


    // Use this for initialization
    void Start () {
        mother.Activate(false);
        father.Activate(true);
    }

    // Update is called once per frame
    void Update () {
        // press tab to change characters
        var tab = Input.GetKeyDown(KeyCode.Tab);

        if (tab)
            ToggleCharacter();
    }

    public void SetKey(int key)
    {
        currentKey = key;

        Color color;

        if (key == 1)
            ColorUtility.TryParseHtmlString("#FFDB00", out color);
        else
            ColorUtility.TryParseHtmlString("#E25775", out color);

        hudCurrentKey.gameObject.SetActive(true);
        hudCurrentKey.color = color;
    }

    internal void RemoveCurrentKey()
    {
        hudCurrentKey.gameObject.SetActive(false);
    }

    public void CompleteHerStory()
    {
        // set her story complete
        // go back father story.
        mother.Activate(false);
        father.Activate(true);
        camera.SetTarget(father);
    }

    public void ToggleCharacter()
    {
        if (father.IsActive())
        {
            mother.Activate(true);
            father.Activate(false);
            camera.SetTarget(mother);
        }
        else
        {
            mother.Activate(false);
            father.Activate(true);
            camera.SetTarget(father);
        }
    }

}
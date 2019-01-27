using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public CameraController camera;
    public CharacterController father;
    public CharacterController mother;
    public Image hudCurrentKey;
    public Image energyVeil;

    public int currentKey { get; private set; } = 0;
    public float maxEnergy = 100;

    public float energy;

    public Dialog dialog;

    [SerializeField] private GameObject gameOverPanel;

    private bool isDecreasing = false;
    private bool isHerStoryComplete = false;
    private bool isHisStoryComplete = false;

    private void Awake()
    {
        instance = this;
        energy = maxEnergy;
    }

    // Use this for initialization
    void Start()
    {
        dialog.ShowText("Start");
        dialog.HideText();

        mother.Activate(false);
        father.Activate(true);
    }

    public void DecreaseEnergy(float decreaseEnergySpeed)
    {
        Color color = energyVeil.color;

        if (energy > 0)
            energy -= Time.deltaTime * decreaseEnergySpeed;

        color.a = 1 - energy / (float)maxEnergy;

        energyVeil.color = color;

        isDecreasing = true;

        if (energy <= 0)
        {
            GameOver();
        }
    }

    public void IncreaseEnergy(float increaseEnergySpeed)
    {
        Color color = energyVeil.color;

        if (energy < maxEnergy)
            energy += Time.deltaTime * increaseEnergySpeed;

        color.a = 1 - energy / (float)maxEnergy;

        energyVeil.color = color;
    }




    // Update is called once per frame
    void Update() {
        // press tab to change characters
        var tab = Input.GetKeyDown(KeyCode.Tab);

        if (tab)
            ToggleCharacter();

        if (!isDecreasing) IncreaseEnergy(5);
        isDecreasing = false;
    }

    public void SetKey(int key)
    {
        currentKey = key;

        Color color;

        if (key == 1)
            ColorUtility.TryParseHtmlString("#FFDB00", out color);
        else if (key == 2)
            ColorUtility.TryParseHtmlString("#5770E2", out color);
        else if (key == 4)
            ColorUtility.TryParseHtmlString("#3EFF00", out color);
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
        if (!isHisStoryComplete)
        {
            // set her story complete
            // go back father story.
            mother.Activate(false);
            father.Activate(true);
            camera.SetTarget(father);
        }

        isHerStoryComplete = true;

        CheckComplete();
    }

    public void CompleteHisStory()
    {
        if (!isHerStoryComplete)
        {
            // set her story complete
            // go back father story.
            mother.Activate(true);
            father.Activate(false);
            camera.SetTarget(mother);
        }

        isHisStoryComplete = true;

        CheckComplete();
    }

    public void CheckComplete()
    {
        if (isHisStoryComplete && isHerStoryComplete)
        {
            dialog.ShowText("Finally Home Together");
            // final screen
        }
    }

    public void ToggleCharacter()
    {
        if (father.IsActive() && !isHerStoryComplete)
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().path, LoadSceneMode.Single);
    }

    private void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
    }

}
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public CameraController camera;
    public CharacterController father;
    public CharacterController mother;
    public int currentKey = 0;


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
}

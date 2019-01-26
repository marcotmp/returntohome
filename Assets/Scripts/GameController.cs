using UnityEngine;

public class GameController : MonoBehaviour {

    public CameraController camera;
    public CharacterController father;
    public CharacterController mother;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // press tab to change characters
        var tab = Input.GetKeyDown(KeyCode.Tab);

        if (tab)
        {
            if (father.IsActive())
            {
                mother.Activate();
                camera.SetTarget(mother);
            }
            else
            {
                father.Activate();
                camera.SetTarget(mother);
            }

        }
    }
}

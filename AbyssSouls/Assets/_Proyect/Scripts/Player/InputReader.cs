using UnityEngine;

public class InputReader : MonoBehaviour
{

    public PlayerControls Controls { get; private set; }


    void Awake()
    {
        Controls = new PlayerControls();
    }

    void OnEnable()
    {
        Controls.Enable();
    }

    void OnDisable()
    {
        Controls.Disable();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    private GameObject menu;

    private ControlKey input;
    private bool paused = false;

    private bool actuated = false;
    private bool toggle = true;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<ControlKey>();
        menu = transform.GetChild(0).gameObject;
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool p = Keyboard.current["escape"].IsPressed();
        if (Gamepad.current != null)
            p |= Gamepad.current["select"].IsPressed();

        if(p && toggle)
        {
            actuated = true;
            toggle = false;
        }else if(!p && !toggle)
        {
            toggle = true;
        }

        if (actuated)
        {
            actuated = false;
            print("pause pressed");
            if (paused)
            {
                Time.timeScale = 1;
                menu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                menu.SetActive(true);
            }
            paused = !paused;
        }
    }
}

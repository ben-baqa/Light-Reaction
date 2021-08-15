using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int dominosDown;

    public Text dominoCount;
    public GameObject winEffect;

    private bool allDominoesDown;

    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        allDominoesDown = DominoInstance.allDown;
        if(allDominoesDown && !triggered)
        {
            triggered = true;
            // Add all effects for win here
            dominoCount.text = "All Dominos Down";
        }

        if (!triggered)
        {
            DominoInstance[] dominos = FindObjectsOfType<DominoInstance>();
            int n = dominos.Length;
            foreach (DominoInstance d in dominos)
                if (d.down)
                    n--;

            dominoCount.text = "Dominos Remaining: " + n;
            dominosDown = dominos.Length - n;
        }
    }
}

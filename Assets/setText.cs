using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setText : MonoBehaviour
{
    public Text txt;
    public GameObject gameOfLife;
    GameOfLife gameOfLifeScript;

    // Start is called before the first frame update
    void Start()
    {
        gameOfLifeScript = gameOfLife.GetComponent<GameOfLife>();
    }

    // Update is called once per frame
    void Update()
    {
        int a = gameOfLifeScript.minSurvivalNeighbourCount;
        int b = gameOfLifeScript.maxSurvivalNeighbourCount;
        int c = gameOfLifeScript.minBirthNeighbourCount;
        int d = gameOfLifeScript.maxBirthNeighbourCount;
        if (a < 10 && b < 10 && c < 10 && d < 10)
        {
            txt.text = string.Format("Rule: {0}{1}{2}{3}\nInitial Density: {4}\nGeneration: {5}", a, b, c, d, gameOfLifeScript.initialDensity, gameOfLifeScript.generation);
        }
        else
        {
            txt.text = string.Format("Rule: {0} {1} {2} {3}\nInitial Density: {4}\nGeneration: {5}", a, b, c, d, gameOfLifeScript.initialDensity, gameOfLifeScript.generation);
        }
    }
}

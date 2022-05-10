using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCompleted : MonoBehaviour
{
    public static int enemyCount;
    public static int treasureCount;
    public GameObject enemyDisplay;
    public GameObject treasureDisplay;
    public static int nextFloor = 4;

    // Update is called once per frame
    void Update()
    {
        enemyDisplay.GetComponent<Text>().text = "" + enemyCount;
        treasureDisplay.GetComponent<Text>().text = "" + treasureCount;
    }
}

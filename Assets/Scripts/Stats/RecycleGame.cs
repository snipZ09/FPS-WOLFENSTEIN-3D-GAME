using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecycleGame : MonoBehaviour
{
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        GlobalLife.lifeValue -= 3;
        if(GlobalLife.lifeValue == 0)
        {
            gameOver.SetActive(true);
        }
        else
        {
            if(GlobalCompleted.nextFloor == 4)
            {
                SceneManager.LoadScene("Level001");
            }
            else
            {
                SceneManager.LoadScene(GlobalCompleted.nextFloor);
            } 
        }
    }
}

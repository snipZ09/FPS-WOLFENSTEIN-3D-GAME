using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class FloorComplete : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject completePanel;
    public GameObject thePlayer;
    public GameObject floorTimer;
    //public string nextScene;

    void OnTriggerEnter(Collider other)
    {
        floorTimer.SetActive(false);
        StartCoroutine(CompletedFloor());
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    IEnumerator CompletedFloor()
    {
        fadeOut.SetActive(true);
        PlayerPrefs.SetInt("SceneToLoad", GlobalCompleted.nextFloor);
        PlayerPrefs.SetInt("LivesSaved", GlobalLife.lifeValue);
        PlayerPrefs.SetInt("ScoreSaved", GlobalScore.scoreValue);
        PlayerPrefs.SetInt("AmmoSaved", GlobaAmmo.handgunAmmo);
        yield return new WaitForSeconds(2);
        completePanel.SetActive(true);
        yield return new WaitForSeconds(5);
        GlobalScore.scoreValue = 0;
        GlobalCompleted.enemyCount = 0;
        GlobalCompleted.treasureCount = 0;
        GlobalCompleted.nextFloor += 1;
        SceneManager.LoadScene(GlobalCompleted.nextFloor);
    }
}


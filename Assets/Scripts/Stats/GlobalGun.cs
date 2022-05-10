using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGun : MonoBehaviour
{
    public static GlobalGun instance;
    public List<GameObject> availableGuns = new List<GameObject>();
    [HideInInspector]
    public int currentGun;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetMouseButton(2))
        {
            if (availableGuns.Count > 0)
            {
                currentGun++;
                if (currentGun >= availableGuns.Count)
                {
                    currentGun = 0;
                }
                SwitchGun();
            }
            else
            {
                Debug.LogError("Player has no guns!");
            }
        }
    }

    public void SwitchGun()
    {
        foreach (GameObject theGun in availableGuns)
        {
            theGun.gameObject.SetActive(false);
            theGun.GetComponent<M4A1Fire>().gunImage.SetActive(false);
        }
        availableGuns[currentGun].gameObject.SetActive(true);
        availableGuns[currentGun].GetComponent<M4A1Fire>().gunImage.SetActive(true);
    }
}

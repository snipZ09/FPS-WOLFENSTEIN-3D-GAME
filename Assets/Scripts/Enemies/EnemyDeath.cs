using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int enemyHeath = 20;
    public bool enemyDead = false;
    public GameObject enemyAI;
    public GameObject theEnemy;

    void DamageEnemy (int damageAmount)
    {
        enemyHeath -= damageAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHeath <= 0 && enemyDead == false)
        {
            enemyDead = true;
            theEnemy.GetComponent<Animator>().Play("Death");
            enemyAI.SetActive(false);
            theEnemy.GetComponent<LookPlayer>().enabled = false;
            this.GetComponent<BoxCollider>().isTrigger = true;
            GlobalScore.scoreValue += 100;
            GlobalCompleted.enemyCount += 1;
        }
    }
}

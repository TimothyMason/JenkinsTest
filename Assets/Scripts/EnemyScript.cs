using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemy;

    // Testing the public
    public int enemyCount = 1;

    public int enemyHealth = 100;

    void Start()
    {
        //Debug.Log("Oi! Fite me m8!");
    }

    void Update()
    {
        ManageEnemyHealth();
        HandleEnemyDeath();
    }

    void ManageEnemyHealth()
    {
        if (enemyHealth <= 0)
        {
            Destroy(enemy);
            enemyCount = enemyCount - 1;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BulletTag")
        {
            enemyHealth = enemyHealth - 10;
        }

        if (col.gameObject.tag == "DeathFromFalling")
        {
            enemyHealth = 0;
        }
    }

    void HandleEnemyDeath()
    {
        if (enemyCount == 0)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}

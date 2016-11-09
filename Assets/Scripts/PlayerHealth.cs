using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player;

    public int playerHealth = 100;

    void Update()
    {
        ManagePlayerHealth();
    }

    void ManagePlayerHealth()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 50, 50), playerHealth.ToString());
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            playerHealth = playerHealth - 20;
        }

        if (col.gameObject.tag == "DeathFromFalling")
        {
            playerHealth = 0;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (playerHealth <= 90)
        {
            playerHealth = playerHealth + 10;
        }
    }
}

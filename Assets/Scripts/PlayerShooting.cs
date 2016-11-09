using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public GameObject playerGun;
    public GameObject bullet;

    public Transform bulletSpawnLocation;

    void Update()
    {
        PlayerCharacterShooting();
    }

    void PlayerCharacterShooting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, bulletSpawnLocation.position, bulletSpawnLocation.rotation);
        }
    }
}

using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    private Rigidbody bulletRB;

    private float bulletFireSpeed = 8f;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bulletRB.AddForce(transform.forward * bulletFireSpeed, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "DeathFromFalling")
        {
            Destroy(this.gameObject);
        }
    }
}

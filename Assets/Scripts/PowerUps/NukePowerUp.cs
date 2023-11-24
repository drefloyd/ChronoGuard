using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explode;
    void Start()
    {
        Destroy(gameObject, 3);//only lasts 3 seconds
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //kill all bots
            Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

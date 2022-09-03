using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * 600f);
        Destroy(gameObject, 0.5f);
        //bullet = GameObject.FindGameObjectsWithTag("Bullet");
        //Rigidbody2D bullet = GetComponent<Rigidbody2D>();
        //bullet.AddForce(transform.up * 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate((transform.forward * 20f * Time.deltaTime));
    }
}

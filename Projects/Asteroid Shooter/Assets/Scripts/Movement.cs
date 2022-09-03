using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D playerBody;
    public GameObject BulletPrefab;
    public float speed = 5f;
    GameObject player;
    public float targetTime = 1.0f;
    public bool timer = true;
    public float buttonTimer = 0.5f;
    public int buttonCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        playerBody = GetComponent<Rigidbody2D>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        buttonTimer -= Time.deltaTime;
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            timer = true;
            targetTime = 1.0f;
        }
        if (Input.GetKey("w"))
        {
            if (Input.GetKeyDown("w"))
            {
                buttonCounter++;
            }
            if ((buttonTimer >= 0.0f) && (buttonCounter == 1) && Input.GetKeyDown("w"))
            {
                playerBody.AddForce(transform.up * 500f);
                //Debug.Log("lets fly buzz");
            }
            else if(buttonTimer <= 0.0f)
            {
                //Debug.Log(buttonTimer);
                //Debug.Log(buttonCounter);
                buttonTimer = 0.5f;
                buttonCounter = 0;
                //Debug.Log("you shouldnt need to see me a lot");
            }
            //this.player.transform.Translate(0.0f,0.01f,0.0f);
            //playerBody.velocity = new Vector2(0 , speed);
            playerBody.AddForce(transform.up * 2f);
        }
        else if (Input.GetKey("d"))
        {
            //playerBody.rotation += 5f;
            playerBody.MoveRotation(playerBody.rotation + -120.0f * Time.fixedDeltaTime);
        }
        if (Input.GetKey("a"))
        {
            //playerBody.rotation += 5f;

            playerBody.MoveRotation(playerBody.rotation + 120.0f * Time.fixedDeltaTime);
        }
        else if (Input.GetKey("d"))
        {
            //playerBody.rotation += 5f;
            playerBody.MoveRotation(playerBody.rotation + -120.0f * Time.fixedDeltaTime);
        }
        else if (Input.GetKeyDown("s"))
        {
            playerBody.drag = 2.9f;
            Debug.Log(playerBody.drag);
        }
        else if (Input.GetKeyUp("s"))
        {
            playerBody.drag = 0.08f;

            Debug.Log(playerBody.drag);
        }
        if (Input.GetKeyDown("space") && timer == true)
        {
            timer = false;
            GameObject temp = Instantiate(BulletPrefab, transform.localPosition, transform.localRotation);
            temp.GetComponent<Rigidbody2D>().velocity = playerBody.velocity;
            //GameObject obj = Instantiate(BulletPrefab);
            //Debug.Log("test");
        }
        if (playerBody.position.x <= -8)
        {
            playerBody.position = new Vector2(8f, playerBody.position.y);
            Debug.Log("pull");
        }
        else if (playerBody.position.x >= 8)
        {
            playerBody.position = new Vector2(-8f, playerBody.position.y);
        }
        else if (playerBody.position.y <= -5)
        {
            playerBody.position = new Vector2(playerBody.position.x, 5f);
        }
        else if (playerBody.position.y >= 5)
        {
            playerBody.position = new Vector2(playerBody.position.x, -5f);
        }

      
    }
}

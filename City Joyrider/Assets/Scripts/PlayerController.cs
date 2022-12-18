using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody carRb;
    public bool gameOver = false;
    public bool isOnGround = true;
    private float turnSpeed = 50.0f;
    private float horizontalInput;
    private float borderRange = 6.0f;

    //Calls Script Spawnmanager
    private SpawnManager spawnManager;


    // Start is called before the first frame update
    void Start()
    {

        carRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        


        if (!gameOver)
        {
            if (transform.position.x < -borderRange)
            {
                transform.position = new Vector3(-borderRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x > borderRange)
            {
                transform.position = new Vector3(borderRange, transform.position.y, transform.position.z);
            }

            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * turnSpeed);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Barrier"))
        {
            
            gameOver = true;
            Debug.Log("Game Over!");
            spawnManager.UpdateScore(0);
            

        }
        else if (collision.gameObject.CompareTag("Wheel"))
        {

        }

    }
}

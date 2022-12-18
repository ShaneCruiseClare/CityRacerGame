using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerControllerScript;
    private float forwardBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript =
        GameObject.Find("Car").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (transform.position.y < forwardBound && gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }
}


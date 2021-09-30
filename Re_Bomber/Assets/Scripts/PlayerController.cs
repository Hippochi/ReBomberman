using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 5f;

    private int bombs = 2;

    public GameObject liveBomb;

    private Rigidbody rigidbody;
    private Transform playerTransform;
    private bool canBomb = true;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
    }


    void Update()
    {
        UpdateMove();
    }

    private void UpdateMove()
    {
        if (Input.GetKey(KeyCode.A))
        { //move left
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, playerSpeed);

        }

        if (Input.GetKey(KeyCode.S))
        { //move down
            rigidbody.velocity = new Vector3(-playerSpeed, rigidbody.velocity.y, rigidbody.velocity.z);

        }

        if (Input.GetKey(KeyCode.D))
        { //move right
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, -playerSpeed);

        }

        if (Input.GetKey(KeyCode.W))
        { //move up
            rigidbody.velocity = new Vector3(playerSpeed, rigidbody.velocity.y, rigidbody.velocity.z);

        }

        if (Input.GetKeyDown(KeyCode.Space) && canBomb == true)
        { //Drop bomb
            DropBomb();
            canBomb = false;
        }

    }


    private void DropBomb()
    {
        Instantiate(liveBomb, new Vector3(Mathf.RoundToInt(playerTransform.position.x),
 liveBomb.transform.position.y, Mathf.RoundToInt(playerTransform.position.z)),
 liveBomb.transform.rotation);


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "SafeTile")
        {
            canBomb = true;
        }
    }
}

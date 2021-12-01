using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 7f;
    public int playerLives;

    private int bombs = 2;

    public GameObject liveBomb;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    private Rigidbody rigidbody;
    private Transform playerTransform;
    private bool canBomb = true;
    private bool canTele = true;
    private bool canDie = true;
    private float teleCD = 120;
    private float DamageCD = 400;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        playerLives = 3;
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
    }


    void Update()
    {
        UpdateMove();
        Timer();
        LifeCheck();
    }

    private void UpdateMove()
    {
        if (Input.GetKey(KeyCode.A)|| Input.GetAxis("Horizontal") < -0.3f)
        { //move left
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, playerSpeed);

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0.3f)
        { //move right
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, -playerSpeed);

        }

        if (Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < -0.3f)
        { //move down
            rigidbody.velocity = new Vector3(-playerSpeed, rigidbody.velocity.y, rigidbody.velocity.z);

        }
        else if (Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0.3f)
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
        if (bombs > 0)
        {
            Instantiate(liveBomb, new Vector3(Mathf.RoundToInt(playerTransform.position.x),
            liveBomb.transform.position.y, Mathf.RoundToInt(playerTransform.position.z)),
            liveBomb.transform.rotation);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "SafeTile")
        {
            canBomb = true;
        }

    }
    void Timer()
    {
        if (canTele == false)
        {
            teleCD--;
            if (teleCD < 0)
            {
                teleCD = 120;
                canTele = true;
            }
        }

        if (canDie == false)
        {
            DamageCD--;
            if (DamageCD < 0)
            {
                DamageCD = 400;
                canDie = true;
            }
        }
    }

    void LifeCheck()
    {
        if (playerLives <= 2)
        {
            life3.SetActive(false);
        }

        if (playerLives <= 1)
        {
            life2.SetActive(false);
        }

        if (playerLives <= 0)
        {
            life1.SetActive(false);
        }
    }


void OnTriggerEnter(Collider col)
    {
        if (canTele == true)
        {
            if (col.gameObject.name == "TeleporterPadA")
            {
                Debug.Log("");
                playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z + 11);

                canTele = false;
            }
            if (col.gameObject.name == "TeleporterPadB")
            {
                Debug.Log("");
                playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z - 11);
                canTele = false;
            }

        }

        if (col.gameObject.tag == "Explosion")
        {
            if (canDie == true) { playerLives--; }
            Debug.Log(playerLives);
            canDie = false;
        }
    }
}

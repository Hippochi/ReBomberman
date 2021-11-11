using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{

    public float enemySpeed = 7f;

    private int bombs = 60;
    private int bombsCD = 120;
    public GameObject liveBomb;

    private Rigidbody rigidbody;
    private Transform enemyTransform;
    
    [SerializeField]
    private bool canMove = true;
    private bool canBomb;
    private Vector2 direction;
    private float moveDetectorx, moveDetectorz;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        enemyTransform = GetComponent<Transform>();
    }
  
    // Update is called once per frame
    void Update()
    {
        bombsCD--;
        if (bombsCD == 0)
        { 
            bombsCD = 120;
            canBomb = true;
        }
        Move();
    }

    private void Move()
    {
        moveDetectorx = Math.Abs(enemyTransform.position.x);
        moveDetectorx = Mathf.Round(moveDetectorx * 10f) / 10f;
        moveDetectorz = Math.Abs(enemyTransform.position.z);
        moveDetectorz = Mathf.Round(moveDetectorz * 10f) / 10f;

        if (enemyTransform.position.z > 1)
        {
            if ((moveDetectorx % 2.0f) == 1.0f && (moveDetectorz % 2.0f) == 0.0f)
            {

                canMove = true;
                bombs--;
            }
        }
        else
        {
            if ((moveDetectorx % 2.0f) == 1.0f && (moveDetectorz % 2.0f) == 1.0f)
            {

                canMove = true;
                bombs--;
            }
        }

        if (canMove == true)
        {
            if (UnityEngine.Random.Range(0, 2) * 2 - 1 == 1)
            {
                if (enemyTransform.position.x > -2.1) { direction.x = -1; }
                else if (enemyTransform.position.x < -8.9) { direction.x = 1; }
                else { direction.x = UnityEngine.Random.Range(0, 2) * 2 - 1; }
                direction.y = 0;
                canMove = false;
            }

            else 
            {
                if (enemyTransform.position.z > -2.1 && enemyTransform.position.z < 0) { direction.y = -1; }
                else if (enemyTransform.position.z < -8.9) { direction.y = 1; }
                else if (enemyTransform.position.z > 9.9) { direction.y = -1; }
                else if (enemyTransform.position.z < 2.1 && enemyTransform.position.z > 0) { direction.y = 1; }
                else { direction.y = UnityEngine.Random.Range(0, 2) * 2 - 1; }
                direction.x = 0;
                canMove = false;
            }
            Debug.Log(canMove);

            
            
        }

        

        rigidbody.velocity = new Vector3(enemySpeed* direction.x,rigidbody.velocity.y, enemySpeed * direction.y);

       if (bombs == 0)
        {
            bombs = 60;
            DropBomb();
        }
    }

    private void DropBomb()
    {
        if (canBomb == true)
        {
            Instantiate(liveBomb, new Vector3(Mathf.RoundToInt(enemyTransform.position.x),
            liveBomb.transform.position.y, Mathf.RoundToInt(enemyTransform.position.z)),
            liveBomb.transform.rotation);
            canBomb = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            Destroy(enemyTransform.root.gameObject);
            ScoreCounter.instance.curScore += 10;

        }
    }
}

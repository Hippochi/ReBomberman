using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    bool timeToSpawn;
    private bool leftOrRight;
    public GameObject Enemy;
    Vector3 position;

    void Start()
    {
        timeToSpawn = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (timeToSpawn == true)
        {
            Invoke("Spawn", 1.5f);
            timeToSpawn = false;
        }
    }

    private void Spawn()
    {
        if (Random.Range(0, 2) * 2 - 1 == -1)
        {
            leftOrRight = true;
        }
        else { leftOrRight = false; }

        if (leftOrRight == true)
        {
            position.z = (Random.Range(1, 5)*2);
        }
        else
        {
            position.z = (Random.Range(-1, -5)*2 ) + 1;
        }
        position.x = (Random.Range(-1, -5)*2  ) + 1;
        position.y = 0.5f;

        Instantiate(Enemy, position, Quaternion.identity);

        timeToSpawn = true;
    }
}

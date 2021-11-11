using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour: MonoBehaviour
{

    public GameObject explosionPrefab;
    private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        Invoke("Explode", 3f);
    }

    // Update is called once per frame

    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GetComponent<MeshRenderer>().enabled = false;
        //transform.Find("Collider").gameObject.SetActive(false);
        Destroy(gameObject, 0.3f);

    }
}

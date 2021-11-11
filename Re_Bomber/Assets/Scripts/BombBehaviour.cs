using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour: MonoBehaviour
{

    public GameObject explosionPrefab;
    private Transform transform;
    private Vector3 adjustedExplosion;
    private Vector3 adjustedExplosion2;
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
        adjustedExplosion = new Vector3(transform.position.x, transform.position.y, transform.position.z + 11);
        adjustedExplosion2 = new Vector3(transform.position.x, transform.position.y, transform.position.z -11);
        Instantiate(explosionPrefab, adjustedExplosion, Quaternion.identity);
        Instantiate(explosionPrefab, adjustedExplosion2, Quaternion.identity);
        GetComponent<MeshRenderer>().enabled = false;
        //transform.Find("Collider").gameObject.SetActive(false);
        Destroy(gameObject, 0.3f);

    }
}

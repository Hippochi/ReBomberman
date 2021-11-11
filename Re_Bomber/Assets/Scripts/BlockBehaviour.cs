using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Material RedMat;
    private Material GreenMat;
    private bool alreadyUsed;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        RedMat = meshRenderer.materials[1];
        GreenMat = meshRenderer.materials[0];
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "DeathTile")
        {
            StartCoroutine(DangerTile());

            Collider[] colliders;
            if ((colliders = Physics.OverlapSphere(transform.position, .5f)).Length > 1)
            {
                foreach (var collider in colliders)
                {
                    var go = collider.gameObject;
                    if (go == gameObject) continue;

                    go.tag = "AdjacentDeath";
                }
            }
            if ((colliders = Physics.OverlapSphere(transform.position-new Vector3(0,0,11), 0.5f)).Length > 1)
            {
                foreach (var collider in colliders)
                {
                    var go = collider.gameObject;
                    if (go == gameObject) continue;

                    go.tag = "AdjacentDeath";
                }
            }
            if ((colliders = Physics.OverlapSphere(transform.position + new Vector3(0,0,11), 0.5f)).Length > 1)
            {
                foreach (var collider in colliders)
                {
                    var go = collider.gameObject;
                    if (go == gameObject) continue;

                    go.tag = "AdjacentDeath";
                }
            }
        
        }
        if (gameObject.tag == "AdjacentDeath")
        {
            
            StartCoroutine(DangerTile());
        }
        
    }

    IEnumerator DangerTile()
    {
        alreadyUsed = true;
        gameObject.tag = "SafeTile";
        yield return new WaitForSecondsRealtime(3f);

        //meshRenderer.material = GreenMat;
        alreadyUsed = false;
    }

    IEnumerator TileHasBeenUsed()
    {
        yield return new WaitForSecondsRealtime(3f);
       
    }

    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == "Bomb")
        {
            gameObject.tag = "DeathTile";

            if (alreadyUsed == true)
            {

            }
        }


        StartCoroutine(TileHasBeenUsed());
    }



    
}

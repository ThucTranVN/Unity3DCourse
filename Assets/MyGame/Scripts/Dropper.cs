using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject spawnObject;
    [SerializeField]
    private float lifeTime;

    private GameObject curSpawnObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //spawn object
            curSpawnObject = Instantiate(spawnObject, spawnPoint);

            if(curSpawnObject != null)
            {
                Destroy(curSpawnObject, lifeTime);
            }
        }
    }
}

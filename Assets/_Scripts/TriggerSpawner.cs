using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    private SpawnerManager spawnerManager;
    [SerializeField]
    private Transform endPlatform;
    [SerializeField]
    private Transform platform;
    private void Start()
    {
        spawnerManager = GameObject.Find("SpawnerManager").GetComponent<SpawnerManager>();
        Destroy(transform.parent.gameObject, 8f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(spawnerManager.platforms[Random.Range(0, spawnerManager.platforms.Length - 1)], new Vector3(platform.position.x, platform.position.y, platform.localScale.z + transform.position.z), Quaternion.identity);
        }
    }

}

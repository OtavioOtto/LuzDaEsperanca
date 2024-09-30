using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject checkPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spawnPoint.transform.position = checkPoint.transform.position;
        }
    }

}

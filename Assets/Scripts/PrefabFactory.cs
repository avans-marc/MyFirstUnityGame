using DG.Tweening;
using System;
using Unity.Mathematics;
using UnityEngine;

public class PrefabFactory : MonoBehaviour
{
    public GameObject prefab;
    public GameObject player;

    public float spawnDistanceMin = 2f;
    public float spawnDistanceMax = 5f;

    public float groundY = 0; // Set this to your ground level


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            CreatePrefabInstance();
        }
    }

    public void CreatePrefabInstance()
    {
        // Random distance between min and max
        float randomDistance = UnityEngine.Random.Range(spawnDistanceMin, spawnDistanceMax);

        
        Vector3 spawnPosition = new Vector3(
            player.transform.position.x + randomDistance,
            groundY,
            player.transform.position.z
        );

        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}

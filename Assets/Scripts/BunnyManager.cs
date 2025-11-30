using DG.Tweening;
using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class BunnyManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject player;

    public event Action OnBunnyExit;


    public float spawnDistanceMin = -5f;
    public float spawnDistanceMax = 5f;

    public float groundY = 0; // Set this to your ground level


    private PlayerController playerController;
    


    public void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        CreatePrefabInstance();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            CreatePrefabInstance();
        }
    }

    public void HandleBunnyExit()
    {
        CreatePrefabInstance();
        this.OnBunnyExit?.Invoke();
    }

    public void CreatePrefabInstance()
    {
        // Random distance between min and max
        float randomDistance = UnityEngine.Random.Range(spawnDistanceMin, spawnDistanceMax);
        
        Vector3 spawnPosition = new Vector3(randomDistance, groundY, 0);

        var bunny = Instantiate(prefab, spawnPosition, quaternion.identity, this.transform);

        // Invert the direction the bunny is going from the direction the player is going
        var bunnyController = bunny.GetComponent<BunnyController>();
        bunnyController.player = player;
        bunnyController.OnBunnyExit += HandleBunnyExit;
    }


}

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


    public void Start()
    {
        //CreatePrefabInstance();
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

    public GameObject PlaceNewBunny()
    {
        Debug.Log($"Place new bunny");

        //placableObjectsUI.SetActive(false);
        GameObject bunny = Instantiate(prefab, Vector3.zero, Quaternion.identity);

        // Add the component to bunnies dragged from the menu
        var bunnyController = bunny.GetComponent<BunnyController>();
        bunnyController.player = player;
        bunnyController.OnBunnyExit += HandleBunnyExit;
        bunnyController.StartDragging();

        return bunny;
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

    public void FinishedDraggingObject2D(DraggableObject draggableObject)
    {
        Debug.Log($"Finished dragging");
    }
}

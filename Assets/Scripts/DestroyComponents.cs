using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DestroyComponents : MonoBehaviour
{
    ARPlaneManager aRPlaneManager;
    ARPointCloudManager aRPointCloudManager;
    private void Awake()
    {
        aRPlaneManager = GetComponent<ARPlaneManager>();
       
        aRPointCloudManager = GetComponent<ARPointCloudManager>();
        
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        ARPlacementManager.OnObjectSpawned += DestroyComponentsOnObjectSpawned;
    }

    private void OnDisable()
    {
        ARPlacementManager.OnObjectSpawned -= DestroyComponentsOnObjectSpawned;
    }

    private void DestroyComponentsOnObjectSpawned(Vector3 spawnPosition)
    {
        Destroy(aRPlaneManager);
        Destroy(aRPointCloudManager);
    }
}

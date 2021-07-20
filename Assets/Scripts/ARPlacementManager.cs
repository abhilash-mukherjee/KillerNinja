using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlacementManager : MonoBehaviour
{
    public delegate void ObjectSpawnManager(Vector3 spawnPosition);
    public static event ObjectSpawnManager OnObjectSpawned;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Camera arCam;
    ARPlaneManager aRPlaneManager;
    private Vector2 touchPosition = default;
    private ARRaycastManager aRRaycastManager;
    private ARAnchorManager aRAnchorManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool objectIsSpawned = false;
    public GameObject shoot;

    public GameObject time;

    void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
    }

    void Update()
    {
        if (Input.touchCount == 0)
            return;
        RaycastHit hit;
        Ray ray = arCam.ViewportPointToRay(new Vector3(0.5f,0.5f));

        // Debug.DrawLine(ray.origin,ray.direction*10,Color.red);
        // Debug.Log(ray.origin);
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            touchPosition = touch.position;
            if (aRRaycastManager.Raycast(touchPosition, hits))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Hit");
                    if (hit.collider.gameObject.CompareTag("ARPlane"))
                    {
                        Debug.Log("Plane");
                        objectIsSpawned = true;
                        var hitPose = hits[0].pose;
                        
                        GameObject instantiatedPrefab = Instantiate(prefab, hitPose.position, hitPose.rotation);
                        

                        Debug.Log("Successful Cube");

                        foreach (ARPlane aRPlane in aRPlaneManager.trackables)
                        {
                            aRPlane.gameObject.SetActive(false);
                        }
                        Destroy(aRPlaneManager);
                        OnObjectSpawned.Invoke(hitPose.position);


                        Debug.Log("Shoot Object Active");
                        shoot.SetActive(true);
                        time.SetActive(true);
                        return;
                    }
                    // if (hit.collider.gameObject.CompareTag("Enemy"))
                    // {
                    //     Destroy(hit.collider.gameObject);
                    // }
                }
                
            }


        }        
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObject : MonoBehaviour
{
    public GameObject placedPrefab;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (raycastManager.Raycast(touch.position, hitResults, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hitResults[0].pose;
                    PlacePrefab(hitPose.position, hitPose.rotation);
                }
            }
        }
    }

    void PlacePrefab(Vector3 position, Quaternion rotation)
    {
        Instantiate(placedPrefab, position, rotation);
    }
}

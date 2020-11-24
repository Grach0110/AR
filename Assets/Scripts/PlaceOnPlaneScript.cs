using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlaneScript : MonoBehaviour
{
    ARRaycastManager aRRaycastManager;
    Vector2 touchePosition;

    public GameObject scenePrefab;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        scenePrefab.SetActive(false);
    }

    private void Update()
    {
        if (Input.touchCount > 0 )
        {
            touchePosition = Input.GetTouch(0).position;

            if (aRRaycastManager.Raycast(touchePosition, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose;

                scenePrefab.SetActive(true);
                scenePrefab.transform.position = hitPose.position;
                LookAtPlayer(scenePrefab.transform);
            }
        }
    }

    void LookAtPlayer(Transform scene)
    {
        var lookDirection = Camera.main.transform.position - scene.position;
        lookDirection.y = 0f;
        scene.rotation = Quaternion.LookRotation(lookDirection);
    }
}
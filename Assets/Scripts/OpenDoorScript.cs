using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class OpenDoorScript : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<Animator>().SetTrigger("OpenDoor");

        var ARPlaneManager = FindObjectOfType<ARPlaneManager>();
        var ARPointManager = FindObjectOfType<ARPointCloudManager>();

        foreach (var point in ARPointManager.trackables)
        {
            point.gameObject.SetActive(false);
        }

        foreach (var plane in ARPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }

        ARPlaneManager.enabled = false;
        ARPointManager.enabled = false;
    }
}

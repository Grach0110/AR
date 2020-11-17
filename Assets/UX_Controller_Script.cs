using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class UX_Controller_Script : MonoBehaviour
{
    private ARPlaneManager aRPlaneManager;
    public GameObject handAnim;


    private void Start()
    {
        aRPlaneManager = GetComponent<ARPlaneManager>();
        aRPlaneManager.planesChanged += aRPlaneManager_planesChanged;
    }

    void aRPlaneManager_planesChanged(ARPlanesChangedEventArgs obj)
    {
        foreach (var item in obj.added)
        {
            handAnim.SetActive(false);
            break;
        }
    }
}
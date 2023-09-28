using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingMousePos : MonoBehaviour
{
    [SerializeField] private Camera sceneCam;

    private Vector3 lastPos;
    [SerializeField] private LayerMask placeLayerMask;

    public Vector3 GetSelectedMapPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCam.nearClipPlane;
        Ray ray = sceneCam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100, placeLayerMask))
        {
            lastPos = hit.point;
        }
        return lastPos;
    }
}

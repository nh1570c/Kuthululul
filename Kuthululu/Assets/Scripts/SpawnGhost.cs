using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    [SerializeField]private GameObject buildingPrefab, placeSystem;
    [SerializeField]PlacementSystem placeSys;


    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            placeSystem.SetActive(false);
        }
        
    }
    public void EnableBuilding()
    {
        placeSystem.SetActive(true);
    }

    
}

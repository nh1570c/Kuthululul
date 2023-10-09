using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    [SerializeField]private GameObject buildingPrefab, placeSystem;
    [SerializeField]PlacementSystem placeSys;
    
    public void EnableBuilding()
    {
        placeSys.ChangePrefab(buildingPrefab);
        placeSystem.SetActive(true);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] GameObject mouseIndi, cellIndi, placeHolder;
    [SerializeField] private GettingMousePos GetMousePos;
    [SerializeField] private Grid grid;
    void Start()
    {
        //GameObject CellGhost = Instantiate(cellIndi);
    }
    private void Update()
    {
        Vector3 mousePos = GetMousePos.GetSelectedMapPos();
        Vector3Int GridPos = grid.WorldToCell(mousePos);
        mouseIndi.transform.position = mousePos;
        cellIndi.transform.position = grid.GetCellCenterWorld(GridPos);
        if(Input.GetMouseButtonDown(1))
        {
            ChangePrefab(placeHolder);
        }
        if(Input.GetMouseButtonDown(0))
        {
            PlaceBuilding();
        }
        
    }

    public void ChangePrefab(GameObject buildPrefab)
    {
        Destroy(cellIndi);
        GameObject newGhost = Instantiate(buildPrefab);
        newGhost.transform.parent = transform;
        cellIndi = newGhost;
    }
    public void PlaceBuilding()
    {
        GameObject placedObj = Instantiate(cellIndi, cellIndi.transform.position, cellIndi.transform.rotation);
        ChangePrefab(placeHolder);
    }
    
}

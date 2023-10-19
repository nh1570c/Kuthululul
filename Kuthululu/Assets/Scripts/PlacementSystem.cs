using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] GameObject mouseIndi, cellIndi, placeHolder, PlacedObjList, stopSign;
    [SerializeField] private GettingMousePos GetMousePos;
    [SerializeField] private Grid grid;
    private bool canBePlaced = true;
    void Start()
    {
        //GameObject CellGhost = Instantiate(cellIndi);
    }
    private void Update()
    {
        if(cellIndi != null)
        {
            Vector3 mousePos = GetMousePos.GetSelectedMapPos();
            Vector3Int GridPos = grid.WorldToCell(mousePos);
            mouseIndi.transform.position = mousePos;
            cellIndi.transform.position = grid.GetCellCenterWorld(GridPos);
            if(Input.GetMouseButtonDown(0))
            {
                if(canBePlaced == true && cellIndi.tag != "PlaceHolder")
                {
                    PlaceBuilding();
                }
            }
        }
    
        if(Input.GetMouseButtonDown(1))
        {
            ChangePrefab(placeHolder);
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
        placedObj.transform.parent = PlacedObjList.transform;
        ChangePrefab(placeHolder);

        //Saving the world pos in a list
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Blocked"))
        {
            stopSign.SetActive(true);
            Debug.Log("Entering");
            canBePlaced = false;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Blocked"))
        {
            stopSign.SetActive(false);
            Debug.Log("leaving");
            canBePlaced = true;
        }
    }
    
}

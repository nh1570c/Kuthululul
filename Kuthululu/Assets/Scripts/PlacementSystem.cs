using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] GameObject mouseIndi, cellIndi;
    [SerializeField] private GettingMousePos GetMousePos;
    [SerializeField] private Grid grid;

    private void Update()
    {
        Vector3 mousePos = GetMousePos.GetSelectedMapPos();
        Vector3Int GridPos = grid.WorldToCell(mousePos);
        Debug.Log(GridPos);
        mouseIndi.transform.position = mousePos;
        cellIndi.transform.position = grid.CellToWorld(GridPos);
    }
}

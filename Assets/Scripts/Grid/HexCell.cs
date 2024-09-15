using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{
    public HexCoordinates coordinates;

    private void Awake()
    {
        
        Debug.Log(coordinates.ToStringOnSeparateLines());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private RaycastHit hit;

    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;    
    }

    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            if(hit.collider.TryGetComponent(out HexCell hex))
            {
                Debug.Log(hex.coordinates.ToStringOnSeparateLines());
            }
        }
    }
}
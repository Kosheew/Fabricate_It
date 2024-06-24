using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedurGenerate : MonoBehaviour
{
    [SerializeField] private GameObject[] _hexPrefabs;
    [SerializeField] private int _radius = 1;

    private void Start()
    {
        StartCoroutine(GenerateHexGrid());
    }



    /*
    [SerializeField] private GameObject _hexPrefab;

    private int _startAngle = 0;

    private Vector3 _objectScale;


    // z = 1.732   / 2
    // 1.5

    private void Start()
    {
        _objectScale = _hexPrefab.transform.localScale / 2;

        Instantiate(_hexPrefab, transform.position, Quaternion.identity);

        Debug.Log(_objectScale);
    }

  
    void Update()
    {
        int startAngle = 30;

        for (int i = 0; i < 6; i++)
        {
            // Convert the angle to radians
            float angleInRadians = Mathf.Deg2Rad * startAngle;

            // Calculate the direction vector
            Vector3 direction = new Vector3(Mathf.Cos(angleInRadians), 0, Mathf.Sin(angleInRadians));

            // Draw the ray
            Debug.DrawRay(transform.position, direction * 5, Color.red);

            // Increment the angle by 60 degrees for the next direction
            startAngle += 60;
        }
    }


    */


    IEnumerator GenerateHexGrid()
    {
        int randomHex = Random.Range(0, _hexPrefabs.Length);

        float hexWidth = _hexPrefabs[randomHex].transform.localScale.x * 1.5f;
        float hexHeight = _hexPrefabs[randomHex].transform.localScale.z * 0.866f * 2;

        Vector3 startPosition = transform.position;

        // Create the central hex
        Instantiate(_hexPrefabs[randomHex], startPosition, Quaternion.identity);

        for (int q = -_radius; q <= _radius; q++)
        {
            int r1 = Mathf.Max(-_radius, -q - _radius);
            int r2 = Mathf.Min(_radius, -q + _radius);

            for (int r = r1; r <= r2; r++)
            {
                if (q == 0 && r == 0) continue; // Skip the central hex

                randomHex = Random.Range(0, _hexPrefabs.Length);
                Vector3 hexPosition = HexToWorldPosition(q, r, hexWidth, hexHeight);
                Instantiate(_hexPrefabs[randomHex], hexPosition, Quaternion.identity);
                yield return new WaitForSeconds(0.025f);
            }
        }
    }

    private Vector3 HexToWorldPosition(int q, int r, float hexWidth, float hexHeight)
    {
        float x = hexWidth * r;
        float z = hexHeight * (q + r / 2f);

        return new Vector3(x, transform.position.y, z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    public GameObject cubePrefab;
    GameObject[] cubes = new GameObject[512];
    public float maxScale;

    private void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject cube = Instantiate(cubePrefab);
            cube.transform.position = transform.position;
            cube.transform.SetParent(transform);
            cube.name = "Cube " + i;
            transform.eulerAngles = new Vector3(0f, -0.703125f * i, 0f);
            cube.transform.position = Vector3.forward * 1500;
            cubes[i] = cube;
        }
    }

    private void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (cubes != null)
            {
                cubes[i].transform.localScale = new Vector3(10f, (AudioPeer.samples[i] * maxScale) + 2, 10f);
            }
        }
    }
}

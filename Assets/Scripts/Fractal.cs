using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;

    [SerializeField]
    private int iteration;

    [SerializeField]
    private float size;

    void Start()
    {
        CreateMengerSponge((iteration-1), Vector3.zero, size*10);
    }

    private void CreateMengerSponge(int level, Vector3 position, float scale)
    {
        if (level == 0)
        {
            GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
            cube.transform.localScale = Vector3.one * scale;
        }
        else
        {
            float newScale = scale/3f;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        if (Mathf.Abs(i) + Mathf.Abs(j) + Mathf.Abs(k) > 1)
                        {
                            Vector3 offset = new Vector3(i, j, k) * newScale;
                            CreateMengerSponge(level - 1, position + offset, newScale);
                        }
                    }
                }
            }
        }
    }
}


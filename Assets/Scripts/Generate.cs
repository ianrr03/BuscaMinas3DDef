using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject piece;
    public int width, height;

    private void Start()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Instantiate(piece, new Vector2(i, j), Quaternion.identity);
            }
        }
    }
}

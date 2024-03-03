using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Block : MonoBehaviour
{
    public bool bomb;

    public int x;

    public int y;


    private void OnMouseDown()
    {
        if (bomb)
        {
            GetComponent<SpriteRenderer>().material.color = Color.red;
        }
        else
        {
            transform.GetChild(0).GetChild(0).GetComponent<Text>().text = BlockGenerator.blockGen.MinesAround(x, y).ToString();
        }
    }

}

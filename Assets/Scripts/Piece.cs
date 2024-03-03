using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    public bool bomb;
    
    public int x, y;

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        if (bomb)
            GetComponent<SpriteRenderer>().material.color = Color.red;
        else
            transform.GetChild(0).GetChild(0).GetComponent<Text>().text =
                Generate.gen.GetBombsAround(x,y).ToString();  
    }
}

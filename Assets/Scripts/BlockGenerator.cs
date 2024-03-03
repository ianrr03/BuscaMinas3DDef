using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{

    //Llamar desde la otra clase
    public static BlockGenerator blockGen;

    public GameObject Block;
    public int width, height, minesAmount;

    private GameObject[,] map;

    private void Awake()
    {
        blockGen = this;
    }

    void Start()
    {
        GenerateMap();
        CameraChange();
        GenerateMines();
    }

    //Cambio de posicion de la camara al centro
    void CameraChange()
    {
        Camera.main.transform.position = new Vector3(width / 2f - 0.5f, height / 2f - 0.5f, -10);
    }


    //Generar el mapa
    void GenerateMap()
    {
        map = new GameObject[width, height];

        //Recorre cada posicion hasta el numero fijado y coloca los bloques
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject newBlock = Instantiate(Block, new Vector2(x, y), Quaternion.identity);
                newBlock.GetComponent<Piece>().x = x;
                newBlock.GetComponent<Piece>().y = y;

                //Almacena el bloque colocado en la array
                map[x, y] = newBlock;
            }
        }
    }

    //Genera las minas
    void GenerateMines()
    {
        int minesPlaced = 0;

        while (minesPlaced < minesAmount)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            Piece blockScript = map[x, y].GetComponent<Piece>();
            if (!blockScript.mine)
            {
                blockScript.mine = true;
                minesPlaced++;
            }
        }
    }

    //Numero de minas alrededor
    public int MinesAround(int x, int y)
    {
        int count = 0;

        //Recorre los cuadrados de al rededor
        for (int xMine = -1; xMine <= 1; xMine++)
        {
            for (int yMine = -1; yMine <= 1; yMine++)
            {
                //Calcula los cuadrados de alrededor
                int checkX = x + xMine;
                int checkY = y + yMine;

                //comprobar que no se valla del mapa
                if (checkX >= 0 && checkX < width && checkY >= 0 && checkY < height)
                {
                    if (map[checkX, checkY].GetComponent<Piece>().mine)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }
}
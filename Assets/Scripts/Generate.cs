using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public static Generate gen;
    public GameObject piece;
    public int width, height, bombsNumber;

    public GameObject[][] map;
    public bool bomb;
    


    private void Awake()
    {
        gen = this; //Hacemos que sea singleton
    }
    void Start()
    {

        map = new GameObject[width][]; //inicializamos el array

        Camera.main.transform.position = new Vector3(((float)width / 2) * 1.0f, ((float)height / 2) * 1.0f, -10); ///pongo la anchura a la mitad y la altura a la mitad * 1 que es lo que mide el cubo y con -10 me echo para atras para verlo todo

        map = new GameObject[width][]; //crearemos un array con todos los elementos
        for (int i = 0; i < map.Length; i++)
        {
            map[i]=new GameObject[height];
        }


        //Creamos el map
        for (int i = 0;i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                map[i][j]=Instantiate(piece,new Vector2(i,j),Quaternion.identity);
                map[i][j].GetComponent<Piece>().x = i;
                map[i][j].GetComponent<Piece>().y = j;
            }
        }
        SetBombs();

        //for (int i = 0; i < bombsNumber; i++)
        //{
        //     map[Random.Range(0, width)][Random.Range(0, height)].GetComponent<SpriteRenderer>().material.color = Color.red;
        //}

    }///Start

    public void SetBombs()
    {
        //Codigo prueba número de bombas
        for(int i = 0; i <bombsNumber; i++)
        {
            int x = Random.Range(0,width);
            int y = Random.Range(0,height);
            if (!map[x][y].GetComponent<Piece>().bomb)
            {
                map[x][y].GetComponent<Piece>().bomb = true;
            }
            else
            {
                i--; //Si nos hemos topado con una bomba, tendremos que buscar otra, este bucle no es un representativo
            }
        }
    }//SetBombs

    public int GetBombsAround(int x, int y)
    {
        int cont = 0;
        if (x > 0 && y < height - 1 && map[x - 1][y + 1].GetComponent<Piece>().bomb)
            cont++;
        if (y < height -1 && map[x][y + 1].GetComponent<Piece>().bomb) 
            cont++;
        if (x < width -1 && y < height - 1 && map[x + 1][y + 1].GetComponent <Piece>().bomb)
            cont++;
        if(x > 0 && map[x - 1][y].GetComponent<Piece>().bomb)
            cont++;
        if(x < width - 1 && map[x + 1][y].GetComponent<Piece>().bomb)
            cont++;
        if (x > 0 && y > 0 && map[x - 1][y - 1].GetComponent<Piece>().bomb)
            cont++;
        if(y > 0 && map[x][y - 1].GetComponent<Piece>().bomb)
            cont++;
        if (x < width - 1 && y > 0 && map[x + 1][y - 1].GetComponent<Piece>().bomb)
            cont++;

        return cont;
    }
}

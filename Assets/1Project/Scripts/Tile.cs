using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]

public class Side
{
    public string top;
    public string right;
    public string bottom;
    public string left;
    public void Rotate()
    {
        string temp = top;
        top = left;
        left = bottom;
        bottom = right;
        right = temp;
    }
    public Side(string s1, string s2, string s3, string s4)
    {
        top = s1;
        right = s2;
        bottom = s3;
        left = s4;
    }
    public Side(){}
}

[System.Serializable]
public class Tile
{
     // 1 - grass  - g
     // 2 - forest - f
     // 3 - river  - r
    [HideInInspector] public int id = 0;
    public Sprite sprite;
    public Side sides;

    [HideInInspector] public Vector3 eulerAngles = new Vector3(0,0,0);
    public Tile(int n, Sprite sprite, Side a)
    {
        this.id = n;
        this.sprite = sprite;
        this.sides = a;
    }

    public void Rotate()
    {
        sides.Rotate();
        eulerAngles += new Vector3(0,0,-90);
    }
}

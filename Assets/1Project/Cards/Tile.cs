using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class Tile
{
     // 1 - grass  - g
     // 2 - forest - f
     // 3 - river  - r
    [HideInInspector] public int id = 0;
    public Sprite sprite;
    public string top;
    public string right;
    public string bottom;
    public string left;

    [HideInInspector] public Vector3 eulerAngles = new Vector3(0,0,0);
    public Tile(int n)
    {
        this.id = n;
    }

    public void Rotate()
    {
        string temp = top;
        top = left;
        left = bottom;
        bottom = right;
        right = temp;
        eulerAngles += new Vector3(0,0,-90);
    }
}

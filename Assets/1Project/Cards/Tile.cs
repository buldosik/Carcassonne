using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
     // 1 - grass  - gr
     // 2 - forest - fr
     // 3 - river  - rv
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
    
}

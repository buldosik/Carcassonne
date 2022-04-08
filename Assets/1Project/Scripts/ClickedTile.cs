using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedTile : MonoBehaviour
{
    public Player player => FindObjectOfType<Player>();
    void OnMouseDown()
    {
        player.PlaceTile(transform.position.x,transform.position.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Tile CurrentTile;
    private TileDeck Deck => FindObjectOfType<TileDeck>();
    public Image TileImage;
    public GameField CurrentField;
    private void Start() {
        GetNewTile();    
    }
    void GetNewTile()
    {
        List <Tile> CurrentDeck = Deck.AllTiles;
        CurrentTile = CurrentDeck[0];
        CurrentDeck.RemoveAt(0);
        Deck.AllTiles = CurrentDeck;    
        TileImage.sprite = CurrentTile.sprite;
    }

    public void RotateTile()
    {
        CurrentTile.Rotate();
        TileImage.rectTransform.localEulerAngles = 
        new Vector3(TileImage.rectTransform.localEulerAngles.x,
                    TileImage.rectTransform.localEulerAngles.y,
                    TileImage.rectTransform.localEulerAngles.z - 90);
    }
    public void PlaceTile(float x, float y)
    {
        if(!CurrentField.AddNewTile(CurrentTile, (int)x, (int)y))
            return;
        TileImage.transform.eulerAngles = new Vector3(0,0,0);
        GetNewTile();
    }
}

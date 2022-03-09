using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameField : MonoBehaviour
{
    public List <List <Tile>> grid = new List<List<Tile>>();
    public int gridSize = 50;
    public Tile startTile;
    public GameObject tilePrefab;
    private void Awake() {
        for(int i = 0; i < gridSize; i++)
        {
            grid.Add(new List<Tile> ());
            for(int j = 0; j < gridSize; j++)
            {
                grid[i].Add(new Tile(-1));
            }
        }   
        grid[25][25] = startTile; 
        DrawNewTile(startTile, 0, 0);
        CheckAwailablePositions();
    }
    public GameObject awailableTilePrefab;
    public List <Tuple <int,int>> awailablePositions = new List<Tuple<int, int>>();
    public GameObject parentAwailableTiles;
    public void CheckAwailablePositions()
    {
        awailablePositions.Clear();
        foreach (Transform child in parentAwailableTiles.transform)
            GameObject.Destroy(child.gameObject);
        //while(parentAwailableTiles.transform.childCount > 0)
        //    Destroy(parentAwailableTiles.transform.GetChild(0).gameObject);
        for(int i = 1; i < gridSize - 1; i++)
        {
            for(int j = 1; j < gridSize - 1; j++)
            {
                if(grid[i][j].id != -1)
                    continue;
                if (grid[i+1][j].id == -1 &&
                    grid[i-1][j].id == -1 &&
                    grid[i][j+1].id == -1 &&
                    grid[i][j-1].id == -1)
                    continue;
                awailablePositions.Add(new Tuple<int, int> (i,j));
                GameObject newAwailableTile = Instantiate(awailableTilePrefab);
                newAwailableTile.transform.parent = parentAwailableTiles.transform;
                newAwailableTile.transform.position = new Vector3((float)((i - 25) * 2), (float)((j-25)*2),0f);
            }
        }
    }

    public void DrawNewTile(Tile tile, int x, int y)
    {
        GameObject newAwailableTile = Instantiate(tilePrefab);
        newAwailableTile.GetComponent<SpriteRenderer>().sprite = tile.sprite;
        TilePosition temp = newAwailableTile.GetComponent<TilePosition>();
        temp.top = tile.top;
        temp.right = tile.right;
        temp.bottom = tile.bottom;
        temp.left = tile.left;
        newAwailableTile.transform.eulerAngles = tile.eulerAngles;
        newAwailableTile.transform.position = new Vector3((float)(x), (float)(y), 0f);    
    }
    public bool AddNewTile(Tile tile, int x, int y)
    {
        if(!IsPossibleToPlace(tile, x, y))
            return false;
        grid[x / 2 + 25][y / 2 + 25] = tile;
        DrawNewTile(tile, x, y);
        CheckAwailablePositions();
        return true;
    }
    public bool IsPossibleToPlace(Tile tile, int x, int y)
    {
        x = x / 2 + 25;
        y = y / 2 + 25;
        for(int i = -1; i <= 1; i++)
        {
            for(int j = -1; j <= 1; j++)
            {
                if(i * i + j * j != 1)
                    continue;
                Tile cur = grid[x + i][y + j];
                if(cur.id == -1)
                    continue;
                if(j == -1 && tile.bottom != cur.top)
                    return false;
                if(j == 1 && tile.top != cur.bottom)
                    return false;
                if(i == -1 && tile.left != cur.right)
                    return false;
                if(i == 1 && tile.right != cur.left)
                    return false;
            }
        }
        return true;
    }
}

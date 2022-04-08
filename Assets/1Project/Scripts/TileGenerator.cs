using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileGenerator : MonoBehaviour
{
    public List <Sprite> spriteList;
    public TileDeck tileDeck;
    public Texture2D tst;

    void Start()
    {
        tst = duplicateTexture(tst);

        for(int i = 0; i < spriteList.Count; i++)
        {
            Side temp = new Side();
            Sprite current = spriteList[i];
            Rect position = current.rect;


            temp.top = DetectTop(tst, i, position);
            temp.right = DetectRight(tst, i, position);
            temp.bottom = DetectBottom(tst, i, position);
            temp.left = DetectLeft(tst, i, position);

            Tile newTile = new Tile(i, current, temp);

        // Exceptions of generator
            //if(i == 8 || i == 11 || i == 12 || i == 49 || i == 51)
            //    Debug.Log(i + " - " + newTile.sides.top + newTile.sides.right + newTile.sides.bottom + newTile.sides.left);

            if(i == 8){
                newTile.sides.right = "r";
                newTile.sides.left = "r";
            }
            if(i == 11){
                newTile.sides.right = "g";
            }
            if(i == 12){
                newTile.sides.left = "g";
            }
            if(i == 49){
                newTile.sides.top = "g";
            }
            if(i == 51){
                newTile.sides.bottom = "g";
            }

            if(i != 52)
                tileDeck.AllTiles.Add(newTile);
        }
    }
    string DetectTop(Texture2D text, int id, Rect pos)
    {
        Color[] a = tst.GetPixels((int)pos.x + 130, (int)pos.y + 260, 10, 1);
        return DetectType(a,id);
    }
    string DetectRight(Texture2D text, int id, Rect pos)
    {
        Color[] a = tst.GetPixels((int)pos.x + 260, (int)pos.y + 130, 1, 10);
        return DetectType(a,id);
    }
    string DetectBottom(Texture2D text, int id, Rect pos)
    {
        Color[] a = tst.GetPixels((int)pos.x + 130, (int)pos.y + 10, 10, 1);
        return DetectType(a,id);
    }
    string DetectLeft(Texture2D text, int id, Rect pos)
    {
        Color[] a = tst.GetPixels((int)pos.x + 10, (int)pos.y + 130, 1, 10);
        return DetectType(a,id);
    }

    string DetectType(Color[] col, int id)
    {
        float ma = 0f, fl = 0;
        float sr = 0f, sg = 0f, sb = 0f;
        for(int j = 0; j < 10; j++){
            if(col[j].b > ma) {
                ma = col[j].b;
                fl = j;
            }
            sr += col[j].r;
            sg += col[j].g;
            sb += col[j].b;
        }
        //if(id == 8 || id == 11 || id == 12 || id == 49 || id == 51)
        //    Debug.Log(id.ToString() + " = RED - " + sr.ToString() + " GREEN - " + sg.ToString() + " MaBLUE - " + ma.ToString());
        
        if(ma > 0.6f - 0.0015f * id)
            return "r";
        if(sr > 5.5f - 0.028f * id && sg > 5.5f - 0.028f * id)
            return "g";
        return "f";
    }

    Texture2D duplicateTexture(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);
    
        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }

    bool CheckPair(Tile gen, Tile my)
    {
        if(gen.sides != my.sides)
            return true;
        return false;
    }
}

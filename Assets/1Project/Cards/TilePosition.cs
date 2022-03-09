using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class TilePosition : MonoBehaviour
{
    private Transform _transform => GetComponent<Transform>();
    public Sprite sprite;
    public string top;
    public string right;
    public string bottom;
    public string left;
    
    void Update()
    {
        _transform.position = new Vector3 ((float)((int)_transform.position.x / 2 * 2), (float)((int)_transform.position.y / 2 * 2), 0f);
    }
}

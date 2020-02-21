using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int index;
    public bool praticable = true;

    public int x;
    public int y;
    public Level level;

    public void Init(int _x, int _y, Level _level)
    {
        x = _x;
        y = _y;
        level = _level;

    }
}

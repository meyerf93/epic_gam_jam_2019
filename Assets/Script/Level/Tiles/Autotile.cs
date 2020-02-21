using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autotile : MonoBehaviour
{
    [SerializeField] Tile fullWall;
    [SerializeField] Tile pillar;
    [SerializeField] Tile right;
    [SerializeField] Tile left;
    [SerializeField] Tile bottom;
    [SerializeField] Tile top;
    [SerializeField] Tile topRight;
    [SerializeField] Tile topleft;
    [SerializeField] Tile bottomLeft;
    [SerializeField] Tile bottomRight;


    Tile tile;
    int x;
    int y;
    Level level;
    public void UpdateState()
    {
        tile = GetComponent<Tile>();
        x = tile.x;
        y = tile.y;
        level = tile.level;

        Tile t = null;
        //if (IsSame(1) && IsSame(3) && IsSame(5) && IsSame(0) && !IsSame(6))
        //    t = topRight;

        if (!IsSame(1) && !IsSame(3) && !IsSame(5) && !IsSame(7))
           t = pillar;
        else if (IsSame(1) && IsSame(3) && IsSame(5) && IsSame(7))
            t = fullWall;
        else if (!IsSame(1) && !IsSame(3) && !IsSame(5) && IsSame(7))
            t = left;
        else if (!IsSame(1) && !IsSame(3) && IsSame(5) && !IsSame(7))
            t = bottom;
        else if (!IsSame(1) && IsSame(3) && !IsSame(5) && !IsSame(7))
            t = right;
        else if (IsSame(1) && !IsSame(3) && !IsSame(5) && !IsSame(7))
            t = top;


        else if (!IsSame(1) && IsSame(3) && !IsSame(5) && IsSame(7))
            t = pillar;
        else if (IsSame(1) && !IsSame(3) && IsSame(5) && !IsSame(7))
            t = fullWall;

        else if (!IsSame(1) && !IsSame(3) && IsSame(5) && IsSame(7))
            t = bottomLeft;
        else if (!IsSame(1) && IsSame(3) && IsSame(5) && !IsSame(7))
            t = bottomRight;
        else if (IsSame(1) && IsSame(3) && !IsSame(5) && !IsSame(7))
            t = topRight;
        else if (IsSame(1) && !IsSame(3) && !IsSame(5) && IsSame(7))
            t = topleft;


        else if (IsSame(1) && IsSame(3) && IsSame(5))
            t = fullWall;
        else if (IsSame(1) && IsSame(3) && IsSame(7))
            t = pillar;
        else if (IsSame(1)&& IsSame(5) && IsSame(7))
            t = fullWall;
        else if (IsSame(3) && IsSame(5) && IsSame(7))
            t = fullWall;

        else if (!IsSame(5))
            t = top;
        else if (!IsSame(7))
            t = top;
        else if (!IsSame(1))
            t = bottom;
        else if (!IsSame(3))
            t = top;

        if (t != null)
        {
            level.tiles[new Vector2(x, y)] = Instantiate(t, transform.position, transform.rotation, level.transform);
            t.Init(x, y, level);
            Destroy(gameObject);
        }
        /*
        if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;


        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;


        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;


        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && IsSame(6) && !IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && IsSame(7))
            t = pillar;
        else if (!IsSame(0) && !IsSame(1) && !IsSame(2) && !IsSame(3) && !IsSame(4) && !IsSame(5) && !IsSame(6) && !IsSame(7))
            t = pillar;
            */
    }
    public bool IsSame(int idx)
    {
        switch (idx)
        {
            case 0: return !level.tiles.ContainsKey(new Vector2(x - 1, y + 1)) || level.tiles[new Vector2(x - 1, y + 1)].index == tile.index;
            case 1: return !level.tiles.ContainsKey(new Vector2(    x, y + 1)) || level.tiles[new Vector2(    x, y + 1)].index == tile.index;
            case 2: return !level.tiles.ContainsKey(new Vector2(x + 1, y + 1)) || level.tiles[new Vector2(x + 1, y + 1)].index == tile.index;
            case 3: return !level.tiles.ContainsKey(new Vector2(x + 1,     y)) || level.tiles[new Vector2(x + 1,     y)].index == tile.index;
            case 4: return !level.tiles.ContainsKey(new Vector2(x + 1, y - 1)) || level.tiles[new Vector2(x + 1, y - 1)].index == tile.index;
            case 5: return !level.tiles.ContainsKey(new Vector2(    x, y - 1)) || level.tiles[new Vector2(    x, y - 1)].index == tile.index;
            case 6: return !level.tiles.ContainsKey(new Vector2(x - 1, y - 1)) || level.tiles[new Vector2(x - 1, y - 1)].index == tile.index;
            case 7: return !level.tiles.ContainsKey(new Vector2(x - 1,     y)) || level.tiles[new Vector2(x - 1,     y)].index == tile.index;
        }
        return false;
    }
}

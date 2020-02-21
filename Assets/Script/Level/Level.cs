using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] bool isFirst = false;
    [SerializeField] Tile wall;
    [SerializeField] Tile ground;
    [SerializeField] Tile warp;
    [SerializeField] Tile hole;
    [SerializeField] Tile trampolin;

    [SerializeField] int size = 10;

    [SerializeField] Level upLevel;
    [SerializeField] Level downLevel;
    [SerializeField] int direction;

    public Dictionary<Vector2, Tile> tiles;
    //Dictionary<Vector2, Tile> walls;
    Dictionary<Vector2, Tile> events;
    bool toPlace;
    bool toPlace2;
    Vector2 startPos;
    Vector2 pos1;
    Vector2 pos2;
    float maxDist;
    float maxDist2;

    public static List<Vector2> aroundOffset = new List<Vector2>
    {
        new Vector2(-1,1),
        new Vector2(0,1),
        new Vector2(1,1),
        new Vector2(1,0),
        new Vector2(1,-1),
        new Vector2(0,-1),
        new Vector2(-1,-1),
        new Vector2(-1,0),
    };

    void SetStartPos(Vector2 pos)
    {
        startPos = pos;
    }

    public void SetOpacity(float a)
    {
        foreach(Tile t in tiles.Values)
        {
            t.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, a);
        }
        foreach (Tile t in events.Values)
        {
            t.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, a);
        }
    }

    public void Generate()
    {
        tiles = new Dictionary<Vector2, Tile>();
      //  walls = new Dictionary<Vector2, Tile>();
        events = new Dictionary<Vector2, Tile>();
        Vector2 pos = Vector2.zero;
        toPlace = true;
        toPlace2 = true;
        maxDist = 0;
        maxDist2 = 0;
        RecursiveFill((int)pos.x, (int)pos.y, size);

        List<Vector2> tempList = new List<Vector2>();
        foreach (Vector2 k in tiles.Keys) tempList.Add(k);

        foreach (Vector2 tPos in tempList)
        {
            //put walls
            foreach (Vector2 pos2 in aroundOffset)
            {
                Vector2 wallPos = tPos + pos2;
                if (!tiles.ContainsKey(wallPos)/* && !tempTiles.ContainsKey(wallPos)*/)
                {
                    Tile t2 = Instantiate(wall, wallPos * LevelGenerator.Instance.tileSize, Quaternion.identity, transform);
                    t2.Init((int)wallPos.x, (int)wallPos.y, this);
                    tiles.Add(wallPos, t2);
                }
            }
        }
        tempList.Clear();
        SetOpacity(0);

    }

    public void AddObstacles()
    {
        if (isFirst) return;

        if(direction > 0 && downLevel != null)
        {
            // Holes
            for(int i = 0; i < size/5; i++)
            {
                Vector2 position = GetRandomValidPosition(this, downLevel);
                if (position != new Vector2(int.MaxValue, int.MaxValue))
                {
                    Tile h = Instantiate(hole, position * LevelGenerator.Instance.tileSize, Quaternion.identity, transform);
                    h.Init((int)position.x, (int)position.y, this);
                    tiles[position].praticable = false;
                    events.Add(position, h);
                    tiles.Remove(position);

                    foreach (Vector2 around in aroundOffset)
                    {
                        Vector2 posOff = around + position;
                        if (tiles.ContainsKey(posOff))
                        {
                            tiles[posOff].praticable = false;
                        }
                    }
                }
            }
        }
        else if (direction < 0 && upLevel != null)
        {
            // Tramplin
            for (int i = 0; i < size / 5; i++)
            {
                Vector2 position = GetRandomValidPosition(this, upLevel);
                if (position != new Vector2(int.MaxValue, int.MaxValue))
                {
                    Tile t = Instantiate(trampolin, position * LevelGenerator.Instance.tileSize, Quaternion.identity, transform);
                    t.Init((int)position.x, (int)position.y, this);
                    tiles[position].praticable = false;
                    events.Add(position, t);
                    tiles[position].gameObject.SetActive(false);
                    /*
                    foreach (Vector2 around in aroundOffset)
                    {
                        Vector2 posOff = around + position;
                        if (tiles.ContainsKey(posOff))
                        {
                            tiles[posOff].praticable = false;
                        }
                    }*/
                }
            }
        }

    }

    Vector2 GetRandomValidPosition(Level smaller, Level larger)
    {
        bool trying = true;
        int counter = 1000;
        int changeCounter;
        while(trying && counter-- > 0)
        {
            Vector2 randPos = new Vector2(Random.Range(-smaller.size, smaller.size), Random.Range(-smaller.size, smaller.size));
            if (smaller.tiles.ContainsKey(randPos) && smaller.tiles[randPos].praticable &&
                larger.tiles.ContainsKey(randPos) && larger.tiles[randPos].praticable &&
                !smaller.events.ContainsKey(randPos) && !larger.events.ContainsKey(randPos))
            {
                //Check if it dosen't block a path
                changeCounter = 0;
                for(int i = 1; i < aroundOffset.Count; i++)
                {
                    if (smaller.tiles[randPos + aroundOffset[i]].praticable != smaller.tiles[randPos + aroundOffset[i - 1]].praticable)
                    {
                        changeCounter++;
                    }
                }
                
                if(changeCounter <= 2)
                    return randPos;
            }
        }
        return new Vector2(int.MaxValue, int.MaxValue);
    }

    public void MakeStartLinks()
    {

        Vector2 maxKey = GetFurtherEmptyCase(this, upLevel, Vector2.zero);
        BuildLink(this, upLevel, maxKey, 1);

        Vector2 maxKey2 = GetFurtherEmptyCase(this, downLevel, maxKey);
        BuildLink(this, downLevel, maxKey2, -1);

        upLevel.MakeLink(maxKey);
        downLevel.MakeLink(maxKey2);
    }

    public void MakeLink(Vector2 startPosition)
    {
        if(direction > 0)
        {
            MakeLink(this, upLevel, startPosition, direction);
        }
        else if (direction < 0)
        {
            MakeLink(this, downLevel, startPosition, direction);
        }
    }

    public void MakeLink(Level lv1, Level lv2, Vector2 startPosition, int direction)
    {
        Vector2 warpPos = GetFurtherEmptyCase(lv1, lv2, startPosition);
        BuildLink(lv1, lv2, warpPos, direction);
        if(lv2 != null)
            lv2.MakeLink(warpPos);
    }

    Vector2 GetFurtherEmptyCase(Level lv1, Level lv2, Vector2 position)
    {
        float maxDist = 0;
        Vector2 maxKey = Vector2.zero;
        foreach (Vector2 key in lv1.tiles.Keys)
        {
            if (lv1.tiles[key].praticable && (lv2==null || (lv2.tiles.ContainsKey(key) && lv2.tiles[key].praticable)))
            {
                float tempDist = Vector2.Distance(position, key);
                if (tempDist > maxDist)
                {
                    maxDist = tempDist;
                    maxKey = key;
                }
            }
        }
        return maxKey;
    }

    void BuildLink(Level lv1, Level lv2, Vector2 position, int direction)
    {
        if (lv1 != null)
        {
            Tile warp1 = Instantiate(warp, position * LevelGenerator.Instance.tileSize, Quaternion.identity, lv1.transform);
            warp1.Init((int)position.x, (int)position.y, this);
            warp1.GetComponent<Warp>().SetDirection(direction);
            lv1.events.Add(position, warp1);

            foreach(Vector2 around in aroundOffset)
            {
                Vector2 posOff = around + position;
                if (tiles.ContainsKey(posOff))
                {
                    tiles[posOff].praticable = false;
                }
            }
        }

        if (lv2 != null)
        {
            Tile warp2 = Instantiate(warp, position * LevelGenerator.Instance.tileSize, Quaternion.identity, lv2.transform);
            warp2.Init((int)position.x, (int)position.y, this);
            warp2.GetComponent<Warp>().SetDirection(-direction);
            lv2.events.Add(position, warp2);

            foreach (Vector2 around in aroundOffset)
            {
                Vector2 posOff = around + position;
                if (tiles.ContainsKey(posOff))
                {
                    tiles[posOff].praticable = false;
                }
            }
        }
    }

    void RecursiveFill(int x, int y, int counter)
    {
        Vector2 pos = new Vector2(x, y);
        List<Vector2> adjacentTiles = new List<Vector2>{
            new Vector2(x, y+1),
            new Vector2(x-1, y),
            new Vector2(x+1, y),
            new Vector2(x, y-1)
        };
        List<Vector2> adjacentTiles2 = new List<Vector2>{
            new Vector2(x, y+1),
            new Vector2(x-1, y),
            new Vector2(x+1, y),
            new Vector2(x, y-1),
            new Vector2(x+1, y+1),
            new Vector2(x-1, y+1),
            new Vector2(x+1, y-1),
            new Vector2(x-1, y-1)
        };

        if (!tiles.ContainsKey(pos))
        {
            Tile t = Instantiate(ground, pos * LevelGenerator.Instance.tileSize, Quaternion.Euler(0, 0, Random.Range(0, 4) * 90), transform);
            t.Init((int)pos.x, (int)pos.y, this);
            tiles.Add(pos, t);
            if (counter > 0)
            {
                for (int i = 0; i < adjacentTiles.Count; i++)
                {
                    Vector2 temp = adjacentTiles[i];
                    int randomIndex = Random.Range(i, adjacentTiles.Count);
                    adjacentTiles[i] = adjacentTiles[randomIndex];
                    adjacentTiles[randomIndex] = temp;
                }
                //put ground
                counter -= Random.Range(1, 4);
                foreach (Vector2 pos2 in adjacentTiles)
                {
                    RecursiveFill((int)pos2.x, (int)pos2.y, counter);
                }
            }
            else
            {
                //put walls
                foreach (Vector2 pos2 in adjacentTiles2)
                {
                    if (!tiles.ContainsKey(pos2)/* && !tempTiles.ContainsKey(wallPos)*/)
                    {
                        Tile t2 = Instantiate(wall, pos2 * LevelGenerator.Instance.tileSize, Quaternion.identity, transform);
                        t2.Init((int)pos2.x, (int)pos2.y, this);
                        tiles.Add(pos2, t2);
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Room : MonoBehaviour
{
    [SerializeField] Tile wall;
    [SerializeField] Tile ground;

    public Dictionary<Vector2, Tile> tiles;

    private void Update()
    {
        foreach(Tile tile in GetComponentsInChildren<Tile>())
        {
            tile.transform.position = RoundedPosition(tile.transform.position);
        }
    }

    Vector2 RoundedPosition(Vector2 pos)
    {
        int posX = (int)((pos.x + 0.1f) / LevelGenerator.Instance.tileSize);
        int posY = (int)((pos.y + 0.1f) / LevelGenerator.Instance.tileSize);
        return new Vector2(posX, posY) * LevelGenerator.Instance.tileSize;
    }

    public void GenerateRoom(int size)
    {
        tiles = new Dictionary<Vector2, Tile>();

        int x = 0;
        int y = 0;
        bool notComplete = true;
        int direction = 0;
        // WALLS
        while (notComplete)
        {
            Vector2 pos = new Vector2(x, y);

            if (tiles.ContainsKey(pos))
            {
                notComplete = false;
            }
            else
            {
                Tile t = Instantiate(wall, pos * LevelGenerator.Instance.tileSize, Quaternion.identity, transform);
                tiles.Add(pos, t);
            }

            switch (direction)
            {
                case 0: x++; break;
                case 1: y++; break;
                case 2: x--; break;
                case 3: y--; break;
            }


            if (x == size && direction == 0) direction++;
            else if (y == size && direction == 1) direction++;
            else if (x == 0 && direction == 2) direction++;

        }

        //FILL ROOM
        FillRoom(1, 1);
    }

    void FillRoom(int x, int y)
    {
        Vector2 pos = new Vector2(x, y);
        List<Vector2> adjacentTiles = new List<Vector2>{
            new Vector2(x, y+1),
            new Vector2(x-1, y),
            new Vector2(x+1, y),
            new Vector2(x, y-1)
        };

        if (!tiles.ContainsKey(pos))
        {
            Tile t = Instantiate(ground, pos * LevelGenerator.Instance.tileSize, Quaternion.identity, transform);
            tiles.Add(pos, t);
        }

        foreach (Vector2 adjPos in adjacentTiles)
            if (!tiles.ContainsKey(adjPos))
            {
                FillRoom((int)adjPos.x, (int)adjPos.y);
            }

    }
}

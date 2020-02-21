using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    public static UnityEvent onChangeLevel = new UnityEvent();
    [SerializeField] int NumberOfRooms = 1;
    public int levelSize = 50;

    public float tileSize = 0.16f;
    [SerializeField] Room roomPrefab;
    [SerializeField] Tile wall;
    [SerializeField] Tile ground;

    [SerializeField] List<Level> levels;
    [SerializeField] Level startLevel;
    [SerializeField] GameObject transitionPanel;

    public AudioSource victorySnd;
    public int level = 0;
    public int GetLevel { get { return level - 5; } }
    public Level GetCurentLevel { get { return levels[level]; } }
    // int roomIdx = 0;

    Dictionary<Vector2, Tile> newTiles;

    public static LevelGenerator Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //startLevel.Generate();

        foreach (Level l in levels)
            l.Generate();

        startLevel.MakeStartLinks();


        foreach (Level l in levels)
            l.AddObstacles();

        foreach (Autotile at in GetComponentsInChildren<Autotile>(true))
        {
            at.UpdateState();
        }
        level = levels.Count / 2 + 1;
        ChangeLevel(level - 1);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.U))
        {
            ChangeLevel(level + 1);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            ChangeLevel(level - 1);
        }*/
    }

    public void ChangeLevel(int idx)
    {
        onChangeLevel.Invoke();
        if (idx >= levels.Count || idx < 0)
        {
            StartCoroutine(VictoryScene());
			return;
        }
        StartCoroutine(ChangeCamera(level, idx));
        level = idx;
    }

    IEnumerator VictoryScene()
    {
        victorySnd.Play();
        transitionPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Fin");

    }

    IEnumerator ChangeCamera(int current, int next)
    {
        levels[next].gameObject.SetActive(true);
        for (float t = 0; t < 0.5f; t+=Time.deltaTime)
        {
            if (current != next)
            {
                levels[current].SetOpacity(1f - t * 2f);
                levels[next].SetOpacity(t * 2f);
                float lerp = Mathf.Lerp(Mathf.Abs(current - 5), Mathf.Abs(next - 5), t * 2f);
                Camera.main.orthographicSize = 10 + (lerp * 3f);
            }
            yield return null;
        }
        if (current != next)
        {
            levels[current].SetOpacity(0);
            levels[next].SetOpacity(1);
            levels[current].gameObject.SetActive(false);
        }
        Camera.main.orthographicSize = 10 + Mathf.Abs((next-5)*3f);
    }
    public void Move(int direction)
    {
        ChangeLevel(level + direction);
    }


    /*
    Dictionary<Vector2, Tile> RoomTiles()
    {
        return levels[level].rooms[roomIdx].tiles;
    }

    
    void GenerateLevel(int lvl)
    {
        level = lvl;
        for (int i = 0; i < NumberOfRooms; i++)
        {
            roomIdx = i;
            GenerateRoom(Random.Range(1, 6)*5);
        }
    }

    void GenerateRoom(int size)
    {
        Room room = Instantiate(roomPrefab, transform);
        room.GenerateRoom(size);
    }

    bool CheckNext(Vector2 pos, int direction)
    {
        switch (direction)
        {
            case 0: return RoomTiles().ContainsKey(pos + Vector2.right);
            case 1: return RoomTiles().ContainsKey(pos + Vector2.up);
            case 2: return RoomTiles().ContainsKey(pos + Vector2.left);
            case 3: return RoomTiles().ContainsKey(pos + Vector2.down);
        }
        return false;
    }


    void GenerateRoomV2(int size)
    {
        int maxI = Random.Range(0, 6);
        for(int i = 0; i <= maxI; i++)
        {
            int maxX = Random.Range(5, 11);
            int maxY = Random.Range(5, 11);
            int startX = Random.Range(-10, -4);
            int startY = Random.Range(-10, -4);

            for(int x = startX; x <= maxX; x++)
            {
                for (int y = startY; y <= maxY; y++)
                {
                    if(RoomTiles().ContainsKey(new Vector2(x, y)))
                    {

                    }
                }

            }

        }
    }


    void AddBump(int direction, Vector2 start, Vector3 last)
    {
        Vector2 size = new Vector2(Random.Range(1, 4), Random.Range(1, 4));

    }
    
    void NewGeneration()
    {
        newTiles = new Dictionary<Vector2, Tile>();

        for(int x = 0; x <= levelSize; x++)
        {
            for(int y = 0; y <= levelSize; y++)
            {
                Vector2 pos = new Vector2(x, y);
                float z = Mathf.PerlinNoise(pos.x / 10f, pos.y / 10f) - Mathf.PerlinNoise((pos.x+30) / 10f, pos.y / 10f)*0.15f + Mathf.Pow(Vector2.Distance(new Vector2(levelSize/2, levelSize/2), pos)/(levelSize/2), 4);
                if(z > 0.55f)
                {
                    Tile t = Instantiate(wall, pos * LevelGenerator.tileSize, Quaternion.identity, transform);
                    newTiles.Add(pos, t);
                }
                else
                {
                    Tile t = Instantiate(ground, pos * LevelGenerator.tileSize, Quaternion.identity, transform);
                    newTiles.Add(pos, t);
                }
            }
        }
    }
    */

    }

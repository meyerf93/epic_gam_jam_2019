using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<MonsterAI> monsterPrefabls;


    List<MonsterAI> monsters = new List<MonsterAI>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        LevelGenerator.onChangeLevel.AddListener(() => ClearMonsters());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(20f);
        while (true)
        {
			MonsterAI monster = Instantiate(monsterPrefabls[Random.Range(0,monsterPrefabls.Count)], player.transform.position + new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f),0).normalized*Random.Range(15f,24f), Quaternion.identity, transform);
            monster.SetTarget(player);
            monsters.Add(monster);
            yield return new WaitForSeconds(Random.Range(8f, 15f) - LevelGenerator.Instance.GetLevel);
        }
    }

    void ClearMonsters()
    {
        foreach(MonsterAI m in monsters)
        {
            Destroy(m.gameObject);
        }
        monsters.Clear();
    }


}

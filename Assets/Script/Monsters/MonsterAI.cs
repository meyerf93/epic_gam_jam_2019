using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{

    GameObject target;
    float speed;
    float timer;
    float frequancy;
    float speedFactor;
    // Start is called before the first frame update
    void Start()
    {
        frequancy = Random.Range(0f, 10f);
        speedFactor = Random.Range(5f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * frequancy;
        speed = (Mathf.Sin(timer)+1.2f)* speedFactor;
        Vector3 direction = (target.transform.position - transform.position + new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f))*0.5f).normalized;

        transform.position += Time.deltaTime * speed * direction;

        if (Random.Range(0f,1f) > 0.99f)
        {
            frequancy = Random.Range(0f, 10f);
            speedFactor = Random.Range(5f, 8f);
        }

    }

    public void SetTarget(GameObject player)
    {
        target = player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		int actual_level = LevelGenerator.Instance.GetLevel;
		SceneManagerLevel.Instance.setLevelTransition(actual_level, 0 );

        if (collision.tag == "Player" && !MovementPlayer.lockControls)
        {
            collision.transform.parent.Find("GhostHitSound").GetComponent<AudioSource>().Play();
            LevelGenerator.Instance.ChangeLevel(5);
            target.transform.position = Vector3.zero;
        }
    }
}

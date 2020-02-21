using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] Sprite moveDown;
    int direction;
    static bool warped = false;

    public void SetDirection(int dir)
    {
        direction = dir;
        if(dir < 0)
        {
            GetComponent<SpriteRenderer>().sprite = moveDown;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {



        if(collision.tag == "Player" && !warped && !MovementPlayer.lockControls)
        {
            GetComponentInChildren<AudioSource>().Play();
            int actual_level = LevelGenerator.Instance.GetLevel;
            SceneManagerLevel.Instance.setLevelTransition(actual_level, actual_level + direction);
        
            //LevelGenerator.Instance.StartCoroutine(fallAnimManagement(collision));
            //collision.GetComponentInParent<Animator>().SetTrigger("Stair");
            //+ transition effect
            collision.gameObject.transform.parent.transform.position = transform.position;
            LevelGenerator.Instance.Move(direction);
            warped = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && warped)
        {
            warped = false;
        }
    }
}

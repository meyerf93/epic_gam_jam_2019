using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramplin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !MovementPlayer.lockControls)
        {
            GetComponentInChildren<AudioSource>().Play();
            LevelGenerator.Instance.StartCoroutine(fallAnimManagement(collision));
        }
    }

    IEnumerator fallAnimManagement(Collider2D collision)
    {
        MovementPlayer.lockControls = true;

		int actual_level = LevelGenerator.Instance.GetLevel;
        SceneManagerLevel.Instance.setLevelTransition(actual_level, actual_level + 1);

        collision.GetComponentInParent<Animator>().SetTrigger("Jump");
        Vector3 start = collision.gameObject.transform.parent.transform.position;
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            Vector3 lerp = Vector3.Lerp(start, transform.position, t * 2f);
            collision.gameObject.transform.parent.transform.position = lerp;
            yield return null;
        }
        collision.gameObject.transform.parent.transform.position = transform.position;
        MovementPlayer.lockControls = false;
        LevelGenerator.Instance.Move(1);
    }
}

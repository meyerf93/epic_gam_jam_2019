using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrace : MonoBehaviour
{
    [SerializeField] List<GameObject> markersA;
    [SerializeField] List<GameObject> markersB;
    [SerializeField] int maxDrop = 100;
    [SerializeField] AudioSource sound;
    List<GameObject> putDown = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            sound.Play();
            GameObject go = Instantiate(markersA[Random.Range(0, markersA.Count)], transform.position, Quaternion.identity, LevelGenerator.Instance.GetCurentLevel.transform);
            putDown.Add(go);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            sound.Play();
            GameObject go = Instantiate(markersB[Random.Range(0, markersB.Count)], transform.position, Quaternion.identity, LevelGenerator.Instance.GetCurentLevel.transform);
            putDown.Add(go);
        }
        if (putDown.Count > maxDrop)
        {
            Destroy(putDown[0]);
            putDown.RemoveAt(0);
        }
    }
}

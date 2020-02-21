using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOpacityOnStart : MonoBehaviour
{
    [SerializeField] bool show;
    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

        if (show)
            StartCoroutine(Show());
        else
            StartCoroutine(Hide());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Show()
    {
        for (float t = 0; t < .5f; t += Time.deltaTime)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, t*2f);
            yield return null;
        }
        img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
    }

    IEnumerator Hide()
    {
        for (float t = 0; t < .5f; t += Time.deltaTime)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 1f-t*2f);
            yield return null;
        }
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
    }
}

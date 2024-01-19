using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScale : MonoBehaviour
{
    public GameObject sagetuta;
    public Text text;
    public void OnPointerEnter()
    {
        text.color = new Color(1, 1, 1, 1);
        transform.localScale = new Vector2(1.15f, 1.15f);
        sagetuta.SetActive(true);
    }
    public void OnPointerExit()
    {
        text.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1);
        transform.localScale = new Vector2(1f, 1f);
        sagetuta.SetActive(false);
    }
}

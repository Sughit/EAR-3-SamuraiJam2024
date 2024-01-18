using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScale : MonoBehaviour
{
    public GameObject sagetuta;
    public void OnPointerEnter()
    {
        transform.localScale = new Vector2(1.15f, 1.15f);
        sagetuta.SetActive(true);
    }
    public void OnPointerExit()
    {
        transform.localScale = new Vector2(1f, 1f);
        sagetuta.SetActive(false);
    }
}

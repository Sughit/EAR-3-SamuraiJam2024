using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparTaieturi : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Active());
    }
    IEnumerator Active()
    {
        yield return new WaitForSeconds(0.12f);
        this.gameObject.SetActive(false);
    }

}

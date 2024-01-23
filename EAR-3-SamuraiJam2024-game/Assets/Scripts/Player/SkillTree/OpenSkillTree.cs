using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSkillTree : MonoBehaviour
{
    public GameObject skillGO;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(!GameManager.gameStarted) skillGO.SetActive(!skillGO.activeSelf);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blood : MonoBehaviour
{
    public static Blood instance;
    public Canvas canvas;
    public GameObject blood;

    void Awake()
    {
        instance=this;
    }

    public void SpawnBlood()
    {
        var bloodGO = Instantiate(blood, new Vector3(Random.Range(0, 2000), Random.Range(0, 1000), 0), Quaternion.Euler(0, 0, Random.Range(0, 360)));
        bloodGO.transform.SetParent(canvas.gameObject.transform);
        bloodGO.transform.localScale = new Vector3(Random.Range(.5f, 1.5f), Random.Range(.5f, 1.5f), 1);
    }

    public void DeleteBlood()
    {
        foreach(Transform blood in canvas.transform)
        {
            if(blood.gameObject.tag == "Blood") blood.GetComponent<BloodGO>().DestroyBlood();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTreeDark : MonoBehaviour
{
    public SpriteRenderer tree1, tree2;
    
    public void Night()
    {
        tree1.color = new Color(0, 0, 0, 255);
        tree2.color = new Color(0, 0, 0, 255);
    }

    public void Day()
    {
        tree1.color = new Color(255, 255, 255, 255);
        tree2.color = new Color(255, 255, 255, 255);
    }
}

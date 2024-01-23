using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public void Shuriken1()
    {
        if(GetComponent<UnlockSkills>().cost <= UnlockSkills.numSkillPoints)
        {
            PlayerAttack.canShurikenAttack=true;
        }
    }

    public void Shuriken2()
    {
        if(GetComponent<UnlockSkills>().cost <= UnlockSkills.numSkillPoints)
        {
            PlayerAttack.can2ShurikenAttack=true;
        }
    }

    public void Shuriken3()
    {
        if(GetComponent<UnlockSkills>().cost <= UnlockSkills.numSkillPoints)
        {
            PlayerAttack.can3ShurikenAttack=true;
        }
    }
}

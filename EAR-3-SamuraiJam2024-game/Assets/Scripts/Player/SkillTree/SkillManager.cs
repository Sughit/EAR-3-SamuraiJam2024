using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public void Heal()
    {
        if(GetComponent<UnlockSkills>().cost <= UnlockSkills.numSkillPoints)
        {
            if(GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().health < GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().maxHealth)
            {
                if(GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().health <= GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().maxHealth - 10f)
                {
                    GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().health += 10f;
                    UnlockSkills.numSkillPoints -= GetComponent<UnlockSkills>().cost;
                }
                else 
                {
                    GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().health = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().maxHealth;
                    UnlockSkills.numSkillPoints -= GetComponent<UnlockSkills>().cost;
                }
            }
        }
    }

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

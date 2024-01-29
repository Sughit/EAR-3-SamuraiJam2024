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

    public void HeavyRate()
    {
        if(GetComponent<UnlockSkills>().cost <= UnlockSkills.numSkillPoints)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerAttack>().attackHeavyRate = 1.4f;
        }
    }

    public void LightRate()
    {
        if(GetComponent<UnlockSkills>().cost <= UnlockSkills.numSkillPoints)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerAttack>().attackRate = 0.3f;
        }
    }

    public void HeavyDamage()
    {
        if(GetComponent<UnlockSkills>().cost <= UnlockSkills.numSkillPoints)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerAttack>().heavyDamage = 10f;
        }
    }

    public void LightDamage()
    {
        if(GetComponent<UnlockSkills>().cost <= UnlockSkills.numSkillPoints)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerAttack>().lightDamage = 5f;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockSkills : MonoBehaviour
{
    public Button[] nextSkills;
    public GameObject[] inactives;
    bool canUnlockCurrentSkill=true;
    public Image usedBtnImage;
    public int cost = 1;
    public Text costText;
    public Text skillPointsText;

    public static int numSkillPoints=10;

    void Start()
    {
        costText.text = $"Cost: {cost}";
        skillPointsText.text = $"Skill Points: {numSkillPoints}";
    }

    void Update()
    {
        skillPointsText.text = $"Skill Points: {numSkillPoints}";
    }

    public void UnlockSkill()
    {
        if(canUnlockCurrentSkill && cost <= numSkillPoints)
        {
            if(nextSkills.Length > 0) 
            {
                foreach(var nextSkill in nextSkills)
                {
                    nextSkill.gameObject.SetActive(true);
                }
                foreach(var inactive in inactives)
                {
                    inactive.SetActive(false);
                }
            }
            usedBtnImage.gameObject.SetActive(true);
            Debug.Log("Skill unlocked");
            canUnlockCurrentSkill=false;
            numSkillPoints -= cost;
            skillPointsText.text = $"Skill Points: {numSkillPoints}";
        }
    }
}

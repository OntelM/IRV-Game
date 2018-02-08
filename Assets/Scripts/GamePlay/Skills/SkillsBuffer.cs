using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class SkillsBuffer : MonoBehaviour {

    



    public void Skill(int id, int powerID)
    {
        switch (id)
        {
            case 0:
                FireSkill(powerID);
                break;
            case 1:
                WaterSkill(powerID);
                break;
            case 2:
                EarthSkill(powerID);
                break;
            case 3:
                EarSkill(powerID);
                break;
            default:

                break;
        }
    }


    //   Categorii Skilluri

    private void FireSkill(int powerID)
    {
        switch (powerID)
        {
            case 0:
                FireSkillNameSkill();
                break;
            default:

                break;
        }
    }
    private void WaterSkill(int powerID)
    {

    }
    private void EarthSkill(int powerID)
    {

    }
    private void EarSkill(int powerID)
    {

    }

    //Skilluri

    private void FireSkillNameSkill()
    {

    }


}

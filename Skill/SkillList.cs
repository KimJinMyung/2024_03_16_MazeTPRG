using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Skill
{
    internal class SkillList
    {
        private Dictionary<Skill, SkillClass> skillList;

        public Dictionary<Skill,SkillClass> GetSkillList { get { return skillList; } }

        public SkillList() 
        {
            skillList = new Dictionary<Skill, SkillClass>();
            skillList.Add(Skill.MegaSlash, new Skill_A_MegaSlash());
            skillList.Add(Skill.AnkleSlit, new Skill_B_AnkleSlit());
            skillList.Add(Skill.Bleeding, new Skill_C_Bleeding());
        }               

        public void skillCoolTimeMinus(int battleCount)
        {            
            foreach (var item in skillList)
            {
                item.Value.SetBattleCount(battleCount);
            }
        }
    }
}

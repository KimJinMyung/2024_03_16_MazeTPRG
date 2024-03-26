using MazeTPRG.Monster;
using MazeTPRG.Monster.MonsterListManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Skill
{
    internal class Skill_A_MegaSlash : SkillClass
    {

        public Skill_A_MegaSlash()
        {
            this.skillName = "메가 슬래시";
            this.EffectValue = Player.GetATK * 1.8;
            this.UseMana = 30;
            this.SkillCoolTime = 0;
        }

        public override bool SkillEffect(int monsterIndex)
        {
            if (SkillCoolTime != 0) 
            {
                Console.WriteLine($"{SkillCoolTime}턴 후에 사용 가능");
                Thread.Sleep(1500);
                return false;
            }

            if (Player.GetCurrentMP < UseMana)
            {
                Console.WriteLine($"마나가 부족합니다.");
                Thread.Sleep(1500);
                return false;
            }

            Player.HealMP(-UseMana);
            Console.WriteLine($"{this.skillName} 시전!!!");
            //강력한 데미지
            bool KillMonster = PlayerBattleMonsterList.GetBattleMonster(monsterIndex).Hurt(this.EffectValue);
            
            //쿨타임 3턴
            SkillCoolTime = 4;

            if (KillMonster)
            {
                Player.AddCurrentEXP(monsterIndex+1);
            }return true;
        }
    }
}

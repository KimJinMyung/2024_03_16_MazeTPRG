using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Skill
{
    internal class Skill_C_Bleeding : SkillClass
    {
        private int TargetIndex;
        private double SpeedDownValue;
        private bool IsEffectDuaration;

        public Skill_C_Bleeding()
        {
            this.skillName = "출혈 부여";
            this.UseMana = 20;
            this.SpeedDownValue = 0;
            //스킬 쿨타임
            this.SkillCoolTime = 0;
            //지속 턴
            this.EffectDuration = 6;
        }

        public override bool SkillEffect(int monsterIndex)
        {
            this.Target = PlayerBattleMonsterList.GetBattleMonster(monsterIndex);
            this.TargetIndex = monsterIndex;
            this.EffectValue = Target.GetHP * 0.05;

            if (SkillCoolTime != 0)
            {
                Console.WriteLine($"{SkillCoolTime}턴 후에 사용 가능");
                Thread.Sleep(1500);
                return false;
            }            

            Player.HealMP(-UseMana);
            Console.WriteLine($"{this.skillName} 시전!!!\n");         

            //50% 확률로 부여 성공
            int skillSuccess = new Random().Next(100);
            if (skillSuccess >= 50)
            { 
                Console.WriteLine("부여 성공!!!");
                this.IsEffectDuaration = true; 
            }else
            {
                Console.WriteLine("부여 실패!!!");
                this.IsEffectDuaration = false;
            }

            //쿨타임 3턴
            SkillCoolTime = 4;
            
            return true;
        }

        public override void UseSkillEffect() 
        {
            if (IsEffectDuaration)
            {
                Bleeding(TargetIndex);
            }            
        }

        public void Bleeding(int monsterIndex)
        {
            if (this.EffectDuration == 0) return;

            Console.WriteLine("출혈 발생!!");
            bool KillMonster = Target.Hurt(this.EffectValue);
            Thread.Sleep(1500);

            if (KillMonster)
            {
                Player.AddCurrentEXP(monsterIndex + 1);
            }
        }

        public override void EndSkillEffect()
        {
            if (!this.UseSkill) return;
            if (Target != PlayerBattleMonsterList.GetBattleMonster(TargetIndex)) return;
            if (PlayerBattleMonsterList.GetBattleMonster(TargetIndex) == default) return;
            this.IsEffectDuaration = false;
            Console.WriteLine($"{this.skillName}의 지속시간이 끝났습니다.\n");
            Console.WriteLine("=============================");
            Console.WriteLine($"{Target.GetMonsterName}의 현재 속도 : {Target.GetSpeed}");
            Console.WriteLine("=============================\n");
        }
    }
}

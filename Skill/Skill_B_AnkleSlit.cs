using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Skill
{
    internal class Skill_B_AnkleSlit : SkillClass
    {
        private int TargetIndex;
        private double SpeedDownValue;

        public Skill_B_AnkleSlit()
        {
            this.skillName = "발목 긋기";
            this.EffectValue = Player.GetATK * 0.5;
            this.UseMana = 15;
            this.SpeedDownValue = 0;
            //스킬 쿨타임
            this.SkillCoolTime = 0;
            //지속 턴
            this.EffectDuration = 3;
        }

        public override bool SkillEffect(int monsterIndex)
        {            
            this.Target = PlayerBattleMonsterList.GetBattleMonster(monsterIndex);
            this.TargetIndex = monsterIndex;

            if (SkillCoolTime != 0)
            {
                Console.WriteLine($"{SkillCoolTime}턴 후에 사용 가능");
                Thread.Sleep(1500);
                return false;
            }

            Player.HealMP(-UseMana);
            Console.WriteLine($"{this.skillName} 시전!!!\n");
            //소량의 데미지
            bool KillMonster = Target.Hurt(this.EffectValue);

            SpeedSlow(monsterIndex);

            //쿨타임 2턴
            SkillCoolTime = 3;

            if (KillMonster)
            {
                Player.AddCurrentEXP(monsterIndex + 1);
            }
            return true;
        }

        public void SpeedSlow(int monsterIndex)
        {
            this.UseSkill = true;
            //감소시키는 수치 저장
            SpeedDownValue = Target.GetSpeed * 0.5;

            //부가 효과 텍스트
            Console.WriteLine($"{Target.GetMonsterName}의 속도가 {SpeedDownValue}만큼 감소하였습니다.\n");            

            //몬스터 스피드 50% 감소
            Target.SpeedValueTrans(SpeedDownValue);
        }

        public override void EndSkillEffect()
        {
            if (!this.UseSkill) return;
            if(Target != PlayerBattleMonsterList.GetBattleMonster(TargetIndex)) return;
            if (PlayerBattleMonsterList.GetBattleMonster(TargetIndex) == default) return;
            Target.SpeedValueTrans(-SpeedDownValue);
            Console.WriteLine($"{this.skillName}의 지속시간이 끝났습니다.\n");            
        }

    }
}

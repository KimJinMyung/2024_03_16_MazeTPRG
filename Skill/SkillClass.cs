using MazeTPRG.Monster;
using MazeTPRG.Monster.MonsterListManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Skill
{
    internal abstract class SkillClass
    {
        protected string skillName;
        protected double EffectValue;
        protected double UseMana;
        protected Player Player;
        protected BattleMonsterList PlayerBattleMonsterList;
        protected int BattleCount = 0;
        protected int SkillCoolTime;
        protected int EffectDuration;
        protected bool UseSkill = false;

        protected Monster.Monster Target;

        public SkillClass()
        {
            this.Player = Player.Instance;
            PlayerBattleMonsterList = Player.GetBattleMonsterList;
        }
        public string GetName {  get; }
        public abstract bool SkillEffect(int monsterIndex);

        //쿨타임 감소
        public void SetBattleCount(int battleCount)
        {
            if (this.BattleCount != battleCount) 
            {
                this.BattleCount = battleCount;
                SkillCoolTime--;
                if (SkillCoolTime <= 0) SkillCoolTime = 0;
                EffectDuration--;
                if (EffectDuration <= 0) 
                {
                    EndSkillEffect();
                    EffectDuration = 0;
                }
                else
                {
                    UseSkillEffect();
                }
            }            
        }

        public virtual void EndSkillEffect() { }
        public virtual void UseSkillEffect() { }

        public double GetEffectDuration {  get { return EffectDuration; } }
    }
}

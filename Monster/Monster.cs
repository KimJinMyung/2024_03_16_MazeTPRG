using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazeTPRG.Monster
{
    internal abstract class Monster : IMonsterAction
    {
        protected string Name = string.Empty;
        protected double HP;
        protected double ATK;
        protected double Defense;
        protected int GiveEXP;
        protected bool isDead = false;

        protected string SkillName = string.Empty;
        protected double SkillDamage;

        public string GetMonsterName { get {  return Name; } }
        public double GetHP { get { return HP; } } 

        public int GetGiveEXP {  get { return GiveEXP; } }

        public bool Hurt(double damage)
        {
            double currentHP = this.HP;
            this.HP -= (damage - (damage * Defense / 100));
            if (this.HP <= 0) isDead = true;
            else isDead = false;
            Console.WriteLine($"{Name}이/가 {Math.Round(currentHP - HP,2)}의 피해를 입었습니다.");
            return isDead;
        }

        public abstract Monster Clone();

        public abstract bool Attack(Player player);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MazeTPRG.Monster.Ork
{
    internal class Ork : Monster
    {
        public Ork()
        {
            Name = "오크";
            HP = 150;
            ATK = 20;
            Defense = 5;
            GiveEXP = 20;

            SkillName = "내려찍기";
            SkillDamage = 30;
        }

        public override Monster Clone()
        {
            return new Ork();
        }

        public bool CommonAttack(Player player)
        {
            bool BattleEnd = false;
            bool isKillPlayer = player.Hurt(ATK);
            if (isKillPlayer) BattleEnd = true;
            else BattleEnd = false;
            Console.WriteLine($"{Name}의 공격!!");
            return BattleEnd;
        }

        public bool SkillAttack(Player player)
        {
            bool BattleEnd = false;
            bool isKillPlayer = player.Hurt(SkillDamage);
            if (isKillPlayer) BattleEnd = true;
            else BattleEnd = false;
            Console.WriteLine($"{Name}이 강력한 공격을 시전합니다.");
            Console.WriteLine($"{Name}의 {SkillName}!!!");
            return BattleEnd;
        }

        public override bool Attack(Player player)
        {
            bool BattleEnd = false;

            int AttackTypePer = new Random().Next(100);

            if (AttackTypePer <= 20) BattleEnd = SkillAttack(player);
            else BattleEnd = CommonAttack(player);

            return BattleEnd;
        }
    }
}

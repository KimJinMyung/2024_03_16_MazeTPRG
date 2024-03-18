using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Monster.Gobline
{
    internal class Gobline : Monster
    {

        public Gobline()
        {
            Name = "고블린";
            HP = 100;
            ATK = 15;
            Defense = 3;
            Speed = 5;
            GiveEXP = 10;

            SkillName = "급습";
            SkillDamage = 25;
        }

        public override Monster Clone()
        {
            return new Gobline();
        }

        public bool CommonAttack(Player player)
        {
            bool BattleEnd = false;
            Console.WriteLine($"{Name}의 공격!!\n");
            bool isKillPlayer = player.Hurt(ATK);
            if (isKillPlayer) BattleEnd = true;
            else BattleEnd = false;
            return BattleEnd;
        }

        public bool SkillAttack(Player player)
        {
            bool BattleEnd = false;
            Console.WriteLine($"{Name}이 강력한 공격을 시전합니다.");
            Console.WriteLine($"{Name}의 {SkillName}!!!\n");
            bool isKillPlayer = player.Hurt(SkillDamage);
            if (isKillPlayer) BattleEnd = true;
            else BattleEnd = false;
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

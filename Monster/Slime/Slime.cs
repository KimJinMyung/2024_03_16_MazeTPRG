using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Monster.Slime
{
    internal class Slime : Monster
    {
        public Slime()
        {
            Name = "슬라임";
            HP = 80;
            ATK = 8;
            Defense = 1;
            Speed = 2;
            GiveEXP = 8;

            Design = @"                             
          ██████████            
      ████▒▒▒▒▒▒▒▒▒▒████        
    ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓██      
  ██▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓██    
  ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██    
██▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██  
██▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██  
██▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██  
██▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██  
  ██▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██    
    ██████████████████████     
                                
";

            SkillName = "산성 침뱉기";
            SkillDamage = 16;
        }
        public override Monster Clone()
        {
            return new Slime();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Skill
{
    enum Skill
    {
        MegaSlash,
        AnkleSlit,
        Bleeding
    }

    internal class SelectSkill
    {
        private SkillList skillList;

        public SelectSkill()
        {
            skillList = new SkillList();
        }

        public void SkillCoolTimeMinus(int battleCount)
        {
            skillList.skillCoolTimeMinus(battleCount);
        }
                     
        public bool PrintSkillSelect()
        {
            bool turnEnd = false;

            Console.WriteLine("=====================");
            //강력한 데미지
            Console.WriteLine("1. 메가 슬래시");
            //소량의 데미지와 이속 감소
            Console.WriteLine("2. 발목 긋기");
            //매 턴마다 일정한 출혈 데미지 부여
            Console.WriteLine("3. 출혈 부여");
            Console.WriteLine("=====================\n");

            Console.WriteLine("=====================");
            Console.Write("사용할 스킬 선택 : ");

            try
            {
                while (Console.KeyAvailable) { Console.ReadKey(true); }

                int inputAction = int.Parse(Console.ReadLine());

                Console.WriteLine("=====================");
                turnEnd = SelectTarget(inputAction);
                //행동을 수행하였으면 true를 반환
            }
            catch (Exception e)
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
            return turnEnd;

        }

        public bool SelectTarget(int action)
        {
            bool turnEnd = false;

            foreach (var item in skillList.GetSkillList)
            {
                if((int)item.Key+1 == action)
                {
                    Console.Write("공격할 몬스터 선택 : ");
                    int AttackMonsterIndex = int.Parse(Console.ReadLine());
                    Console.WriteLine("=====================");
                    Console.WriteLine();
                    //스킬을 사용했으면 true를 반환
                    turnEnd = item.Value.SkillEffect(AttackMonsterIndex-1);
                    return turnEnd;
                }
            }
            return turnEnd;           
        }

        

    }
}

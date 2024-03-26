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
        private int[] cursorPos;
        private List<string> TextList = new List<string>();

        public SelectSkill()
        {
            skillList = new SkillList();
            cursorPos = new int[2];
        }

        public void SkillCoolTimeMinus(int battleCount)
        {
            skillList.skillCoolTimeMinus(battleCount);
        }

        public void SetCursorPosX(int x)
        {
            cursorPos[0] = x;
        }
        public void SetCursorPosY(int y)
        {;
            cursorPos[1] = y;
        }

        public void ActionSelectSkillText()
        {
            TextList.Clear();

            TextList.Add("==================================");
            //강력한 공격
            TextList.Add($"1. 메가 슬래시    사용 마나 : {new Skill_A_MegaSlash().GetUseMana}");
            //소량의 데미지와 이속 감소
            TextList.Add($"2. 발목 긋기     사용 마나 : {new Skill_B_AnkleSlit().GetUseMana}");
            //매 턴마다 일정한 출혈 데미지 부여
            TextList.Add($"3. 출혈 부여     사용 마나 : {new Skill_C_Bleeding().GetUseMana}");
            //메뉴로 돌아가기
            TextList.Add("4. 취소");
            TextList.Add("==================================\n");

            TextList.Add("==================================");
            TextList.Add("사용할 스킬 선택 : ");
        }

        public bool PrintSkillSelect()
        {
            bool turnEnd = false;

            ActionSelectSkillText();

            int line = 0;
            foreach (var item in TextList)
            {
                Console.SetCursorPosition(2, cursorPos[1] + line);
                Console.Write(item);
                line++;
            }

            try
            {
                while (Console.KeyAvailable) { Console.ReadKey(true); }

                int inputAction = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(2, Console.GetCursorPosition().Top);
                Console.WriteLine("==================================");
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
                    Console.SetCursorPosition(2, Console.GetCursorPosition().Top);
                    Console.Write("공격할 몬스터 선택 : ");
                    int AttackMonsterIndex = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(2, Console.GetCursorPosition().Top);
                    Console.WriteLine("==================================");
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

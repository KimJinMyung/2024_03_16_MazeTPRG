using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.UI
{
    internal class StoryUI : TextAnimation
    {
        private List<string> storyList;

        public StoryUI()
        {
            Console.Clear();

            storyList = new List<string>();

            GameStroy();

            int cursorLine = 0;
            foreach (var item in storyList)
            {
                Console.SetCursorPosition(10, 5 + cursorLine);
                TextAni(item);
                cursorLine++;
            }

            Console.SetCursorPosition(21, cursorLine + 9);
            Console.WriteLine("진행을 원하면 아무 키나 입력하시오...");
        }

        public void GameStroy()
        {    
            storyList.Add("신의 저주에 인하여 탄생한 괴물, 미노타우르스...");
            storyList.Add("반인반수인 그 괴물은 오늘도 자신의 쾌락을 위해 인간을 학살하고 다녔다.\n" );
            storyList.Add("\n");
            storyList.Add("왕은 자신의 백성들이 괴물에 의하여 죽는 것에 분노하였고");
            storyList.Add("자신의 모든 군대를 동원하여 그를 미로안에 가두는 것에 성공한다.");
            storyList.Add("\n");
            storyList.Add("현재 당신은 사랑하는 그/그녀 와의 결혼 자격을 증명하기 위해");
            storyList.Add("크레타 섬에 위치한 이곳, 미노타우르스의 미궁에 발을 들이기로 한다.");
            storyList.Add("\n");
            storyList.Add("당신이 안으로 들어가자 미궁의 문은 곧바로 굳게 닫혀 더이상 열리지 않았고");
            storyList.Add("결국, 당신은 작은 횃불에 의지하며 앞으로 나아가기로 결심한다.");
        }        
    }

   

}

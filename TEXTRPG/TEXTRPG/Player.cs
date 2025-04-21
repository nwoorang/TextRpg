using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public class Player
    {

        public float Lv { get; private set; }
        public string Name { get; private set; }
        public string Class { get; private set; }
        public float BaseAtk { get; private set; }
        public float BaseDef { get; private set; }
        public float BaseHp { get; private set; }


        // 기본 생성자 (초기값 설정)
        public Player()
        {
            Lv = 1;
            Name = "Unnamed";
            Class = "NoClass";
            BaseAtk = 10;
            BaseDef = 5;
            BaseHp = 100;
        }

        // 매개변수 생성자 (커스텀 설정)
        public Player(float lv, string name, string job, float atk, float def, float hp)
        {
            Lv = lv;
            Name = name;
            Class = job;
            BaseAtk = atk;
            BaseDef = def;
            BaseHp = hp;
        }
    }
}

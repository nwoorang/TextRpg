using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public class Item
    {
        public string Name { get; private set; }

        public Dictionary<StatType, int> Stats { get; private set; } = new();
        public float Gold { get; private set; }
        public string Description { get; private set; }

        public bool IsEquipped { get; set; } = false;

        public EquipType Equip_Type { get; private set; } //장비타입  //나중에 아이템을 상속받은 장비로 바꿀거임
        public Item() { } //기본 생성자
        public Item(string name, string des, float gold = 0)
        { Name = name; Description = des; Gold = gold; }

        public void SetIsEquipped(bool isEquipped)
        {
            IsEquipped = isEquipped;

        }

        public void SetStats(StatType type, int value)
        {
            if (Stats.ContainsKey(type))
            {
                Stats[type] = value;
            }
            else
            {
                Stats.Add(type, value);
            }
        }
    }
}

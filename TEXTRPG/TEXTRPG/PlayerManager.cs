using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace TEXTRPG
{
    public class PlayerManager
    {
        private Player _player;

        // 플레이어 스탯 프로퍼티 (Player 클래스의 값을 그대로 노출)
        public float Lv => _player.Lv;
        public string Name => _player.Name;
        public string Class => _player.Class;
        public float Atk => _player.BaseAtk + GetEquipmentStat(StatType.Atk); // 기본 + 장비 스탯
        public float Def => _player.BaseDef + GetEquipmentStat(StatType.Def); //변수를 부를때마다 장비능력치 합산을 해줌
        public float Hp => _player.BaseHp + GetEquipmentStat(StatType.Hp); //실시간 업데이트
        public int gold { get; set; } = 1111500;

        // 장착된 아이템 리스트
        private List<Item> _equippedItems = new List<Item>();

        public PlayerManager(Player player)
        {
            _player = player;
        }

        // 장비 스탯 합산 메서드
        public float GetEquipmentStat(StatType type)
        {
            float total = 0f;

            foreach (Item item in _equippedItems)
            {
                // 아이템이 해당 스탯을 가지고 있다면 값을 더함
                if (item.Stats.ContainsKey(type))
                {
                    total += item.Stats[type];
                }
            }

            return total;
        }


        // 장비 장착
        public void EquipItem(Item item) //장비 장착,해제
        {
            if (item == null)
            {
                Console.WriteLine("아이템이 없으므로 장착,해제 불가");
                return;
            }
            if (!item.IsEquipped)
            {
                _equippedItems.Add(item);
                item.SetIsEquipped(true);
            }
            else
            {
                _equippedItems.Remove(item);
                item.SetIsEquipped(false);
            }

        }

    }
}

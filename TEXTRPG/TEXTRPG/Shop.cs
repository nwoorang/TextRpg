using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public class Shop : ItemContainer
    {
        private Dictionary<Item, bool> checkItem { get; set; } = new();
        public override void AddItem(Item additem)//아이템 추가
        {
            items.Add(additem);
        }
        public override void RemoveItem(Item removeItem)//아이템 제거
        {
            items.Remove(removeItem);
        }
        public override int GetLength() //아이템 개수
        {
            return items.Count;
        }
        public override List<Item> SetItem() //아이템리스트주기
        {
            return items;
        }
        public void ShowAllItem() //아이템 모두 보여주기
        {
            foreach (Item item in items)
            {
                Console.Write("-");
                Console.Write($"{item.Name}");
                Console.Write($" | ");
                foreach (KeyValuePair<StatType, int> list in item.Stats)
                {
                    Console.Write("[{0}:{1}]", list.Key, list.Value);
                }
                Console.Write($" | ");
                Console.WriteLine($"{item.Description}");
            }
        }
        public override void ShowItem(int num) //특정 아이템 보여주기
        {
            int num2 = num; //인덱스 맞추기
            Console.Write("-");
            Console.Write($" {num2 + 1} ");
            Console.Write($"{items[num2].Name}");
            Console.Write($" | ");
            foreach (KeyValuePair<StatType, int> list in items[num2].Stats)
            {
                Console.Write($"{list.Key}+{list.Value}");
            }
            Console.Write($" | ");
            Console.WriteLine($"{items[num2].Description}");
        }

        public void ShowBuyableItems(ItemContainer container, int i)//장비 유무 확인후 구매했는지 안했는지 체크
        {
            //가게의 아이템 수만큼 ShowBuyableItems을 실행한다.
            //첫번째 상점의 아이템과 인벤토리의 각 아이템들을 비교해서 찾아낸다.
            bool found = false;
            for (int j = 0; j < container.GetLength(); j++)
            {
                if (items[i].Name == container.SetItem()[j].Name)
                {
                    found = true;
                    break; //찾았으면 더이상 찾지않음
                }
            }
            if (!found)
            {
                Console.WriteLine($"{items[i].Gold} G");
            }
            else
            {
                Console.WriteLine("구매완료");
            }
        }
        public void BuyItem(ItemContainer container, int i, int currentgold, out int remindgold)//구매
        {
            remindgold = currentgold; //구매전 골드
            int j = i - 1; //스위치에서는 1부터 시작하므로 -1
            //여기가 문제
            if (j < items.Count)
            {
                checkItem.TryGetValue(items[j], out bool key);
                if (key)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    return;
                }
            }

            if (items[j].Gold > remindgold)
            {
                Console.WriteLine("골드가 부족합니다.");
                return;
            }
            remindgold = (int)Math.Max(0, currentgold - items[j].Gold);

            Item itemToMove = this.items[j];
            container.AddItem(itemToMove);  // 인벤토리에 추가
            checkItem.TryAdd(items[j], true); //add를 쓰면 중첩이 되므로 tryadd 사용
            Console.WriteLine($"{itemToMove.Name} 구매완료");

        }

        public void SellItem(ItemContainer container, int i, int currentgold, out int remindgold)//판매
        {
            remindgold = currentgold; //구매전 골드
            int j = i - 1; //스위치에서는 1부터 시작하므로 -1

            if (j < items.Count)
            {
                checkItem.TryGetValue(items[j], out bool key);
                if (!key)
                {
                    Console.WriteLine("소유중이지 않으므로 판매 불가능입니다.");
                    return;
                }
            }

            remindgold = (int)Math.Max(0, currentgold + items[j].Gold * 0.85);

            Item itemToMove = this.items[j];
            itemToMove.SetIsEquipped(false);
            container.RemoveItem(itemToMove);  // 인벤토리에서 제거
            checkItem.Remove(itemToMove); //상점에 구매가능체크리스트에서 제거
            Console.WriteLine($"{itemToMove.Name} 판매완료");
        }



    }
}

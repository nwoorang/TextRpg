using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public class Inventory : ItemContainer
    {


        public override void AddItem(Item additem)
        {
            items.Add(additem);
        }

        public override void RemoveItem(Item removeItem)
        {
            items.Remove(removeItem);

        }

        public override void ShowItem(int num) //특정 아이템 보여주기
        {
            int num2 = num; //인덱스 맞추기
            Console.Write("-");
            Console.Write($" {num2 + 1} ");
            if (items[num2].IsEquipped)
                Console.Write("[E]");
            Console.Write($"{items[num2].Name}");
            Console.Write($" | ");
            foreach (KeyValuePair<StatType, int> list in items[num2].Stats)
            {
                Console.Write($"{list.Key}+{list.Value}");
            }
            Console.Write($" | ");
            Console.WriteLine($"{items[num2].Description}");
        }
        public void ShowAllItem() //아이템 모두 보여주기
        {

            foreach (Item item in items)
            {
                Console.Write("-");
                if (item.IsEquipped)
                    Console.Write("[E]");
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
        public Item FindNameItem(string name) //이름으로 아이템 찾기
        {
            Item? returnItem = items.Find(item => item.Name == name);

            return returnItem;
        }

        public Item FindArrayItem(int num) //몇번째 배열인지로 아이템 찾기
        {
            if (items.Count > 0)
            {
                Console.WriteLine("아이템이 있습니다.");
                Item? returnItem = items[num - 1];
                return returnItem;
            }
            else
            {
                Console.WriteLine("아이템이 없습니다.");
            }
            return null;
        }

        public override int GetLength() //아이템 개수
        {
            return items.Count;
        }

        public override List<Item> SetItem()
        {
            return items;
        }
    }
}

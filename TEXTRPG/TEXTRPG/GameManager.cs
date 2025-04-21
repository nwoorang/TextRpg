using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public class GameManager
    {
        public Player player;
        public Inventory inventory;
        public PlayerManager playerManager;
        public Shop shop;
        public void addInfo(Player p_player, Inventory p_inventory, PlayerManager statsManager, Shop shop)
        {
            this.player = p_player;
            this.inventory = p_inventory;
            this.playerManager = statsManager;
            this.shop = shop;
        }

        public void ShowMainWindow()
        {
            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("      스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("1.상태 보기");
            Console.WriteLine("2.인벤토리");
            Console.WriteLine("3.상점");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력하세요.");
            Console.Write(">>");
        }

        public void ShowStatWindow()
        {
            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("상태 보기");

            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");
            Console.WriteLine($"Lv. {playerManager.Lv}");
            Console.WriteLine($"{playerManager.Name} ({playerManager.Class})");
            Console.WriteLine($"공격력 :  {playerManager.Atk}(+{playerManager.GetEquipmentStat(StatType.Atk)}) ");
            Console.WriteLine($"방어력 :  {playerManager.Def}(+{playerManager.GetEquipmentStat(StatType.Def)})");
            Console.WriteLine($"체력 : {playerManager.Hp}");
            Console.WriteLine($"Gold : {playerManager.gold} G");
            Console.WriteLine("");
            Console.WriteLine("0.나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력하세요.");
            Console.Write(">>");
        }

        public void ShowInventoryWindow()
        {
            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            inventory.ShowAllItem();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1.장착 관리");
            Console.WriteLine("2.나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력하세요.");
            Console.Write(">>");
        }

        public void ShowequipmentWindow()
        {
            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("인벤토리-장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < inventory.GetLength(); i++)
            {
                inventory.ShowItem(i);
            }
            Console.WriteLine("");
            Console.WriteLine("0.나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력하세요.");
            Console.Write(">>");
        }


        public void ShopWindow()
        {
            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{playerManager.gold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            shop.ShowAllItem();
            Console.WriteLine("");
            Console.WriteLine("1.아이템 구매");
            Console.WriteLine("2.아이템 판매");
            Console.WriteLine("0.나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력하세요.");
            Console.Write(">>");
        }
        public void ShopBuyWindow()
        {
            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("상점-아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{playerManager.gold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < shop.GetLength(); i++)
            {
                shop.ShowItem(i);
                shop.ShowBuyableItems(inventory, i);
            }
            Console.WriteLine("");
            Console.WriteLine("0.나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력하세요.");
            Console.Write(">>");
        }

    }
}

using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using static Program;
public enum StatType { Atk, Def, Hp} //스탯 타입
internal class Program
{


    private static void Main(string[] args)
    {

        GameManager manager = new GameManager();
        Player user = new Player(01, "noname", "전사", 10, 5, 100, 1500); //테스트용 초기화 하기
        Inventory inventory = new Inventory();
        PlayerManager playerManager = new PlayerManager(user); //종합스탯창
        Shop shop = new Shop(); //상점
        manager.addInfo(user, inventory, playerManager, shop); //게임매니저에 유저와 유저의 인벤토리 전달


        #region 아이템 생성후 관리과정

        /* 생성예시
        Item ironArmor = new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 700)
        {
            Stats =
            {
            [StatType.Def] = 5
            }
        }; //무쇠갑옷 아이템 생성

        inventory.AddItem(ironArmor); //인벤토리에 무쇠갑옷 추가
        ironArmor.Stats[StatType.Hp] = 10; //스탯추가
                                           //몬스터를 잡아서 아이템을 얻은상태 가정
        */

       
        #endregion

        #region 상점 아이템 생성
        Item noviceArmor = new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.",112000)
        {
            Stats =
            {
            [StatType.Def] = 5
            }
        };
        shop.AddItem(noviceArmor);
        inventory.AddItem(noviceArmor);

        Item ironArmor = new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 700)
        {
            Stats =
            {
            [StatType.Def] = 9
            }
        };
        shop.AddItem(ironArmor);
        inventory.AddItem(ironArmor);
        Item spartaArmor = new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",3500)
        {
            Stats =
            {
            [StatType.Def] = 15
            }
        };
        shop.AddItem(spartaArmor);
        inventory.AddItem(spartaArmor);
        Item oldSword = new Item("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 600)
        {
            Stats =
            {
            [StatType.Atk] = 2
            }
        };
        shop.AddItem(oldSword);

        Item bronzeAx = new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 1500)
        {
            Stats =
            {
            [StatType.Atk] = 5
            }
        };
        shop.AddItem(bronzeAx);

        Item spartaSpear = new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 4000)
        {
            Stats =
            {
            [StatType.Atk] = 7
            }
        };

        shop.AddItem(spartaSpear);
        #endregion


        //1차 무한루프 메인화면
        bool check1 = true;
        int select1 = 0;
        while (check1)
        {
            manager.ShowMainWindow(); //메인창 오픈
            select1 = int.Parse(Console.ReadLine());
            switch (select1)
            {
                case 1:
                    //2차 무한루프 스탯창
                    bool check2 = true;
                    int select2 = 0;
                    while (check2)
                    {
                        manager.ShowStatWindow();//스탯창 오픈
                        select2 = int.Parse(Console.ReadLine());
                        switch (select2)
                        {
                            case 0:
                                check2 = false;
                                break;
                            default://예외처리
                                Console.WriteLine("잘못된 입력입니다");
                                break;
                        }
                    }
                    break;
                case 2://인벤토리창
                    bool check3 = true;
                    while (check3)
                    {
                        manager.ShowInventoryWindow();//인벤토리창 오픈
                        int select3 = 0;
                        select3 = int.Parse(Console.ReadLine());
                        switch (select3)
                        {
                            case 1:
                                bool check3_1 = true;
                                int select3_1 = 0;
                                while (check3_1)
                                {
                                    manager.ShowequipmentWindow();//장착관리창 오픈
                                    select3_1 = int.Parse(Console.ReadLine());
                                    switch (select3_1)
                                    {
                                        case 1:
                                            playerManager.EquipItem(inventory.FindArrayItem(select3_1));
                                            //아이템에 장비착용했다 전달
                                            //장비관리창에 스탯 전달
                                            break;
                                        case 2:
                                            playerManager.EquipItem(inventory.FindArrayItem(select3_1));
                                            break;
                                        case 3:
                                            playerManager.EquipItem(inventory.FindArrayItem(select3_1));
                                            break;
                                        case 4:
                                            playerManager.EquipItem(inventory.FindArrayItem(select3_1));
                                            break;
                                        case 5:
                                            playerManager.EquipItem(inventory.FindArrayItem(select3_1));
                                            break;
                                        case 0:
                                            check3_1 = false;
                                            break;
                                        default://예외처리
                                            Console.WriteLine("잘못된 입력입니다");
                                            break;
                                    }
                                }
                                break;

                            case 2:
                                check3 = false;
                                break;
                            default://예외처리
                                Console.WriteLine("잘못된 입력입니다");
                                break;
                        }
                    }

                    break;
                case 3://상점창
                    bool check4 = true;
                    while (check4)
                    {
                        manager.ShopWindow();
                        int select4 = 0;
                        select4 = int.Parse(Console.ReadLine());
                        switch (select4)
                        {
                            case 1:
                                bool check4_1 = true;
                                int select4_1 = 0;
                                while (check4_1)
                                {
                                    manager.ShopPurchaseWindow();//장착관리창 오픈
                                    select4_1 = int.Parse(Console.ReadLine());
                                    switch (select4_1)
                                    {
                                        case 1:
                                            shop.BuyItem(inventory, select4_1);

                                            break;
                                        case 2:
                                            shop.BuyItem(inventory, select4_1);
                                            break;
                                        case 3:
                                            shop.BuyItem(inventory, select4_1);
                                            break;
                                        case 4:
                                            shop.BuyItem(inventory, select4_1);
                                            break;
                                        case 5:
                                            shop.BuyItem(inventory, select4_1);
                                            break;
                                        case 6:
                                            shop.BuyItem(inventory, select4_1);
                                            break;
                                        case 0:
                                            check4_1 = false;
                                            break;
                                        default://예외처리
                                            Console.WriteLine("잘못된 입력입니다");
                                            break;
                                    }
                                }
                                break;

                            case 0:
                                check4 = false;
                                break;
                            default://예외처리
                                Console.WriteLine("잘못된 입력입니다");
                                break;
                        }
                    }

                    break;
                default://예외처리
                    Console.WriteLine("잘못된 입력입니다");
                    break;
            }
        }

    }
    #region 게임매니저
    public class GameManager
    {
        public Player player;
        public Inventory inventory;
        public PlayerManager playerManager;
        public Shop shop;
        public void addInfo(Player p_player, Inventory p_inventory,PlayerManager statsManager,Shop shop)
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
            Console.WriteLine($"공격력 :  {playerManager.Atk} ");
            Console.WriteLine($"방어력 :  {playerManager.Def}");
            Console.WriteLine($"체력 : {playerManager.Hp}");
            Console.WriteLine($"Gold : {playerManager.Gold} G");
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
            for(int i =0; i < inventory.GetLength(); i++)
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
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            shop.ShowAllItem();
            Console.WriteLine("");
            Console.WriteLine("1.아이템 구매");
            Console.WriteLine("0.나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력하세요.");
            Console.Write(">>");
        }
        public void ShopPurchaseWindow()
        {
            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("상점-아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < shop.GetLength(); i++)
            {
                shop.ShowItem(i);
                shop.ShowBuyableItems(inventory,i);
            }
            Console.WriteLine("");
            Console.WriteLine("0.나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력하세요.");
            Console.Write(">>");
        }

    }
    #endregion
    #region 플레이어
    public class Player
    {

        public float Lv { get; private set; }
        public string Name { get; private set; }
        public string Class { get; private set; }
        public float BaseAtk { get; private set; }
        public float BaseDef { get; private set; }
        public float BaseHp { get; private set; }
        public float Gold { get; private set; }

        // 기본 생성자 (초기값 설정)
        public Player()
        {
            Lv = 1;
            Name = "Unnamed";
            Class = "NoClass";
            BaseAtk = 10;
            BaseDef = 5;
            BaseHp = 100;
            Gold = 50;
        }

        // 매개변수 생성자 (커스텀 설정)
        public Player(float lv, string name, string job, float atk, float def, float hp, float gold)
        {
            Lv = lv;
            Name = name;
            Class = job;
            BaseAtk = atk;
            BaseDef = def;
            BaseHp = hp;
            Gold = gold;
        }
    }
    #endregion
    #region 플레이어 매니저
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
        public float Gold => _player.Gold;

        // 장착된 아이템 리스트
        private List<Item> _equippedItems = new List<Item>();

        public PlayerManager(Player player)
        {
            _player = player;
        }

        // 장비 스탯 합산 메서드
        private float GetEquipmentStat(StatType type)
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
    #endregion
    #region 아이템 컨테이너<-인벤토리,상점 부모
    public abstract class ItemContainer //아이템 관리하는 상위 클래스
    {
        protected List<Item> item = new List<Item>(); //아이템 리스트

       // protected Dictionary<int,Item> items= new Dictionary<int,Item>(); //동일 아이템 묶음
        public abstract void AddItem(Item additem);
        public abstract void RemoveItem(Item removeItem);

        public abstract void ShowItem(int num);

        public abstract int GetLength(); //아이템 개수

        public abstract List<Item> SetItem();

        // 공통 메서드 정의
    }
    #endregion
    #region 인벤토리
    public class Inventory : ItemContainer 
    {
        

        public override void AddItem(Item additem)
        {
            item.Add(additem);
        }

        public override void RemoveItem(Item removeItem)
        {
            item.Remove(removeItem);
            
        }

        public override void ShowItem(int num) //특정 아이템 보여주기
        {
            int num2 = num; //인덱스 맞추기
            Console.Write("-");
            Console.Write($" {num2+1} ");
            if (item[num2].IsEquipped)
                    Console.Write("[E]");
                Console.Write($"{item[num2].Name}");
            Console.Write($" | ");
            foreach (KeyValuePair<StatType, int> list in item[num2].Stats)
                {
                    Console.Write($"{list.Key}+{list.Value}");
                }
            Console.Write($" | ");
            Console.WriteLine($"{item[num2].Description}");
        }
        public void ShowAllItem() //아이템 모두 보여주기
        {

            foreach (Item item in item)
            {
                Console.Write("-");
                if (item.IsEquipped)
                    Console.Write("[E]");
                Console.Write($"{item.Name}");
                Console.Write($" | ");
                foreach (KeyValuePair<StatType, int>list in item.Stats)
                {
                    Console.Write("[{0}:{1}]", list.Key,list.Value);
                }
                Console.Write($" | ");
                Console.WriteLine($"{item.Description}");
            }
        }
        public Item FindNameItem(string name) //이름으로 아이템 찾기
        {
            Item? returnItem =item.Find(item => item.Name == name);

            return returnItem;
        }

        public Item FindArrayItem(int num) //몇번째 배열인지로 아이템 찾기
        {
            Item? returnItem = item[num-1];

            return returnItem;
        }

        public override int GetLength() //아이템 개수
        {
            return item.Count;
        }

        public override List<Item> SetItem()
        {
            return item;
        }
    }
    #endregion
    #region 상점클래스
    public class Shop : ItemContainer
    {
        private Dictionary<Item,bool> checkItem { get; set; } = new();
        public override void AddItem(Item additem)
        {
            item.Add(additem);
        }
        public override void RemoveItem(Item removeItem)
        {
            item.Remove(removeItem);
        }

        public void ShowAllItem() //아이템 모두 보여주기
        {
            foreach (Item item in item)
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
            Console.Write($"{item[num2].Name}");
            Console.Write($" | ");
            foreach (KeyValuePair<StatType, int> list in item[num2].Stats)
            {
                Console.Write($"{list.Key}+{list.Value}");
            }
            Console.Write($" | ");
            Console.WriteLine($"{item[num2].Description}");
        }

        public void ShowBuyableItems(ItemContainer container,int i)//사는게 가능한지 체크
        {
            Item foundItem = null;
            if (i< container.GetLength())
               foundItem = item.Find(item => item.Name == container.SetItem()[i].Name);
            //인벤토리의 아이템 리스트
            if (foundItem == null)
            {
                Console.WriteLine($"{item[i].Gold} G");
            }
            else
            {
                checkItem.TryAdd(item[i],true);
                Console.WriteLine("구매완료");
            }
        }


        public override int GetLength() //아이템 개수
        {
            return item.Count;
        }

        public override List<Item> SetItem() //아이템리스트주기
        {
            return item;
        }

        public void BuyItem(ItemContainer container, int i)//구매
        {
            int j = i-1;

            if (j < container.GetLength())
            {
                if (checkItem.TryGetValue(container.SetItem()[j],out bool key))
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    return;
                }
            }
            Item itemToMove = this.item[j];
                container.AddItem(itemToMove);  // 인벤토리에 추가
                Console.WriteLine($"{itemToMove.Name} 구매완료");

        }

        public void SellItem(ItemContainer container, int i)//판매
        {
            if (i < container.GetLength())
            {
                Item itemToMove = this.item[i];
                container.RemoveItem(itemToMove);  // 인벤토리에 추가
                AddItem(itemToMove);    // 상점에서 제거
            }
        }
    }
    #endregion
    #region 아이템
    public class Item
    {
        public string Name { get; private set; }

        public Dictionary<StatType, int> Stats { get; private set; } = new();
        public float Gold { get; private set; }
        public string Description { get; private set; }

        public bool IsEquipped { get; private set; } = false;

        public Item() { } //기본 생성자
        public Item(string name, string des, float gold = 0) { Name = name; Description = des; Gold = gold; }

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
    #endregion


   



}
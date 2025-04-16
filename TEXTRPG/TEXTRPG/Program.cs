using System;
using System.Buffers.Text;
using System.IO;
using System.Xml.Linq;
public enum StatType { Atk, Def, Hp} //스탯 타입
internal class Program
{


    private static void Main(string[] args)
    {
        GameManager manager = new GameManager();
        Player user = new Player(01, "noname", "전사", 10, 5, 100, 1500); //테스트용 초기화 하기
        Inventory inventory = new Inventory();
        PlayerManager playerManager = new PlayerManager(user); //종합스탯창
        manager.addInfo(user, inventory, playerManager); //게임매니저에 유저와 유저의 인벤토리 전달
 

#region 아이템 생성후 관리과정
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

        Item spartaSpear = new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.",1000)
        {
            Stats =
            {
            [StatType.Atk] = 7
            }
        }; //spartaSpear 아이템 생성

        inventory.AddItem(spartaSpear); //인벤토리에 무쇠갑옷 추가
        spartaSpear.Stats[StatType.Hp] = 15; //스탯추가
                                             //몬스터를 잡아서 아이템을 얻은상태 가정

        Item oldSword = new Item("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 1000)
        {
            Stats =
            {
            [StatType.Atk] = 2
            }
        }; //spartaSpear 아이템 생성

        inventory.AddItem(oldSword); //인벤토리에 무쇠갑옷 추가
        oldSword.Stats[StatType.Hp] = 13; //스탯추가
                                             //몬스터를 잡아서 아이템을 얻은상태 가정

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
                                Console.WriteLine("ㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜ잘못된 입력입니다ㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜ");
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
                                        case 0:
                                            check3_1 = false;
                                            break;
                                        default://예외처리
                                            Console.WriteLine("ㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜ잘못된 입력입니다ㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜ");
                                            break;
                                    }
                                }
                                break;

                            case 2:
                                check3 = false;
                                break;
                            default://예외처리
                                Console.WriteLine("ㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜ잘못된 입력입니다ㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜ");
                                break;
                        }
                    }

                    break;
                case 3://상점창
                    //미리 사전에 정의된 아이템들 나열
                    //아이템 뒤에 금액있음

                    break;
                default://예외처리
                    Console.WriteLine("ㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜ잘못된 입력입니다ㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜㅜ");
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
        public void addInfo(Player p_player, Inventory p_inventory,PlayerManager statsManager)
        {
            this.player = p_player;
            this.inventory = p_inventory;
            this.playerManager = statsManager;
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
            Console.WriteLine($"공격력 :  {playerManager.Atk}");
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
            inventory.ShowAllItem();
            inventory.FindArrayItem(1);
            Console.WriteLine("");
            Console.WriteLine("0.나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력하세요.");
            Console.Write(">>");
        }

    }
    #endregion
    #region 플레이어클래스
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
            Class = "Adventurer";
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

    public abstract class ItemContainer //아이템 관리하는 상위 클래스
    {
        protected List<Item> item = new List<Item>(); //아이템 리스트

       // protected Dictionary<int,Item> items= new Dictionary<int,Item>(); //동일 아이템 묶음
        public abstract void AddItem(Item additem);
        public abstract void RemoveItem(Item removeItem);
        // 공통 메서드 정의
    }

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
        
        public void ShowAllItem() //아이템 모두 보여주기
        {
            foreach (Item item in item)
            {
                Console.WriteLine("-");
                if (item.IsEquipped)
                    Console.WriteLine("[E]");
                Console.Write($"{item.Name}");
                foreach (KeyValuePair<StatType, int>list in item.Stats)
                {
                    Console.WriteLine("[{0}:{1}]", list.Key,list.Value);
                }
                Console.WriteLine($"{item.Description}");
                Console.WriteLine($"{item.Gold}");
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
                item.IsEquipped = true;
            }
            else
            {
                _equippedItems.Remove(item);
                item.IsEquipped = false;
            }

        }

    }
    #endregion
    #region 상점클래스
    public class Shop : ItemContainer
    {
        public override void AddItem(Item additem)
        {
            item.Add(additem);
        }
        public override void RemoveItem(Item removeItem)
        {
            item.Remove(removeItem);
        }
    }
    #endregion
    #region 아이템
    public class Item
    {
        public string Name { get; private set; }

        public Dictionary<StatType, int> Stats { get; set; } = new();
        public float Gold { get; private set; }
        public string Description { get; private set; }

        public bool IsEquipped { get; set; } = false;

        public Item(string name,string des,float gold=0) { Name = name;Description = des;Gold = gold; }
    }
    #endregion



}
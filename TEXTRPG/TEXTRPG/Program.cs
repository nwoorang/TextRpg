using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;
using TEXTRPG;
using static System.Collections.Specialized.BitVector32;
using static Program;
public enum StatType { Atk, Def, Hp} //스탯 타입

public enum EquipType { Armor,Sword } //스탯 타입

internal class Program
{


    private static void Main(string[] args)
    {

        GameManager manager = new GameManager();
        Player user = new Player(01, "noname", "전사", 10, 5, 100); //테스트용 초기화 하기
        Inventory inventory = new Inventory();
        PlayerManager playerManager = new PlayerManager(user); //종합스탯창
        Shop shop = new Shop(); //상점
        manager.addInfo(user, inventory, playerManager, shop); //게임매니저에 유저와 유저의 인벤토리 전달



        #region 아이템 생성후 관리과정

        /* 
        생성예시
        Item ironArmor = new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 700)
        {
            Stats =
            {
            [StatType.Def] = 5
            }
        };
        인벤토리에 아이템 추가
        inventory.AddItem(ironArmor); 
        아이템에 스탯추가
        ironArmor.Stats[StatType.Hp] = 10; //스탯추가
        */


        #endregion

        #region 상점 아이템 생성
        Item noviceArmor = new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 1000)
        {

            Stats =
            {
            [StatType.Def] = 5
            }


        };
        shop.AddItem(noviceArmor);

        Item ironArmor = new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 700)
        {
            Stats =
            {
            [StatType.Def] = 9
            }
        };
        shop.AddItem(ironArmor);

        Item spartaArmor = new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500)
        {
            Stats =
            {
            [StatType.Def] = 15
            }
        };
        shop.AddItem(spartaArmor);

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


        Item rtan = new Item("르탄이의 가호", "이거 코딩해줘를 하면 알아서 코딩을 다해준다.", 77777)
        {
            Stats =
            {
            [StatType.Atk] = 77
            }
        };
        rtan.Stats[StatType.Def] = 77;
        rtan.Stats[StatType.Hp] = 77;
        shop.AddItem(rtan);
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
                    ShowStateWindow_1(manager.ShowStatWindow);
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
                                ShowStateWindow_2(manager.ShowequipmentWindow, 1);
                                break;

                            case 2:
                                check3 = false;
                                break;
                            default://예외처리
                                Console.WriteLine("잘못된 입력입니다");
                                Thread.Sleep(1000);
                                break;
                        }
                    }
                    break;
                case 3://상점창
                    bool check4 = true;
                    while (check4)
                    {
                        manager.ShopWindow();//상점창 오픈
                        int select4 = 0;
                        select4 = int.Parse(Console.ReadLine());
                        switch (select4)
                        {
                            case 1:
                                ShowStateWindow_2(manager.ShopBuyWindow, 1);
                                break;
                            case 2:
                                ShowStateWindow_2(manager.ShopBuyWindow, 2);
                                break;

                            case 0:
                                check4 = false;
                                break;
                            default://예외처리
                                Console.WriteLine("잘못된 입력입니다");
                                Thread.Sleep(1000);
                                break;
                        }
                    }
                    break;
                default://예외처리
                    Console.WriteLine("잘못된 입력입니다");
                    Thread.Sleep(1000);
                    break;
            }
        }


        /* 구조층             
          ㄴShowStateWindow(manager.ShowMainWindow); //메인창 오픈
            ㄴShowStateWindow(manager.ShowStatWindow); //스탯창 오픈
            ㄴShowStateWindow(manager.ShowInventoryWindow); //인벤토리창 오픈
                ㄴShowStateShopWindow(manager.ShowequipmentWindow,1); //장비창 오픈
            ㄴShowStateWindow(manager.ShopWindow); //상점창 오픈
                ㄴShowStateShopWindow(manager.ShopBuyWindow, 1); //상점구매창 오픈
                ㄴShowStateShopWindow(manager.ShopBuyWindow, 2); //상점판매창 오픈
        */

        void ShowStateWindow_1(Action action)//스탯창,인벤토리창,상점창
        {
            bool check = true;
            int select = 0;
            while (check)
            {
                action();//각 윈도우 오픈
                select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 0:
                        check = false;
                        break;
                    default://예외처리
                        Console.WriteLine("잘못된 입력입니다");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        void ShowStateWindow_2(Action action,int i)//장비창,상점구매판매창
        {
            bool check = true;
            int select = 0;
            while (check)
            {
                action();//각 윈도우 오픈
                select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        Func(i);
                        break;
                    case 2:
                        Func(i);
                        break;
                    case 3:
                        Func(i);
                        break;
                    case 4:
                        Func(i);
                        break;
                    case 5:
                        Func(i);
                        break;
                    case 6:
                        Func(i);
                        break;
                    case 7:
                        Func(i);
                        break;
                    case 0:
                        check = false;
                        break;
                    default://예외처리
                        Console.WriteLine("잘못된 입력입니다");
                        Thread.Sleep(1000);
                        break;
                }
            }

            void Func(int i)
            {
                if (action == manager.ShowequipmentWindow)
                {
                    playerManager.EquipItem(inventory.FindArrayItem(select));
                }
                else if (action == manager.ShopBuyWindow&&i==1)
                {
                    shop.BuyItem(inventory, select, playerManager.gold, out int g);
                    playerManager.gold = g; //구매후 골드 업데이트
                }
                else if (action == manager.ShopBuyWindow&&i==2)
                {
                    shop.SellItem(inventory, select, playerManager.gold, out int g);
                    playerManager.gold = g; //구매후 골드 업데이트
                }
            }

        }

    }
}

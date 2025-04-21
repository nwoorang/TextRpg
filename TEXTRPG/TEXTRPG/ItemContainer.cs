using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public abstract class ItemContainer //아이템 관리하는 상위 클래스
    {
        protected List<Item> items = new List<Item>(); //아이템 리스트

        // protected Dictionary<int,Item> items= new Dictionary<int,Item>(); //동일 아이템 묶음
        public abstract void AddItem(Item additem);
        public abstract void RemoveItem(Item removeItem);

        public abstract void ShowItem(int num);

        public abstract int GetLength(); //아이템 개수

        public abstract List<Item> SetItem();

        // 공통 메서드 정의
    }
}

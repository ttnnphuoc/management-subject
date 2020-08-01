using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningSubject.Models
{
    public class JsTreeModel
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }
        public bool children { get; set; } // if node has sub-nodes set true or not set false
        public JsTreeModel(string id, string parent, string text, bool children)
        {
            this.id = id;
            this.parent = parent;
            this.text = text;
            this.children = children;
        }
        public JsTreeModel()
        {

        }
        public List<JsTreeModel> GetDataList()
        {
            List<JsTreeModel> items = new List<JsTreeModel>();
            // set items in here

            items.Add(new JsTreeModel(generateID(), "1", "Giới thiệu về C#", false));
            items.Add(new JsTreeModel(generateID(), "1", "Cài đặt và sử dụng Visual Studio", false));
            items.Add(new JsTreeModel(generateID(), "2", "Kiểu dữ liệu,Biến và biểu thức", false));
            items.Add(new JsTreeModel(generateID(), "1", "Các phép toán trong C#", false));
            items.Add(new JsTreeModel(generateID(), "2", "Các cách ghi chú trong C#", false));
            items.Add(new JsTreeModel(generateID(), "1", "Các cấu trúc điều kiện", false));
            items.Add(new JsTreeModel(generateID(), "2", "Các cấu trúc lặp.", false));
            items.Add(new JsTreeModel(generateID(), "1", "Hàm trong C#", false));
            items.Add(new JsTreeModel(generateID(), "2", "Một số thư viện thường dùng", false));
            return items;
        }
        private string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
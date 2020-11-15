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
    }
}
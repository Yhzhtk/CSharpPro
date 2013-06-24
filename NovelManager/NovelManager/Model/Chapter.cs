using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovelManager.Model
{
    class Chapter
    {
        private bool isUpdate = false;

        public bool IsUpdate
        {
            get { return isUpdate; }
            set { isUpdate = value; }
        }

        private Model.novel_chapter_content content;

        public Model.novel_chapter_content Content
        {
            get { return content; }
            set { content = value; }
        }

        private int cid;
        public int Cid
        {
            get { return cid; }
            set { cid = value; }
        }
        
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private int isEmpty;
        public int IsEmpty
        {
            get { return isEmpty; }
            set { isEmpty = value; }
        }
    }
}

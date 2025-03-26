using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    public class tree_class
    {
        public string value { get; set; }
        public List<tree_class> children { get; set; } //автосвойства можно не прописывать самой get set

        public tree_class(string val)
        {
            value = val;
            children = new List<tree_class>();
        }

        public void Add_new(tree_class new_leaf) {
            children.Add(new_leaf);
        }

        public void Print_whole_tree()
        {
            Console.WriteLine("Value: "+value);

            if (children != null)
            {
                foreach (tree_class child in children)
                {
                    child.Print_whole_tree();
                }
            }
        }
    }
}

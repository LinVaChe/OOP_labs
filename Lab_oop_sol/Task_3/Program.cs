using Task_3;

tree_class root = new tree_class("root");
tree_class child1 = new tree_class("child_1");
tree_class child2 = new tree_class("child_2");
tree_class child3 = new tree_class("child_3");

root.Add_new(child1);
root.Add_new(child2);   
root.Add_new(child3);

tree_class grand_child11 = new tree_class("grandchild_1_1");
tree_class grand_child12 = new tree_class("grandchild_1_2");
tree_class grand_child31 = new tree_class("grandchild_3_1");

child1.Add_new(grand_child11);
child1.Add_new(grand_child12);
child3.Add_new(grand_child31);

Console.WriteLine("My tree structure: ");
root.Print_whole_tree();

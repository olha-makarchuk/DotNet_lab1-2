using DotNet_lab1_2;

var tree = new BinaryTree<int>();
tree.Add(6);
tree.Add(7);
tree.Add(2);
tree.Add(1);
tree.Add(8);
tree.Add(4);
tree.Add(3);
tree.Add(9);


Console.WriteLine("Прямий обхiд:");
foreach (var item in tree.Preorder())
{
    Console.Write(item + ", ");
}

Console.WriteLine("\nЗворотний обхiд:");
foreach (var item in tree.Postorder())
{
    Console.Write(item + ", ");
}

Console.WriteLine("\nЦентрований обхiд:");

foreach (var item in tree.Inorder())
{
    Console.Write(item + ", ");
}

Console.WriteLine("\n\nПрямий обхiд пiсля балансування:");
tree.Balance();
foreach (var item in tree.Preorder())
{
    Console.Write(item + ", ");
}

int remove_element = 2;
Console.WriteLine("\n\nВидаляємо елемент - "+ remove_element+"\nПрямий обхiд:");
tree.Remove(remove_element);
foreach (var item in tree.Preorder())
{
    Console.Write(item + ", ");
}

Console.Read();


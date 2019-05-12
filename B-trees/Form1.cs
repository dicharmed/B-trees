using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace B_trees
{
    public partial class Form1 : Form
    {
        BinaryTree binaryTree = new BinaryTree();

        public Form1()
        {
            InitializeComponent();

            // Hide console
            ShowWindow(GetConsoleWindow(), SW_HIDE);

            // Show console
           // ShowWindow(handle, SW_SHOW);
        }

        private void ShowMenu()
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    //theory  
                    Help.ShowHelp(this, "helpTheory.chm", "b_trees.htm");
                    break;
                case 1:
                    // Show console
                    ShowWindow(GetConsoleWindow(), SW_SHOW);
                    //show demo menu
                    ShowDemoMenu();
                    break;
                case 2:
                    //test     
                    Form2 form2 = new Form2();
                    form2.Show();
                    break;
                case 3://exit
                    Application.Exit();
                    break;
            }
        }

        private void DemoMenu()
        {
            WriteLineCentered("Демонстрация\n");
            Console.WriteLine("\n");
            Console.WriteLine("1. Добавить элемент\n2. Удалить элемент\n3. Найти минимальный элемент\n4. Найти максимальный элемент\n5. Найти высоту дерева\n6. Найти количество листьев дерева\n7. Сбалансированное дерево?\n8. Печать дерева\n9. Выход\n");

        }
        private void ShowDemoMenu()
        {
            int d, element;            
            DemoMenu();
            do {
                Console.WriteLine("\n");
                Console.WriteLine("Выберете пункт меню ->");

                //выбор пункта меню
                d = Convert.ToInt32(Console.ReadLine());

                switch (d)
                {
                    case 1://ADD
                        Console.WriteLine("Введите число для вставки: ");
                        element = Convert.ToInt32(Console.ReadLine());
                        binaryTree.Insert(element);
                        Console.WriteLine($"Элемент {element} был вставлен в дерево");
                        break;                   
                    case 2://REMOVE
                        if (binaryTree.Root != null)
                        {
                            Console.WriteLine("Введите число для удаления: ");
                            element = Convert.ToInt32(Console.ReadLine());
                            var rez = binaryTree.FindRecursive(element);
                            if (rez != null)
                            {
                                binaryTree.Remove(element);
                                Console.WriteLine($"Элемент {element} был удален из дерева");
                            }
                            else
                            {
                                Console.WriteLine($"Элемент {element} не существует в дереве!");
                            }
                        }else Console.WriteLine("В дереве нет ни одного элемента. Сначала добавьте элемент в дерево!");
                        break;
                    case 3: //FIND min ELEMENT   
                        if (binaryTree.Root != null)
                        {
                            Console.WriteLine($"Минимальный элемент: {binaryTree.Smallest()}");
                        }
                        else Console.WriteLine("В дереве нет ни одного элемента. Сначала добавьте элемент в дерево!");
                        break;
                    case 4: //FIND max ELEMENT   
                        if (binaryTree.Root != null)
                        {
                            Console.WriteLine($"Максимальный элемент: {binaryTree.Largest()}");
                        }
                        else Console.WriteLine("В дереве нет ни одного элемента. Сначала добавьте элемент в дерево!");
                        break;
                    case 5: //HEIGHT    
                        if (binaryTree.Root != null)
                        {
                            Console.WriteLine($"Высота дерева: {binaryTree.Height()}");
                        }
                        else Console.WriteLine("В дереве нет ни одного элемента. Сначала добавьте элемент в дерево!");
                        break;
                    case 6: //AMOUNT OF LEAVES
                        if (binaryTree.Root != null)
                        {
                            Console.WriteLine($"Количество листьев дерева: {binaryTree.NumberOfLeafNodes()}");
                        }
                        else Console.WriteLine("В дереве нет ни одного элемента. Сначала добавьте элемент в дерево!");
                        break;
                    case 7://IS BALANCED
                        if (binaryTree.Root != null)
                        {
                            bool balanced = binaryTree.IsBalanced();
                        if(balanced == true) Console.WriteLine("Дерево сбалансированное");
                        else Console.WriteLine("Дерево не сбалансированное");
                        }
                        else Console.WriteLine("В дереве нет ни одного элемента. Сначала добавьте элемент в дерево!");
                        break;
                    case 8://PRINT
                        if (binaryTree.Root != null)
                        {
                            binaryTree.Print();
                        }
                        else Console.WriteLine("В дереве нет ни одного элемента. Сначала добавьте элемент в дерево!");
                        break; 
                    case 9: //EXIT
                        ShowWindow(GetConsoleWindow(), SW_HIDE);
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Такого пункта меню не существует...");
                        break;
                }

            } while (d < 9);
            
        }

  
       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMenu();
        }

        static void WriteLineCentered(string text)//вывод текста в консоль посередине
        {
            int width = Console.WindowWidth;
            if (text.Length < width)
            {
                text = text.PadLeft((width - text.Length) / 2 + text.Length, ' ');
            }
            Console.WriteLine(text);
        }

        //this for show/hide console
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

    }
}

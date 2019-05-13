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
using System.Threading;

namespace B_trees
{
    public partial class Form1 : Form
    {
        BinaryTree binaryTree = new BinaryTree();

        public Form1()
        {
            InitializeComponent();

            //for blocking X from console
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);

            // Hide console
            ShowWindow(GetConsoleWindow(), SW_HIDE);

            // Show console
            // ShowWindow(handle, SW_SHOW);
        }

        private void ShowMenu()
        {
            switch (ListBox1.SelectedIndex)
            {
                case 0:
                    //theory  
                    Help.ShowHelp(this, "helpTheory.chm", "b_trees.htm");
                    break;
                case 1:                    
                    // Show console
                    ShowWindow(GetConsoleWindow(), SW_SHOW);
                    //show title
                    title();
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
           Console.WriteLine("1. Добавить элемент\n2. Удалить элемент\n3. Найти минимальный элемент\n4. Найти максимальный элемент\n5. Найти высоту дерева\n6. Найти количество листьев дерева\n7. Сбалансированное дерево?\n8. Печать дерева\n9. Выход\n");
        }

        private void title()
        {
            WriteLineCentered("ФЕДЕРАЛЬНОЕ АГЕНТСТВО ПО РЫБОЛОВСТВУ");
            WriteLineCentered("ФЕДЕРАЛЬНОЕ ГОСУДАРСТВЕННОЕ ОБРАЗОВАТЕЛЬНОЕ УЧРЕЖДЕНИЕУ");
            WriteLineCentered("ВЫСШЕГО ПРОФЕССИОНАЛЬНОГО ОБРАЗОВАНИЯ");
            WriteLineCentered("<<АСТРАХАНСКИЙ ГОСУДАРСТВЕННЫЙ ТЕХНИЧЕСКИЙ УНИВЕРСИТЕТ>>");
            WriteLineCentered("ИНСТИТУТ ИНФОРМАЦИОННЫХ ТЕХНОЛОГИЙ И КОММУНИКАЦИЙ");
            WriteLineCentered("КАФЕДРА");
            WriteLineCentered("<<АВТОМАТИЗИРОВАННЫЕ СИСТЕМЫ ОБРАБОТКИ ИНФОРМАЦИИ И УПРАВЛЕНИЯ>>\n");

            WriteLineCentered("КУРСОВАЯ РАБОТА");
            WriteLineCentered("по дисциплине\n");

            WriteLineCentered("<<Алгоритмы и структуры данных>>");
            WriteLineCentered("на тему:<<Учебно-демонстрационная программа модуля для работы с бинарным деревом>>\n");
            WriteLineCentered("Выполнила студентка группы ЗИПРб-31");
            WriteLineCentered("Калиева Диана\n");
        }

        private void ShowDemoMenu()
        {
            int d, element;
            DemoMenu();
            this.Close(); //close form1(main menu)
            do
            {               
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
                        }
                        else Console.WriteLine("В дереве нет ни одного элемента. Сначала добавьте элемент в дерево!");
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
                            if (balanced == true) Console.WriteLine("Дерево сбалансированное");
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
                        ShowWindow(GetConsoleWindow(), SW_HIDE); //hide console
                        Console.Clear();//clear console
                        Thread t1 = new Thread(new ThreadStart(callForm));//new thread for calling form1
                        t1.Start(); //open form1
                        break;
                    default:
                        Console.WriteLine("Такого пункта меню не существует...");
                        break;
                }

            } while (true);

        }

        static void callForm() //for open form1 (main menu)
        {
            Form1 formm = new Form1();
            Application.Run(formm);
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        //this is for show/hide console

        //[DllImport("kernel32.dll")]
        // static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        //for enabling X console (button X enabled, you cant close console by click the button)
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();        
    }
}

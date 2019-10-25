using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace B_trees
{
    public partial class Form2 : Form
    {
        string file_name = "t.txt";
        string[,] array;
        int total, amount_of_questions, correct_answers, wrong_answers, questionsAmount;
        static Random rand = new Random();

        public Form2()
        {
            InitializeComponent();
            init_test();
        }
        private void init_test()
        {
            button_next.Text = "Следующий вопрос";
            amount_of_questions = 11;
            questionsAmount = amount_of_questions;
            correct_answers = 0;
            wrong_answers = 0;
            load_file();
            radio_checked();
            radio_turn_on_off();
            label_result.Text = "";
            amount_of_questions--;
            show_question();
        }

        private void load_file()
        {
            try
            {
                string[] lines = File.ReadAllLines(file_name, Encoding.UTF8);
                total = lines.Length / 4; //total amount of questions in file 
                array = new string[amount_of_questions, 4];

                int[] temp = new int[amount_of_questions];
                int j;
                int k = 0;
                do
                {
                    j = rand.Next(0, total) * 4;
                    if (!temp.Contains(j))
                    {
                        array[k, 0] = lines[j];
                        for (int i = 1; i < 4; i++)
                            array[k, i] = lines[j + i];
                        temp[k] = j;
                        k++;
                    }
                } while (!(k == amount_of_questions));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void show_question()
        {
            radio_checked();
            label_question.Text = array[amount_of_questions, 0];
            radio_tags(rand.Next(1, 7));
            radio_answer1.Text = array[amount_of_questions, Convert.ToInt16(radio_answer1.Tag)];
            radio_answer2.Text = array[amount_of_questions, Convert.ToInt16(radio_answer2.Tag)];
            radio_answer3.Text = array[amount_of_questions, Convert.ToInt16(radio_answer3.Tag)];
        }
        private void button_next_Click(object sender, EventArgs e)
        {
            if (amount_of_questions < 0) { init_test(); return; }

            if (!(radio_answer1.Checked || radio_answer2.Checked || radio_answer3.Checked))
            {
                MessageBox.Show("Выберите вариант ответа");
                return;
            }
            if ((radio_answer1.Checked & Convert.ToInt16(radio_answer1.Tag) == 1) ||
                (radio_answer2.Checked & Convert.ToInt16(radio_answer2.Tag) == 1) ||
                (radio_answer3.Checked & Convert.ToInt16(radio_answer3.Tag) == 1))
            {
                correct_answers++;
                amount_of_questions--;
            }
            else
            {
                MessageBox.Show("Правильный вариант ответа: " + array[amount_of_questions, 1]);
                wrong_answers++;
                amount_of_questions--;
            }

            if (amount_of_questions < 0)
            {
                show_result();
                label_question.Text = "Результат теста";
                button_next.Text = "Тест заново";
                radio_turn_on_off();
                return;
            }
            show_question();
        }
        private void radio_turn_on_off()
        {
            if (amount_of_questions < 0)
            {
                radio_answer1.Visible = false;
                radio_answer2.Visible = false;
                radio_answer3.Visible = false;
            }
            else
            {
                radio_answer1.Visible = true;
                radio_answer2.Visible = true;
                radio_answer3.Visible = true;
            }
        }

        private void radio_checked()
        {
            radio_answer1.Checked = false;
            radio_answer2.Checked = false;
            radio_answer3.Checked = false;
        }


        private void radio_tags(int i)
        {
            switch (i)
            {
                case 1: radio_answer1.Tag = 1; radio_answer2.Tag = 2; radio_answer3.Tag = 3; break;
                case 2: radio_answer1.Tag = 1; radio_answer2.Tag = 3; radio_answer3.Tag = 2; break;
                case 3: radio_answer1.Tag = 2; radio_answer2.Tag = 1; radio_answer3.Tag = 3; break;
                case 4: radio_answer1.Tag = 2; radio_answer2.Tag = 3; radio_answer3.Tag = 1; break;
                case 5: radio_answer1.Tag = 3; radio_answer2.Tag = 1; radio_answer3.Tag = 2; break;
                case 6: radio_answer1.Tag = 3; radio_answer2.Tag = 2; radio_answer3.Tag = 1; break;
            }
        }

        private void show_result()
        {
            double percent = (correct_answers * 100) / questionsAmount;

            label_result.Text = "Правильных ответов: " + correct_answers.ToString() + "\n" +
                "Неправильных ответов: " + wrong_answers.ToString() + "\n" + "Вы ответили на: " + percent + "%";            
             
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Кузнецов_23ИС.FolderforModel;

namespace Кузнецов_23ИС
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Model1 DB = new Model1();//глобальная статическая переменна которая необходима для работы с классом ModelDB

        List<Table_Motorbike> Motorbikes = DB.Table_Motorbike.ToList();//Список класса Table_Motorbike содержащий данные из одноименной таблицы SQL
        int AccNumber = 0;//Переменна нужная для того, чтобы программа понимала на каком элементе из списка Motorbikes мы сейчас находимся

        private void Loading()//Первоначальная (обыная) загрузка элементов User Control
        {
            userControlName1.Fill(Motorbikes[AccNumber]);//заполнение 1-го User Control
            userControlName2.Fill(Motorbikes[AccNumber + 1]);//заполнение 2-го User Control
        }

        private void Loading(bool Incr)//Перегрузка метода Loading, чтобы на вход были другие параметры
        {
            if (Incr == true && Motorbikes.Count > AccNumber + 2)//проверка при нажатии "Листать вправо"
                AccNumber++;
            else if (Incr == false && 0 <= AccNumber - 1)//проверка при нажатии "Листать влево"
                AccNumber--;
            else
                return;//Если проверка не пройдена выход из метода

            Loading();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            Loading();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Loading(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loading(false);
        }
    }
}

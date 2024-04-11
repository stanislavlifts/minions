﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Миниони
{
    public partial class Form1 : Form
    {
        string connectionString = "server=10.42.42.64;port=3306;user=PC1;password=1111;database=minions";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection  dbMinions = new MySqlConnection(connectionString);
            dbMinions.Open();
            MessageBox.Show("Connection is now opened");

            MySqlCommand command = new MySqlCommand("select * from towns",dbMinions);

            MySqlDataReader reader = command.ExecuteReader();   

            List<ComboItem> items = new List<ComboItem>();

            while (reader.Read())
            {
                ComboItem item = new ComboItem();
                item.Id = (int)reader[0];
                item.Name = (string)reader[1];

                items.Add(item);

                //item.Id = 102;
                //item.Name="Stanislav";

            }
            reader.Close();

            comboBox1.DataSource = items;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            dbMinions.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($" 102. Ti vuvede{textBox1.Text}s godini {textBox2.Text}s grad {comboBox1.Text}-->{comboBox1.SelectedValue}");

            string insertSQL = "insert into minions.minions" +
            "(id, `name`, age, town_id)" +
            $"Values (102,@townName,@age,@townId)";
            //zapochva insert zaqvka
        }
    }
}

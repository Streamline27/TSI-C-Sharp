﻿using Lab5_DataBind.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_DataBind
{
    public partial class InputForm : Form
    {
        private IList<Person> personList;
        private DbForm dbForm;


        public InputForm()
        {
            InitializeComponent();

            personList = new BindingList<Person>();
            AttachDataSource();

        }


        // Events
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Person person = getPersonFromForm();
                personList.Add(person);
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("Age must be a number");
            }
        }


        private void buttonClear_Click(object sender, EventArgs e)
        {
            personList.Clear();
        }


        // Private helper functions
        private void AttachDataSource()
        {
            var source = new BindingSource(personList, null);
            dataGridView.DataSource = source;
        }


        private Person getPersonFromForm()
        {
            String firstName = tbFirstName.Text;
            String lastName = tbLastName.Text;
            int age = getAge();

            Person person = new Person(firstName, lastName, age);
            return person;
        }

        private int getAge()
        {
                int age;
                if (!Int32.TryParse(tbAge.Text, out age)) throw new System.ArgumentException {};
                return age;          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbForm = new DbForm(personList);
            dbForm.Show();
        }

    }
}
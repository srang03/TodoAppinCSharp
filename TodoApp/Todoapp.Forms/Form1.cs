using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TodoApp.Models;

namespace Todoapp.Forms
{
    public partial class Form1 : Form
    {
        private readonly ITodoRepository<TodoModel> _repository; 

        public Form1()
        {
            InitializeComponent();
            _repository = new TodoRepositoryJSON("C:\\Users\\Ian\\Desktop\\ian\\C#\\TodoAppinCSharp\\TodoApp\\Todo.ConsoleApp\\Todo.json");
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            _repository.AddTodo(new TodoModel()
            {
                Title = this.txb_todo.Text,
                IsDone = this.cbx_result.Checked
            });

            MessageBox.Show(_repository.Test());
            DisplayData();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            this.dataGridView1.DataSource = null; // Refresh 초기화
            this.dataGridView1.DataSource = _repository.GetAll();
        }
    }
}

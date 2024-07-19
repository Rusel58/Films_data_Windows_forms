using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JSONObject;

namespace _9_Davletov_CHW_3_2_pro
{
    /// <summary>
    /// Class for wotking with table of actors.
    /// </summary>
    public partial class ActorTable : Form
    {
        /// <summary>
        /// Initializes a new instance of the ActorTable class with the movie object.
        /// </summary>
        /// <param name="movie">Movie object.</param>
        public ActorTable(Movie movie)
        {
            InitializeComponent();

            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;

            // Changing background color of empty field. 
            dataGridView1.BackgroundColor = SystemColors.Control;

            // Setting name, size and style of Font family.
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);

            // Changing color of cells.
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dataGridView1.DefaultCellStyle.BackColor = Color.LightGray;

            // Setting color of border.
            dataGridView1.GridColor = Color.Black;

            // Deleting left colomn for highlighting row.
            dataGridView1.RowHeadersVisible = false;


            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ActorId", typeof(Guid));
            dataTable.Columns.Add("ActorName", typeof(string));
            dataTable.Columns.Add("Nationality", typeof(string));
            dataTable.Columns.Add("Earnings", typeof(double));

            foreach (Actor actor in movie.Actors) 
            {
                dataTable.Rows.Add(actor.ActorId, actor.ActorName, actor.Nationality, actor.Earnings);
            }

            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}

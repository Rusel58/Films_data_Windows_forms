using JSONObject;
using System.Data;
using System.Windows.Forms;

namespace _9_Davletov_CHW_3_2_pro
{
    /// <summary>
    /// Class for wotking with table of movies.
    /// </summary>
    public partial class MovieTable : Form
    {
        /// <summary>
        /// Initializes a new instance of the ActorTable class with the list of movies.
        /// </summary>
        /// <param name="movies">List of movies object.</param>
        public MovieTable(List<Movie> movies)
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
            dataTable.Columns.Add("MovieId", typeof(Guid));
            dataTable.Columns.Add("MovieTitle", typeof(string));
            dataTable.Columns.Add("Earnings", typeof(double));
            dataTable.Columns.Add("ActorsPercent", typeof(double));
            dataTable.Columns.Add("ReleaseYear", typeof(int));
            dataTable.Columns.Add("Genre", typeof(string));
            dataTable.Columns.Add("Rating", typeof(double));

            foreach (Movie movie in movies) 
            {
                dataTable.Rows.Add(movie.MovieId, movie.MovieTitle, movie.Earnings, movie.ActorsPercent,
                    movie.ReleaseYear, movie.Genre, movie.Rating);
            }

            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
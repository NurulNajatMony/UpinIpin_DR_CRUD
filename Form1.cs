using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUDMahasiswaADO
{
    public partial class FormMahasiswa : Form
    {
        public FormMahasiswa()
        {
            InitializeComponent();
        }

        //membuat method koneksi database (dalam class formMahasiswa)
        private readonly SqlConnection conn;
        private readonly string connectionString = (
            "Data Source=LAPTOP-4F1IGKI8\\NURUL;Initial Catalog=DBAkademikADO;Integrated Security=True");


        //langkah 5 ( membuat method koneksi database)
        private void connectToDatabase()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                MessageBox.Show("Koneksi berhasil!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal: " + ex.Message);
            }
        }

        //event tombol koneksi
        private void btnConnect_Click(object sender, EventArgs e)
        {
            connectToDatabase();
        }

        
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

        //langkah 6 (menampilkan data dengan sqldatareader)
        private void btnShowData_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                FormMahasiswa1.Rows.Clear();
                FormMahasiswa1.Columns.Clear();

                FormMahasiswa1.Columns.Add("NIM", "NIM");
                FormMahasiswa1.Columns.Add("Nama", "Nama");
                FormMahasiswa1.Columns.Add("JenisKelamin", "Jenis Kelamin");
                FormMahasiswa1.Columns.Add("TanggalLahir", "Tanggal Lahir");
                FormMahasiswa1.Columns.Add("Alamat", "Alamat");
                FormMahasiswa1.Columns.Add("KodeProdi", "Kode Prodi");

                string query = "SELECT * FROM Mahasiswa";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FormMahasiswa1.Rows.Add(
                        reader["NIM"].ToString(),
                        reader["Nama"].ToString(),
                        reader["JenisKelamin"].ToString(),
                        Convert.ToDateTime(reader["TanggalLahir"]).ToShortDateString(),
                        reader["Alamat"].ToString(),
                        reader["KodeProdi"].ToString()
                    );
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Menampilkan Data: " + ex.Message);
            }
        }

       
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Rest
{
    class cPersoneller
    {
        cGenel gnl = new cGenel();
        #region field
        private int _personelid;
        private int _personelgorevid;
        private string _personelad;
        private string _personelsoyad;
        private string _personelparola;
        private string _personelkullaniciadi;
        private bool _personeldurum;
        #endregion
        #region properties
        public int Personelid
        {
            get => _personelid; set => _personelid = value;
        }
 
        public int Personelgorevid
        {
            get => _personelgorevid; set => _personelgorevid = value;
        }
        public string Personelad
        {
            get => _personelad; set => _personelad = value;
        }
        public string Personelsoyad
        {
            get => _personelsoyad; set => _personelsoyad = value;
        }
        public string Personelparola
        {
            get => _personelparola; set => _personelparola = value;
        }
        public string Personelkullaniciadi
        {
            get => _personelkullaniciadi; set => _personelkullaniciadi = value;
        }
        public bool Personeldurum
        {
            get => _personeldurum; set => _personeldurum = value;
        }
        public SqlDataReader SqlDataReader { get; private set; }
        #endregion

        public bool PersonelEntryControl(string password, int userId)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.constring);
            SqlCommand cmd = new SqlCommand("Select * From Personeller Where ID=@Id And PAROLA=@password", con);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = userId;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            return result;
        }
        public void PersonelGetbyInformation(ComboBox cb)
        {
            cb.Items.Clear();
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.constring);
            SqlCommand cmd = new SqlCommand("Select * From Personeller ", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cPersoneller p = new cPersoneller();
                p._personelid = Convert.ToInt32(dr["Id"]);
                p._personelgorevid = Convert.ToInt32(dr["Gorev_id"]);
                p._personelad = Convert.ToString(dr["Ad"]);
                p._personelsoyad = Convert.ToString(dr["Soyad"]);
                p._personelkullaniciadi = Convert.ToString(dr["Kullanici_adi"]);
                p._personelparola = Convert.ToString(dr["Parola"]);
                p._personeldurum = Convert.ToBoolean(dr["Durum"]);
                cb.Items.Add(p);
            }

            dr.Close();
            con.Close();
        }
        public override string ToString()
        {
            return Personelad + " " + Personelsoyad;
        }
    }
}

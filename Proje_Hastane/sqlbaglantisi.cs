using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace Proje_Hastane
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source = ABC; Initial Catalog = HastaneProje; Integrated Security = True");
            baglan.Open();
            return baglan;
        }
    }
}

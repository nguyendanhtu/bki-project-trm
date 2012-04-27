using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;

[WebService(Namespace = "http://bkindex.com")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class PersonService : System.Web.Services.WebService
{
    [WebMethod]
    public List<Person> GetPersons(string name_prefix)
    {
        return get_top_ten_teacher_name(name_prefix);
    }

    private List<Person> get_top_ten_teacher_name(string ip_str_teacher_name)
    {
        SqlConnection v_connec = getConnection();
        if(v_connec.State == ConnectionState.Closed)
          v_connec.Open();
        DataTable v_dt = new DataTable();
        string query = " SELECT TOP 10 dgv.ID,dgv.HO_VA_TEN_DEM,dgv.TEN_GIANG_VIEN"
                      +" FROM DM_GIANG_VIEN dgv"
                      + " WHERE (dgv.HO_VA_TEN_DEM+' '+ dgv.TEN_GIANG_VIEN) LIKE N'" + ip_str_teacher_name + "%'"
                      + " OR (dgv.HO_VA_TEN_DEM+ dgv.TEN_GIANG_VIEN) LIKE N'" + ip_str_teacher_name + "%'"
                      +" ORDER BY dgv.TEN_GIANG_VIEN";
        SqlCommand v_comman = new SqlCommand(query, v_connec);
        SqlDataAdapter v_adap = new SqlDataAdapter(v_comman);
       v_adap.Fill(v_dt);
        if (v_dt.Rows.Count == 0) return null;
        List<Person> persons = new List<Person>();
        if (v_dt.Rows.Count > 0)
            for (int i = 0; i < v_dt.Rows.Count; i++)
            {
                Person v_per = new Person();
                v_per.ID = int.Parse(v_dt.Rows[i]["ID"].ToString());
                v_per.Name = v_dt.Rows[i]["HO_VA_TEN_DEM"].ToString().TrimEnd()+" "+v_dt.Rows[i]["TEN_GIANG_VIEN"].ToString();
                persons.Add(v_per);
                //persons.Add(new Person()
                //{
                //    ID = int.Parse(v_dt.Rows[i]["ID"].ToString()),
                //    Name = v_dt.Rows[i]["TEN_GIANG_VIEN"].ToString()
                //});
            }
        return persons;
    }

    private SqlConnection getConnection()
    {
        string v_str_query_string = "Data Source=.\\SQLEXPRESS; Initial Catalog=TRM; User Id=sa; Password=123456;";
        return new SqlConnection(v_str_query_string);
    }
}


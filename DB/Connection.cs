using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
public class Connection
{
 
    public SqlConnection conn = new SqlConnection();

    public SqlConnection create_AppConn()
    {
        if (conn.State == System.Data.ConnectionState.Closed)
        {
            string App_Conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; //getxmlvale(AppDomain.CurrentDomain.BaseDirectory + "/Config.xml", "JobApp_config");
            conn.ConnectionString = App_Conn;
            conn.Open();
        }
        return conn;
    }
    public void dispose_AppConn()
    {
        if (conn.State == System.Data.ConnectionState.Open)
        {
            conn.Close();
            // conn.Dispose()
        }
    }

    public int ExecuteNonQuery(string query)
    {
        using (SqlConnection connection = create_AppConn())
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = System.Data.CommandType.Text;
            return command.ExecuteNonQuery();
        }
    }

    public DataTable ExecuteReader(string query)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = create_AppConn())
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            return dt;
        }
    }

    public DataTable dataAdapterFill(string query)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = create_AppConn())
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            da.Dispose();
            command.Dispose();
        }
        return dt;
    }

    public string getxmlvale(string xmlpath, string nodeName)
    {
        string xmlFile = File.ReadAllText(xmlpath);
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(xmlFile);
        XmlNodeList nodeList = xmldoc.GetElementsByTagName(nodeName);
        string outputstr = string.Empty;
        foreach (XmlNode node in nodeList)
        {
            outputstr = node.InnerText;
        }
        return outputstr;
    }

    public object ExecuteScaler(string qry)
    {
        object ret = null;
        using (SqlConnection connection = create_AppConn())
        {
            SqlCommand cmd = new SqlCommand(qry, connection);
            ret = (cmd.ExecuteScalar());
        }
        return ret;
    }
}
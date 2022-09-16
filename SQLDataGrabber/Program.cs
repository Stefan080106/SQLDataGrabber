using System.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        string connetionString;
        SqlConnection cnn;
        connetionString = @"Server=localhost;Database=master;Trusted_Connection=True;";
        cnn = new SqlConnection(connetionString);
        cnn.Open();
        Console.WriteLine("Connection Open  !");

        SqlCommand command;
        SqlDataReader dataReader;
        string sql, Out = "";

        sql = "SELECT * FROM Test";

        command = new SqlCommand(sql, cnn);

        dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                Out += (i == 0 ? "" : " - ") + dataReader.GetValue(i);
            }
            Out += "\n";
        }

        Console.WriteLine(Out);
        dataReader.Close();
        command.Dispose();
        cnn.Close();
    }
}
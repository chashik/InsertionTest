using Comparison;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ORMFree
{
    public class SQLClientProvider : Provider<Metering>
    {
        private string _connectionString;

        public SQLClientProvider(Metering[] meterings) : base(meterings)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["mirDBConnectionString"].ConnectionString;
        }

        public override string Name => "SqlClient (Stored procedure - for iterative, SqlBulkCopy - for bulk)";

        public override void ClearSource()
         {
            using (SqlConnection myConnection = new SqlConnection(_connectionString))
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("dbo.METERING_DeleteAll", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.ExecuteNonQuery();
            }
        }

        protected override void AddMultiple(Metering[] dataItems)
        {
            using (SqlConnection myConnection = new SqlConnection(_connectionString))
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(myConnection))
            {
                myConnection.Open();

                var reader = dataItems.ToList().GetDataReader();

                bulkCopy.DestinationTableName = "dbo.METERINGS";

                try
                {
                    bulkCopy.WriteToServer(reader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        protected override void AddSingle(Metering item)
        {
             using (SqlConnection myConnection = new SqlConnection(_connectionString))
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("dbo.METERING_Insert", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IDOBJECT", item.IDOBJECT));
                cmd.Parameters.Add(new SqlParameter("@IDTYPE_OBJECT", item.IDTYPE_OBJECT));
                cmd.Parameters.Add(new SqlParameter("@TIME_END", item.TIME_END));
                cmd.Parameters.Add(new SqlParameter("@IDOBJECT_AGGREGATE", item.IDOBJECT_AGGREGATE));
                cmd.Parameters.Add(new SqlParameter("@IDOBJECT_AVERAGE", item.IDOBJECT_AVERAGE));
                cmd.Parameters.Add(new SqlParameter("@TIME_BEGIN", item.TIME_BEGIN));
                cmd.Parameters.Add(new SqlParameter("@STATUS", item.STATUS));
                cmd.Parameters.Add(new SqlParameter("@VALUE_METERING", item.VALUE_METERING));
                cmd.Parameters.Add(new SqlParameter("@TIME_INSERT", item.TIME_BEGIN));

                cmd.ExecuteNonQuery();
            }
        }

        protected override Metering[] CreateDataItems(Metering[] meterings) => meterings;
    }
}

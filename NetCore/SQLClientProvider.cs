using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace NetCore
{
    public class SQLClientProvider : Provider<METERING>
    {
        private string _connectionString =
            @"Data Source=CHUGGUN\SQLEXPRESS;Initial Catalog=mir;Persist Security Info=True;User ID=cl;Password=cl";

        public SQLClientProvider(Metering[] meterings) : base(meterings)
        {
        }

        public override string Name => "SqlClient (Stored procedure - for iterative, SqlBulkCopy - for bulk)";

        public override void ClearSource()
         {
            using (SqlConnection myConnection = new SqlConnection(_connectionString))
            {
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("dbo.METERING_DeleteAll", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
        }

        protected override void AddMultiple(METERING[] dataItems)
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

        protected override void AddSingle(METERING item)
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
                cmd.Parameters.Add(new SqlParameter("@TIME_INSERT", item.TIME_INSERT));

                cmd.ExecuteNonQuery();
            }
        }

        protected override METERING[] CreateDataItems(Metering[] meterings)
        {
            return Array.ConvertAll(meterings,
                p => new METERING()
                {
                    IDOBJECT = p.IDOBJECT,
                    IDOBJECT_AVERAGE = p.IDOBJECT_AVERAGE,
                    IDTYPE_OBJECT = p.IDTYPE_OBJECT,
                    STATUS = p.STATUS,
                    TIME_BEGIN = p.TIME_BEGIN,
                    TIME_END = p.TIME_END,
                    VALUE_METERING = p.VALUE_METERING,
                    TIME_INSERT = p.TIME_BEGIN
                });
        }
    }
}

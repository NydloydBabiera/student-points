using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_points
{
    internal class DatabaseClass
    {
        public class DBPostgres
        {
            private readonly string _connStr;
            private string c_Columname;
            private string c_Values;
            public DBPostgres(string connStr)
            {
                _connStr = connStr;
            }
            


            public void AddRecord(string tableName, Dictionary<string, object> data)
            {
                using (var conn = new NpgsqlConnection(_connStr))
                {
                    try
                    {
                        conn.Open();

                        var columns = new StringBuilder();
                        var values = new StringBuilder();
                        var cmd = new NpgsqlCommand();
                        int i = 0;

                        foreach (var kvp in data)
                        {
                            string paramName = "@p" + i;

                            columns.Append(kvp.Key);
                            values.Append(paramName);

                            if (i < data.Count - 1)
                            {
                                columns.Append(", ");
                                values.Append(", ");
                            }

                            cmd.Parameters.AddWithValue(paramName, kvp.Value ?? DBNull.Value);
                            i++;
                        }

                        // ✅ Include RETURNING * to get the inserted row
                        cmd.Connection = conn;
                        cmd.CommandText = $"INSERT INTO {tableName} ({columns}) VALUES ({values}) RETURNING *;";

                        // Execute and get the inserted row
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // You can access columns by name or index
                                var insertedRow = new Dictionary<string, object>();

                                for (int j = 0; j < reader.FieldCount; j++)
                                {
                                    insertedRow[reader.GetName(j)] = reader.GetValue(j);
                                }





                                // Optionally return the row if you want to use it outside
                                //return insertedRow;
                            }
                            else
                            {
                                MessageBox.Show("⚠️ No record was inserted.", "Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"❌ Error inserting record:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }



            public void setColumn(string columnName)
            {
                if (c_Columname == string.Empty)
                    c_Columname = columnName;
                else
                    c_Columname = c_Columname + ", " + columnName;
            }

            public void setValues(string val)
            {
                if (c_Values == string.Empty)
                {
                    if (val != "")
                    {
                        if (val.Substring(0, 1) == "@")
                            c_Values = " " + val.Substring(1) + " ";
                        else
                            c_Values = "'" + val + "'";
                    }


                }
                else
                {

                    if (val != "")
                    {
                        if (val.Substring(0, 1) == "@")
                            c_Values = c_Values + ", " + val.Substring(1);
                        else
                            c_Values = c_Values + ", '" + val + "'";
                    }
                    else
                    {
                        Console.WriteLine("val:" + val);
                    }

                }



            }

            public void LoadData(string tableName, DataGridView gridView)
            {
                using (var conn = new NpgsqlConnection(_connStr))
                {
                    try
                    {
                        conn.Open();

                        string query = $"SELECT * FROM {tableName}";
                        using (var da = new NpgsqlDataAdapter(query, conn))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            gridView.DataSource = dt;
                            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"❌ Error loading data:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            public async Task<int> UpdateRowAsync(
            string tableName,
            string keyColumn,
            object keyValue,
            Dictionary<string, object> columnsToUpdate)
            {
                if (columnsToUpdate == null || columnsToUpdate.Count == 0)
                    throw new ArgumentException("No columns provided to update.");

                // Build SET clause dynamically: "col1 = @col1, col2 = @col2"
                var setClauses = new List<string>();
                foreach (var col in columnsToUpdate)
                {
                    setClauses.Add($"{col.Key} = @{col.Key}");
                }

                string query = $@"
                UPDATE {tableName}
                SET {string.Join(", ", setClauses)}
                WHERE {keyColumn} = @keyValue;
            ";
                using (var conn = new NpgsqlConnection(_connStr))
                {
                    await conn.OpenAsync();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        // Add dynamic parameters
                        foreach (var col in columnsToUpdate)
                        {
                            if (col.Value is long)
                            {
                                cmd.Parameters.Add($"@{col.Key}", NpgsqlTypes.NpgsqlDbType.Bigint)
                                              .Value = (long)col.Value;
                            }
                            else if (col.Value is int)
                            {
                                cmd.Parameters.Add($"@{col.Key}", NpgsqlTypes.NpgsqlDbType.Integer)
                                              .Value = (int)col.Value;
                            }
                            else if (col.Value is DateTime)
                            {
                                cmd.Parameters.Add($"@{col.Key}", NpgsqlTypes.NpgsqlDbType.Timestamp)
                                              .Value = (DateTime)col.Value;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue($"@{col.Key}", col.Value ?? DBNull.Value);
                            }
                        }
                        // Key parameter
                        cmd.Parameters.AddWithValue("@keyValue", keyValue);

                        return await cmd.ExecuteNonQueryAsync(); // returns number of affected rows
                    }
                }

               
            }

            public bool CheckIfDataExists(string tableName, string columnName, string value)
            {
                if (string.IsNullOrWhiteSpace(_connStr))
                {
                    MessageBox.Show("❌ Connection string is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(columnName))
                {
                    MessageBox.Show("❌ Table name or column name is null or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                using (var conn = new NpgsqlConnection(_connStr))
                {
                    try
                    {
                        conn.Open();
                        string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @value";

                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@value", value ?? (object)DBNull.Value);

                            var result = cmd.ExecuteScalar();

                            if (result == null || result == DBNull.Value)
                                return false;

                            int count = Convert.ToInt32(result);
                            return count > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"❌ Error checking data existence:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            public async Task<int> DeleteRowAsync(
           string tableName,
           string keyColumn,
           object keyValue)
            {
                if (string.IsNullOrWhiteSpace(tableName))
                    throw new ArgumentException("Table name is required.");

                if (string.IsNullOrWhiteSpace(keyColumn))
                    throw new ArgumentException("Key column is required.");

                string query = $@"
                DELETE FROM {tableName}
                WHERE {keyColumn} = @keyValue;
            ";

                //await using var conn = new NpgsqlConnection(_connStr);
                //await conn.OpenAsync();

                //await using var cmd = new NpgsqlCommand(query, conn);

                using (var conn = new NpgsqlConnection(_connStr))
                {
                    await conn.OpenAsync();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        // Parameter typing
                        if (keyValue is long)
                        {
                            cmd.Parameters.Add("@keyValue", NpgsqlTypes.NpgsqlDbType.Bigint).Value = keyValue;
                        }
                        else if (keyValue is int)
                        {
                            cmd.Parameters.Add("@keyValue", NpgsqlTypes.NpgsqlDbType.Integer).Value = keyValue;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@keyValue", keyValue);
                        }

                        return await cmd.ExecuteNonQueryAsync();
                    }
                }
     
            }

            public (int studentId, string name, string gradeLevel, string levelSection, string studentIdNumber, string points)? GetStudentInformation(string rfidNumber)
            {
                using (var conn = new NpgsqlConnection(_connStr))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(
                        "select " +
                        "s.studentid, " +
                        "CONCAT(s.firstname, ' ', s.middlename, ' ', s.lastname) as name, "+
                        "s.gradeLevel, "+
                        "s.levelSection, "+
                        "s.studetidnumber, "+
                        "CONCAT(TO_CHAR(COALESCE(SUM(sp.points), 0), 'FM999999999990.00'), ' points') AS points " +
                        "from students s "+
                        "left "+
                        "join studentpoints sp on sp.studentid = s.studentid "+
                        "where s.rfidnumber = @rfidNumber " +
                        "group by s.studentid ", conn))
                    {
                        cmd.Parameters.AddWithValue("@rfidNumber", rfidNumber);

                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                return (rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5));
                            }
                        }
                    }
                }
                // Return null if no row found
                return null;
            }


        }
    }
}

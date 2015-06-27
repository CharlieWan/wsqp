using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;   //DataSet/DataTable/DataRow/DataCol
using System.Reflection;   //反射命名空间
using MySql.Data.MySqlClient;

namespace DAL
{
    /// <summary>
    /// 数据库操作帮助类
    /// </summary>
    public static class MySqlHelper
    {
        //1.准备连接字符串
        //public static readonly string connStr = ConfigurationManager.AppSettings["connStr"];
        public static readonly string connStr = ConfigurationManager.ConnectionStrings["mysqlConnStr"].ConnectionString;

        #region 2.执行查询多行语句 - 返回数据表 +static DataTable ExcuteDataTable(string strSelectCmd, params SqlParameter[] paras)
        /// <summary>
        /// 2.执行查询多行语句 - 返回数据表
        /// </summary>
        /// <param name="strSelectCmd"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static DataTable ExcuteDataTable(string strSelectCmd, params MySqlParameter[] paras)
        {
            //1.创建连接通道
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                //2.创建适配器
                MySqlDataAdapter da = new MySqlDataAdapter(strSelectCmd, conn);
                //2.1设置查询命令的参数
                da.SelectCommand.Parameters.AddRange(paras);
                //3.数据表
                DataTable dt = new DataTable();
                //4.将数据查询并填充到数据表中
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region  2.0升级泛型版 ------ 执行查询多行语句 - 返回数据表
        /// <summary>
        /// 2.0升级泛型版 ------ 执行查询多行语句 - 返回数据表
        /// </summary>
        /// <typeparam name="T2">泛型类型</typeparam>
        /// <param name="strSelectCmd">查询sql语句</param>
        /// <param name="paras">查询参数</param>
        /// <returns>泛型集合</returns>
        public static List<T2> ExcuteList<T2>(string strSelectCmd, params MySqlParameter[] paras)
        {
            //1.创建连接通道
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                //2.创建适配器
                MySqlDataAdapter da = new MySqlDataAdapter(strSelectCmd, conn);
                //2.1设置查询命令的参数
                da.SelectCommand.Parameters.AddRange(paras);
                //3.数据表
                DataTable dt = new DataTable();
                //4.将数据查询并填充到数据表中u



                da.Fill(dt);
                //5.将DataTable转成泛型集合List<T2>
                if (dt.Rows.Count > 0)
                {
                    //6.创建泛型集合对象
                    List<T2> list = new List<T2>();
                    //7.遍历数据行，将行数据存入 实体对象中，并添加到 泛型集合中list
                    foreach (DataRow row in dt.Rows)
                    {
                        //留言：等学完反射后再讲~~~~！
                        //7.1先获得泛型的类型(里面包含该类的所有信息---有什么属性啊，有什么方法啊，什么字段啊....................)
                        Type t = typeof(T2);
                        //7.2根据类型创建该类型的对象
                        T2 model = (T2)Activator.CreateInstance(t);// new Student()
                        //7.3根据类型 获得 该类型的 所有属性定义
                        PropertyInfo[] properties = t.GetProperties();
                        //7.4遍历属性数组
                        foreach (PropertyInfo p in properties)
                        {
                            //7.4.1获得属性名，作为列名
                            string colName = p.Name;
                            //7.4.2根据列名 获得当前循环行对应列的值
                            object colValue = row[colName];
                            //7.4.3将列值 赋给 model对象的p属性
                            //model.Name=colValue;
                            p.SetValue(model, colValue, null);
                        }
                        //7.5将装好 了行数据的 实体对象 添加到 泛型集合中 O了！！！
                        list.Add(model);
                    }
                    return list;
                }
            }
            return null;
        }
        #endregion

        #region 3.执行查询多行语句 - 返回数据读取器  +static SqlDataReader ExcuteDataReader(string strSelectCmd, params SqlParameter[] paras)
        /// <summary>
        /// 执行查询多行语句 - 返回数据读取器
        /// </summary>
        /// <param name="strSelectCmd"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static MySqlDataReader ExcuteDataReader(string strSelectCmd, params MySqlParameter[] paras)
        {
            MySqlConnection conn = null;
            try
            {
                //1.创建连接通道
                conn = new MySqlConnection(connStr);
                //2.创建命令对象
                MySqlCommand cmd = new MySqlCommand(strSelectCmd, conn);
                //3.添加命令参数
                cmd.Parameters.AddRange(paras);
                //4.打开连接
                conn.Open();
                //5.创建读取器（当关闭此读取器时，会自动关闭连接通道）
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);//当关闭此读取器时，会自动关闭连接通道
                //6.返回读取器
                return dr;
            }
            catch (Exception ex)
            {
                conn.Dispose();
                throw ex;
            }
        }
        #endregion

        #region 4.执行非查询语句（增删改） +static int ExcuteNonQuery(string strCmd, params SqlParameter[] paras)
        /// <summary>
        /// 执行非查询语句（增删改）
        /// </summary>
        /// <param name="strCmd"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static int ExcuteNonQuery(string strCmd, params  MySqlParameter[] paras)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand cmd = new MySqlCommand(strCmd, conn);
                cmd.Parameters.AddRange(paras);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region 5.查询结果集里的第一个单元格的值（单个值）+static object ExcuteScalar(string strSelectCmd, params SqlParameter[] paras)
        /// <summary>
        /// 查询结果集里的第一个单元格的值（单个值）
        /// </summary>
        /// <param name="strSelectCmd"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static object ExcuteScalar(string strSelectCmd, params MySqlParameter[] paras)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand cmd = new MySqlCommand(strSelectCmd, conn);
                cmd.Parameters.AddRange(paras);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
        #endregion

        #region 6.查询结果集里的第一个单元格的值（单个值）-- 泛型版本 + static T ExcuteScalar<T>(string strSelectCmd, params SqlParameter[] paras)
        /// <summary>
        /// 查询结果集里的第一个单元格的值（单个值）-- 泛型版本
        /// </summary>
        /// <typeparam name="T">类型参数</typeparam>
        /// <param name="strSelectCmd"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static T ExcuteScalar<T>(string strSelectCmd, params MySqlParameter[] paras)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand cmd = new MySqlCommand(strSelectCmd, conn);
                cmd.Parameters.AddRange(paras);
                conn.Open();
                object o = cmd.ExecuteScalar();
                return (T)o;
            }
        }
        #endregion

         #region 7.执行 特殊的 分页存储过程 +DataTable GetPageListByProc(int pageIndex, int pageSize,out int pageCount,out int rowCount)
        /// <summary>
        ///04.执行 特殊的 分页存储过程
        /// </summary>
        /// <param name="proName">存储过程名称</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="userId">用户id</param>
        /// <param name="pageCount">总页数--输出</param>
        /// <param name="rowCount">总行数--输出</param>
        /// <returns></returns>
        public static DataTable GetPageListByProc(string proName, int pageIndex, int pageSize, int cid, out int pageCount, out int rowCount)
        {
            DataTable dt = new DataTable();
            //创建连接通道
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                //创建适配器对象
                MySqlDataAdapter da = new MySqlDataAdapter(proName, conn);
                //设置 命令类型 为存储过程
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //设置 参数
                da.SelectCommand.Parameters.AddWithValue("@pi", pageIndex);//当前页码
                da.SelectCommand.Parameters.AddWithValue("@ps", pageSize);//页容量

                //在存储过程中 输出参数
                da.SelectCommand.Parameters.Add(new MySqlParameter("@pc", SqlDbType.Int));
                da.SelectCommand.Parameters.Add(new MySqlParameter("@rc", SqlDbType.Int));
                //将后面两个参数 设置为 输出类型
                da.SelectCommand.Parameters[2].Direction = ParameterDirection.Output;
                da.SelectCommand.Parameters[3].Direction = ParameterDirection.Output;
                da.SelectCommand.Parameters.AddWithValue("@cid", cid);
                //执行 并将查询到的 结果 赋给 数据表对象
                da.Fill(dt);
                //获得 存储过程 返回的 输出参数
                rowCount = Convert.ToInt32(da.SelectCommand.Parameters[2].Value);
                pageCount = Convert.ToInt32(da.SelectCommand.Parameters[3].Value);
            }
            //返回数据表
            return dt;
        }
        #endregion

        #region 8.执行查询多行语句 - 返回数据读取器  +static SqlDataReader ExcuteDataReader(string strSelectCmd, params SqlParameter[] paras)
        /// <summary>
        /// 执行查询多行语句 - 返回数据读取器
        /// </summary>
        /// <param name="strSelectCmd"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static MySqlDataReader ExcuteDataReaderNew(string strSelectCmd, params MySqlParameter[] paras)
        {
            MySqlConnection conn = null;
            try
            {
                //1.创建连接通道
                conn = new MySqlConnection(connStr);
                //2.创建命令对象
                MySqlCommand cmd = new MySqlCommand(strSelectCmd, conn);
                //3.添加命令参数
                cmd.Parameters.AddRange(paras);
                //4.打开连接
                conn.Open();
                //5.创建读取器（当关闭此读取器时，会自动关闭连接通道）
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);//当关闭此读取器时，会自动关闭连接通道
                //6.返回读取器
                return dr;
            }
            catch (Exception ex)
            {
                conn.Dispose();
                throw ex;
            }
        }
        #endregion
    }
}
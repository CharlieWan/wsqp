using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
  public  class Entry
    {
      public DataTable GetAllEntryGroup()
      {
          string sql = "select * from entry_group";
          return MySqlHelper.ExcuteDataTable(sql);
      }

      public DataTable GetEntriesByGid(int gid)
      {
          string sql = "select  *  from entry where  isdelete=0 and gid=@gid";
          MySqlParameter msp = new MySqlParameter("@gid",gid);
          return MySqlHelper.ExcuteDataTable(sql, msp);
      }

      public DataTable GetPasswordById(int id)
      {
          string sql = "select  *  from entry where isdelete=0 and id=@id";
          MySqlParameter msp = new MySqlParameter("@id",id);
          return MySqlHelper.ExcuteDataTable(sql, msp);
      }
    }
}

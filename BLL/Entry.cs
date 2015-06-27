using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
 public    class Entry
    {
     DAL.Entry dalEntry = new DAL.Entry();
     public DataTable GetAllEntryGroup()
     {
         return dalEntry.GetAllEntryGroup();
     }

     public DataTable GetEntriesByGid(int gid)
     {
         return dalEntry.GetEntriesByGid(gid);
     }

     public DataTable GetPasswordById(int id)
     {
         return dalEntry.GetPasswordById(id);
     }
    }
}

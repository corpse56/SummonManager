using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SummonManager.CLASSES
{
    class DBCableList :DB
    {
        public DataTable GetPackage(int IDWP)
        {
            DA.SelectCommand.Parameters.AddWithValue("IDWP", IDWP);
            DA.SelectCommand.CommandText = " select A.ID id,A.ID nn,B.CABLENAME,A.CNT " +
                                           " left join " + Base.BaseName + "..CABLELIST B ON B.ID = A.IDCABLE " +
                                           " from " + Base.BaseName + "..CABLES where IDWP = @IDWP ";
            DA.Fill(DS, "t");
            return DS.Tables["t"];
        }

    }
}

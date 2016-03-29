using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummonManager.CLASSES.IRole_namespace;
using System.Windows.Forms;
using SummonManager.CLASSES;



namespace SummonManager
{

    public class UVO_DIRECTOR  :  IRole
    {


        public override string GetRoleName()
        {
            return "Директор";
        }

        public override void ssLoad(ShowSummon ss)
        {
            DisableAbsolute(ss);
            LoadSummon(ss);
            EnableInitial(ss);
        }


        public override void EnableInitial(ShowSummon ss)
        {
            ss.bPrint.Enabled = true;
            ss.bCancel.Enabled = true;
        }
        public override void EnableEdit(ShowSummon ss)
        {
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SummonManager.CLASSES.IRole_namespace;
using System.Windows.Forms;



namespace SummonManager
{

    public class UVO_ADMIN:IRole
    {

        public override string GetRoleName()
        {
            return "Администратор";
        }

        public override void ssLoad(ShowSummon ss)
        {
            DisableAbsolute(ss);
            LoadSummon(ss);
            EnableInitial(ss);

        }
        public override void EnableInitial(ShowSummon ss)
        {

            ss.bEdit.Enabled = true;
            ss.bSave.Enabled = false;
            ss.bPrint.Enabled = true;
            ss.bDelSummon.Enabled = true;
            ss.bEditCustomers.Enabled = true;
            ss.bEditWP.Enabled = true;
            ss.bPurchMat.Enabled = true;

            ss.summonTransfer1.Enabled = true;
            ss.summonTransfer2.Enabled = true;

            ss.summonNotes1.button1.Enabled = true;
        }
        public override void EnableEdit(ShowSummon ss)
        {
            EnableAll(ss);
        }

        private void EnableAll(ShowSummon ss)
        {
            ss.tbQUANTITY.ReadOnly = false;
            ss.tbSHIPPING.ReadOnly = false;
            ss.tbCONTRACT.ReadOnly = false;
            ss.tbDELIVERY.ReadOnly = false;
            ss.tbPayStatus.ReadOnly = false;

            ss.cbAccept.ReadOnly = false;
            ss.cbCustomers.ReadOnly = false;
            ss.cbSISP.ReadOnly = false;
            ss.cbPacking.ReadOnly = false;
            ss.cbMountingKit.ReadOnly = false;
            ss.cbCustDept.ReadOnly = false;

            ss.dtpPTIME.Enabled = true;
            ss.chbDeterm.Enabled = true;

            if (ss.chbDeterm.Checked)
                ss.dtpAPPROX.Enabled = false;
            else
                ss.dtpAPPROX.Enabled = true;

            ss.bEdit.Enabled = false;
            ss.bSave.Enabled = true;
            ss.summonTransfer1.Enabled = true;
            ss.summonTransfer2.Enabled = true;

            ss.chbBillPayed.Enabled = true;
            ss.chbDocsRdy.Enabled = true;
        }

    }
}

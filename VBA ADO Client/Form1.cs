using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Tools->References
// ADODB Microsoft ActiveX Data Objects 6.1 Library  C:\Program Files (x86)\Common Files\System\ado\msado15.dll


namespace VBA_ADO_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //var vVarArray;
            ADODB.Connection oConn;
            oConn = new ADODB.Connection();
            // SimpleOLEDBProvider1.MyDataSource is progid of the custom simple provider
            oConn.Open("Provider=MSDAOSP;Data Source=ArmDataOLEDBProvider.ArmDataSource");

            ADODB.Recordset rsColors;
            rsColors = new ADODB.Recordset();
            rsColors.ActiveConnection = oConn;
            rsColors.Open("colors");



            // rsColors.Seek "Green"  ' * throws error "Current provider does not support the necessary interface for Index functionality."
            // rsColors.Sort = "colorName" ' * throws error "Current provider does not support the necessary interfaces for sorting or filtering."



            Debug.Assert(rsColors.RecordCount == 3);
            rsColors.Filter = "colorName='Green' or colorName='Red'";
            rsColors.Update();
            Debug.Assert (rsColors.RecordCount == 2);


            rsColors.Filter = "";


            rsColors.AddNew();
   // rsColors.i["ColorName"] = "Yellow";
    //rsColors!ColorRGB = "FFFF00";
            rsColors.Update();


    Debug.Assert (rsColors.RecordCount == 4);


            rsColors.MoveFirst();
            rsColors.Delete();
            rsColors.Update();


    Debug.Assert (rsColors.RecordCount == 3);



            rsColors.MoveFirst();
    //        vVarArray = Application.WorksheetFunction.Transpose(rsColors.GetRows);
    

   // Dim rsCustomers As ADODB.Recordset
   // Set rsCustomers = New ADODB.Recordset

  //  Set rsCustomers.ActiveConnection = oConn
  //  rsCustomers.Open "customers"

  //  vVarArray = Application.WorksheetFunction.Transpose(rsCustomers.GetRows)
  //  Stop

  //  Dim rsOrders As ADODB.Recordset
  //  Set rsOrders = New ADODB.Recordset

  //  Set rsOrders.ActiveConnection = oConn


  //  rsOrders.Open "Orders"
  //  vVarArray = Application.WorksheetFunction.Transpose(rsOrders.GetRows)

    //'Dim rng As Excel.Range
    //'Set rng = ThisWorkbook.Worksheets.Item(1).Cells(1, 1)
    //'rsOrders.MoveFirst
    //'rng.CopyFromRecordset rsOrders




        }
    }
}

using System.Collections.Generic;
using System.Windows.Forms;
using EllipticCurveCompoents;
using System.Data;
using System.Data.OleDb;
using System.IO;


namespace SigningInterface
{
	public partial class Form4 : Form
	{
		Form3 form3;
		DataSet dataset = new DataSet();
		string select;
		OleDbConnection strCon;
		OleDbCommand comand;
		OleDbDataAdapter adapter;
		public Form4()
		{
			InitializeComponent();
			form3 = new Form3();
		}

		public void Show(string title)
		{
			this.showResult();
		}

		public void showCreateSignResult(List<CheckBox> checkBoxes)
		{
			InitializeCurves.getCurvesAndPoints();
			List<(IEllipticCurve, IPoint)> curvesAndPoints = new List<(IEllipticCurve, IPoint)>();
			foreach (var cb in checkBoxes)
			{
				if (cb.Name == "cbWeirCartes")
				{
					curvesAndPoints.Add((InitializeCurves.weierstrassCartesianCurve, InitializeCurves.weierstrassCartesianPoint));
				}
				else if (cb.Name == "cbWeirProj")
				{
					curvesAndPoints.Add((InitializeCurves.weierstrassProjectiveCurve, InitializeCurves.weierstrassProjectivePoint));
				}
				else if (cb.Name == "cbEdwCartes")
				{
					curvesAndPoints.Add((InitializeCurves.edwardsCartesianCurve, InitializeCurves.edwardsCartesianPoint));
				}
				else if (cb.Name == "cbEdwProj")
				{
					curvesAndPoints.Add((InitializeCurves.edwardsProjectiveCurve, InitializeCurves.edwardsProjectivePoint));
				}
			}
			Measurement.generateSign(curvesAndPoints);
		}

		public void showVerifySignResult(List<CheckBox> checkBoxes)
		{
			InitializeCurves.getCurvesAndPoints();
			List<(IEllipticCurve, IPoint)> curvesAndPoints = new List<(IEllipticCurve, IPoint)>();
			List<(IEllipticCurve, IPoint)> QCurvesPoints = new List<(IEllipticCurve, IPoint)>();
			foreach (var cb in checkBoxes)
			{
				if (cb.Name == "cbWeirCartes")
				{
					curvesAndPoints.Add((InitializeCurves.weierstrassCartesianCurve, 
						InitializeCurves.weierstrassCartesianPoint));
					QCurvesPoints.Add((InitializeCurves.weierstrassCartesianCurve,
						InitializeCurves.QWeirCartesianPoint));
				}
				else if (cb.Name == "cbWeirProj")
				{
					curvesAndPoints.Add((InitializeCurves.weierstrassProjectiveCurve,
						InitializeCurves.weierstrassProjectivePoint));
					QCurvesPoints.Add((InitializeCurves.weierstrassProjectiveCurve,
						InitializeCurves.QWeirProjectivePoint));
				}
				else if (cb.Name == "cbEdwCartes")
				{
					curvesAndPoints.Add((InitializeCurves.edwardsCartesianCurve,
						InitializeCurves.edwardsCartesianPoint));
					QCurvesPoints.Add((InitializeCurves.edwardsCartesianCurve,
						InitializeCurves.QEdwCartesianPoint));
				}
				else if (cb.Name == "cbEdwProj")
				{
					curvesAndPoints.Add((InitializeCurves.edwardsProjectiveCurve,
						InitializeCurves.edwardsProjectivePoint));
					QCurvesPoints.Add((InitializeCurves.edwardsProjectiveCurve,
						InitializeCurves.QEdwProjectivePoint));
				}
			}
			Measurement.verifySign(curvesAndPoints, QCurvesPoints);
		}

		private void showResult()
        {
			DataTable.DataSource=null;
			this.Show();
			var name = Path.GetFullPath("../fillDataGrid/tableData.txt").Remove(Path.GetFullPath("../fillDataGrid/tableData.txt").LastIndexOf("\\"));
			var fileName = "tableData.txt";
			select = "SELECT * FROM [" + fileName + "]";
			strCon = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + name + ";Extended Properties=text");
			comand = new OleDbCommand(select, strCon);
			adapter = new OleDbDataAdapter(comand);
			strCon.Open();
			adapter.Fill(dataset);
			DataTable.DataSource = dataset.Tables[0];
			strCon.Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
			this.Close();
        }
    }
}
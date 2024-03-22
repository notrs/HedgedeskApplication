namespace HedgedeskReportProject
{
    partial class ReconciliationReport_ByComp
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReconciliationReport_ByComp));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            this.groupFooterSection2 = new Telerik.Reporting.GroupFooterSection();
            this.txtSumTotalBrokerComm = new Telerik.Reporting.TextBox();
            this.txtSumTotalPBF = new Telerik.Reporting.TextBox();
            this.txtSumProfitLoss = new Telerik.Reporting.TextBox();
            this.txtSumOfMargin = new Telerik.Reporting.TextBox();
            this.txtCurrentLedgerBalance = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.txtSumOpenEquity = new Telerik.Reporting.TextBox();
            this.groupHeaderSection2 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox40 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox42 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.textBox29 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // groupFooterSection2
            // 
            this.groupFooterSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(1.1998825073242188D);
            this.groupFooterSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txtSumTotalBrokerComm,
            this.txtSumTotalPBF,
            this.txtSumProfitLoss,
            this.txtSumOfMargin,
            this.txtCurrentLedgerBalance,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox13,
            this.textBox16,
            this.textBox25,
            this.txtSumOpenEquity});
            this.groupFooterSection2.Name = "groupFooterSection2";
            this.groupFooterSection2.PageBreak = Telerik.Reporting.PageBreak.After;
            this.groupFooterSection2.Style.BackgroundColor = System.Drawing.Color.White;
            // 
            // txtSumTotalBrokerComm
            // 
            this.txtSumTotalBrokerComm.Format = "{0:N2}";
            this.txtSumTotalBrokerComm.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.8898200988769531D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.txtSumTotalBrokerComm.Name = "txtSumTotalBrokerComm";
            this.txtSumTotalBrokerComm.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.71018123626708984D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.txtSumTotalBrokerComm.Style.Font.Bold = false;
            this.txtSumTotalBrokerComm.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.txtSumTotalBrokerComm.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtSumTotalBrokerComm.Value = "= SUM(TotalBrokerComm)";
            // 
            // txtSumTotalPBF
            // 
            this.txtSumTotalPBF.Format = "{0:N2}";
            this.txtSumTotalPBF.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9583334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.txtSumTotalPBF.Name = "txtSumTotalPBF";
            this.txtSumTotalPBF.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.54166698455810547D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.txtSumTotalPBF.Style.Font.Bold = false;
            this.txtSumTotalPBF.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.txtSumTotalPBF.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtSumTotalPBF.Value = "=SUM(IsNull(TotalPBFFees,0.00))";
            // 
            // txtSumProfitLoss
            // 
            this.txtSumProfitLoss.Format = "{0:N2}";
            this.txtSumProfitLoss.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.7999997138977051D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.txtSumProfitLoss.Name = "txtSumProfitLoss";
            this.txtSumProfitLoss.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80000036954879761D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.txtSumProfitLoss.Style.Font.Bold = false;
            this.txtSumProfitLoss.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.txtSumProfitLoss.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtSumProfitLoss.Value = "= SUM(MTDProfitLoss)";
            // 
            // txtSumOfMargin
            // 
            this.txtSumOfMargin.Format = "{0:N2}";
            this.txtSumOfMargin.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.8800010681152344D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.txtSumOfMargin.Name = "txtSumOfMargin";
            this.txtSumOfMargin.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.710258960723877D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.txtSumOfMargin.Style.Font.Bold = false;
            this.txtSumOfMargin.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.txtSumOfMargin.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtSumOfMargin.Value = "=Sum(AdjustmentAmount)";
            // 
            // txtCurrentLedgerBalance
            // 
            this.txtCurrentLedgerBalance.Format = "{0:N2}";
            this.txtCurrentLedgerBalance.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.90000057220459D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.txtCurrentLedgerBalance.Name = "txtCurrentLedgerBalance";
            this.txtCurrentLedgerBalance.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.8902592658996582D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.txtCurrentLedgerBalance.Style.Font.Bold = false;
            this.txtCurrentLedgerBalance.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.txtCurrentLedgerBalance.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtCurrentLedgerBalance.Value = "=Sum(Net)";
            // 
            // textBox2
            // 
            this.textBox2.Format = "{0:N2}";
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9000791311264038D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999998331069946D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox2.Style.Font.Bold = false;
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox2.Value = "=SUM(BeginningOpenEquity)";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0084516210481524467D), Telerik.Reporting.Drawing.Unit.Inch(0.54776096343994141D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6914695501327515D), Telerik.Reporting.Drawing.Unit.Inch(0.17712323367595673D));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.textBox3.Style.Color = System.Drawing.Color.White;
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox3.Value = "Futures Position Group:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.15625D), Telerik.Reporting.Drawing.Unit.Inch(0.55208331346511841D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5437498092651367D), Telerik.Reporting.Drawing.Unit.Inch(0.17712323367595673D));
            this.textBox4.Style.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.textBox4.Style.Color = System.Drawing.Color.White;
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox4.Value = "Futures Position Group Recap:";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.15625D), Telerik.Reporting.Drawing.Unit.Inch(0.84776085615158081D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8020046949386597D), Telerik.Reporting.Drawing.Unit.Inch(0.1999608725309372D));
            this.textBox13.Style.Font.Bold = false;
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox13.Value = "CURRENT LEDGER BALANCE:";
            // 
            // textBox16
            // 
            this.textBox16.Format = "{0:N2}";
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9583334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.84776085615158081D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3915880918502808D), Telerik.Reporting.Drawing.Unit.Inch(0.1999608725309372D));
            this.textBox16.Style.Font.Bold = false;
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox16.Value = "=SUM(IsNull(BeginningOpenEquity,0)) + SUM(IsNull(Equity,0)) - Sum(IsNull(TotalBro" +
    "kerComm,0)) + SUM(IsNull(MTDProfitLoss,0)) + Sum(IsNull(AdjustmentAmount,0))";
            // 
            // textBox25
            // 
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.8000000715255737D), Telerik.Reporting.Drawing.Unit.Inch(0.54776096343994141D));
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8999212980270386D), Telerik.Reporting.Drawing.Unit.Inch(0.17708413302898407D));
            this.textBox25.Style.Color = System.Drawing.Color.Black;
            this.textBox25.Style.Font.Bold = true;
            this.textBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox25.Value = "=FuturesPositionGroup";
            // 
            // txtSumOpenEquity
            // 
            this.txtSumOpenEquity.Format = "{0:N2}";
            this.txtSumOpenEquity.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6001577377319336D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.txtSumOpenEquity.Name = "txtSumOpenEquity";
            this.txtSumOpenEquity.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0000003576278687D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.txtSumOpenEquity.Style.Font.Bold = false;
            this.txtSumOpenEquity.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.txtSumOpenEquity.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtSumOpenEquity.Value = "=SUM( Equity)";
            // 
            // groupHeaderSection2
            // 
            this.groupHeaderSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.69999992847442627D);
            this.groupHeaderSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox11,
            this.textBox10,
            this.textBox8,
            this.textBox6,
            this.textBox5,
            this.textBox14,
            this.textBox15,
            this.textBox20,
            this.textBox40,
            this.textBox9});
            this.groupHeaderSection2.Name = "groupHeaderSection2";
            this.groupHeaderSection2.PrintOnEveryPage = false;
            this.groupHeaderSection2.Style.BackgroundColor = System.Drawing.Color.LightSlateGray;
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9583334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.84158754348754883D), Telerik.Reporting.Drawing.Unit.Inch(0.299959659576416D));
            this.textBox11.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Value = "PBF Fees";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.8000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.079922080039978D), Telerik.Reporting.Drawing.Unit.Inch(0.299959659576416D));
            this.textBox10.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.Value = "MTD Purchase Settle";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.8800010681152344D), Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0199199914932251D), Telerik.Reporting.Drawing.Unit.Inch(0.299959659576416D));
            this.textBox8.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.Value = "Adjustment";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6001579761505127D), Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2895832061767578D), Telerik.Reporting.Drawing.Unit.Inch(0.299959659576416D));
            this.textBox6.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox6.Value = "Open Equity";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9081958235744878E-17D), Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.299959659576416D));
            this.textBox5.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox5.Value = "            Account";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9000788927078247D), Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.7000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.299959659576416D));
            this.textBox14.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox14.Style.Font.Bold = true;
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox14.Value = "Beginning Open Equity for Month";
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.8898200988769531D), Telerik.Reporting.Drawing.Unit.Inch(0.40003934502601624D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0684343576431274D), Telerik.Reporting.Drawing.Unit.Inch(0.299959659576416D));
            this.textBox15.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox15.Style.Font.Bold = true;
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox15.Value = "MTD Broker Comm";
            // 
            // textBox20
            // 
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.90000057220459D), Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0915485620498657D), Telerik.Reporting.Drawing.Unit.Inch(0.299959659576416D));
            this.textBox20.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox20.Style.Font.Bold = true;
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox20.Value = "Net";
            // 
            // textBox40
            // 
            this.textBox40.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.8000000715255737D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4999210834503174D), Telerik.Reporting.Drawing.Unit.Inch(0.17708413302898407D));
            this.textBox40.Style.Color = System.Drawing.Color.White;
            this.textBox40.Style.Font.Bold = true;
            this.textBox40.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox40.Value = "=FuturesPositionGroup";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0084516210481524467D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6914695501327515D), Telerik.Reporting.Drawing.Unit.Inch(0.17712323367595673D));
            this.textBox9.Style.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.textBox9.Style.Color = System.Drawing.Color.White;
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox9.Value = "Futures Position Group:";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.1000000238418579D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox1,
            this.textBox42});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9378803194267675E-05D));
            this.pictureBox1.MimeType = "image/jpeg";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.7000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.79996079206466675D));
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // textBox42
            // 
            this.textBox42.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.80007892847061157D));
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(9.9915485382080078D), Telerik.Reporting.Drawing.Unit.Inch(0.29992112517356873D));
            this.textBox42.Style.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.textBox42.Style.Color = System.Drawing.Color.White;
            this.textBox42.Style.Font.Bold = true;
            this.textBox42.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.textBox42.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox42.Value = "Futures Trading - Ledger Balance and Margins Reconciliation";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.9000396728515625D), Telerik.Reporting.Drawing.Unit.Inch(3.9378803194267675E-05D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.0914692878723145D), Telerik.Reporting.Drawing.Unit.Inch(0.29996061325073242D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.Value = "=Now()";
            // 
            // textBox18
            // 
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(3.9498012483818457E-05D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.5999603271484375D), Telerik.Reporting.Drawing.Unit.Inch(0.29996061325073242D));
            this.textBox18.Style.Font.Bold = true;
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox18.Value = "=\"Page \" + PageNumber + \" of \" + PageCount";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20011758804321289D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox19,
            this.textBox24,
            this.textBox27,
            this.textBox28,
            this.textBox29,
            this.textBox7,
            this.textBox12,
            this.textBox21});
            this.detail.Name = "detail";
            // 
            // textBox19
            // 
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox19.Value = "=[Company] + \"-\" + [Account] + \"-\" + [AccountName]";
            // 
            // textBox24
            // 
            this.textBox24.Format = "{0:N2}";
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.7999997138977051D), Telerik.Reporting.Drawing.Unit.Inch(0.00011761983478209004D));
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80000036954879761D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox24.Style.Font.Bold = false;
            this.textBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox24.Value = "=MTDProfitLoss";
            // 
            // textBox27
            // 
            this.textBox27.Format = "{0:N2}";
            this.textBox27.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9583334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.00011761983478209004D));
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.54166698455810547D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox27.Style.Font.Bold = false;
            this.textBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox27.Value = "=IIF(TotalPBFFees = 0, \"\", TotalPBFFees)";
            // 
            // textBox28
            // 
            this.textBox28.Format = "{0:N2}";
            this.textBox28.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.8898200988769531D), Telerik.Reporting.Drawing.Unit.Inch(0.00011761983478209004D));
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.71018064022064209D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox28.Style.Font.Bold = false;
            this.textBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox28.Value = "=iif(TotalBrokerComm =0, \"\", TotalBrokerComm)\r\n";
            // 
            // textBox29
            // 
            this.textBox29.Format = "{0:N2}";
            this.textBox29.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6001579761505127D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox29.Style.Font.Bold = false;
            this.textBox29.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox29.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox29.Value = "=iif(Equity=0, \"\", Equity)";
            // 
            // textBox7
            // 
            this.textBox7.Format = "{0:N2}";
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.90000057220459D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.8902592658996582D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox7.Style.Font.Bold = false;
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox7.Value = "=Net";
            // 
            // textBox12
            // 
            this.textBox12.Format = "{0:N2}";
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.8800010681152344D), Telerik.Reporting.Drawing.Unit.Inch(0.00011761983478209004D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.71025902032852173D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox12.Style.Font.Bold = false;
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox12.Value = "=AdjustmentAmount";
            // 
            // textBox21
            // 
            this.textBox21.Format = "{0:N2}";
            this.textBox21.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9000788927078247D), Telerik.Reporting.Drawing.Unit.Inch(0.00011761983478209004D));
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999999523162842D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox21.Style.Font.Bold = false;
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox21.Value = "=BeginningOpenEquity";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.299999862909317D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox18});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // ReconciliationReport_ByComp
            // 
            group1.GroupFooter = this.groupFooterSection2;
            group1.GroupHeader = this.groupHeaderSection2;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("=FuturesPositionGroupID"));
            group1.Name = "group2";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection2,
            this.groupFooterSection2,
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "ReconciliationReport_ByComp";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(9.9915485382080078D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.Group group2;
        private Telerik.Reporting.GroupFooterSection groupFooterSection2;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection2;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.Group group1;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox29;
        private Telerik.Reporting.TextBox txtSumOpenEquity;
        private Telerik.Reporting.TextBox txtSumTotalBrokerComm;
        private Telerik.Reporting.TextBox txtSumTotalPBF;
        private Telerik.Reporting.TextBox txtSumProfitLoss;
        private Telerik.Reporting.TextBox txtSumOfMargin;
        private Telerik.Reporting.TextBox txtCurrentLedgerBalance;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBox42;
        private Telerik.Reporting.TextBox textBox40;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox25;
    }
}
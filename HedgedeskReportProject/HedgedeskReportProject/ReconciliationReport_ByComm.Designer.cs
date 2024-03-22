namespace HedgedeskReportProject
{
    partial class ReconciliationReport_ByComm
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection2 = new Telerik.Reporting.GroupFooterSection();
            this.txtSumTotalBrokerComm = new Telerik.Reporting.TextBox();
            this.txtSumProfitLoss = new Telerik.Reporting.TextBox();
            this.txtCurrentLedgerBalance = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.txtSumOpenEquity = new Telerik.Reporting.TextBox();
            this.groupHeaderSection2 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox42 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.textBox29 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.textBox40 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // group1
            // 
            this.group1.GroupFooter = this.groupFooterSection2;
            this.group1.GroupHeader = this.groupHeaderSection2;
            this.group1.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("=FuturesPositionGroupID")});
            this.group1.Name = "group2";
            // 
            // groupFooterSection2
            // 
            this.groupFooterSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.29980340600013733D);
            this.groupFooterSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txtSumTotalBrokerComm,
            this.txtSumProfitLoss,
            this.txtCurrentLedgerBalance,
            this.textBox2,
            this.txtSumOpenEquity});
            this.groupFooterSection2.Name = "groupFooterSection2";
            this.groupFooterSection2.PageBreak = Telerik.Reporting.PageBreak.After;
            this.groupFooterSection2.Style.BackgroundColor = System.Drawing.Color.White;
            // 
            // txtSumTotalBrokerComm
            // 
            this.txtSumTotalBrokerComm.Format = "{0:N2}";
            this.txtSumTotalBrokerComm.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1999993324279785D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.txtSumTotalBrokerComm.Name = "txtSumTotalBrokerComm";
            this.txtSumTotalBrokerComm.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.71018123626708984D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.txtSumTotalBrokerComm.Style.Font.Bold = false;
            this.txtSumTotalBrokerComm.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.txtSumTotalBrokerComm.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtSumTotalBrokerComm.Value = "= SUM(IsNull(TotalBrokerComm,0.00000))";
            // 
            // txtSumProfitLoss
            // 
            this.txtSumProfitLoss.Format = "{0:N2}";
            this.txtSumProfitLoss.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5499210357666016D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.txtSumProfitLoss.Name = "txtSumProfitLoss";
            this.txtSumProfitLoss.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80000036954879761D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.txtSumProfitLoss.Style.Font.Bold = false;
            this.txtSumProfitLoss.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.txtSumProfitLoss.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtSumProfitLoss.Value = "= SUM(IsNull(MTDProfitLoss,0.00000))";
            // 
            // txtCurrentLedgerBalance
            // 
            this.txtCurrentLedgerBalance.Format = "{0:N2}";
            this.txtCurrentLedgerBalance.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.txtCurrentLedgerBalance.Name = "txtCurrentLedgerBalance";
            this.txtCurrentLedgerBalance.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
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
            // txtSumOpenEquity
            // 
            this.txtSumOpenEquity.Format = "{0:N2}";
            this.txtSumOpenEquity.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6999998092651367D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.txtSumOpenEquity.Name = "txtSumOpenEquity";
            this.txtSumOpenEquity.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0000003576278687D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.txtSumOpenEquity.Style.Font.Bold = false;
            this.txtSumOpenEquity.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.txtSumOpenEquity.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtSumOpenEquity.Value = "=SUM(IsNull(Equity,0.00000))";
            // 
            // groupHeaderSection2
            // 
            this.groupHeaderSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.69999992847442627D);
            this.groupHeaderSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox10,
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
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.3000006675720215D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5083335638046265D), Telerik.Reporting.Drawing.Unit.Inch(0.299959659576416D));
            this.textBox10.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.Value = "MTD Purchase Settle";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6001579761505127D), Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3997631072998047D), Telerik.Reporting.Drawing.Unit.Inch(0.299959659576416D));
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
            this.textBox5.Value = "            Commodity";
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
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5D), Telerik.Reporting.Drawing.Unit.Inch(0.40003934502601624D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999216318130493D), Telerik.Reporting.Drawing.Unit.Inch(0.299959659576416D));
            this.textBox15.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox15.Style.Font.Bold = true;
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox15.Value = "MTD Broker Comm";
            // 
            // textBox20
            // 
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.808413028717041D), Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6915483474731445D), Telerik.Reporting.Drawing.Unit.Inch(0.299959659576416D));
            this.textBox20.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox20.Style.Font.Bold = true;
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox20.Value = "Net";
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
            // 
            // textBox42
            // 
            this.textBox42.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.80007892847061157D));
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(9.5000009536743164D), Telerik.Reporting.Drawing.Unit.Inch(0.29992112517356873D));
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
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.4999604225158691D), Telerik.Reporting.Drawing.Unit.Inch(0.1999608725309372D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.Value = "=Now()";
            // 
            // textBox18
            // 
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4999997615814209D), Telerik.Reporting.Drawing.Unit.Inch(0.19999964535236359D));
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
            this.textBox28,
            this.textBox29,
            this.textBox7,
            this.textBox21});
            this.detail.Name = "detail";
            // 
            // textBox19
            // 
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D), Telerik.Reporting.Drawing.Unit.Inch(0.00011761983478209004D));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8000000715255737D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox19.Value = "=[Commodity] + \"-\" + [DESC]";
            // 
            // textBox24
            // 
            this.textBox24.Format = "{0:N2}";
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5499210357666016D), Telerik.Reporting.Drawing.Unit.Inch(0.00011761983478209004D));
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80000036954879761D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox24.Style.Font.Bold = false;
            this.textBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox24.Value = "=MTDProfitLoss";
            // 
            // textBox28
            // 
            this.textBox28.Format = "{0:N2}";
            this.textBox28.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0D));
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
            this.textBox29.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.7000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0D));
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
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox7.Style.Font.Bold = false;
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox7.Value = "=Net";
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
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20000024139881134D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox18});
            this.pageFooterSection1.Name = "pageFooterSection1";
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
            // ReconciliationReport_ByComm
            // 
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection2,
            this.groupFooterSection2,
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "ReconciliationReport_ByComm";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(9.5000009536743164D);
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
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.Group group2;
        private Telerik.Reporting.Group group1;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox29;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBox42;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox txtSumOpenEquity;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox txtCurrentLedgerBalance;
        private Telerik.Reporting.TextBox txtSumProfitLoss;
        private Telerik.Reporting.TextBox txtSumTotalBrokerComm;
        private Telerik.Reporting.GroupFooterSection groupFooterSection2;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection2;
        private Telerik.Reporting.TextBox textBox40;
    }
}
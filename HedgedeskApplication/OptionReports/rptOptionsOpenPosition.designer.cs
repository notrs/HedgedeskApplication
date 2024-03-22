namespace HedgedeskApplication.OptionReports
{
    partial class rptOptionsOpenPosition
    { 
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.Hedgedesk = new Telerik.Reporting.SqlDataSource();
            this.ordTypeGroupHeader = new Telerik.Reporting.GroupHeaderSection();
            this.ordTypeCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ordTypeDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.ordTypeGroupFooter = new Telerik.Reporting.GroupFooterSection();
            this.aMTSumFunctionTextBox1 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.textBox29 = new Telerik.Reporting.TextBox();
            this.ordTypeGroup = new Telerik.Reporting.Group();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.labelsGroupHeader = new Telerik.Reporting.GroupHeaderSection();
            this.aMTCaptionTextBox = new Telerik.Reporting.TextBox();
            this.tP_PriceCaptionTextBox = new Telerik.Reporting.TextBox();
            this.hedgeOptionCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ordTypeCaptionTextBox1 = new Telerik.Reporting.TextBox();
            this.commodityCaptionTextBox1 = new Telerik.Reporting.TextBox();
            this.orderTimeCaptionTextBox = new Telerik.Reporting.TextBox();
            this.orderDateCaptionTextBox = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.commentCaptionTextBox = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.labelsGroupFooter = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroup = new Telerik.Reporting.Group();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.tP_ACCTCaptionTextBox = new Telerik.Reporting.TextBox();
            this.tP_ACCTDataTextBox = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.orderDateDataTextBox = new Telerik.Reporting.TextBox();
            this.orderTimeDataTextBox = new Telerik.Reporting.TextBox();
            this.commodityDataTextBox1 = new Telerik.Reporting.TextBox();
            this.ordTypeDataTextBox1 = new Telerik.Reporting.TextBox();
            this.aMTDataTextBox = new Telerik.Reporting.TextBox();
            this.tP_PriceDataTextBox = new Telerik.Reporting.TextBox();
            this.commentDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.hedgeOptionDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.AccountGroup = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection2 = new Telerik.Reporting.GroupFooterSection();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.groupHeaderSection2 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Hedgedesk
            // 
            this.Hedgedesk.CommandTimeout = 60;
            this.Hedgedesk.ConnectionString = "Data Source=SQLDEV2\\GRAIN;Initial Catalog=HedgeDesk;Persist Security Info=True;Us" +
    "er ID=IUser_Hedgebook;Password=hedgebook";
            this.Hedgedesk.Name = "Hedgedesk";
            this.Hedgedesk.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@HedgeUserID", System.Data.DbType.Int32, "=0"),
            new Telerik.Reporting.SqlDataSourceParameter("@OptionExpirationDate", System.Data.DbType.Date, "=Parameters.ExpirationDate.Value")});
            this.Hedgedesk.SelectCommand = "proc_rptHBOptionsOpenPosition";
            this.Hedgedesk.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // ordTypeGroupHeader
            // 
            this.ordTypeGroupHeader.Height = new Telerik.Reporting.Drawing.Unit(0.1979166716337204D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.ordTypeGroupHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.ordTypeCaptionTextBox,
            this.ordTypeDataTextBox,
            this.textBox13,
            this.textBox16});
            this.ordTypeGroupHeader.Name = "ordTypeGroupHeader";
            // 
            // ordTypeCaptionTextBox
            // 
            this.ordTypeCaptionTextBox.CanGrow = true;
            this.ordTypeCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.02083333395421505D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.02083333395421505D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.ordTypeCaptionTextBox.Name = "ordTypeCaptionTextBox";
            this.ordTypeCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.48541674017906189D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.ordTypeCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White;
            this.ordTypeCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.ordTypeCaptionTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8D, Telerik.Reporting.Drawing.UnitType.Point);
            this.ordTypeCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.ordTypeCaptionTextBox.StyleName = "Caption";
            this.ordTypeCaptionTextBox.Value = "Option:";
            // 
            // ordTypeDataTextBox
            // 
            this.ordTypeDataTextBox.CanGrow = true;
            this.ordTypeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.5063287615776062D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.02083333395421505D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.ordTypeDataTextBox.Name = "ordTypeDataTextBox";
            this.ordTypeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.79367130994796753D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.ordTypeDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8D, Telerik.Reporting.Drawing.UnitType.Point);
            this.ordTypeDataTextBox.StyleName = "Data";
            this.ordTypeDataTextBox.Value = "=Fields.HedgeOption";
            // 
            // textBox13
            // 
            this.textBox13.CanGrow = true;
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.1479957103729248D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.02083333395421505D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.79367130994796753D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox13.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox13.StyleName = "Data";
            this.textBox13.Value = "=Fields.SettlePrice";
            // 
            // textBox16
            // 
            this.textBox16.CanGrow = true;
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.4000000953674316D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.02083333395421505D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.74791687726974487D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox16.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox16.Style.Color = System.Drawing.Color.Black;
            this.textBox16.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox16.StyleName = "Caption";
            this.textBox16.Value = "Settle Price:";
            // 
            // ordTypeGroupFooter
            // 
            this.ordTypeGroupFooter.Height = new Telerik.Reporting.Drawing.Unit(0.20003943145275116D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.ordTypeGroupFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.aMTSumFunctionTextBox1,
            this.textBox1,
            this.textBox18,
            this.textBox20,
            this.textBox27,
            this.textBox28,
            this.textBox29});
            this.ordTypeGroupFooter.Name = "ordTypeGroupFooter";
            // 
            // aMTSumFunctionTextBox1
            // 
            this.aMTSumFunctionTextBox1.CanGrow = true;
            this.aMTSumFunctionTextBox1.Format = "{0:#,##0.##;<#,##0.##>}";
            this.aMTSumFunctionTextBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.7000801563262939D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.aMTSumFunctionTextBox1.Name = "aMTSumFunctionTextBox1";
            this.aMTSumFunctionTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.099920392036438D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.aMTSumFunctionTextBox1.Style.Font.Bold = true;
            this.aMTSumFunctionTextBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.aMTSumFunctionTextBox1.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.aMTSumFunctionTextBox1.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.aMTSumFunctionTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.aMTSumFunctionTextBox1.StyleName = "Data";
            this.aMTSumFunctionTextBox1.Value = "=Sum(Fields.AMT)";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.8000000715255737D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.80000180006027222D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox1.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox1.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.StyleName = "Data";
            this.textBox1.Value = "Total Amount:";
            // 
            // textBox18
            // 
            this.textBox18.CanGrow = true;
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.0999999046325684D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(7.8837074397597462E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.74174642562866211D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox18.Style.Font.Bold = true;
            this.textBox18.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox18.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox18.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox18.StyleName = "Data";
            this.textBox18.Value = "Total Settle:";
            // 
            // textBox20
            // 
            this.textBox20.CanGrow = true;
            this.textBox20.Format = "{0:$#,##0.00;<$#,##0.00>}";
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.8418254852294922D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.3581748008728027D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox20.Style.Font.Bold = true;
            this.textBox20.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox20.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox20.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox20.StyleName = "Data";
            this.textBox20.Value = "=Sum(Fields.SettlePrice * Fields.AMT)";
            // 
            // textBox27
            // 
            this.textBox27.CanGrow = true;
            this.textBox27.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(6.2000789642333984D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.69984197616577148D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox27.Style.Font.Bold = true;
            this.textBox27.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox27.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox27.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox27.StyleName = "Data";
            this.textBox27.Value = "Total Prem:";
            // 
            // textBox28
            // 
            this.textBox28.CanGrow = true;
            this.textBox28.Format = "{0:$#,##0.00;<$#,##0.00>}";
            this.textBox28.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(6.8999996185302734D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.1000005006790161D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox28.Style.Font.Bold = true;
            this.textBox28.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox28.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox28.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox28.StyleName = "Data";
            this.textBox28.Value = "=Sum(Fields.OptionPremium * Fields.AMT)";
            // 
            // textBox29
            // 
            this.textBox29.CanGrow = true;
            this.textBox29.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.79991942644119263D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.0000017881393433D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox29.Style.Font.Bold = true;
            this.textBox29.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox29.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox29.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox29.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox29.StyleName = "Data";
            this.textBox29.Value = "= Fields.HedgeOption";
            // 
            // ordTypeGroup
            // 
            this.ordTypeGroup.GroupFooter = this.ordTypeGroupFooter;
            this.ordTypeGroup.GroupHeader = this.ordTypeGroupHeader;
            this.ordTypeGroup.Groupings.AddRange(new Telerik.Reporting.Data.Grouping[] {
            new Telerik.Reporting.Data.Grouping("=Fields.HedgeOption")});
            this.ordTypeGroup.Name = "ordTypeGroup";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = new Telerik.Reporting.Drawing.Unit(0.0520833320915699D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.reportFooter.Name = "reportFooter";
            this.reportFooter.Style.Visible = false;
            // 
            // labelsGroupHeader
            // 
            this.labelsGroupHeader.Height = new Telerik.Reporting.Drawing.Unit(0.18333339691162109D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.labelsGroupHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.aMTCaptionTextBox,
            this.tP_PriceCaptionTextBox,
            this.hedgeOptionCaptionTextBox,
            this.ordTypeCaptionTextBox1,
            this.commodityCaptionTextBox1,
            this.orderTimeCaptionTextBox,
            this.orderDateCaptionTextBox,
            this.textBox9,
            this.textBox14,
            this.textBox21,
            this.commentCaptionTextBox,
            this.textBox7,
            this.textBox23});
            this.labelsGroupHeader.Name = "labelsGroupHeader";
            this.labelsGroupHeader.PrintOnEveryPage = true;
            this.labelsGroupHeader.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // aMTCaptionTextBox
            // 
            this.aMTCaptionTextBox.CanGrow = true;
            this.aMTCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.8167457580566406D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.aMTCaptionTextBox.Name = "aMTCaptionTextBox";
            this.aMTCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.983254611492157D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.aMTCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White;
            this.aMTCaptionTextBox.Style.BorderColor.Left = System.Drawing.Color.White;
            this.aMTCaptionTextBox.Style.BorderColor.Right = System.Drawing.Color.White;
            this.aMTCaptionTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.aMTCaptionTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.aMTCaptionTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.aMTCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.aMTCaptionTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.aMTCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.aMTCaptionTextBox.StyleName = "Caption";
            this.aMTCaptionTextBox.Value = "Amount";
            // 
            // tP_PriceCaptionTextBox
            // 
            this.tP_PriceCaptionTextBox.CanGrow = true;
            this.tP_PriceCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.2000789642333984D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.tP_PriceCaptionTextBox.Name = "tP_PriceCaptionTextBox";
            this.tP_PriceCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.64166784286499023D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.tP_PriceCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White;
            this.tP_PriceCaptionTextBox.Style.BorderColor.Left = System.Drawing.Color.White;
            this.tP_PriceCaptionTextBox.Style.BorderColor.Right = System.Drawing.Color.White;
            this.tP_PriceCaptionTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.tP_PriceCaptionTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tP_PriceCaptionTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tP_PriceCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.tP_PriceCaptionTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.tP_PriceCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tP_PriceCaptionTextBox.StyleName = "Caption";
            this.tP_PriceCaptionTextBox.Value = "Strike Price";
            // 
            // hedgeOptionCaptionTextBox
            // 
            this.hedgeOptionCaptionTextBox.CanGrow = true;
            this.hedgeOptionCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.800079345703125D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.hedgeOptionCaptionTextBox.Name = "hedgeOptionCaptionTextBox";
            this.hedgeOptionCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.39992061257362366D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.hedgeOptionCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White;
            this.hedgeOptionCaptionTextBox.Style.BorderColor.Left = System.Drawing.Color.White;
            this.hedgeOptionCaptionTextBox.Style.BorderColor.Right = System.Drawing.Color.White;
            this.hedgeOptionCaptionTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.hedgeOptionCaptionTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.hedgeOptionCaptionTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.hedgeOptionCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.hedgeOptionCaptionTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.hedgeOptionCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.hedgeOptionCaptionTextBox.StyleName = "Caption";
            this.hedgeOptionCaptionTextBox.Value = "Option";
            // 
            // ordTypeCaptionTextBox1
            // 
            this.ordTypeCaptionTextBox1.CanGrow = true;
            this.ordTypeCaptionTextBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.9916667938232422D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.ordTypeCaptionTextBox1.Name = "ordTypeCaptionTextBox1";
            this.ordTypeCaptionTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.30833354592323303D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.ordTypeCaptionTextBox1.Style.BackgroundColor = System.Drawing.Color.White;
            this.ordTypeCaptionTextBox1.Style.BorderColor.Left = System.Drawing.Color.White;
            this.ordTypeCaptionTextBox1.Style.BorderColor.Right = System.Drawing.Color.White;
            this.ordTypeCaptionTextBox1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.ordTypeCaptionTextBox1.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.ordTypeCaptionTextBox1.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.ordTypeCaptionTextBox1.Style.Color = System.Drawing.Color.Black;
            this.ordTypeCaptionTextBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.ordTypeCaptionTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ordTypeCaptionTextBox1.StyleName = "Caption";
            this.ordTypeCaptionTextBox1.Value = "Type";
            // 
            // commodityCaptionTextBox1
            // 
            this.commodityCaptionTextBox1.CanGrow = true;
            this.commodityCaptionTextBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.2000789642333984D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.commodityCaptionTextBox1.Name = "commodityCaptionTextBox1";
            this.commodityCaptionTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.79150897264480591D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.commodityCaptionTextBox1.Style.BackgroundColor = System.Drawing.Color.White;
            this.commodityCaptionTextBox1.Style.BorderColor.Left = System.Drawing.Color.White;
            this.commodityCaptionTextBox1.Style.BorderColor.Right = System.Drawing.Color.White;
            this.commodityCaptionTextBox1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.commodityCaptionTextBox1.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.commodityCaptionTextBox1.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.commodityCaptionTextBox1.Style.Color = System.Drawing.Color.Black;
            this.commodityCaptionTextBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.commodityCaptionTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.commodityCaptionTextBox1.StyleName = "Caption";
            this.commodityCaptionTextBox1.Value = "Commodity";
            // 
            // orderTimeCaptionTextBox
            // 
            this.orderTimeCaptionTextBox.CanGrow = true;
            this.orderTimeCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.70007878541946411D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.orderTimeCaptionTextBox.Name = "orderTimeCaptionTextBox";
            this.orderTimeCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.49992132186889648D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.orderTimeCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White;
            this.orderTimeCaptionTextBox.Style.BorderColor.Left = System.Drawing.Color.White;
            this.orderTimeCaptionTextBox.Style.BorderColor.Right = System.Drawing.Color.White;
            this.orderTimeCaptionTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.orderTimeCaptionTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.orderTimeCaptionTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.orderTimeCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.orderTimeCaptionTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.orderTimeCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.orderTimeCaptionTextBox.StyleName = "Caption";
            this.orderTimeCaptionTextBox.Value = "Time";
            // 
            // orderDateCaptionTextBox
            // 
            this.orderDateCaptionTextBox.CanGrow = true;
            this.orderDateCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.orderDateCaptionTextBox.Name = "orderDateCaptionTextBox";
            this.orderDateCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.70000004768371582D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.orderDateCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White;
            this.orderDateCaptionTextBox.Style.BorderColor.Left = System.Drawing.Color.White;
            this.orderDateCaptionTextBox.Style.BorderColor.Right = System.Drawing.Color.White;
            this.orderDateCaptionTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.orderDateCaptionTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.orderDateCaptionTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.orderDateCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.orderDateCaptionTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.orderDateCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.orderDateCaptionTextBox.StyleName = "Caption";
            this.orderDateCaptionTextBox.Value = "Date";
            // 
            // textBox9
            // 
            this.textBox9.CanGrow = true;
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.300079345703125D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.51658773422241211D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox9.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox9.Style.BorderColor.Left = System.Drawing.Color.White;
            this.textBox9.Style.BorderColor.Right = System.Drawing.Color.White;
            this.textBox9.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox9.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.Color = System.Drawing.Color.Black;
            this.textBox9.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.StyleName = "Caption";
            this.textBox9.Value = "Initials";
            // 
            // textBox14
            // 
            this.textBox14.CanGrow = true;
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.8418254852294922D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.3581748008728027D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox14.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox14.Style.BorderColor.Left = System.Drawing.Color.White;
            this.textBox14.Style.BorderColor.Right = System.Drawing.Color.White;
            this.textBox14.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox14.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox14.Style.Color = System.Drawing.Color.Black;
            this.textBox14.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox14.StyleName = "Caption";
            this.textBox14.Value = "Settle Value";
            // 
            // textBox21
            // 
            this.textBox21.CanGrow = true;
            this.textBox21.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(8.0000791549682617D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.699842631816864D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox21.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox21.Style.BorderColor.Left = System.Drawing.Color.White;
            this.textBox21.Style.BorderColor.Right = System.Drawing.Color.White;
            this.textBox21.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox21.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox21.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox21.Style.Color = System.Drawing.Color.Black;
            this.textBox21.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox21.StyleName = "Caption";
            this.textBox21.Value = "Exp. Date";
            // 
            // commentCaptionTextBox
            // 
            this.commentCaptionTextBox.CanGrow = true;
            this.commentCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(8.6999998092651367D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(7.8837074397597462E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.commentCaptionTextBox.Name = "commentCaptionTextBox";
            this.commentCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.8250821828842163D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.commentCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White;
            this.commentCaptionTextBox.Style.BorderColor.Left = System.Drawing.Color.White;
            this.commentCaptionTextBox.Style.BorderColor.Right = System.Drawing.Color.White;
            this.commentCaptionTextBox.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.commentCaptionTextBox.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.commentCaptionTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.commentCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.commentCaptionTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.commentCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.commentCaptionTextBox.StyleName = "Caption";
            this.commentCaptionTextBox.Value = "Comment";
            // 
            // textBox7
            // 
            this.textBox7.CanGrow = true;
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(6.8999996185302734D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.1000005006790161D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox7.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox7.Style.BorderColor.Left = System.Drawing.Color.White;
            this.textBox7.Style.BorderColor.Right = System.Drawing.Color.White;
            this.textBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox7.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.Color = System.Drawing.Color.Black;
            this.textBox7.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.StyleName = "Caption";
            this.textBox7.Value = "Premium Value";
            // 
            // textBox23
            // 
            this.textBox23.CanGrow = true;
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(6.2000789642333984D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.69984197616577148D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox23.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox23.Style.BorderColor.Left = System.Drawing.Color.White;
            this.textBox23.Style.BorderColor.Right = System.Drawing.Color.White;
            this.textBox23.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox23.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox23.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox23.Style.Color = System.Drawing.Color.Black;
            this.textBox23.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox23.StyleName = "Caption";
            this.textBox23.Value = "Premium";
            // 
            // labelsGroupFooter
            // 
            this.labelsGroupFooter.Height = new Telerik.Reporting.Drawing.Unit(0.0520833320915699D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.labelsGroupFooter.Name = "labelsGroupFooter";
            this.labelsGroupFooter.Style.Visible = false;
            // 
            // labelsGroup
            // 
            this.labelsGroup.GroupFooter = this.labelsGroupFooter;
            this.labelsGroup.GroupHeader = this.labelsGroupHeader;
            this.labelsGroup.Name = "labelsGroup";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = new Telerik.Reporting.Drawing.Unit(0.30025991797447205D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageInfoTextBox,
            this.textBox5,
            this.currentTimeTextBox,
            this.textBox6});
            this.pageFooter.Name = "pageFooter";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(5.2395834922790527D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791648089885712D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.26025915145874D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.pageInfoTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(9.6999998092651367D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15234310925006867D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.80000048875808716D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791679382324219D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox5.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "= PageCount";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.02083333395421505D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791648089885712D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.1979165077209473D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.currentTimeTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.currentTimeTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(9.4999208450317383D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791648089885712D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.19999949634075165D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791679382324219D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox6.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = " of";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = new Telerik.Reporting.Drawing.Unit(0.14583325386047363D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox3});
            this.reportHeader.Name = "reportHeader";
            // 
            // textBox3
            // 
            this.textBox3.Bindings.Add(new Telerik.Reporting.Binding("Parent.Visible", "=Count(1)=0"));
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.1479957103729248D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.1541666984558105D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.0520833320915699D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Style.Color = System.Drawing.Color.Red;
            this.textBox3.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox3.Value = "No records returned.";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.0001578330993652D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.29992136359214783D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.titleTextBox.Style.Color = System.Drawing.Color.Black;
            this.titleTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(17D, Telerik.Reporting.Drawing.UnitType.Point);
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Options Open Position";
            // 
            // tP_ACCTCaptionTextBox
            // 
            this.tP_ACCTCaptionTextBox.CanGrow = true;
            this.tP_ACCTCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.9208333492279053D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.tP_ACCTCaptionTextBox.Name = "tP_ACCTCaptionTextBox";
            this.tP_ACCTCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.0791667699813843D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.tP_ACCTCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White;
            this.tP_ACCTCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.tP_ACCTCaptionTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(13D, Telerik.Reporting.Drawing.UnitType.Point);
            this.tP_ACCTCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.tP_ACCTCaptionTextBox.StyleName = "Caption";
            this.tP_ACCTCaptionTextBox.Value = "Account:";
            // 
            // tP_ACCTDataTextBox
            // 
            this.tP_ACCTDataTextBox.CanGrow = true;
            this.tP_ACCTDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(5.0000786781311035D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.tP_ACCTDataTextBox.Name = "tP_ACCTDataTextBox";
            this.tP_ACCTDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.5999999046325684D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.tP_ACCTDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(13D, Telerik.Reporting.Drawing.UnitType.Point);
            this.tP_ACCTDataTextBox.StyleName = "Data";
            this.tP_ACCTDataTextBox.Value = "=Fields.TP_ACCT";
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(0.1666666716337204D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.orderDateDataTextBox,
            this.orderTimeDataTextBox,
            this.commodityDataTextBox1,
            this.ordTypeDataTextBox1,
            this.aMTDataTextBox,
            this.tP_PriceDataTextBox,
            this.commentDataTextBox,
            this.textBox10,
            this.hedgeOptionDataTextBox,
            this.textBox15,
            this.textBox22,
            this.textBox8,
            this.textBox24});
            this.detail.Name = "detail";
            // 
            // orderDateDataTextBox
            // 
            this.orderDateDataTextBox.CanGrow = true;
            this.orderDateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.02083333395421505D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.orderDateDataTextBox.Name = "orderDateDataTextBox";
            this.orderDateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.67916673421859741D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.orderDateDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.orderDateDataTextBox.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.orderDateDataTextBox.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.orderDateDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.orderDateDataTextBox.StyleName = "Data";
            this.orderDateDataTextBox.Value = "=Fields.OrderDate";
            // 
            // orderTimeDataTextBox
            // 
            this.orderTimeDataTextBox.CanGrow = true;
            this.orderTimeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.70007878541946411D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.orderTimeDataTextBox.Name = "orderTimeDataTextBox";
            this.orderTimeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.49992132186889648D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.orderTimeDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.orderTimeDataTextBox.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.orderTimeDataTextBox.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.orderTimeDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.orderTimeDataTextBox.StyleName = "Data";
            this.orderTimeDataTextBox.Value = "=Fields.OrderTime";
            // 
            // commodityDataTextBox1
            // 
            this.commodityDataTextBox1.CanGrow = true;
            this.commodityDataTextBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.2000789642333984D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.commodityDataTextBox1.Name = "commodityDataTextBox1";
            this.commodityDataTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.79992121458053589D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.commodityDataTextBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.commodityDataTextBox1.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.commodityDataTextBox1.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.commodityDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.commodityDataTextBox1.StyleName = "Data";
            this.commodityDataTextBox1.Value = "=Fields.Commodity";
            // 
            // ordTypeDataTextBox1
            // 
            this.ordTypeDataTextBox1.CanGrow = true;
            this.ordTypeDataTextBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.0000791549682617D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.ordTypeDataTextBox1.Name = "ordTypeDataTextBox1";
            this.ordTypeDataTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.2999211847782135D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.ordTypeDataTextBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.ordTypeDataTextBox1.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.ordTypeDataTextBox1.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.ordTypeDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ordTypeDataTextBox1.StyleName = "Data";
            this.ordTypeDataTextBox1.Value = "=Fields.ContractType";
            // 
            // aMTDataTextBox
            // 
            this.aMTDataTextBox.CanGrow = true;
            this.aMTDataTextBox.Format = "{0:#,##0.##;<#,##0.##>}";
            this.aMTDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.8167457580566406D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.aMTDataTextBox.Name = "aMTDataTextBox";
            this.aMTDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.98325490951538086D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.aMTDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.aMTDataTextBox.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.aMTDataTextBox.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.aMTDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.aMTDataTextBox.StyleName = "Data";
            this.aMTDataTextBox.Value = "=Fields.AMT";
            // 
            // tP_PriceDataTextBox
            // 
            this.tP_PriceDataTextBox.CanGrow = true;
            this.tP_PriceDataTextBox.Format = "{0:#,##0.#####;<#,##0.####>}";
            this.tP_PriceDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.2000789642333984D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.tP_PriceDataTextBox.Name = "tP_PriceDataTextBox";
            this.tP_PriceDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.64166784286499023D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.tP_PriceDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.tP_PriceDataTextBox.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.tP_PriceDataTextBox.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.tP_PriceDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tP_PriceDataTextBox.StyleName = "Data";
            this.tP_PriceDataTextBox.Value = "=Fields.StrikePrice";
            // 
            // commentDataTextBox
            // 
            this.commentDataTextBox.CanGrow = true;
            this.commentDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(8.6999998092651367D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.commentDataTextBox.Name = "commentDataTextBox";
            this.commentDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.8250821828842163D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.commentDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.commentDataTextBox.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.commentDataTextBox.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.commentDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.commentDataTextBox.StyleName = "Data";
            this.commentDataTextBox.Value = "=Fields.Comment";
            // 
            // textBox10
            // 
            this.textBox10.CanGrow = true;
            this.textBox10.Format = "";
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.300079345703125D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.51658773422241211D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox10.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox10.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox10.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.StyleName = "Data";
            this.textBox10.Value = "=Fields.Initials";
            // 
            // hedgeOptionDataTextBox
            // 
            this.hedgeOptionDataTextBox.CanGrow = true;
            this.hedgeOptionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.800079345703125D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.hedgeOptionDataTextBox.Name = "hedgeOptionDataTextBox";
            this.hedgeOptionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.39992094039916992D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.hedgeOptionDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.hedgeOptionDataTextBox.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.hedgeOptionDataTextBox.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.hedgeOptionDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.hedgeOptionDataTextBox.StyleName = "Data";
            this.hedgeOptionDataTextBox.Value = "=Fields.HedgeOption";
            // 
            // textBox15
            // 
            this.textBox15.CanGrow = true;
            this.textBox15.Format = "{0:$#,##0.00;<$#,##0.00>}";
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.8418254852294922D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.3581748008728027D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox15.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox15.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox15.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox15.StyleName = "Data";
            this.textBox15.Value = "=Fields.SettlePrice * Fields.AMT";
            // 
            // textBox22
            // 
            this.textBox22.CanGrow = true;
            this.textBox22.Format = "{0:d}";
            this.textBox22.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(8.0000791549682617D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.699842631816864D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox22.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox22.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox22.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox22.StyleName = "Data";
            this.textBox22.Value = "=Fields.ExpirationDate";
            // 
            // textBox8
            // 
            this.textBox8.CanGrow = true;
            this.textBox8.Format = "{0:$#,##0.00;<$#,##0.00>}";
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(6.8999996185302734D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.1000005006790161D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox8.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox8.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox8.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.StyleName = "Data";
            this.textBox8.Value = "=Fields.OptionPremium * Fields.AMT";
            // 
            // textBox24
            // 
            this.textBox24.CanGrow = true;
            this.textBox24.Format = "{0:$#,##0.00;<$#,##0.00>}";
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(6.2000789642333984D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.69984197616577148D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791667461395264D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox24.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox24.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox24.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox24.StyleName = "Data";
            this.textBox24.Value = "=Fields.OptionPremium";
            // 
            // AccountGroup
            // 
            this.AccountGroup.GroupFooter = this.groupFooterSection1;
            this.AccountGroup.GroupHeader = this.groupHeaderSection1;
            this.AccountGroup.Groupings.AddRange(new Telerik.Reporting.Data.Grouping[] {
            new Telerik.Reporting.Data.Grouping("=Fields.TP_ACCT")});
            this.AccountGroup.Name = "AccountGroup";
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(0.0520833320915699D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupFooterSection1.Name = "groupFooterSection1";
            this.groupFooterSection1.PageBreak = Telerik.Reporting.PageBreak.After;
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.tP_ACCTDataTextBox,
            this.tP_ACCTCaptionTextBox});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            this.groupHeaderSection1.PageBreak = Telerik.Reporting.PageBreak.None;
            this.groupHeaderSection1.PrintOnEveryPage = true;
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(0.5D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // group1
            // 
            this.group1.GroupFooter = this.groupFooterSection2;
            this.group1.GroupHeader = this.groupHeaderSection2;
            this.group1.Groupings.AddRange(new Telerik.Reporting.Data.Grouping[] {
            new Telerik.Reporting.Data.Grouping("=Fields.StrikePrice")});
            this.group1.Name = "group1";
            // 
            // groupFooterSection2
            // 
            this.groupFooterSection2.Height = new Telerik.Reporting.Drawing.Unit(0.19999997317790985D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupFooterSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox12,
            this.textBox11,
            this.textBox17,
            this.textBox19,
            this.textBox25,
            this.textBox26});
            this.groupFooterSection2.Name = "groupFooterSection2";
            // 
            // textBox12
            // 
            this.textBox12.CanGrow = true;
            this.textBox12.Format = "{0:#,##0.##;<#,##0.##>}";
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.7000801563262939D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.099920392036438D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox12.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox12.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox12.StyleName = "Data";
            this.textBox12.Value = "=Sum(Fields.AMT)";
            // 
            // textBox11
            // 
            this.textBox11.CanGrow = true;
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.8000000715255737D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.80008000135421753D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox11.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox11.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox11.StyleName = "Data";
            this.textBox11.Value = "Total Amount:";
            // 
            // textBox17
            // 
            this.textBox17.CanGrow = true;
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.0999999046325684D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.74174642562866211D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox17.Style.Font.Bold = true;
            this.textBox17.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox17.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox17.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox17.StyleName = "Data";
            this.textBox17.Value = "Total Settle:";
            // 
            // textBox19
            // 
            this.textBox19.CanGrow = true;
            this.textBox19.Format = "{0:$#,##0.00;<$#,##0.00>}";
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.8418254852294922D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.3581748008728027D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox19.Style.Font.Bold = true;
            this.textBox19.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox19.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox19.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox19.StyleName = "Data";
            this.textBox19.Value = "=Sum(Fields.SettlePrice * Fields.AMT)";
            // 
            // textBox25
            // 
            this.textBox25.CanGrow = true;
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(6.2000789642333984D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.69984167814254761D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox25.Style.Font.Bold = true;
            this.textBox25.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox25.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox25.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox25.StyleName = "Data";
            this.textBox25.Value = "Total Prem:";
            // 
            // textBox26
            // 
            this.textBox26.CanGrow = true;
            this.textBox26.Format = "{0:$#,##0.00;<$#,##0.00>}";
            this.textBox26.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(6.8999996185302734D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.1000005006790161D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox26.Style.Font.Bold = true;
            this.textBox26.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(7D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox26.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox26.Style.Padding.Right = new Telerik.Reporting.Drawing.Unit(0.019999999552965164D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.textBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox26.StyleName = "Data";
            this.textBox26.Value = "=Sum(Fields.OptionPremium * Fields.AMT)";
            // 
            // groupHeaderSection2
            // 
            this.groupHeaderSection2.Height = new Telerik.Reporting.Drawing.Unit(0.18333339691162109D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupHeaderSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2,
            this.textBox4});
            this.groupHeaderSection2.Name = "groupHeaderSection2";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Format = "{0:# 0.00###}";
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.800000011920929D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.0020835399627686D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "=Fields.StrikePrice";
            // 
            // textBox4
            // 
            this.textBox4.CanGrow = true;
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.014504432678222656D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.78541690111160278D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15833334624767304D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox4.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox4.Style.Color = System.Drawing.Color.Black;
            this.textBox4.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox4.StyleName = "Caption";
            this.textBox4.Value = "Strike Price:";
            // 
            // rptOptionsOpenPosition
            // 
            this.DataSource = this.Hedgedesk;
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.AccountGroup,
            this.ordTypeGroup,
            this.group1,
            this.labelsGroup});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.ordTypeGroupHeader,
            this.ordTypeGroupFooter,
            this.groupHeaderSection2,
            this.groupFooterSection2,
            this.labelsGroupHeader,
            this.labelsGroupFooter,
            this.reportFooter,
            this.pageFooter,
            this.reportHeader,
            this.detail,
            this.pageHeaderSection1});
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(0.25D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(0.25D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(0.25D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(0.25D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "HedgeUser";
            reportParameter1.Text = "HedgeUser";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter2.AllowBlank = false;
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "ExpirationDate";
            reportParameter2.Text = "Expiration Date";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter2.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.BackgroundColor = System.Drawing.Color.Empty;
            styleRule1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            styleRule1.Style.Font.Name = "Tahoma";
            styleRule1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(18D, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            styleRule2.Style.Color = System.Drawing.Color.White;
            styleRule2.Style.Font.Bold = true;
            styleRule2.Style.Font.Italic = false;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11D, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule2.Style.Font.Strikeout = false;
            styleRule2.Style.Font.Underline = false;
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Color = System.Drawing.Color.Black;
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10D, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Color = System.Drawing.Color.Black;
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8D, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = new Telerik.Reporting.Drawing.Unit(10.5250825881958D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.Name = "rptOptionsOpenPosition";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource Hedgedesk;
        private Telerik.Reporting.GroupHeaderSection ordTypeGroupHeader;
        private Telerik.Reporting.TextBox ordTypeCaptionTextBox;
        private Telerik.Reporting.TextBox ordTypeDataTextBox;
        private Telerik.Reporting.GroupFooterSection ordTypeGroupFooter;
        private Telerik.Reporting.TextBox aMTSumFunctionTextBox1;
        private Telerik.Reporting.Group ordTypeGroup;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeader;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooter;
        private Telerik.Reporting.Group labelsGroup;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.TextBox tP_ACCTCaptionTextBox;
        private Telerik.Reporting.TextBox tP_ACCTDataTextBox;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox orderDateDataTextBox;
        private Telerik.Reporting.TextBox orderTimeDataTextBox;
        private Telerik.Reporting.TextBox commodityDataTextBox1;
        private Telerik.Reporting.TextBox ordTypeDataTextBox1;
        private Telerik.Reporting.TextBox aMTDataTextBox;
        private Telerik.Reporting.TextBox hedgeOptionDataTextBox;
        private Telerik.Reporting.TextBox tP_PriceDataTextBox;
        private Telerik.Reporting.TextBox commentDataTextBox;
        private Telerik.Reporting.Group AccountGroup;
        private Telerik.Reporting.GroupFooterSection groupFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox aMTCaptionTextBox;
        private Telerik.Reporting.TextBox commentCaptionTextBox;
        private Telerik.Reporting.TextBox tP_PriceCaptionTextBox;
        private Telerik.Reporting.TextBox hedgeOptionCaptionTextBox;
        private Telerik.Reporting.TextBox ordTypeCaptionTextBox1;
        private Telerik.Reporting.TextBox commodityCaptionTextBox1;
        private Telerik.Reporting.TextBox orderTimeCaptionTextBox;
        private Telerik.Reporting.TextBox orderDateCaptionTextBox;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.Group group1;
        private Telerik.Reporting.GroupFooterSection groupFooterSection2;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection2;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.TextBox textBox29;
    }
}
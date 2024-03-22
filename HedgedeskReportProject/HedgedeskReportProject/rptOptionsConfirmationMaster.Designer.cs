namespace HedgedeskReportProject
{
    partial class rptOptionsConfirmationMaster
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.tP_ACCTDataTextBox = new Telerik.Reporting.TextBox();
            this.tP_ACCTCaptionTextBox = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.group2 = new Telerik.Reporting.Group();
            this.labelsGroupFooter = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeader = new Telerik.Reporting.GroupHeaderSection();
            this.Hedgedesk = new Telerik.Reporting.SqlDataSource();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.rsubOptionsConfirmation2 = new HedgedeskReportProject.rsubOptionsConfirmation();
            this.subReport2 = new Telerik.Reporting.SubReport();
            this.rsubOptionsConfirmationOffset2 = new HedgedeskReportProject.rsubOptionsConfirmationOffset();
            this.rsubOptionsConfirmation1 = new HedgedeskReportProject.rsubOptionsConfirmation();
            this.rsubOptionsConfirmationOffset1 = new HedgedeskReportProject.rsubOptionsConfirmationOffset();
            ((System.ComponentModel.ISupportInitialize)(this.rsubOptionsConfirmation2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsubOptionsConfirmationOffset2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsubOptionsConfirmation1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsubOptionsConfirmationOffset1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // group1
            // 
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("=Fields.TP_ACCT")});
            this.group1.Name = "AccountGroup";
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(0.0520833320915699D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupFooterSection1.Name = "groupFooterSection1";
            this.groupFooterSection1.PageBreak = Telerik.Reporting.PageBreak.After;
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(1.7541278600692749D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.tP_ACCTDataTextBox,
            this.tP_ACCTCaptionTextBox,
            this.subReport1,
            this.textBox23,
            this.textBox1,
            this.subReport2});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            this.groupHeaderSection1.PageBreak = Telerik.Reporting.PageBreak.None;
            this.groupHeaderSection1.PrintOnEveryPage = true;
            // 
            // tP_ACCTDataTextBox
            // 
            this.tP_ACCTDataTextBox.CanGrow = true;
            this.tP_ACCTDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.5000004768371582D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.11029863357543945D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.tP_ACCTDataTextBox.Name = "tP_ACCTDataTextBox";
            this.tP_ACCTDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.5999999046325684D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.tP_ACCTDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(13D, Telerik.Reporting.Drawing.UnitType.Point);
            this.tP_ACCTDataTextBox.StyleName = "Data";
            this.tP_ACCTDataTextBox.Value = "=Fields.TP_ACCT";
            // 
            // tP_ACCTCaptionTextBox
            // 
            this.tP_ACCTCaptionTextBox.CanGrow = true;
            this.tP_ACCTCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.4207546710968018D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.11029863357543945D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.tP_ACCTCaptionTextBox.Name = "tP_ACCTCaptionTextBox";
            this.tP_ACCTCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.0791667699813843D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.tP_ACCTCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White;
            this.tP_ACCTCaptionTextBox.Style.Color = System.Drawing.Color.Black;
            this.tP_ACCTCaptionTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(13D, Telerik.Reporting.Drawing.UnitType.Point);
            this.tP_ACCTCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.tP_ACCTCaptionTextBox.StyleName = "Caption";
            this.tP_ACCTCaptionTextBox.Value = "Account:";
            // 
            // textBox23
            // 
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.02083333395421505D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.55412751436233521D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(11.430001258850098D, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.50800013542175293D, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox23.Style.Font.Bold = false;
            this.textBox23.Style.Font.Name = "Tahoma";
            this.textBox23.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox23.Value = "THE FOLLOWING TRADES HAVE BEEN MADE THIS DAY FOR YOUR ACCOUNT AND RISK.";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.02083333395421505D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.2541275024414063D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(11.430001258850098D, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.50800013542175293D, Telerik.Reporting.Drawing.UnitType.Cm));
            this.textBox1.Style.Font.Bold = false;
            this.textBox1.Style.Font.Name = "Tahoma";
            this.textBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox1.Value = "MEMO OPTIONS OFFSETTING INFORMATION.";
            // 
            // group2
            // 
            this.group2.GroupFooter = this.labelsGroupFooter;
            this.group2.GroupHeader = this.labelsGroupHeader;
            this.group2.Name = "labelsGroup";
            // 
            // labelsGroupFooter
            // 
            this.labelsGroupFooter.Height = new Telerik.Reporting.Drawing.Unit(0.0520833320915699D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.labelsGroupFooter.Name = "labelsGroupFooter";
            this.labelsGroupFooter.Style.Visible = false;
            // 
            // labelsGroupHeader
            // 
            this.labelsGroupHeader.Height = new Telerik.Reporting.Drawing.Unit(0.0520833320915699D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.labelsGroupHeader.Name = "labelsGroupHeader";
            this.labelsGroupHeader.PrintOnEveryPage = true;
            this.labelsGroupHeader.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // Hedgedesk
            // 
            this.Hedgedesk.CommandTimeout = 60;
            this.Hedgedesk.ConnectionString = "Data Source=SQLDEV4;Initial Catalog=HedgeDesk;Persist Security Info=True;User ID=" +
    "IUser_Hedgebook;Password=hedgebook";
            this.Hedgedesk.Name = "Hedgedesk";
            this.Hedgedesk.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@HedgeUserID", System.Data.DbType.Int32, "=Parameters.HedgeUserID.Value")});
            this.Hedgedesk.ProviderName = "System.Data.SqlClient";
            this.Hedgedesk.SelectCommand = "proc_rptHBOptionsConfirmationMaster";
            this.Hedgedesk.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // reportFooter
            // 
            this.reportFooter.Height = new Telerik.Reporting.Drawing.Unit(0.0520833320915699D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.reportFooter.Name = "reportFooter";
            this.reportFooter.Style.Visible = false;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = new Telerik.Reporting.Drawing.Unit(0.35841211676597595D, Telerik.Reporting.Drawing.UnitType.Inch);
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
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(9.6999998092651367D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14791648089885712D, Telerik.Reporting.Drawing.UnitType.Inch));
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
            this.reportHeader.Height = new Telerik.Reporting.Drawing.Unit(0.14587259292602539D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox3});
            this.reportHeader.Name = "reportHeader";
            // 
            // textBox3
            // 
            this.textBox3.Bindings.Add(new Telerik.Reporting.Binding("Parent.Visible", "=Count(1)=0"));
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.2000000476837158D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9339065551757812E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.1541666984558105D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.14583325386047363D, Telerik.Reporting.Drawing.UnitType.Inch));
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
            this.titleTextBox.Value = "Options Confirmation";
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(0.052083373069763184D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Name = "detail";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(0.5D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.75420647859573364D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.subReport1.Name = "subReport1";
            this.subReport1.ReportSource = this.rsubOptionsConfirmation2;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(10.499960899353027D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.subReport1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // rsubOptionsConfirmation2
            // 
            this.rsubOptionsConfirmation2.Name = "rsubOptionsConfirmationTwo";
            // 
            // subReport2
            // 
            this.subReport2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.55412757396698D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.subReport2.Name = "subReport2";
            this.subReport2.ReportSource = this.rsubOptionsConfirmationOffset2;
            this.subReport2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(10.499960899353027D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999980926513672D, Telerik.Reporting.Drawing.UnitType.Inch));
            // 
            // rsubOptionsConfirmationOffset2
            // 
            this.rsubOptionsConfirmationOffset2.Name = "rsubOptionsConfirmationOffset2";
            // 
            // rsubOptionsConfirmation1
            // 
            this.rsubOptionsConfirmation1.Name = "rsubOptionsConfirmation1";
            // 
            // rsubOptionsConfirmationOffset1
            // 
            this.rsubOptionsConfirmationOffset1.Name = "rsubOptionsConfirmationOffset";
            // 
            // rptOptionsConfirmationMaster
            // 
            this.DataSource = this.Hedgedesk;
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1,
            this.group2});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
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
            this.Width = new Telerik.Reporting.Drawing.Unit(10.5D, Telerik.Reporting.Drawing.UnitType.Inch);
            ((System.ComponentModel.ISupportInitialize)(this.rsubOptionsConfirmation2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsubOptionsConfirmationOffset2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsubOptionsConfirmation1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsubOptionsConfirmationOffset1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource Hedgedesk;
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
        private Telerik.Reporting.Group AccountGroup;
        private Telerik.Reporting.GroupFooterSection groupFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.SubReport subReport1;
        private rsubOptionsConfirmation rsubOptionsConfirmation1;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.SubReport subReport2;
        private rsubOptionsConfirmationOffset rsubOptionsConfirmationOffset1;
        private Telerik.Reporting.Group group1;
        private rsubOptionsConfirmation rsubOptionsConfirmation2;
        private rsubOptionsConfirmationOffset rsubOptionsConfirmationOffset2;
        private Telerik.Reporting.Group group2;
    }
}
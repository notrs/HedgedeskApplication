using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Data;

using System.Drawing;

namespace HedgedeskApplication.Models
{
    public class RiskPosition
    {

        public void SetupRiskPosition(ListView lv, DataTable dtRisk, ref int RiskPositionSetting)
        {
            lv.Clear();
            lv.View = View.Details;
            lv.FullRowSelect = true;
            int Counter = dtRisk.Columns.Count;
            //int RiskPositionSetting = 0;
            int CountDivide = Counter - 2;
            int WidthControl = lv.Width - 140;
            int RowWidth = WidthControl / CountDivide;
            int RowCounter = dtRisk.Rows.Count;
            System.Drawing.Font boldrow = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);
            System.Drawing.Font regrow = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            lv.Clear();
            for (int i = 0; i < Counter; i++)
            {
                if (dtRisk.Columns[i].ColumnName == "Mo" )
                {
                    lv.Columns.Add(dtRisk.Columns[i].ColumnName, 90, HorizontalAlignment.Left);
                }
                else
                {
                    if (dtRisk.Columns[i].ColumnName == "Year")
                    {
                        lv.Columns.Add(dtRisk.Columns[i].ColumnName, 45, HorizontalAlignment.Left);
                    }
                    else
                    {
                        lv.Columns.Add(dtRisk.Columns[i].ColumnName, RowWidth, HorizontalAlignment.Right);
                    }
                }


            }
            foreach (DataRow row in dtRisk.Rows)
            {
                
                ListViewItem lvi = new ListViewItem(row[0].ToString());
                lvi.UseItemStyleForSubItems = false;
                for (int j = 1; j < Counter; j++)
                {
                    if (row[0].ToString().Trim() == "Position")
                    {
                        lvi.SubItems.Add(row[j].ToString(), Color.Black, Color.Transparent, boldrow);
                    }
                    else if (row[0].ToString().Trim() == "Over")
                    {
                        lvi.SubItems.Add(row[j].ToString(), Color.Black, Color.Transparent, boldrow);

                    }
                    else
                    {
                        lvi.SubItems.Add(row[j].ToString(), Color.Black, Color.Transparent, regrow);
                    }
                }
                lv.Items.Add(lvi);
            }

            for (int x = 0; x < lv.Items.Count; x++)
            {
                if (lv.Items[x].SubItems[0].Text.ToString() == "Over")
                {
                    for (int q = 0; q < lv.Items[x].SubItems.Count; q++)
                    {
                        if (lv.Items[x].SubItems[q].Text.ToString() != "Over" && lv.Items[x].SubItems[q].Text.ToString() != "")
                        {
                            if (Convert.ToDecimal(lv.Items[x].SubItems[q].Text.ToString()) < 0)
                            {
                                lv.Items[x].SubItems[q].ForeColor = Color.Red;
                                //lv.Items[x].SubItems[q].Font.Bold = true;
                                lv.Items[x].SubItems[q].Text = (Convert.ToDecimal(lv.Items[x].SubItems[q].Text.ToString()) * -1).ToString();
                                RiskPositionSetting = RiskPositionSetting + 1;

                            }
                            else 
                            {
                                lv.Items[x].SubItems[q].Text = "".ToString();
                            }
                        }
                    }
                }
                else 
                {
                    for (int q = 0; q < lv.Items[x].SubItems.Count; q++)
                    {
                        if (lv.Items[x].SubItems[q].Text.ToString() == "0.00")
                        {
                            
                                lv.Items[x].SubItems[q].Text = "".ToString();
                                //RiskPositionSetting = RiskPositionSetting + 1;

                            
                        }
                    }
                }
                
            }

            

        }

        public void SetupRiskPositionCash(ListView lv, DataTable dtRisk)
        {
            lv.Clear(); 
            lv.View = View.Details;
            lv.FullRowSelect = true;
            int Counter = dtRisk.Columns.Count;
            int CountDivide = Counter - 2;
            int WidthControl = lv.Width - 90;
            int RowWidth = WidthControl / CountDivide;
            int RowCounter = dtRisk.Rows.Count;
            System.Drawing.Font boldrow = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);
            System.Drawing.Font regrow = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            lv.Clear();
            for (int i = 0; i < Counter; i++)
            {
                if (dtRisk.Columns[i].ColumnName == "Mo")
                {
                    lv.Columns.Add(dtRisk.Columns[i].ColumnName, 55, HorizontalAlignment.Left);
                }
                else
                {
                    if (dtRisk.Columns[i].ColumnName == "Year")
                    {
                        lv.Columns.Add("Yr", 30, HorizontalAlignment.Left);
                    }
                    else
                    {
                        lv.Columns.Add(dtRisk.Columns[i].ColumnName, RowWidth, HorizontalAlignment.Right);
                    }
                }


            }
            foreach (DataRow row in dtRisk.Rows)
            {

                ListViewItem lvi = new ListViewItem(row[0].ToString());
                if (lvi.Text == "Spread Limit" || lvi.Text == "Over" || lvi.Text == "Spread Position")
                {
                }
                else
                {
                    lvi.UseItemStyleForSubItems = false;
                    for (int j = 1; j < Counter; j++)
                    {
                        if (row[0].ToString().Trim() == "Position")
                        {
                            lvi.SubItems.Add(row[j].ToString(), Color.Black, Color.Transparent, boldrow);
                        }
                        else if (row[0].ToString().Trim() == "Spread Position")
                        {
                            //lvi.SubItems.Add(row[j].ToString(), Color.Black, Color.Transparent, boldrow);

                        }
                        else if (row[0].ToString().Trim() == "Over")
                        {
                            //lvi.SubItems.Add(row[j].ToString(), Color.Black, Color.Transparent, boldrow);

                        }
                        else if (row[0].ToString().Trim() == "Spread Limit")
                        {
                            //lvi.SubItems.Add(row[j].ToString(), Color.Black, Color.Transparent, boldrow);

                        }
                        else
                        {
                            lvi.SubItems.Add(row[j].ToString(), Color.Black, Color.Transparent, regrow);
                        }
                    }
                    lv.Items.Add(lvi);
                }
            }

            for (int x = 0; x < lv.Items.Count; x++)
            {
                for (int q = 0; q < lv.Items[x].SubItems.Count; q++)
                {
                    if (lv.Items[x].SubItems[q].Text.ToString() == "0.00")
                    {

                        lv.Items[x].SubItems[q].Text = "".ToString();
                        //RiskPositionSetting = RiskPositionSetting + 1;


                    }
                }
            }



        }
    }
}

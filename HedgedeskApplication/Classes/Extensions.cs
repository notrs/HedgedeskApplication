using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Telerik.WinControls.UI;
using System.Threading.Tasks;
using System.Threading;

namespace HedgedeskApplication.Classes
{
    class Extensions
    {
    }

    public class CalendarColumn : DataGridViewColumn
    {
        public CalendarColumn()
            : base(new CalendarCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell. 
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class CalendarCell : DataGridViewTextBoxCell
    {

        public CalendarCell()
            : base()
        {
            // Use the short date format. 
            this.Style.Format = "g";
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value. 
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CalendarEditingControl ctl =
                DataGridView.EditingControl as CalendarEditingControl;
            // Use the default row value when Value property is null. 
            if (this.Value == null)
            {
                ctl.Value = (DateTime)this.DefaultNewRowValue;
            }
            else
            {
                try
                {
                    ctl.Value = (DateTime)this.Value;
                }
                catch
                {
                    ctl.Value = (DateTime)this.DefaultNewRowValue;
                }

            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarCell uses. 
                return typeof(CalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains. 

                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value. 
                return DateTime.Now;
            }
        }
    }

    class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public CalendarEditingControl()
        {
            //this.Format = DateTimePickerFormat.Short;
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "MM/dd/yyyy hh:mm";
            this.ShowUpDown = true;
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue  
        // property. 
        public object EditingControlFormattedValue
        {
            get
            {
                //return this.Value.ToShortDateString();
                return this.Value.ToShortTimeString();
            }
            set
            {
                if (value is String)
                {
                    try
                    {
                        // This will throw an exception of the string is  
                        // null, empty, or not in the format of a date. 
                        this.Value = DateTime.Parse((String)value);
                    }
                    catch
                    {
                        // In the case of an exception, just use the  
                        // default value so we're not left with a null 
                        // value. 
                        this.Value = DateTime.Now;
                    }
                }
            }
        }

        // Implements the  
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method. 
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the  
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method. 
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex  
        // property. 
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey  
        // method. 
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed. 
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit  
        // method. 
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        // Implements the IDataGridViewEditingControl 
        // .RepositionEditingControlOnValueChange property. 
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl 
        // .EditingControlDataGridView property. 
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl 
        // .EditingControlValueChanged property. 
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl 
        // .EditingPanelCursor property. 
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell 
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }

    public class CalendarDateColumn : DataGridViewColumn
    {
        public CalendarDateColumn()
            : base(new CalendarDateCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarDateCell. 
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(CalendarDateCell)))
                {
                    throw new InvalidCastException("Must be a CalendarDateCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class CalendarDateCell : DataGridViewTextBoxCell
    {

        public CalendarDateCell()
            : base()
        {
            // Use the short date format. 
            this.Style.Format = "d";
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value. 
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CalendarDateEditingControl ctl =
                DataGridView.EditingControl as CalendarDateEditingControl;
            // Use the default row value when Value property is null. 
            if (this.Value == null)
            {
                ctl.Value = (DateTime)this.DefaultNewRowValue;
            }
            else
            {
                try
                {
                    ctl.Value = (DateTime)this.Value;
                }
                catch
                {
                    ctl.Value = (DateTime)this.DefaultNewRowValue;
                }

            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarDateCell uses. 
                return typeof(CalendarDateEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarDateCell contains. 

                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value. 
                return DateTime.Now;
            }
        }
    }

    class CalendarDateEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public CalendarDateEditingControl()
        {
            //this.Format = DateTimePickerFormat.Short;
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "MM/dd/yyyy";
            this.ShowUpDown = true;
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue  
        // property. 
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Value.ToShortDateString();
                //return this.Value.ToShortTimeString();
            }
            set
            {
                if (value is String)
                {
                    try
                    {
                        // This will throw an exception of the string is  
                        // null, empty, or not in the format of a date. 
                        this.Value = DateTime.Parse((String)value);
                    }
                    catch
                    {
                        // In the case of an exception, just use the  
                        // default value so we're not left with a null 
                        // value. 
                        this.Value = DateTime.Now;
                    }
                }
            }
        }

        // Implements the  
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method. 
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the  
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method. 
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex  
        // property. 
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey  
        // method. 
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed. 
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit  
        // method. 
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        // Implements the IDataGridViewEditingControl 
        // .RepositionEditingControlOnValueChange property. 
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl 
        // .EditingControlDataGridView property. 
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl 
        // .EditingControlValueChanged property. 
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl 
        // .EditingPanelCursor property. 
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell 
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
    public class dgvCustomVCF : System.Windows.Forms.DataGridView
    {

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            GlobalStore.setIsRowChanged(false);
            string myControl = "";
            myControl = this.CurrentCell.GetType().ToString();
            if (keyData == Keys.Return && myControl == "System.Windows.Forms.DataGridViewButtonCell")
            {
                keyData = Keys.Enter;
                {
                    GlobalStore.setIsRowChanged(true);
                    msg.WParam = (IntPtr)Keys.Enter;
                }
            }

            else if (keyData == Keys.Return | keyData == Keys.Tab)
            {
                if (CurrentCellAddress.X == ColumnCount - 1)
                {
                    keyData = Keys.Cancel;
                    {
                        msg.WParam = (IntPtr)Keys.Cancel;
                    }
                }
                else
                {
                    keyData = Keys.Tab;
                    {
                        msg.WParam = (IntPtr)Keys.Tab;
                    }
                }
            }


            if (keyData == (Keys.Shift | Keys.Tab))
            {
                if (CurrentCellAddress.X == 0)
                {
                    keyData = Keys.Cancel;
                    {
                        msg.WParam = (IntPtr)Keys.Cancel;
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessDialogKey(System.Windows.Forms.Keys keyData)
        {

            if (keyData == Keys.Return | keyData == Keys.Tab)
            {
                if (CurrentCellAddress.X == ColumnCount - 1)
                {
                    keyData = Keys.Cancel;
                }
                else
                {
                    keyData = Keys.Tab;
                }
            }

            if (keyData == (Keys.Shift | Keys.Tab))
            {
                if (CurrentCellAddress.X == 0)
                {
                    keyData = Keys.Cancel;
                }
            }

            return base.ProcessDialogKey(keyData);
        }


    }

    public class CustomCheckBoxElement : RadCheckBoxElement
    {

        protected override void OnKeyDown(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                SendKeys.Send("{TAB}");
                return;

            }



            base.OnKeyDown(e);

        }



        protected override Type ThemeEffectiveType
        {

            get { return typeof(RadCheckBoxElement); }

        }

    }

    public class CustomCheckBox : RadCheckBox
    {

        protected override RadButtonElement CreateButtonElement()
        {

            return new CustomCheckBoxElement();

        }



        public override string ThemeClassName
        {

            get
            {

                return typeof(RadCheckBox).FullName;

            }

        }

    }

    class MyDateTimerPicker : DateTimePicker
    {

        private SolidBrush m_BackColorBrush;



        public MyDateTimerPicker()
        {

            //m_BackColorBrush = new SolidBrush(base.BackColor);

            m_BackColorBrush = new SolidBrush(Color.Green);

        }



        public override System.Drawing.Color BackColor
        {

            get
            {

                return base.BackColor;

            }

            set
            {

                if (null != m_BackColorBrush)
                {

                    m_BackColorBrush.Dispose();

                }

                base.BackColor = value;

                m_BackColorBrush = new SolidBrush(value);

                this.Invalidate();

            }

        }



        protected override void WndProc(ref Message m)
        {

            const int WM_ERASEBKGND = 20;

            if (WM_ERASEBKGND == m.Msg)
            {

                Graphics g = Graphics.FromHdc(m.WParam);

                g.FillRectangle(m_BackColorBrush, this.ClientRectangle);

                g.Dispose();

            }

            else
            {

                base.WndProc(ref m);

            }

        }

    }

    public class UIContext
    {
        private static TaskScheduler m_Current;

        public static TaskScheduler Current
        {
            get { return m_Current; }
            private set { m_Current = value; }
        }

        public static void Initialize()
        {
            if (Current != null)
                return;

            if (SynchronizationContext.Current == null)
                SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

            Current = TaskScheduler.FromCurrentSynchronizationContext();
        }

    }


}

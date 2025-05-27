using Timer = System.Windows.Forms.Timer;

namespace MysGame.data;

public partial class Debug : Form
{
    private readonly Timer _debugTimer;
    
    public Debug()
    {
        InitializeComponent();
        this.TabStop = false;
        _debugTimer = new Timer();
        _debugTimer.Interval = 1000;
        _debugTimer.Tick += (s, e) => UpdateDebugGird();
        _debugTimer.Start();
    }

    /// <summary>
    /// 컨트롤 상태 업데이트
    /// </summary>
    private void UpdateDebugGird()
    {
        foreach (Control control in this.Controls)
        {
            if (control is not DataGridView debugGrid) continue;

            foreach (DataGridViewRow row in debugGrid.Rows)
            {
                if (row.Tag is not Control ctrl) continue;
                
                row.Cells["Visible"].Value = ctrl.Visible;
                row.Cells["Text"].Value = ctrl.Text;
                row.Cells["Location"].Value = ctrl.Location;
                row.Cells["Size"].Value = ctrl.Size;
            }
        }
    }

    /// <summary>
    /// 데이터 그리드 생성 및 초기화 (컨트롤 값과 항목 추가)
    /// </summary>
    /// <param name="userControl"></param>
    public void LoadControl(Control userControl)
    {
        Label userControlName = new Label();
        userControlName.Text = userControl.GetType().Name;
        userControlName.Dock = DockStyle.Top;
        
        DataGridView debugGrid = new DataGridView();
        debugGrid.Visible = true;
        debugGrid.ReadOnly = true;
        debugGrid.Enabled = false;
        debugGrid.Dock = DockStyle.Top;
        debugGrid.RowHeadersVisible = false;
        debugGrid.AllowUserToAddRows = false;
        debugGrid.AllowUserToDeleteRows = false;
        debugGrid.AllowUserToResizeRows = false;
        debugGrid.AllowUserToResizeColumns = false;
        debugGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        debugGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        debugGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        debugGrid.DefaultCellStyle.SelectionBackColor = debugGrid.DefaultCellStyle.BackColor;
        debugGrid.DefaultCellStyle.SelectionForeColor = debugGrid.DefaultCellStyle.ForeColor;

        debugGrid.Columns.Add("ControlName", "Control");
        debugGrid.Columns.Add("Name", "Name");
        debugGrid.Columns.Add("Visible", "Visible");
        debugGrid.Columns.Add("Text", "Text");
        debugGrid.Columns.Add("Location", "Location");
        debugGrid.Columns.Add("Size", "Size");
        
        foreach (Control control in userControl.Controls)
        {
            int rowIndex = debugGrid.Rows.Add();
            DataGridViewRow row = debugGrid.Rows[rowIndex];
            
            row.Cells["ControlName"].Value = control.GetType().Name;
            row.Cells["Name"].Value = control.Name;
            row.Cells["Visible"].Value = control.Visible;
            row.Cells["Text"].Value = control.Text;
            row.Cells["Location"].Value = control.Location;
            row.Cells["Size"].Value = control.Size;
            row.Tag = control;
        }

        this.Controls.Add(debugGrid);
        this.Controls.Add(userControlName);
    }
}
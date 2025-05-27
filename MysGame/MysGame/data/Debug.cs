namespace MysGame.data;

public partial class Debug : Form
{
    private readonly DataGridView _debugGrid = new DataGridView();
    
    public Debug()
    {
        InitializeComponent();
        this.TabStop = false;

        _debugGrid.Visible = true;
        _debugGrid.Location = new Point(0, 0);
        _debugGrid.Dock = DockStyle.Fill;
        _debugGrid.AllowUserToResizeColumns = false;
        _debugGrid.AllowUserToResizeRows = false;
        _debugGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        // _debugGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        // _debugGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        // _debugGrid.ReadOnly = true;
        _debugGrid.RowHeadersVisible = false;
        _debugGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

        var visibleColumns = new DataGridViewCheckBoxColumn
        {
            Name = "Visible",
            HeaderText = "Visible",
            DataPropertyName = "Visible"
        };
        
        _debugGrid.Columns.Add("ControlName", "Control");
        _debugGrid.Columns.Add("Name", "Name");
        _debugGrid.Columns.Add(visibleColumns);
        _debugGrid.Columns.Add("Text", "Text");
        _debugGrid.Columns.Add("Location", "Location");
        _debugGrid.Columns.Add("Size", "Size");
        
        this.Controls.Add(_debugGrid);
    }

    public void LoadControl(UserControl userControl)
    {
        _debugGrid.Rows.Add(userControl.GetType().Name);

        if (userControl.Controls.Count <= 0) 
            return;
        
        foreach (Control control in userControl.Controls)
        {
            _debugGrid.Rows.Add(control.GetType().Name,
                control.Name,
                control.Visible,
                control.Text,
                control.Location.ToString(),
                control.Size.ToString());
        }
    }
}
using System.ComponentModel;

namespace MysGame.data.resource.control;

partial class TextArea
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        textLabel = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // TextBox
        // 
        textLabel.Location = new System.Drawing.Point(0, 0);
        textLabel.Name = "textLabel";
        textLabel.Size = new System.Drawing.Size(497, 134);
        textLabel.TabIndex = 0;
        textLabel.Text = "label1";
        // 
        // TextArea
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.Black;
        Controls.Add(textLabel);
        Font = new System.Drawing.Font("Ink Free", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        ForeColor = System.Drawing.Color.Black;
        Size = new System.Drawing.Size(497, 134);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label textLabel;

    #endregion
}
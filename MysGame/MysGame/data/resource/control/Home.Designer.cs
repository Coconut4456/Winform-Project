using System.ComponentModel;

namespace MysGame.data.resource.control;

partial class Home
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
        titleLabel = new System.Windows.Forms.Label();
        newGameButton = new System.Windows.Forms.Button();
        loadButton = new System.Windows.Forms.Button();
        settingButton = new System.Windows.Forms.Button();
        exitButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // titleLabel
        // 
        titleLabel.BackColor = System.Drawing.Color.Transparent;
        titleLabel.Font = new System.Drawing.Font("Ink Free", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        titleLabel.ForeColor = System.Drawing.Color.White;
        titleLabel.Location = new System.Drawing.Point(-9, 32);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new System.Drawing.Size(909, 183);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "truth is lie";
        titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // newGameButton
        // 
        newGameButton.BackColor = System.Drawing.Color.Transparent;
        newGameButton.FlatAppearance.BorderSize = 0;
        newGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        newGameButton.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        newGameButton.ForeColor = System.Drawing.Color.White;
        newGameButton.Location = new System.Drawing.Point(12, 265);
        newGameButton.Name = "newGameButton";
        newGameButton.Size = new System.Drawing.Size(153, 44);
        newGameButton.TabIndex = 1;
        newGameButton.Text = "NewGame";
        newGameButton.UseVisualStyleBackColor = false;
        // 
        // loadButton
        // 
        loadButton.BackColor = System.Drawing.Color.Transparent;
        loadButton.FlatAppearance.BorderSize = 0;
        loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        loadButton.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        loadButton.ForeColor = System.Drawing.Color.White;
        loadButton.Location = new System.Drawing.Point(12, 315);
        loadButton.Name = "loadButton";
        loadButton.Size = new System.Drawing.Size(153, 44);
        loadButton.TabIndex = 2;
        loadButton.Text = "Load";
        loadButton.UseVisualStyleBackColor = false;
        // 
        // settingButton
        // 
        settingButton.BackColor = System.Drawing.Color.Transparent;
        settingButton.FlatAppearance.BorderSize = 0;
        settingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        settingButton.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        settingButton.ForeColor = System.Drawing.Color.White;
        settingButton.Location = new System.Drawing.Point(12, 365);
        settingButton.Name = "settingButton";
        settingButton.Size = new System.Drawing.Size(153, 44);
        settingButton.TabIndex = 3;
        settingButton.Text = "Setting";
        settingButton.UseVisualStyleBackColor = false;
        // 
        // exitButton
        // 
        exitButton.BackColor = System.Drawing.Color.Transparent;
        exitButton.FlatAppearance.BorderSize = 0;
        exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        exitButton.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        exitButton.ForeColor = System.Drawing.Color.White;
        exitButton.Location = new System.Drawing.Point(12, 415);
        exitButton.Name = "exitButton";
        exitButton.Size = new System.Drawing.Size(153, 44);
        exitButton.TabIndex = 4;
        exitButton.Text = "Exit";
        exitButton.UseVisualStyleBackColor = false;
        // 
        // Home
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.Black;
        BackgroundImage = ((System.Drawing.Image)resources.GetObject("$this.BackgroundImage"));
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        Controls.Add(exitButton);
        Controls.Add(settingButton);
        Controls.Add(loadButton);
        Controls.Add(newGameButton);
        Controls.Add(titleLabel);
        Location = new System.Drawing.Point(15, 15);
        Size = new System.Drawing.Size(1200, 760);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button newGameButton;
    private System.Windows.Forms.Button loadButton;
    private System.Windows.Forms.Button settingButton;
    private System.Windows.Forms.Button exitButton;
    private System.Windows.Forms.Label titleLabel;

    #endregion
}
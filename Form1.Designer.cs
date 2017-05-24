namespace RoutingProtocolImplementation
{
    partial class RouterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RouterButton = new System.Windows.Forms.Button();
            this.NodeButton = new System.Windows.Forms.Button();
            this.routerListBox = new System.Windows.Forms.ListBox();
            this.routerTableListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // RouterButton
            // 
            this.RouterButton.Location = new System.Drawing.Point(64, 209);
            this.RouterButton.Name = "RouterButton";
            this.RouterButton.Size = new System.Drawing.Size(75, 23);
            this.RouterButton.TabIndex = 0;
            this.RouterButton.Text = "Add Router";
            this.RouterButton.UseVisualStyleBackColor = true;
            // 
            // NodeButton
            // 
            this.NodeButton.Location = new System.Drawing.Point(281, 209);
            this.NodeButton.Name = "NodeButton";
            this.NodeButton.Size = new System.Drawing.Size(75, 23);
            this.NodeButton.TabIndex = 1;
            this.NodeButton.Text = "Add Node";
            this.NodeButton.UseVisualStyleBackColor = true;
            // 
            // routerListBox
            // 
            this.routerListBox.FormattingEnabled = true;
            this.routerListBox.Location = new System.Drawing.Point(39, 30);
            this.routerListBox.Name = "routerListBox";
            this.routerListBox.Size = new System.Drawing.Size(125, 160);
            this.routerListBox.TabIndex = 2;
            // 
            // routerTableListView
            // 
            this.routerTableListView.Location = new System.Drawing.Point(216, 30);
            this.routerTableListView.Name = "routerTableListView";
            this.routerTableListView.Size = new System.Drawing.Size(186, 160);
            this.routerTableListView.TabIndex = 3;
            this.routerTableListView.UseCompatibleStateImageBehavior = false;
            // 
            // RouterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 262);
            this.Controls.Add(this.routerTableListView);
            this.Controls.Add(this.routerListBox);
            this.Controls.Add(this.NodeButton);
            this.Controls.Add(this.RouterButton);
            this.Name = "RouterForm";
            this.Text = "Harder Daddy";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RouterButton;
        private System.Windows.Forms.Button NodeButton;
        private System.Windows.Forms.ListBox routerListBox;
        private System.Windows.Forms.ListView routerTableListView;
    }
}


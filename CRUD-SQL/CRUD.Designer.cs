namespace CRUD_SQL
{
    partial class CRUD
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.serverChoose = new System.Windows.Forms.ComboBox();
            this.dbChoose = new System.Windows.Forms.ComboBox();
            this.tableChoose = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.textboxRead = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 117);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1472, 306);
            this.dataGridView1.TabIndex = 0;
            // 
            // serverChoose
            // 
            this.serverChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serverChoose.FormattingEnabled = true;
            this.serverChoose.Location = new System.Drawing.Point(164, 44);
            this.serverChoose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.serverChoose.Name = "serverChoose";
            this.serverChoose.Size = new System.Drawing.Size(160, 24);
            this.serverChoose.TabIndex = 1;
            this.serverChoose.SelectedIndexChanged += new System.EventHandler(this.serverChoose_SelectedIndexChanged);
            // 
            // dbChoose
            // 
            this.dbChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbChoose.FormattingEnabled = true;
            this.dbChoose.Location = new System.Drawing.Point(417, 43);
            this.dbChoose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dbChoose.Name = "dbChoose";
            this.dbChoose.Size = new System.Drawing.Size(160, 24);
            this.dbChoose.TabIndex = 2;
            this.dbChoose.SelectedIndexChanged += new System.EventHandler(this.dbChoose_SelectedIndexChanged);
            // 
            // tableChoose
            // 
            this.tableChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tableChoose.FormattingEnabled = true;
            this.tableChoose.Location = new System.Drawing.Point(684, 43);
            this.tableChoose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableChoose.Name = "tableChoose";
            this.tableChoose.Size = new System.Drawing.Size(160, 24);
            this.tableChoose.TabIndex = 3;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1037, 39);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 28);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(195, 489);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 28);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(377, 489);
            this.btnRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(100, 28);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(745, 489);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(944, 489);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // textboxRead
            // 
            this.textboxRead.Location = new System.Drawing.Point(508, 491);
            this.textboxRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textboxRead.Name = "textboxRead";
            this.textboxRead.Size = new System.Drawing.Size(197, 22);
            this.textboxRead.TabIndex = 9;
            // 
            // CRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 576);
            this.Controls.Add(this.textboxRead);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tableChoose);
            this.Controls.Add(this.dbChoose);
            this.Controls.Add(this.serverChoose);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CRUD";
            this.Text = "CRUD on SQL using LINQ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox serverChoose;
        private System.Windows.Forms.ComboBox dbChoose;
        private System.Windows.Forms.ComboBox tableChoose;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox textboxRead;
    }
}


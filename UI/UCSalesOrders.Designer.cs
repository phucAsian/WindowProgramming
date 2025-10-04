namespace Supermarket
{
    partial class UCInvoice
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudInvoiceQty = new System.Windows.Forms.NumericUpDown();
            this.txtInvoicePrice = new System.Windows.Forms.TextBox();
            this.cmbInvoiceProduct = new System.Windows.Forms.ComboBox();
            this.cmbInvoiceCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInvoiceTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnInvoiceCreate = new System.Windows.Forms.Button();
            this.btnInvoiceEdit = new System.Windows.Forms.Button();
            this.btnInvoiceDelete = new System.Windows.Forms.Button();
            this.btnInvoiceSave = new System.Windows.Forms.Button();
            this.btnInvoiceIssue = new System.Windows.Forms.Button();
            this.btnInvoiceReload = new System.Windows.Forms.Button();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInvoiceQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudInvoiceQty);
            this.groupBox1.Controls.Add(this.txtInvoicePrice);
            this.groupBox1.Controls.Add(this.cmbInvoiceProduct);
            this.groupBox1.Controls.Add(this.cmbInvoiceCategory);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblInvoiceTotal);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(911, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN HÓA ĐƠN";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // nudInvoiceQty
            // 
            this.nudInvoiceQty.Location = new System.Drawing.Point(761, 48);
            this.nudInvoiceQty.Name = "nudInvoiceQty";
            this.nudInvoiceQty.Size = new System.Drawing.Size(103, 20);
            this.nudInvoiceQty.TabIndex = 7;
            // 
            // txtInvoicePrice
            // 
            this.txtInvoicePrice.Location = new System.Drawing.Point(550, 49);
            this.txtInvoicePrice.Name = "txtInvoicePrice";
            this.txtInvoicePrice.Size = new System.Drawing.Size(149, 20);
            this.txtInvoicePrice.TabIndex = 6;
            // 
            // cmbInvoiceProduct
            // 
            this.cmbInvoiceProduct.FormattingEnabled = true;
            this.cmbInvoiceProduct.Location = new System.Drawing.Point(248, 48);
            this.cmbInvoiceProduct.Name = "cmbInvoiceProduct";
            this.cmbInvoiceProduct.Size = new System.Drawing.Size(221, 21);
            this.cmbInvoiceProduct.TabIndex = 5;
            // 
            // cmbInvoiceCategory
            // 
            this.cmbInvoiceCategory.FormattingEnabled = true;
            this.cmbInvoiceCategory.Location = new System.Drawing.Point(16, 48);
            this.cmbInvoiceCategory.Name = "cmbInvoiceCategory";
            this.cmbInvoiceCategory.Size = new System.Drawing.Size(177, 21);
            this.cmbInvoiceCategory.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(792, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(605, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giá bán";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Danh mục";
            // 
            // lblInvoiceTotal
            // 
            this.lblInvoiceTotal.AutoSize = true;
            this.lblInvoiceTotal.BackColor = System.Drawing.SystemColors.Control;
            this.lblInvoiceTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceTotal.ForeColor = System.Drawing.Color.Red;
            this.lblInvoiceTotal.Location = new System.Drawing.Point(794, 99);
            this.lblInvoiceTotal.Name = "lblInvoiceTotal";
            this.lblInvoiceTotal.Size = new System.Drawing.Size(31, 13);
            this.lblInvoiceTotal.TabIndex = 2;
            this.lblInvoiceTotal.Text = "......";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(727, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Thành tiền:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sản phẩm";
            // 
            // btnInvoiceCreate
            // 
            this.btnInvoiceCreate.Location = new System.Drawing.Point(30, 178);
            this.btnInvoiceCreate.Name = "btnInvoiceCreate";
            this.btnInvoiceCreate.Size = new System.Drawing.Size(97, 38);
            this.btnInvoiceCreate.TabIndex = 3;
            this.btnInvoiceCreate.Text = "Tạo hóa đơn";
            this.btnInvoiceCreate.UseVisualStyleBackColor = true;
            this.btnInvoiceCreate.Click += new System.EventHandler(this.btnInvoiceCreate_Click);
            // 
            // btnInvoiceEdit
            // 
            this.btnInvoiceEdit.Location = new System.Drawing.Point(152, 178);
            this.btnInvoiceEdit.Name = "btnInvoiceEdit";
            this.btnInvoiceEdit.Size = new System.Drawing.Size(97, 38);
            this.btnInvoiceEdit.TabIndex = 4;
            this.btnInvoiceEdit.Text = "Sửa hóa đơn";
            this.btnInvoiceEdit.UseVisualStyleBackColor = true;
            this.btnInvoiceEdit.Click += new System.EventHandler(this.btnInvoiceEdit_Click);
            // 
            // btnInvoiceDelete
            // 
            this.btnInvoiceDelete.Location = new System.Drawing.Point(280, 178);
            this.btnInvoiceDelete.Name = "btnInvoiceDelete";
            this.btnInvoiceDelete.Size = new System.Drawing.Size(97, 38);
            this.btnInvoiceDelete.TabIndex = 5;
            this.btnInvoiceDelete.Text = "Xóa hóa đơn";
            this.btnInvoiceDelete.UseVisualStyleBackColor = true;
            this.btnInvoiceDelete.Click += new System.EventHandler(this.btnInvoiceDelete_Click);
            // 
            // btnInvoiceSave
            // 
            this.btnInvoiceSave.Location = new System.Drawing.Point(405, 178);
            this.btnInvoiceSave.Name = "btnInvoiceSave";
            this.btnInvoiceSave.Size = new System.Drawing.Size(97, 38);
            this.btnInvoiceSave.TabIndex = 6;
            this.btnInvoiceSave.Text = "Lưu";
            this.btnInvoiceSave.UseVisualStyleBackColor = true;
            this.btnInvoiceSave.Click += new System.EventHandler(this.btnInvoiceSave_Click);
            // 
            // btnInvoiceIssue
            // 
            this.btnInvoiceIssue.Location = new System.Drawing.Point(528, 178);
            this.btnInvoiceIssue.Name = "btnInvoiceIssue";
            this.btnInvoiceIssue.Size = new System.Drawing.Size(97, 38);
            this.btnInvoiceIssue.TabIndex = 7;
            this.btnInvoiceIssue.Text = "Xuất hóa đơn";
            this.btnInvoiceIssue.UseVisualStyleBackColor = true;
            this.btnInvoiceIssue.Click += new System.EventHandler(this.btnInvoiceIssue_Click);
            // 
            // btnInvoiceReload
            // 
            this.btnInvoiceReload.Location = new System.Drawing.Point(651, 178);
            this.btnInvoiceReload.Name = "btnInvoiceReload";
            this.btnInvoiceReload.Size = new System.Drawing.Size(97, 38);
            this.btnInvoiceReload.TabIndex = 9;
            this.btnInvoiceReload.Text = "Làm mới";
            this.btnInvoiceReload.UseVisualStyleBackColor = true;
            this.btnInvoiceReload.Click += new System.EventHandler(this.btnInvoiceReload_Click);
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Location = new System.Drawing.Point(13, 251);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.ReadOnly = true;
            this.dgvInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoices.Size = new System.Drawing.Size(911, 410);
            this.dgvInvoices.TabIndex = 8;
            // 
            // UCInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnInvoiceReload);
            this.Controls.Add(this.dgvInvoices);
            this.Controls.Add(this.btnInvoiceIssue);
            this.Controls.Add(this.btnInvoiceSave);
            this.Controls.Add(this.btnInvoiceDelete);
            this.Controls.Add(this.btnInvoiceEdit);
            this.Controls.Add(this.btnInvoiceCreate);
            this.Controls.Add(this.groupBox1);
            this.Name = "UCInvoice";
            this.Size = new System.Drawing.Size(963, 688);
            this.Load += new System.EventHandler(this.UCSalesOrders_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInvoiceQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NumericUpDown nudInvoiceQty;
        private System.Windows.Forms.TextBox txtInvoicePrice;
        private System.Windows.Forms.ComboBox cmbInvoiceProduct;
        private System.Windows.Forms.ComboBox cmbInvoiceCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblInvoiceTotal;
        private System.Windows.Forms.Button btnInvoiceCreate;
        private System.Windows.Forms.Button btnInvoiceEdit;
        private System.Windows.Forms.Button btnInvoiceDelete;
        private System.Windows.Forms.Button btnInvoiceSave;
        private System.Windows.Forms.Button btnInvoiceIssue;
        private System.Windows.Forms.Button btnInvoiceReload;
        private System.Windows.Forms.DataGridView dgvInvoices;
    }
}

﻿
namespace uidev.Controls
{
    partial class FxCheckbox
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FxCheckbox
            // 
            this.Border = false;
            this.EnabledChanged += new System.EventHandler(this.FxCheckbox_EnabledChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FxCheckbox_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FxCheckbox_MouseDown);
            this.MouseEnter += new System.EventHandler(this.FxCheckbox_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FxCheckbox_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FxCheckbox_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

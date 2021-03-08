using MSSwindow.CommonClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MSSwindow
{
    public partial class ImageUpload : Form
    {
        readonly int RefID = 0;
        int? AttachID = null;
        string LocalFileName = string.Empty;
        public ImageUpload(int Ref)
        {
            InitializeComponent();
            RefID = Ref;

        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
            pictureBox1.ImageLocation = textBox1.Text;
        }

        private void BindGrid()
        {
            CustomerClass cls = new CustomerClass();
            DataTable dt = new DataTable();
            if (cls.GetAttachMent(RefID).Tables.Count > 0)
            {
                dt = cls.GetAttachMent(RefID).Tables[0];
                dataGridViewLeger.DataSource = dt;
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Save Record?", "Product Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (TxtDescription.Text == string.Empty)
                {
                    MessageBox.Show(this, "Please Enter Description", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                Random rnd = new Random();
                CustomerClass cls = new CustomerClass();
                string address = textBox1.Text;
                String DirName = Path.GetDirectoryName(address);
                string Fname = rnd.Next().ToString() + Path.GetFileName(address);
                string SourcePath = Path.Combine(DirName, Path.GetFileName(address));
                int Result = cls.InsertUpdateAttachment(AttachID, RefID, TxtDescription.Text, Fname);
                if (Result > 0)
                {
                    if (AttachID == null)
                        CopyImage(SourcePath, Fname);
                    MessageBox.Show(this, "Attachment Saved SuccessFully", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    BindGrid();
                    clearAll();
                }
                else
                {
                    MessageBox.Show(this, "Attachment not Saved SuccessFully", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }

            }
        }

        private void clearAll()
        {
            TxtDescription.Text = string.Empty;
            textBox1.Text = string.Empty;
            pictureBox1.ImageLocation = string.Empty;
            AttachID = null;
        }
        private void CopyImage(String FromLocation, string FileName)
        {
            //string[] files = System.IO.Directory.GetFiles(FromLocation);
            String ExePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            ExePath = ExePath.Substring(6);
            ExePath = ExePath + "\\Images\\" + FileName;
            System.IO.File.Copy(FromLocation, ExePath, true);

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Delete Attachment?", "Purchase Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (AttachID == null)
                {
                    MessageBox.Show(this, "Please Select Row From Grid", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                CustomerClass cls = new CustomerClass();

                int Result = cls.DeleteAttachment((int)AttachID);
                if (Result > 0)
                {
                    DeleteImage(LocalFileName);
                    MessageBox.Show(this, "Attachment Deleted SuccessFully", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    BindGrid();
                    clearAll();
                }
                else
                {
                    MessageBox.Show(this, "Attachment not Deleted SuccessFully", "MSS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }

            }
        }
        private void ShowImageInPictureBox(string FileName)
        {
            String ExePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            ExePath = ExePath.Substring(6);
            ExePath = ExePath + "\\Images\\" + FileName;
            textBox1.Text = ExePath;
            pictureBox1.ImageLocation = ExePath;

        }

        private void DeleteImage(string FileName)
        {
            String ExePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            ExePath = ExePath.Substring(6);
            ExePath = ExePath + "\\Images\\" + FileName;
            System.IO.File.Delete(ExePath);
           
        }
        private void dataGridViewLeger_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AttachID = Convert.ToInt32(dataGridViewLeger.Rows[e.RowIndex].Cells["id"].Value.ToString());
                TxtDescription.Text = dataGridViewLeger.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                string FName = dataGridViewLeger.Rows[e.RowIndex].Cells["FilePath"].Value.ToString();
                LocalFileName = FName;
                ShowImageInPictureBox(FName);

            }
        }

        private void ImageUpload_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

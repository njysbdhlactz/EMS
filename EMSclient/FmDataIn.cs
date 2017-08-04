using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EMSclient
{
    public partial class FmDataIn : Form
    {
        public FmDataIn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//取消
        {
            this.Close();
        }

        private void bookinfo_CheckedChanged(object sender, EventArgs e)//导入图书
        {
            if (this.bookinfo.Checked)
            {
                MessageBox.Show("注意：\n    图书信息包括：book_id(图书编号，不能为空),book_code(条形码，不能为空),book_name(图书名称，不能为空),book_style(图书类型，不能为空),book_author(作者，可为空),book_publish(出版社),book_isbn(ISBN，不能为空),book_inprice(进价，不能为空),book_outprice(售价，不能为空),book_page(页码，可为空),book_bookcase(书架，可为空),book_count(库存量),book_date(出版日期，可为空),book_in(入库时间，可为空),book_memo(图书简介，可为空),book_cd_case(图书附加光盘所在书架，可为空)。导入数据的时候Excel文件应包含所有的图书信息，标识为'可为空'的图书信息表示该信息的内容可以为空表示，否则不能用空表示，必需填写。设置Excel表格工作簿的名称为excel(默认为Sheet1)。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click(object sender, EventArgs e)//导入数据
        {
            if (this.small.Checked)
            {
                this.openFileDialog1.Filter = "Excel文件|*.xls|所有文件|*.*";
                this.openFileDialog1.DefaultExt = "xls";
                this.openFileDialog1.FilterIndex = 1;
            }
            else
            {
                this.openFileDialog1.Filter = "Excel文件|*.xlsx|所有文件|*.*";
                this.openFileDialog1.DefaultExt = "xlsx";
                this.openFileDialog1.FilterIndex = 1;
            }
            /////////////////////////////////////////////////////////////////
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (this.bookinfo.Checked)
                {
                    this.Book_InfoDataIn();
                }
                else if (this.cdinfo.Checked)
                {
                    this.Cd_InfoDataIn();
                }
                else if (this.vipinfo.Checked)
                {
                    this.VipDataIn();
                }
                else if (this.provider.Checked)
                {
                    this.ProviderDataIn();
                }
                else
                {
                    MessageBox.Show("请选择你要导入数据的项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void vipinfo_CheckedChanged(object sender, EventArgs e)//导入会员
        {
            if (this.vipinfo.Checked)
            {
                MessageBox.Show("注意：\n    会员信息包括：vip_id(会员号，不能为空),vip_name(会员姓名，可为空),vip_sex(性别，可为空),vip_tel(电话，可为空),vip_address(地址，可为空),vip_identity(身份证号，可为空),vip_style(会员类型，不能为空),vip_date(会员办理日期，不能为空)。导入数据的时候Excel文件应包含所有的会员信息，标识为'可为空'的会员信息表示该信息的内容可以为空表示，否则不能用空表示，必需填写。设置Excel表格工作簿的名称为excel(默认为Sheet1)。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void cdinfo_CheckedChanged(object sender, EventArgs e)//导入光盘
        {
            if (this.cdinfo.Checked)
            {
                MessageBox.Show("注意：\n    光盘信息包括：cd_id(光盘编号，不能为空),cd_code(条形码，不能为空),cd_name(光盘名称，不能为空),cd_style(光盘类型，不能为空),cd_author(作者，可为空),cd_publish(出版社),cd_isbn(ISBN，不能为空),cd_inprice(进价，不能为空),cd_outprice(售价，不能为空),cd_bookcase(书架，可为空),cd_count(库存量),cd_date(出版日期，可为空),book_in(入库时间，可为空),cd_memo(光盘简介，可为空)。导入数据的时候Excel文件应包含所有的光盘信息，标识为'可为空'的光盘信息表示该信息的内容可以为空表示，否则不能用空表示，必需填写。设置Excel表格工作簿的名称为excel(默认为Sheet1)。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void provider_CheckedChanged(object sender, EventArgs e)//导入供应商
        {
            if (this.provider.Checked)
            {
                MessageBox.Show("注意：\n    供应商信息包括：provider_id(供应商编号，不能为空),provider_name(姓名，可为空),provider_address(地址，可为空),provider_post(邮政编码，可为空),provider_tel(电话，可为空),provider_fax(传真，可为空)。导入数据的时候Excel文件应包含所有的供应商信息，标识为'可为空'的供应商信息表示该信息的内容可以为空表示，否则不能用空表示，必需填写。设置Excel表格工作簿的名称为excel(默认为Sheet1)。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// 导入图书信息
        /// </summary>
        private void Book_InfoDataIn()
        {
            SqlConnection connect = InitConnect.GetConnection();
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                if (this.small.Checked)
                {
                    cmd = new SqlCommand("insert into book_info(book_id,book_code,book_name,book_style,book_author,book_publish,book_isbn,book_inprice,book_outprice,book_page,book_bookcase,book_count,book_date,book_in,book_memo,book_cd_case) select book_id,book_code,book_name,book_style,book_author,book_publish,book_isbn,book_inprice,book_outprice,book_page,book_bookcase,book_count,book_date,book_in,book_memo,book_cd_case from opendatasource('Microsoft.Jet.Oledb.4.0','Extended Properties=Excel 5.0;Data Source=" + this.openFileDialog1.FileName + "')...[excel$]", connect);
                }
                else
                {
                    cmd = new SqlCommand("insert into book_info(book_id,book_code,book_name,book_style,book_author,book_publish,book_isbn,book_inprice,book_outprice,book_page,book_bookcase,book_count,book_date,book_in,book_memo,book_cd_case) select book_id,book_code,book_name,book_style,book_author,book_publish,book_isbn,book_inprice,book_outprice,book_page,book_bookcase,book_count,book_date,book_in,book_memo,book_cd_case from opendatasource('Microsoft.ACE.Oledb.12.0','Extended Properties=Excel 12.0;Data Source=" + this.openFileDialog1.FileName + "')...[excel$]", connect);
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("成功导入了图书信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ee)
            {
                MessageBox.Show("导入图书信息失败！\n错误信息：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                connect.Close();
            }
        }

        /// <summary>
        /// 导入光盘信息
        /// </summary>
        private void Cd_InfoDataIn()
        {
            SqlConnection connect = InitConnect.GetConnection();
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                if (this.small.Checked)
                {
                    cmd = new SqlCommand("insert into cd_info(cd_id,cd_code,cd_name,cd_style,cd_author,cd_publish,cd_isbn,cd_inprice,cd_outprice,cd_bookcase,cd_count,cd_date,cd_in,cd_memo) select cd_id,cd_code,cd_name,cd_style,cd_author,cd_publish,cd_isbn,cd_inprice,cd_outprice,cd_bookcase,cd_count,cd_date,cd_in,cd_memo from opendatasource('Microsoft.Jet.Oledb.4.0','Extended Properties=Excel 5.0;Data Source=" + this.openFileDialog1.FileName + "')...[excel$]", connect);
                }
                else
                {
                    cmd = new SqlCommand("insert into cd_info(cd_id,cd_code,cd_name,cd_style,cd_author,cd_publish,cd_isbn,cd_inprice,cd_outprice,cd_bookcase,cd_count,cd_date,cd_in,cd_memo) select cd_id,cd_code,cd_name,cd_style,cd_author,cd_publish,cd_isbn,cd_inprice,cd_outprice,cd_bookcase,cd_count,cd_date,cd_in,cd_memo from opendatasource('Microsoft.ACE.Oledb.12.0','Extended Properties=Excel 12.0;Data Source=" + this.openFileDialog1.FileName + "')...[excel$]", connect);
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("成功导入了图书信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ee)
            {
                MessageBox.Show("导入图书信息失败！\n错误信息：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                connect.Close();
            }
        }

        /// <summary>
        /// 导入会员信息
        /// </summary>
        private void VipDataIn()
        {
            SqlConnection connect = InitConnect.GetConnection();
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                if (this.small.Checked)
                {
                    cmd = new SqlCommand("insert into vip(vip_id,vip_name,vip_sex,vip_tel,vip_address,vip_identity,vip_style,vip_date) select vip_id,vip_name,vip_sex,vip_tel,vip_address,vip_identity,vip_style,vip_date from opendatasource('Microsoft.Jet.Oledb.4.0','Extended Properties=Excel 5.0;Data Source=" + this.openFileDialog1.FileName + "')...[excel$]", connect);
                }
                else
                {
                    cmd = new SqlCommand("insert into vip(vip_id,vip_name,vip_sex,vip_tel,vip_address,vip_identity,vip_style,vip_date) select vip_id,vip_name,vip_sex,vip_tel,vip_address,vip_identity,vip_style,vip_date from opendatasource('Microsoft.ACE.Oledb.12.0','Extended Properties=Excel 12.0;Data Source=" + this.openFileDialog1.FileName + "')...[excel$]", connect);
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("成功导入了会员信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ee)
            {
                MessageBox.Show("导入会员信息失败！\n错误信息：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                connect.Close();
            }
        }

        /// <summary>
        /// 导入 供应商信息
        /// </summary>
        private void ProviderDataIn()
        {
            SqlConnection connect = InitConnect.GetConnection();
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                if (this.small.Checked)
                {
                    cmd = new SqlCommand("insert into provider(provider_id,provider_name,provider_address,provider_post,provider_tel,provider_fax) select provider_id,provider_name,provider_address,provider_post,provider_tel,provider_fax from opendatasource('Microsoft.Jet.Oledb.4.0','Extended Properties=Excel 5.0;Data Source=" + this.openFileDialog1.FileName + "')...[excel$]", connect);
                }
                else
                {
                    cmd = new SqlCommand("insert into provider(provider_id,provider_name,provider_address,provider_post,provider_tel,provider_fax) select provider_id,provider_name,provider_address,provider_post,provider_tel,provider_fax from opendatasource('Microsoft.ACE.Oledb.12.0','Extended Properties=Excel 12.0;Data Source=" + this.openFileDialog1.FileName + "')...[excel$]", connect);
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("成功导入了供应商信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ee)
            {
                MessageBox.Show("导入供应商信息失败！\n错误信息：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                connect.Close();
            }
        }
    }
}
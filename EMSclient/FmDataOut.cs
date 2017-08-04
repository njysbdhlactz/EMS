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
    public partial class FmDataOut : Form
    {
        public FmDataOut()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        private void dataout_Click(object sender, EventArgs e)//导出
        {
            if (this.bookinfo.Checked)
            {
                InitConnect.DataOut(this.saveFileDialog1,"select book_id as 图书编号,book_code as 条形码,book_name as 图书名称,book_style as 图书类型,book_author as 作者,book_publish as 出版社,book_isbn as ISBN,book_inprice as 进价,book_outprice as 售价,book_page as 页码,book_bookcase as 书架,book_count as 库存量,convert(varchar(10),book_date,120) as 出版时间,convert(varchar(10),book_in,120) as 入库时间,book_memo as 图书简介,book_cd_case as 图书附加光盘所在书架 from book_info");
            }
            else if (this.cdinfo.Checked)
            {
                InitConnect.DataOut(this.saveFileDialog1,"select cd_id as 光盘编号,cd_code as 条形码,cd_name as 光盘名称,cd_style as 光盘类型,cd_author as 作者,cd_publish as 出版社,cd_isbn as ISBN,cd_inprice as 进价,cd_outprice as 售价,cd_bookcase as 书架,cd_count as 库存量,convert(varchar(10),cd_date,120) as 出版时间,convert(varchar(10),cd_in,120) as 入库时间,cd_memo as 光盘简介 from cd_info");
            }
            else if (this.vip.Checked)
            {
                InitConnect.DataOut(this.saveFileDialog1,"select vip_id as 会员编号,vip_name as 姓名,vip_sex as 性别,vip_tel as 电话,vip_address as 地址,vip_identity as 身份证号,vip_style as 会员类型,convert(varchar(10),vip_date,120) as 会员办理时间 from vip");
            }
            else if (this.provider.Checked)
            {
                InitConnect.DataOut(this.saveFileDialog1,"select provider_id as 供应商编号,provider_name as 姓名,provider_address as 地址,provider_post as 邮政编码,provider_tel as 联系电话,provider_fax as 传真 from provider");
            }
            else if (this.booksale.Checked)
            {
                InitConnect.DataOut(this.saveFileDialog1,"select book_sale.book_sale_id as 图书编号,book_sale.book_sale_code as 条形码,book_info.book_name as 图书名称,book_info.book_publish as 出版社,book_info.book_isbn as ISBN,convert(varchar(10),book_sale.book_sale_date,120) as 销售日期,book_sale.book_sale_count as 销售数量,book_user.user_id as 操作员号,book_user.user_name as 操作员姓名,book_sale.book_sale_vip as 会员号 from book_info inner join book_sale on book_info.book_id=book_sale.book_sale_id inner join book_user on book_sale.book_sale_who=book_user.user_id");
            }
            else if (this.cdsale.Checked)
            {
                InitConnect.DataOut(this.saveFileDialog1,"select cd_sale.cd_sale_id as 光盘编号,cd_sale.cd_sale_code as 条形码,cd_info.cd_name as 光盘名称,cd_info.cd_publish as 出版社,cd_info.cd_isbn as ISBN,convert(varchar(10),cd_sale.cd_sale_date,120) as 销售日期,cd_sale.cd_sale_count as 销售数量,book_user.user_id as 操作员号,book_user.user_name as 操作员姓名,cd_sale.cd_sale_vip as 会员号 from cd_info inner join cd_sale on cd_info.cd_id=cd_sale.cd_sale_id inner join book_user on cd_sale.cd_sale_who=book_user.user_id");
            }
            else if (this.bookback.Checked)
            {
                InitConnect.DataOut(this.saveFileDialog1,"select book_back.book_back_id as 图书编号,book_back.book_back_code as 条形码,book_info.book_name as 图书名称,book_info.book_publish as 出版社,book_info.book_isbn as ISBN,book_back.book_back_count as 退还数量,convert(varchar(10),book_back.book_back_date,120) as 退还日期 from book_back inner join book_info on book_info.book_id=book_back.book_back_id");
            }
            else if (this.cdback.Checked)
            {
                InitConnect.DataOut(this.saveFileDialog1,"select cd_back.cd_back_id as 光盘编号,cd_back.cd_back_code as 条形码,cd_info.cd_name as 光盘名称,cd_info.cd_publish as 出版社,cd_info.cd_isbn as ISBN,cd_back.cd_back_count as 退还数量,convert(varchar(10),cd_back.cd_back_date,120) as 退还日期 from cd_back inner join cd_info on cd_back.cd_back_id=cd_info.cd_id");
            }
            else if (this.bookbad.Checked)
            {
                InitConnect.DataOut(this.saveFileDialog1,"select book_bad.book_bad_id as 图书编号,book_bad.book_bad_code as 条形码,book_info.book_name as 图书名称,book_info.book_publish as 出版社,book_info.book_isbn as ISBN,book_bad.book_bad_count as 损坏数量,book_bad.book_bad_memo as 备注 from book_bad inner join book_info on book_bad.book_bad_id=book_info.book_id");
            }
            else if (this.cdbad.Checked)
            {
                InitConnect.DataOut(this.saveFileDialog1,"select cd_bad.cd_bad_id as 光盘编号,cd_bad.cd_bad_code as 条形码,cd_info.cd_name as 光盘名称,cd_info.cd_publish as 出版社,cd_info.cd_isbn as ISBN,cd_bad.cd_bad_count as 损坏数量,cd_bad.cd_bad_memo as 备注 from cd_bad inner join cd_info on cd_bad.cd_bad_id=cd_info.cd_id");
            }
            else if (this.bookreturn.Checked)
            {
                InitConnect.DataOut(this.saveFileDialog1,"select book_return.book_return_id as 图书编号,book_return.book_return_code as 条形码,book_info.book_name as 光盘名称,book_info.book_publish as 出版社,book_info.book_isbn as ISBN,convert(varchar(10),book_return.book_return_sale,120) as 购买时间,convert(varchar(10),book_return.book_return_date,120) as 退货时间,book_return.book_return_count as 退货数量,book_user.user_id as 操作员号,book_user.user_name as 操作员姓名,book_return.book_return_memo as 备注 from book_info inner join book_return on book_info.book_id=book_return_id inner join book_user on book_user.user_id=book_return.book_return_who");
            }
            else if (this.cdreturn.Checked)
            {
                InitConnect.DataOut(this.saveFileDialog1,"select cd_return.cd_return_id as 光盘编号,cd_return.cd_return_code as 条形码,cd_info.cd_name as 光盘名称,cd_info.cd_publish as 出版社,cd_info.cd_isbn as ISBN,convert(varchar(10),cd_return.cd_return_sale,120) as 购买时间,convert(varchar(10),cd_return.cd_return_date,120) as 退货时间,cd_return.cd_return_count as 退货数量,book_user.user_id as 操作员号,book_user.user_name as 操作员姓名,cd_return.cd_return_memo as 备注 from cd_info inner join cd_return on cd_info.cd_id=cd_return.cd_return_id inner join book_user on cd_return.cd_return_who=book_user.user_id");
            }
            else
            {
                MessageBox.Show("请选择你要导出的数据项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
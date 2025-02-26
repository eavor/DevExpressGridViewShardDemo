using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Amount", gridView1.Columns["Amount"], "组计: {0}");

            startDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            EndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            GridViewConfig(gridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            #region 生成测试数据
            List<OrderDetails> orderDetails = new List<OrderDetails>
            {
                new OrderDetails
                {
                    Code = "BM515709-20181203001",
                    Date = DateTime.Now,
                    CreateUser = "admin",
                    State = "审核中",
                    Contract = "10010",
                    Customer = "中山市欧乐家具生成商",
                    Address = "中山市小榄镇",
                    Amount = 9000,
                    Way = "微信支付",
                    Remark = ""
                },
                  new OrderDetails
                    {
                    Code = "BM515709-20181203002",
                    Date = DateTime.Now,
                    CreateUser = "admin",
                    State = "审核中",
                    Contract = "10011",
                    Customer = "中山市欧乐家具生成商",
                    Address = "中山市小榄镇",
                    Amount = 1800,
                    Way = "微信支付",
                    Remark = "尽快发货"
                },
                      new OrderDetails
                    {
                    Code = "BM515709-20181203003",
                    Date = DateTime.Now,
                    CreateUser = "admin",
                    State = "已完成",
                    Contract = "10012",
                    Customer = "中山市欧乐家具生成商",
                    Address = "中山市小榄镇",
                    Amount = 18888,
                    Way = "微信支付",
                    Remark = "月底发货"
                },

               new OrderDetails
                {
                    Code = "BM515709-20181203004",
                    Date = DateTime.Now,
                    CreateUser = "admin",
                    State = "审核中",
                    Contract = "10086",
                    Customer = "中山市金牌家具有限公司",
                    Address = "中山市板芙镇",
                    Amount = 27000,
                    Way = "银行转账",
                    Remark = ""
                },
                    new OrderDetails
                        {
                        Code = "BM515709-20181203005",
                        Date = DateTime.Now,
                        CreateUser = "admin",
                        State = "审核中",
                        Contract = "1008611",
                        Customer = "中山市金牌家具有限公司",
                        Address = "中山市板芙镇",
                        Amount = 18000,
                        Way = "银行转账",
                        Remark = "尽快发货"
                    },
                        new OrderDetails
                        {
                        Code = "BM515709-20181203006",
                        Date = DateTime.Now,
                        CreateUser = "admin",
                        State = "已完成",
                        Contract = "1008678",
                        Customer = "中山市金牌家具有限公司",
                        Address = "中山市板芙镇",
                        Amount = 29999,
                        Way = "银行转账",
                        Remark = "月底发货"
                    }
            };
            #endregion
            //SqlSugarHelper.Db.Insertable(orderDetails).ExecuteCommand();


            if (string.IsNullOrEmpty(EndDate.Text) || string.IsNullOrEmpty(startDate.Text))
            {
                gridView1.GridControl.DataSource = SqlSugarHelper.Db.Queryable<OrderDetails>().ToList();
            }
            else
            {
                DateTime start = DateTime.Parse(startDate.Text).AddDays(-1);
                DateTime end = DateTime.Parse(EndDate.Text).AddDays(1);

                Task.Run(() => { gridView1.GridControl.DataSource = SqlSugarHelper.Db.Queryable<OrderDetails>().Where(s => s.Date > start && s.Date < end).ToList(); });
                
            }
        }



        /// <summary>
        /// gridView样式
        /// </summary>
        /// <param name="gdv"></param>
        public void GridViewConfig(DevExpress.XtraGrid.Views.Grid.GridView gdv)
        {
            #region GridView属性设置
            //行号所在列的宽度
            gdv.IndicatorWidth = 40;
            //顶部面板 可用于分组
            gdv.OptionsView.ShowGroupPanel = true;
            //显示底部面板 可用于展示统计
            gdv.OptionsView.ShowFooter = true;
            //奇数行的效果设置是否可用
            gdv.OptionsView.EnableAppearanceEvenRow = true;
            //失去焦点时 是否保留行选中效果
            gdv.OptionsSelection.EnableAppearanceHideSelection = false;
            //是否显示焦点单元格样式
            gdv.OptionsSelection.EnableAppearanceFocusedCell = false;
            //只读
            gdv.OptionsBehavior.ReadOnly = true;
            //不可编辑 若设置不可编辑 会导致表格中增加的按钮的单击事件不可用
            gdv.OptionsBehavior.Editable = false;
            //行选中
            gdv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            //边框
            //gdv.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            //关闭列右键菜单
            gdv.OptionsMenu.EnableColumnMenu = true;
            //列字体对齐方式
            gdv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //列字体设置
            gdv.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            //行字体对齐方式
            gdv.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //奇数行背景色
            gdv.Appearance.EvenRow.BackColor = Color.FromArgb(228, 243, 255);
            //焦点行背景色
            gdv.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 153, 255);
            //焦点行字体颜色
            gdv.Appearance.FocusedRow.ForeColor = Color.White;
            //FooterPanel字体对齐方式
            gdv.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //行字体
            gdv.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            //导出相关设置
            gdv.AppearancePrint.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gdv.OptionsPrint.AutoWidth = false;
            gdv.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            #endregion

            #region 行号显示
            gdv.CustomDrawRowIndicator += (s, e) =>
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                e.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                {

                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            };
            #endregion

            #region 当表格内容为空时显示
            gdv.CustomDrawEmptyForeground += (s, e) =>
            {
                if (gdv.RowCount == 0)
                {
                    string str = "未查询数据";
                    Font font = new Font("微软雅黑", 14F, FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                    Rectangle rectangle = new Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 5, e.Bounds.Width - 5, e.Bounds.Height - 5);
                    e.Graphics.DrawString(str, font, Brushes.Black, rectangle);
                }
            };

            #endregion
        }
    }
}

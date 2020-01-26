using CheckOutApp.entity;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CheckOutApp.utill
{
    class PrintUtill
    {
        public CheckoutRecord record { get; set; }
        //打印单据  带预览
        public void PrintService()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                //pd.DefaultPageSettings.Landscape = true;
                pd.PrintPage += Pd_PrintPage1;
                PrintPreviewDialog dialog = new PrintPreviewDialog();
                dialog.Document = pd;
                if (dialog.ShowDialog() == DialogResult.Yes)
                {
                    pd.Print();
                };
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("错误,因为" + ex.Message, "错误");
            }
        }
        //打印单据 无预览
        public void PrintServiceNoPreview()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                //pd.DefaultPageSettings.Landscape = true;
                pd.PrintPage += Pd_PrintPage1;
                pd.Print();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("错误,因为" + ex.Message, "错误");
            }
        }
        //出库单据模板 横版
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("宋体",20,FontStyle.Bold);
            Font font1 = new Font("宋体", 12, FontStyle.Regular);
            Pen pen = new Pen(Brushes.Black);
            e.Graphics.DrawString("出库单据",font,Brushes.Black,500,150);
            e.Graphics.DrawString("日期：", font1, Brushes.Black, 100, 150);
            e.Graphics.DrawString("年", font1, Brushes.Black, 250, 150);
            e.Graphics.DrawString("月", font1, Brushes.Black, 300, 150);
            e.Graphics.DrawString("日", font1, Brushes.Black, 350, 150);
            e.Graphics.DrawString("单据号：", font1, Brushes.Black, 750, 150);
            e.Graphics.DrawString(record.recordId, font1, Brushes.Black, 850, 150);
            e.Graphics.DrawRectangle(pen,new Rectangle(90,180,1000,100));
            e.Graphics.DrawLine(pen, 90, 230, 1090, 230);
            for(int i = 290; i < 1000; i += 200)
            {
                e.Graphics.DrawLine(pen, i, 180, i, 280);
            }
            e.Graphics.DrawString("车牌号", font1, Brushes.Black, 95, 200);
            e.Graphics.DrawString("数量(方)", font1, Brushes.Black, 295, 200);
            e.Graphics.DrawString("金额(元)", font1, Brushes.Black, 495, 200);
            e.Graphics.DrawString("付款方式", font1, Brushes.Black, 695, 200);
            e.Graphics.DrawString("备注", font1, Brushes.Black, 895, 200);
            e.Graphics.DrawString(record.carNumber, font1, Brushes.Black, 95, 250);
            e.Graphics.DrawString(record.totalNumber, font1, Brushes.Black, 295, 250);
            e.Graphics.DrawString(record.totalSum, font1, Brushes.Black, 495, 250);
            e.Graphics.DrawString(record.paymentMethod, font1, Brushes.Black, 695, 250);
            e.Graphics.DrawString(record.remark, font1, Brushes.Black, 895, 250);
            e.Graphics.DrawString("车队单位：", font1,Brushes.Black,90, 300);
            e.Graphics.DrawString(record.company, font1, Brushes.Black, 190, 300);
            e.Graphics.DrawString("入场时间：", font1, Brushes.Black, 420, 300);
            e.Graphics.DrawString(record.inTime, font1, Brushes.Black, 510, 300);
            e.Graphics.DrawString("操作人：", font1, Brushes.Black, 750, 300);
            e.Graphics.DrawString(record.recordOperator, font1, Brushes.Black, 820, 300);
        }
        //出库单据模板 横版
        private void Pd_PrintPage1(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("宋体", 18, FontStyle.Bold);
            Font font1 = new Font("宋体", 12, FontStyle.Regular);
            Pen pen = new Pen(Brushes.Black);
            e.Graphics.DrawString("出库单据", font, Brushes.Black, 350, 30);
            //e.Graphics.DrawString("日期：", font1, Brushes.Black, 100, 150);
            //e.Graphics.DrawString("年", font1, Brushes.Black, 250, 150);
            //e.Graphics.DrawString("月", font1, Brushes.Black, 300, 150);
            //e.Graphics.DrawString("日", font1, Brushes.Black, 350, 150);
            e.Graphics.DrawString("单据号：", font1, Brushes.Black, 35, 80);
            e.Graphics.DrawString(record.recordId, font1, Brushes.Black, 100, 80);
            e.Graphics.DrawRectangle(pen, new Rectangle(35, 110, 750, 80));
            e.Graphics.DrawLine(pen, 35, 150, 785, 150);
            for (int i = 185; i < 750; i += 150)
            {
                e.Graphics.DrawLine(pen, i, 110, i, 190);
            }
            e.Graphics.DrawString("车牌号", font1, Brushes.Black, 40, 120);
            e.Graphics.DrawString("数量(方)", font1, Brushes.Black, 190, 120);
            e.Graphics.DrawString("金额(元)", font1, Brushes.Black, 340, 120);
            e.Graphics.DrawString("付款方式", font1, Brushes.Black, 490, 120);
            e.Graphics.DrawString("备注", font1, Brushes.Black, 640, 120);
            e.Graphics.DrawString(record.carNumber, font1, Brushes.Black, 40, 160);
            e.Graphics.DrawString(record.totalNumber, font1, Brushes.Black, 190, 160);
            e.Graphics.DrawString(record.totalSum, font1, Brushes.Black, 340, 160);
            e.Graphics.DrawString(record.paymentMethod, font1, Brushes.Black, 490, 160);
            e.Graphics.DrawString(record.remark, font1, Brushes.Black, 640, 160);
            e.Graphics.DrawString("车队单位：", font1, Brushes.Black, 40, 205);
            e.Graphics.DrawString(record.company, font1, Brushes.Black, 125, 205);
            e.Graphics.DrawString("入场时间：", font1, Brushes.Black, 540, 80);
            e.Graphics.DrawString(record.inTime, font1, Brushes.Black, 635, 80);
            e.Graphics.DrawString("操作人：", font1, Brushes.Black, 635, 205);
            e.Graphics.DrawString(record.recordOperator, font1, Brushes.Black, 710, 205);
        }
    }
}

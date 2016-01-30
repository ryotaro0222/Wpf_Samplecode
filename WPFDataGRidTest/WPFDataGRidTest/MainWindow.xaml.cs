using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace WPFDataGRidTest
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // データテーブル
        private DataTable m_dt;

        // コンストラクタ
        public MainWindow()
        {
            InitializeComponent();

            // テーブルの初期化
            try
            {
                InitTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        // メンバ関数
        /// <summary>
        /// テーブルの初期化
        /// </summary>
        private void InitTables()
        {
            // 水平スクロールバー
            DataGridWindow.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            // 垂直スクロールバー
            DataGridWindow.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;

            //new Log {チケット番号 = ret.ToString(), 取引種類 = "Ask", シンボル = symbol, レート = mt4.Ask, 価格 = 0, 損益 = 0, 日付 = x}
            DataGridWindow.Columns.Add(new DataGridTextColumn() { Header = "チケット番号", IsReadOnly = false, FontSize = 12, Binding = new Binding("ticket") });
            DataGridWindow.Columns.Add(new DataGridTextColumn() { Header = "取引種類", IsReadOnly = false, FontSize = 12, Binding = new Binding("Ask") });
            DataGridWindow.Columns.Add(new DataGridTextColumn() { Header = "シンボル", IsReadOnly = false, FontSize = 12, Binding = new Binding("symbol") });
            DataGridWindow.Columns.Add(new DataGridTextColumn() { Header = "レート", IsReadOnly = false, FontSize = 12, Binding = new Binding("rate") });
            DataGridWindow.Columns.Add(new DataGridTextColumn() { Header = "価格", IsReadOnly = false, FontSize = 12, Binding = new Binding("price") });
            DataGridWindow.Columns.Add(new DataGridTextColumn() { Header = "損益", IsReadOnly = false, FontSize = 12, Binding = new Binding("soneki") });
            DataGridWindow.Columns.Add(new DataGridTextColumn() { Header = "日付", IsReadOnly = false, FontSize = 12, Binding = new Binding("date") });
           
                
            
            m_dt = new DataTable("DataGridTest");

            m_dt.Columns.Add(new DataColumn("ticket", typeof(int)));
            m_dt.Columns.Add(new DataColumn("Ask", typeof(string)));
            m_dt.Columns.Add(new DataColumn("symbol", typeof(string )));
            m_dt.Columns.Add(new DataColumn("rate", typeof(double)));
            m_dt.Columns.Add(new DataColumn("price", typeof(double)));
            m_dt.Columns.Add(new DataColumn("soneki", typeof(double)));
            m_dt.Columns.Add(new DataColumn("date", typeof(int)));

            // サンプルデータ追加
            DataRow newRowItem;

            newRowItem = m_dt.NewRow();
            newRowItem["symbol"] = "USDJPY";
            newRowItem["ticket"] = 11111;
            newRowItem["Ask"] = "ask";
            newRowItem["rate"] = 1.1;
            newRowItem["date"] = 111;
            m_dt.Rows.Add(newRowItem);

            // グリッドにバインド
            DataGridWindow.DataContext = m_dt;

            /*for (int i = 0; i < 100; i++)
            {
                newRowItem = m_dt.NewRow();
                newRowItem["test_string"] = "test" + i.ToString();
                newRowItem["test_id"] = i.ToString();
                m_dt.Rows.Add(newRowItem);
            }*/

            

        }
    }
}
using System.Text;
using System.Windows.Forms;

namespace OGameEmptyPlanetFinder.GUI
{
    public static class FinderFormCommons
    {
        public static string listToClipboard(ListView listView, CheckBox checkBox, string separator = "|")
        {
            StringBuilder sb = new StringBuilder();
            foreach (ListViewItem item in listView.Items)
            {
                if (sb.Length > 0)
                {
                    sb.Append("\n");
                }
                if (checkBox.Checked)
                {
                    sb.Append("[coordinates]").Append(item.Text).Append("[/coordinates]");
                }
                else
                {
                    sb.Append(item.Text);
                }
                if (item.SubItems != null && item.SubItems.Count > 1)
                {
                    for (int i = 1; i < item.SubItems.Count; i++)
                    {
                        sb.Append(separator).Append(item.SubItems[i].Text);
                    }
                }
            }
            Clipboard.SetText(sb.ToString());
            return sb.ToString();
        }

        public static void openBrowser(string url, Timer refreshTimer)
        {
            bool isAutoRefresh = refreshTimer.Enabled;
            OGameBrowser browser = new OGameBrowser(url);
            if (isAutoRefresh)
            {
                refreshTimer.Stop();
            }
            browser.ShowDialog();
            if (isAutoRefresh)
            {
                refreshTimer.Start();
            }
        }


        public static void smallerThan(NumericUpDown start, NumericUpDown stop)
        {
            if (start.Value > stop.Value)
            {
                stop.Value = start.Value;
            }
        }

        public static void biggerThan(NumericUpDown start, NumericUpDown stop)
        {
            if (start.Value > stop.Value)
            {
                start.Value = stop.Value;
            }
        }

        public static void reverseOnMaxAndBack(NumericUpDown numericField)
        {
            if (numericField.Value >= numericField.Maximum)
            {
                numericField.Value = numericField.Minimum + 1;
            }
            else if (numericField.Value <= numericField.Minimum)
            {
                numericField.Value = numericField.Maximum - 1;
            }
        }
    }
}

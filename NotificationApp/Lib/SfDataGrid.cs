using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace NotificationApp.Lib
{
    public class SfDataGrid : FrameLayout
    {
        private IEnumerable<object> itemsSource;
        public IEnumerable<object> ItemsSource
        {
            get
            {
                return this.itemsSource;
            }
            set
            {
                if (itemsSource != (IEnumerable<object>)value)
                {
                    IEnumerable<object> obj = this.itemsSource;
                    this.itemsSource = value;
                    this.OnItemsSourceChanged(obj, value);
                }
            }
        }
        public List<string> Columns { get; set; }

        public SfDataGrid(Context context) : base(context)
        {
            Initialize();
        }

        private void Initialize()
        {
            Columns = new List<string>();
        }

        private void OnItemsSourceChanged(IEnumerable<object> oldValue, IEnumerable<object> newValue)
        {
            AssignDataToGrid();
        }

        private void AssignDataToGrid()
        {
            var vScrollView = new ScrollView(Context);
            var hScrollView = new HorizontalScrollView(Context);

            var tableLayout = new TableLayout(Context) { StretchAllColumns = true };

            var headerRow = new TableRow(Context)
            {
                LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent)
            };

            foreach (var column in Columns)
            {
                var textView = new TextView(Context) { Text = column };
                textView.Left = 15;
                textView.SetPadding(16, 16, 16, 16);
                textView.SetTextSize(Android.Util.ComplexUnitType.Dip, 16);
                textView.SetBackgroundColor(Android.Graphics.Color.ParseColor("#008080"));
                textView.SetTextColor(Android.Graphics.Color.White);
                headerRow.AddView(textView);
            }

            tableLayout.AddView(headerRow);

            foreach (var item in ItemsSource)
            {
                var itemRow = new TableRow(Context);

                foreach (var column in Columns)
                {
                    var value = item.GetType().GetProperty(column).GetValue(item, null);

                    var textView = new TextView(Context) { Text = (value == null ? null : value.ToString()) };
                    textView.SetBackgroundResource(Resource.Drawable.cell_shape);
                    itemRow.AddView(textView);
                }

                tableLayout.AddView(itemRow);
            }

            hScrollView.AddView(tableLayout);

            vScrollView.AddView(hScrollView);

            this.AddView(vScrollView);
        }
    }
}
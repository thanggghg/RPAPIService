using System.Drawing;

namespace GoSell.Common.Models.Requests
{
    public class InitializeExportCommonData
    {
        public List<ExportSheet> Sheets { get; set; }
        public string TemplateType { get; set; }
        public string TemplateName { get; set; }
    }

    public class ExportToExcelRequest
    {
        public bool IsSeparateSheet { get; set; }
        public List<ExportSheet> Sheets { get; set; }
    }

    public class ExportSheet
    {
        public string SheetName { get; set; }
        public List<Title> Titles { get; set; }
        public List<Header> Headers { get; set; }
        public List<ExportData> DataItems { get; set; }
        public List<ExportDataItem> Footers { get; set; }
        public List<int> HiddenColumns { get; set; } = [];
        public string ContentWidgetTitle { get; set; }
        public HeaderStyle HeaderStyle { get; set; }
        public int startRowIndex { get; set; }

        public bool isCustomColumnType { get; set; } = true;
    }

    public class Title
    {
        public int RowOrder { get; set; }
        public int ColumnOrder { get; set; }
        public string Caption { get; set; }
        public int FontSize { get; set; }
        public bool FontBold { get; set; }
    }

    public class Header
    {
        public string Code { get; set; }
        public int Order { get; set; }
        public string Type { get; set; }
        public string Caption { get; set; }
    }

    public class HeaderStyle
    {
        public Color FontColor { get; set; }
        public Color BackgroundColor { get; set; }
    }

    public class ExportData
    {
        public List<ExportDataItem> Items { get; set; }
    }

    public class ExportDataItem
    {
        public string Code { get; set; }
        public int Order { get; set; }
        public string DisplayText { get; set; }
    }
}

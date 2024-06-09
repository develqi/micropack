namespace Micropack.Multilingual;

// برخی از ستون های دیتابیس شامل قوانین زیر است
// یا باید محتوای اینام تبدیل به یک متن هاص شود مثلا بلی و خیر نمایش داده شود
// یا وضعیت فرآیندی فرم نمایش داده شود

// یک نوع دیگر به این شکل است که مثلا
// بین صفر تا صد بود رنگ قرمز
// اگر بین صد و هزار بود رنگ سبز
// اگر بیشتر از هزار بود رنگ زرد

// نوع دیگر ستون ها به این شکل است مبلغ است و باید سه رقم سه رقم جدا شود


public abstract class DatagridBuilder
{
    public abstract ColumnItem[] Columns { get; }
}

public class DatagridBuilder<TItem> : DatagridBuilder where TItem : class, IHistoryItem
{
    private ColumnItem? _column;
    private readonly List<ColumnItem> _columns = [];

    public override ColumnItem[] Columns
    {
        get
        {
            //if (!HasColumn("Id"))
            //    _columns.Add(new Column { Name = "Id", Visible = ColumnVisibilities.NoneColumn, Caption = new Caption("شناسه") });

            //if (!HasColumn("CreatorName")) // Caption = new MultilingualFactory("ایجاد کننده", "Creator Name", GetOrder()).Create()
            //    _columns.Add(new Column { Name = "CreatorName", Visible = ColumnVisibilities.ExtraColumn, Caption = new Caption("ایجاد کننده"), Type = ColumnTypes.String });

            //if (!HasColumn("CreatedOn")) // Caption = new MultilingualFactory("", "", "Created On", GetOrder()).Create()
            //    _columns.Add(new Column { Name = "CreatedOn", Visible = ColumnVisibilities.ExtraColumn, Caption = new Caption("تاریخ ثبت"), Type = ColumnTypes.DateTime });

            //if (!HasColumn("LastModifiedOn")) // Caption = new MultilingualFactory("", "", "Last Modified On", GetOrder()).Create()
            //    _columns.Add(new Column { Name = "LastModifiedOn", Visible = ColumnVisibilities.ExtraColumn, Caption = new Caption("تاریخ آخرین تغییرات"), Type = ColumnTypes.DateTime });

            //if (!HasColumn("LastModifierName")) // Caption = new MultilingualFactory("", "", "Last Modifier Name", GetOrder()).Create()
            //    _columns.Add(new Column { Name = "LastModifierName", Visible = ColumnVisibilities.ExtraColumn, Caption = new Caption("آخرین تغییر دهنده"), Type = ColumnTypes.String });

            return [.. _columns];
        }
    }

    //public DatagridBuilder<TItem> ColumnFor<TProperty>(Expression<Func<TItem, TProperty>> expression)
    //{
    //    if (_columns.Count > 255)
    //        throw new ArgumentException("Column is limited to 255");

    //    var name = (expression.Body as MemberExpression).Member.Name;

    //    _column = new Column { Title = new MultilingualFactory(name, "", Order: GetOrder()).Create(), Type = GetType(name) };
    //    _columns.Add(_column);

    //    return this;
    //}

    public DatagridBuilder<TItem> Fa(string fa)
    {
        _column.Caption.Label = fa;

        return this;
    }

    //public DatagridBuilder<TItem> Fa(string fa)
    //{
    //    var faDictionaryItem = _column.Title.Item("Fa");

    //    if (faDictionaryItem is null)
    //        faDictionaryItem = new MultilingualItem { Code = "Fa", Caption = fa };

    //    faDictionaryItem.Caption = fa;

    //    _column.Title.Items.Add(faDictionaryItem);
    //    return this;
    //}

    //public DatagridBuilder<TItem> En(string en)
    //{
    //    var item = _column.Caption.Item("En");

    //    if (item is null)
    //        item = new MultilingualItem { Code = "En", Caption = en };

    //    item.Caption = en;

    //    _column.Title.Items.Add(item);
    //    return this;
    //}

    public DatagridBuilder<TItem> ClassName(string className)
    {
        _column.ClassName = className;
        return this;
    }

    public DatagridBuilder<TItem> Type(ColumnTypes columnType)
    {
        _column.Type = columnType;
        return this;
    }

    //public DatagridLocalization<TItem> HasType(ColumnTypes type)
    //{
    //    _column.Type = type;

    //    return this;
    //}

    public void ExtraColumn() => _column.Visible = ColumnVisibilities.ExtraColumn;

    /// <summary>
    /// ستون هایی که سمت فرانت اند برای اعمال لاجیک نیاز هستند
    /// ولی در ستون های گرید نمایش داده نمی شود و امکان انتخاب هم ندارند
    /// </summary>
    public void NoneColumn() => _column.Visible = ColumnVisibilities.NoneColumn;

    public DatagridBuilder<TItem> Unsortable()
    {
        _column.Sortable = false;
        return this;
    }

    public string Query => string.Join(",", Columns.Where(x => x.Visible != ColumnVisibilities.ExtraColumn).Select(column => FormatColumnName(column.Name)).Append("CreatorId").Append("LastModifierId"));

    public bool HasColumn(string columns, string key) => Query.Contains(key) && (string.IsNullOrWhiteSpace(columns) || columns.Contains(key));

    // < ---------------------------------------- Private Methods ---------------------------------------- >

    private ColumnTypes GetType(string propertyName)
    {
        var property = typeof(TItem).GetProperty(propertyName);

        var propertyType = property?.PropertyType;

        if (propertyType.IsGenericType &&
            propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            propertyType = propertyType.GetGenericArguments()[0];
        }

        var propertyTypeName = propertyType.Name;

        var isEnum = property.PropertyType.IsEnum;
        if (isEnum)
            return ColumnTypes.Enum;

        return propertyTypeName switch
        {
            "Byte" or "Int16" or "Int32" or "Int64" => ColumnTypes.Number,
            "Boolean" => ColumnTypes.Boolean,
            _ => ColumnTypes.String,
        };
    }

    private byte GetOrder() => (byte)(_columns.Count + 1);

    private bool HasColumn(string name) => _columns.Any(column => column.Name == name);

    private string FormatColumnName(string columnName) => $"{columnName.Substring(0, 1).ToUpper()}{columnName.Substring(1, columnName.Length - 1)}";
}

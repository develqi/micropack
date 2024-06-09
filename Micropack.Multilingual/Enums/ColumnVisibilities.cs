namespace Micropack.Multilingual;

public enum ColumnVisibilities : byte
{
    /// <summary>
    /// ستون های پیش فرض دیتاگرید
    /// </summary>
    DefaultColumn = 1,

    /// <summary>
    /// ستون هایی که توسط کاربر به دیتاگرید اضافه می شوند
    /// </summary>
    ExtraColumn = 2,

    /// <summary>
    /// برای ستون هایی مثل شناسه" که نباید نمایش داده شود ولی سمت فرانت اند روی آنها لاجیک نوشته می شود
    /// </summary>
    NoneColumn = 3
}
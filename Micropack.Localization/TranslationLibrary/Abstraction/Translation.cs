namespace Micropack.Localization
{
    // ترجمه عنوان لیبل ها
    // ترجمه داده های اولیه مثلا اسم ماژول ها به فارسی و انگلیسی
    // ترجمه عنوان ستون های گریدویو ها
    // ترجمه عباراتی که ممکنه مربوط به یک جدول هم نباشند. مثلا ستون نام
    // سازمان در گریدویوی لیست دپارتمان ها
    // ترجمه پیغام های ولیدیشن
    // ترجمه پیغام های عملیات موفق

    // امکان تغییر نام ماژول ها و تمامی لیبل ها در هر زبان، توسط خود کاربر
    // دسترسی پرمیشن کاربر در تنظیمات

    public abstract class Translation
    {
        public int Id { get; set; }

        /// <summary>
        /// کلید ترجمه
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// متن مورد نظر به صورت ترجمه شده
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// متن اختصاصی که کاربر جایگزین میکند
        /// </summary>
        public string CustomValue { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}

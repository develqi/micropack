namespace Micropack.Multilingual;

public class MultilingualBuilder<TMultilingual> where TMultilingual : Multilingual
{
    protected TMultilingual _item;
    protected readonly List<TMultilingual> _items = [];

    public TMultilingual[] Items => _items.ToArray();

    protected MultilingualBuilder<TMultilingual> AddItem(string key)
    {
        if (Exist(key))
            throw new ArgumentException("Item key is already exist.");

        if (_items.Count > 255)
            throw new ArgumentException("Item is limited to 255");

        _item = Activator.CreateInstance<TMultilingual>();

        _item.Key = key;
        _items.Add(_item);

        return this;
    }

    public virtual MultilingualBuilder<TMultilingual> Fa(string fa)
    {
        var caption = _item.Captions.FirstOrDefault(item => item.Language == "Fa");
        if (caption != null)
            caption.Language = fa;

        caption = new Caption { Language = "Fa", Label = fa };
        _item.Captions.Add(caption);

        return this;
    }

    public virtual MultilingualBuilder<TMultilingual> En(string en)
    {
        var caption = _item.Captions.FirstOrDefault(item => item.Language == "En");
        if (caption != null)
            caption.Language = en;

        caption = new Caption { Language = "En", Label = en };
        _item.Captions.Add(caption);

        return this;
    }

    public virtual MultilingualBuilder<TMultilingual> Order(byte order)
    {
        //_item.Order = order;
        return this;
    }

    private bool Exist(string key) => _items.Any(item => item.Key.Equals(key, StringComparison.CurrentCultureIgnoreCase));

    private byte GetOrder() => (byte)(_items.Count + 1);

    public TMultilingual[] Build() => Items;
}
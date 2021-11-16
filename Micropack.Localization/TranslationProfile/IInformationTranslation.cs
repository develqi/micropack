﻿namespace Micropack.Localization
{
    public interface IInformationTranslation
    {
        Dictionary[] Informations { get; }

        IInformationTranslation InformationFor(string key);

        IInformationTranslation FaInfo(string fa);

        IInformationTranslation EnInfo(string en);
    }
}

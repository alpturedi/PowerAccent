﻿using PowerAccent.Core.Tools;
using System.Configuration;
using static PowerAccent.Core.Tools.Enums;

namespace PowerAccent.Core.Services;

public class SettingsService : ApplicationSettingsBase
{
    [UserScopedSetting()]
    [DefaultSettingValue("Top")]
    public Position Position
    {
        get { return (Position)this["Position"]; }
        set { this["Position"] = value; Save(); }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("False")]
    public bool UseCaretPosition
    {
        get { return (bool)this["UseCaretPosition"]; }
        set { this["UseCaretPosition"] = value; Save(); }
    }

    #region LetterKey

    [UserScopedSetting()]
    public char[] LetterKeyA
    {
        get { return (char[])this["LetterKeyA"]; }
        set { this["LetterKeyA"] = value; }
    }

    [UserScopedSetting()]
    public char[] LetterKeyC
    {
        get { return (char[])this["LetterKeyC"]; }
        set { this["LetterKeyC"] = value; }
    }

    [UserScopedSetting()]
    public char[] LetterKeyE
    {
        get { return (char[])this["LetterKeyE"]; }
        set { this["LetterKeyE"] = value; }
    }

    [UserScopedSetting()]
    public char[] LetterKeyI
    {
        get { return (char[])this["LetterKeyI"]; }
        set { this["LetterKeyI"] = value; }
    }

    [UserScopedSetting()]
    public char[] LetterKeyO
    {
        get { return (char[])this["LetterKeyO"]; }
        set { this["LetterKeyO"] = value; }
    }

    [UserScopedSetting()]
    public char[] LetterKeyU
    {
        get { return (char[])this["LetterKeyU"]; }
        set { this["LetterKeyU"] = value; }
    }

    [UserScopedSetting()]
    public char[] LetterKeyY
    {
        get { return (char[])this["LetterKeyY"]; }
        set { this["LetterKeyY"] = value; }
    }

    public void SetLetterKey(LetterKey letter, char[] value)
    {
        string key = $"LetterKey{letter}";
        this[key] = value;
    }

    public char[] GetLetterKey(LetterKey letter)
    {
        string key = $"LetterKey{letter}";
        if (this[key] != null)
            return (char[])this[key];

        return GetDefaultLetterKey(letter);
    }

    public char[] GetDefaultLetterKey(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'ä', 'â', 'á', 'à', 'ã' };
            case LetterKey.C:
                return new char[] { 'ç' };
            case LetterKey.E:
                return new char[] { 'ë', 'ê', 'é', 'è', '€' };
            case LetterKey.I:
                return new char[] { 'ï', 'î', 'í', 'ì' };
            case LetterKey.O:
                return new char[] { 'ö', 'ô', 'ó', 'ò', 'õ' };
            case LetterKey.U:
                return new char[] { 'ü', 'û', 'ú', 'ù' };
            case LetterKey.Y:
                return new char[] { 'ÿ', 'ý' };
        }

        throw new ArgumentException("Letter {0} is missing", letter.ToString());
    }

    #endregion
}

public enum Position
{
    Top,
    Bottom,
    Left,
    Right,
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight,
    Center
}
